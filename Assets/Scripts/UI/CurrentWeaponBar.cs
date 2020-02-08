using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CurrentWeaponBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Text _ammunition;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

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
        _image.sprite = _player.CurrentWeapon.Icon;
    }
}
