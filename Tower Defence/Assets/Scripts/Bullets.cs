
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float _speed = 50f;
    [SerializeField] private Transform _target;

    public void GetTarget(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        if (_target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;

        float moveSpeed = _speed * Time.deltaTime;

        if (dir.magnitude<moveSpeed)
        {
            TargetHit();
            return;
        }
        
        transform.Translate(dir.normalized * moveSpeed, Space.World);
    }

    void TargetHit()
    {
        
        Destroy(gameObject);
    }
}
