using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    
    [System.Serializable]
    public class Waves
    {
        public string _enemyName;
        public Rigidbody _enemy;
        public float _enemySpawnDelay;
        public int _enemySpawnCount;
        public int _enemyHealth;
    }

    public Waves[] _waves;
    public int index;
    public float _waveCountDown = 5f;
    public int _waveDelay = 5;
    public int _wavesNumber;
   


    private GameObject[] arrayEnemy;

    private void Start()
    {
        index = 0;
        _wavesNumber = 0;
    }

    private void Update()
    {
        arrayEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (_waveCountDown <= 0)
        {
            if (arrayEnemy.Length == 0)
            {
                StartCoroutine(Spawn(_waves[index]));
                _wavesNumber++;
            }

            if (_waveCountDown <= 0)
            {
                _waveCountDown = 5f;
            }
        }
        _waveCountDown -= Time.deltaTime;
    }

    IEnumerator Spawn(Waves wave)
    {
        for (int i = 0; i<wave._enemySpawnCount; i++)
        {
            SpawnEnemy(_waves[index]._enemy);
            yield return new WaitForSeconds(wave._enemySpawnDelay);
        }
        //_waves[index]._enemyHealth += 10;
        index++;

        if (index>_waves.Length-1)
        {
            index = 0;
            foreach(Waves _allwave in _waves)
            {
                _allwave._enemyHealth += 10;
                _allwave._enemySpawnCount += Random.Range(1, 3);
            }
        }
        yield return new WaitForSeconds(_waveDelay);
    }

    private void SpawnEnemy(Rigidbody enemy)
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
