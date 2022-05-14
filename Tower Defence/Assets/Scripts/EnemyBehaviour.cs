using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody _enemy;
    [SerializeField] private GameObject _wayPointsColl;
    [SerializeField] private Transform[] _wayPoints;

    [SerializeField] private int _index;
    [SerializeField] private float _speed;

    public int _enemyHealth;
    public int _bulletDamage;
    public WaveSpawner _spawner;


    public Slider _slider;
    public int _maxHealth;
    

    private void Awake()
    {
        _enemy = GetComponent<Rigidbody>();
        _wayPoints = _wayPointsColl.transform.GetComponentsInChildren<Transform>();
        _spawner = GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<WaveSpawner>();
        //Debug.Log(_wayPoints.Length);
    }
    // Start is called before the first frame update
    void Start()
    {
        _index = 0;
        _speed = 30;
        _enemyHealth = _spawner._waves[_spawner.index]._enemyHealth;
        _maxHealth = _enemyHealth;
        _slider.maxValue = _maxHealth;
        _bulletDamage = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (_index != _wayPoints.Length)
        {
            _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _wayPoints[_index].position,_speed * Time.deltaTime); 
        }

        
        //_enemy.transform.localRotation = Quaternion.LookRotation((_wayPoints[_index].position - _enemy.transform.position).normalized, Vector3.forward);
        if( (_enemy.transform.position - _wayPoints[_index].position).magnitude <= 1f)
        {
            //Debug.Log( "Index = " + _index);
            if ((_index == _wayPoints.Length-1))
            {
                Destroy(this.gameObject);
                GameManager.instance._isGameOver = true;
            }
            //Debug.Log(_index);
            _index++;
        }      


        //UI
        _slider.value = _enemyHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _enemyHealth -= 40;
            if (_enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

    }

}
