using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUI : MonoBehaviour
{
    [SerializeField] private Ray _ray;
    [SerializeField] private RaycastHit _hit;

    private void Update()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(_ray, out _hit))
        {
            Debug.Log(_hit.collider.tag);
        }
    }

}
