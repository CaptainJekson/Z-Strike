﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponButtons : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerAnimation _playerAnimation;

    private bool _isFire;

    public event UnityAction ShootButtonPressed;

    private void Update()
    {
        if (_isFire && _player.CurrentWeapon.IsAutomatic)
            ShootButtonPressed?.Invoke();
    }

    public void OnSelectionWeaponClick(int weaponNumber)
    {
        _player.WeaponSelection(weaponNumber);
    }

    public void OnShootButtonClick()
    {
        ShootButtonPressed?.Invoke();
    }

    public void OnShootButtonClickDown()
    {
        _isFire = true;
    }

    public void OnShootButtonClickUp()
    {
        _isFire = false;
    }
}
