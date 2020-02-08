using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private WeaponButtons _weaponButtons;

    [SerializeField] private float _speed = 12.0f;
    [SerializeField] private float _graviry = 9.81f;

    [SerializeField] private List<Weapon> _weapons;
    private CharacterController _controller;
    private PlayerAnimation _playerAnimation;

    public event UnityAction PlayerIdles;
    public event UnityAction PlayerMoves;
    public event UnityAction PlayerShotOrСhange;

    public float Velocity => _controller.velocity.magnitude / _speed;
    public Weapon CurrentWeapon { get; private set; }

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        CurrentWeapon = _weapons[0];
    }

    private void OnEnable()
    {
        _weaponButtons.ShootButtonPressed += Shoot;
    }

    private void OnDisable()
    {
        _weaponButtons.ShootButtonPressed -= Shoot;
    }

    private void Update()
    {
        if (_joystick.IsTouchStick)
        {
            Rotate();
            Moving();
            Shoot();        // <<---- DEBUG
        }
        else
        {
            PlayerIdles?.Invoke();
        }
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

        CurrentWeapon.gameObject.SetActive(false);
        CurrentWeapon = _weapons[weaponNumber];
        CurrentWeapon.gameObject.SetActive(true);

        PlayerShotOrСhange?.Invoke();   
    }

    public void Shoot()
    {
        if (CurrentWeapon.Ammunition > 0)
        {
            CurrentWeapon.Fire(1);
            PlayerShotOrСhange?.Invoke();
        }
    }
}
