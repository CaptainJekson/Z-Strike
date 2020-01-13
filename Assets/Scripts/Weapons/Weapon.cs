using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private PlayerAnimation _playerAnimation;

    [Header("Позиция рук")]
    [SerializeField] private State _handState;

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

    private float _shootCooldown;
    private bool CanAttack => _shootCooldown <= 0.0f;

    public int Damage => _damage;
    public int Ammunition => _ammunition;
    public bool IsAutomatic => _isAutomatic;
    public float HandState => (float)_handState;

    private void Update()
    {
        if (_shootCooldown > 0)
            _shootCooldown -= Time.deltaTime;
    }

    public void Fire(int quantityBullet)
    {
        if(CanAttack && _ammunition > 0)
        {
            _bullet.Play();
            _muzzleFlame.Play();
            _shootingSound.Play();
            _ammunition -= quantityBullet;
            _shootCooldown = _rate;

            Instantiate(_sleeve, transform.position, transform.rotation); // <<================ ПОВОРОТ
        }
    }

    public enum State
    {
        unarmed,
        pistol,
        rifle
    }
}
