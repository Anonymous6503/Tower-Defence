using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBillBoard : MonoBehaviour
{
    [SerializeField] private Transform _cam;

    private void Start()
    {
        _cam = Camera.main.transform;
    }


    private void LateUpdate()
    {
        transform.LookAt(transform.position + _cam.forward);
    }

}
