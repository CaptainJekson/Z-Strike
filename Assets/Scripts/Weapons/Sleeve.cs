using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleeve : MonoBehaviour
{
    [SerializeField] private float _recoilForce;
    [SerializeField] private float _lifeTime;

    private Rigidbody _rigidbody;

    public Vector3 Direction { get; set; }

    private void Awake()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
    }

    private void Start()
    {
        _rigidbody.AddForce(Direction * _recoilForce, ForceMode.Impulse);

        Destroy(gameObject, _lifeTime);
    }

}
