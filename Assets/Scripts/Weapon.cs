using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Характеристики оружия")]
    [SerializeField] private int _damage;
    [SerializeField] private int _ammunition;
    [SerializeField] private float _rate;
    [SerializeField] private bool _isAutomatic;

    [Header("Дульное пламя, патрон и гильза")]
    [SerializeField] private ParticleSystem _muzzleFlame;
    [SerializeField] private ParticleSystem _bullet;
    [SerializeField] private GameObject _sleeve;

    [Header("Звук стрельбы")]
    [SerializeField] private AudioSource _shootingSound;

    public int Damage => _damage;
    public bool IsAutomatic => _isAutomatic;

    public void Fire()
    {
        _bullet.Play();
        _muzzleFlame.Play();
        _shootingSound.Play();
        //Instantiate(_sleeve, transform.position, Quaternion.identity);
    }
}
