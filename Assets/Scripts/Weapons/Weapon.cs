using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [Header("Позиция рук")]
    [SerializeField] private State _handState;

    [Header("Характеристики оружия")]
    [SerializeField] private int _damage;
    [SerializeField] private int _ammunition;
    [SerializeField] private float _rate;
    [SerializeField] private bool _isAutomatic;

    [Header("Дульное пламя и патрон")]
    [SerializeField] private ParticleSystem _muzzleFlame;
    [SerializeField] private ParticleSystem _bullet;

    [Header("гильза и её позиция")]
    [SerializeField] private Sleeve _shell;
    [SerializeField] private Vector3 _positionSleeve;

    [Header("Звук стрельбы")]
    [SerializeField] private AudioSource _shootingSound;

    [Header("Иконка оружия")]
    [SerializeField] private Sprite _icon;

    private float _shootCooldown;
    private bool CanAttack => _shootCooldown <= 0.0f;

    public int Damage => _damage;
    public int Ammunition => _ammunition;
    public bool IsAutomatic => _isAutomatic;
    public float HandState => (float)_handState;
    public Sprite Icon => _icon;

    private void Update()
    {
        if (_shootCooldown > 0)
            _shootCooldown -= Time.deltaTime;
    }

    public void Fire(int quantityBullet)
    {
        if (CanAttack && _ammunition > 0)
        {
            _bullet.Play();
            _muzzleFlame.Play();
            _shootingSound.Play();
            _ammunition -= quantityBullet;
            _shootCooldown = _rate;

            if (_shell != null)
                ShellDropping();
        }
    }

    private void ShellDropping()
    {
        Sleeve newSleeve = Instantiate(_shell, transform.position + _positionSleeve, transform.rotation);
        newSleeve.Direction = -transform.forward;
    }

    public enum State
    {
        unarmed,
        pistol,
        rifle
    }
}
