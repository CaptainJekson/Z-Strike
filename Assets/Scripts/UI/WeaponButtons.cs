using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponButtons : MonoBehaviour
{
    public event UnityAction ShootButtonPressed;

    [SerializeField] private Player _player;
    [SerializeField] private PlayerAnimation _playerAnimation;

    public void OnUnarmedButtonClick(int weaponNumber)
    {
        _playerAnimation.CurrentWeapon = (float)HandState.unarmed;
        _player.WeaponSelection(weaponNumber);
    }

    public void OnPistolButtonClick(int weaponNumber)
    {
        _playerAnimation.CurrentWeapon = (float)HandState.pistol;
        _player.WeaponSelection(weaponNumber);
    }

    public void OnRifleButtonClick(int weaponNumber)
    {
        _playerAnimation.CurrentWeapon = (float)HandState.rifle;
        _player.WeaponSelection(weaponNumber);
    }

    public void OnShootButtonClick()
    {
        ShootButtonPressed?.Invoke();
    }

    public enum HandState
    {
        unarmed,
        pistol,
        rifle
    }
}
