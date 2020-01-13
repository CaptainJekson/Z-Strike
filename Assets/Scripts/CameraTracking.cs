using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private Vector3 _indentPosition;

    private void Update()
    {
        transform.position = new Vector3(_target.position.x - _indentPosition.x, _target.position.y - _indentPosition.y, _target.position.z - _indentPosition.z);   
    }
}
