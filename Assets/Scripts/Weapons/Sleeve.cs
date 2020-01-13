using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleeve : MonoBehaviour
{
    [SerializeField] private float _recoilForce;
    [SerializeField] private float _lifeTime;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
    }

    private void Start()
    {
        _rigidbody.AddForce(Vector3.right * _recoilForce, ForceMode.Impulse);
        Destroy(gameObject, _lifeTime);
    }
}
