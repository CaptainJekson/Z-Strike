using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    public event UnityAction PlayerIdles;
    public event UnityAction PlayerMoves;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private WeaponButtons _weaponButtons;

    [SerializeField] private float _speed = 12.0f;
    [SerializeField] private float _graviry = 9.81f;

    [SerializeField] private List<Weapon> _weapons;
    private Weapon _weapon;

    private CharacterController _controller;
    public float Velocity => _controller.velocity.magnitude / _speed;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _weapon = _weapons[0];
    }

    private void OnEnable()
    {
        _weaponButtons.ShootButtonPressed += Shoot;
    }

    private void Update()
    {
        if (_joystick.IsTouchStick)
        {
            Rotate();
            Moving();
        }
        else
        {
            PlayerIdles?.Invoke();
        }
    }

    private void OnDisable()
    {
        _weaponButtons.ShootButtonPressed -= Shoot;
    }

    private void Moving()
    {
        _controller.Move(new Vector3(_joystick.Horizontal, -_graviry, _joystick.Vertical) * _speed * Time.deltaTime);
        PlayerMoves?.Invoke();
    }

    private void Rotate()
    {
        transform.localRotation = Quaternion.LookRotation(new Vector3(_joystick.Horizontal, 0.0f, _joystick.Vertical));
    }

    public void WeaponSelection(int weaponNumber)
    {
        _weapon.gameObject.SetActive(false);

        _weapon = _weapons[weaponNumber];
        _weapon.gameObject.SetActive(true);
    }

    public void Shoot()
    {
        _weapon.Fire();
    }
}
