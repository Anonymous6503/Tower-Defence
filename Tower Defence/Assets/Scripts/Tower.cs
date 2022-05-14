using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Tower : MonoBehaviour
{
    
    [SerializeField] private GameObject _tower;
    public int _range;
    [SerializeField] private float _turnSpeed = 5f;
    [SerializeField] private GameObject[] _enemiesInScene;
    [SerializeField] private GameObject _target;

    [Header("Firing")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePos;

    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private float _fireReset;
    
    private void Awake()
    {
        _tower.GetComponent<GameObject>();
    }

    private void Start()
    {
        _range = 20;
        InvokeRepeating("CheckEnemiesInRange", 0, 0.5f);
        _target = null;
        _fireReset = _fireRate;
        _firePos = _tower.transform.Find("FirePos");
    }

    void CheckEnemiesInRange()
    {
        _enemiesInScene = GameObject.FindGameObjectsWithTag("Enemy");
        float nearestEnemyDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in _enemiesInScene)
        {
            Vector3 dist = enemy.transform.position - transform.position;
            if (dist.magnitude < nearestEnemyDistance)
            {
                nearestEnemyDistance = dist.magnitude;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy!=null && nearestEnemyDistance <= _range)
        {
            _target = nearestEnemy;
        }
        else
        {
            _target = null;
        }
    }

    private void Update()
    {
        // Check if there is an enemy in the range
        if (_target == null)
        {
            return;
        }
        // Rotation Of Tower towards the nearest Target
        Vector3 dir = _target.transform.position - transform.position;
        Quaternion lookTowards = Quaternion.LookRotation(dir);
        Vector3 rotateTo = Quaternion.Lerp(transform.rotation, lookTowards, Time.deltaTime * _turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotateTo.y, 0);
        
        // Fire
        if (_fireReset <= 0 && _target!= null)
        {
            Fire();
            _fireReset = _fireRate;
        }

        _fireReset -= Time.deltaTime;
    }

    void Fire()
    {
        Debug.Log("Fired");
        GameObject bulletInstance = (GameObject) Instantiate(_bulletPrefab, _firePos.position, Quaternion.identity);
        bulletInstance.transform.parent = _firePos;
        Bullets bt =bulletInstance.GetComponent<Bullets>();
        bt.GetTarget(_target.transform);
    }
}
