using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentWeaponBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Text _ammunition;

    private void OnEnable()
    {
        _player.PlayerShotOrСhange += Refresh;
    }

    private void OnDisable()
    {
        _player.PlayerShotOrСhange -= Refresh;
    }

    private void Refresh()
    {
        _ammunition.text = _player.CurrentWeapon.Ammunition.ToString();
    }
}
