
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _panSpeed =  30f;
    [SerializeField] private float _panBorder = 10f;
    [SerializeField] private float _scroolSpeed;

    [SerializeField] private float _maxY = 150;
    [SerializeField] private float _minY = 10f;

    [SerializeField] protected bool _canMovement = true;


    [SerializeField] private Ray _ray;
    [SerializeField] private RaycastHit _hit;

    private void Update()
    {
        { 
        if (Input.GetKey(KeyCode.W) /*|| Input.mousePosition.y >= Screen.height - _panBorder*/)
        {
            transform.Translate(Vector3.forward * _panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.S) /*|| Input.mousePosition.y <= _panBorder*/)
        {
            transform.Translate(Vector3.back * _panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.D) /*|| Input.mousePosition.x >= Screen.width - _panBorder*/)
        {
            transform.Translate(Vector3.right * _panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.A) /*|| Input.mousePosition.x <= _panBorder*/)
        {
            transform.Translate(Vector3.left * _panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");


        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * _scroolSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, _minY, _maxY);
        transform.position = pos;
    }

        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(_ray, out _hit))
        {
            Debug.Log(_hit.collider.tag);
        }
    }
}
