using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    public event UnityAction PlayerIdles;
    public event UnityAction PlayerMoves;
    public event UnityAction PlayerShotOrСhange;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private WeaponButtons _weaponButtons;

    [SerializeField] private float _speed = 12.0f;
    [SerializeField] private float _graviry = 9.81f;

    [SerializeField] private List<Weapon> _weapons;
    private Weapon _currentWeapon;

    private CharacterController _controller;
    private PlayerAnimation _playerAnimation;

    public float Velocity => _controller.velocity.magnitude / _speed;
    public Weapon CurrentWeapon => _currentWeapon;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _currentWeapon = _weapons[0];
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
        _playerAnimation.HandState = _weapons[weaponNumber].HandState;

        _currentWeapon.gameObject.SetActive(false);
        _currentWeapon = _weapons[weaponNumber];
        _currentWeapon.gameObject.SetActive(true);

        PlayerShotOrСhange?.Invoke();
    }

    public void Shoot()
    {
        if (_currentWeapon.Ammunition > 0)
        {
            _currentWeapon.Fire(1);
            PlayerShotOrСhange?.Invoke();
        }
    }
}
