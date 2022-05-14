using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Buildmanager : MonoBehaviour
{
    //public static Buildmanager instance;

    [SerializeField] private GameObject[] _towers;
    [SerializeField] private int _buildTime;

    [SerializeField] private GameObject _selectedTower;
    [SerializeField] private TowerManager _tower;
    [SerializeField] private GameObject[] tower;

    public int _coinAmount;

    private void Awake()
    {
        /*if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject); 
        */
    }

    private void Start()
    {
        _selectedTower = _towers[0];
        InvokeRepeating("GetTowers", 0.5f, 0.5f);
        InvokeRepeating("CoinIncrement", 01f, 1f);
        _coinAmount = 100;

    }

    private void Update()
    {
        SpawnTower();
    }


    public void SetTower1()
    {
        _selectedTower = _towers[0];
    }

    public void SetTower2()
    {
        _selectedTower = _towers[1];
    }

    public void SetTower3()
    {
        _selectedTower = _towers[2];
    }


   void SpawnTower()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
           if(!EventSystem.current.IsPointerOverGameObject())
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                //Vector3 pos = Camera.main.ScreenToWorldPoint(Vector3 position);
                // Casts the ray and get the first game object hit
                Physics.Raycast(ray, out hit);
               
                if(_coinAmount>=10)
                {
                    SpawnSelectedTower(hit.point, _selectedTower);
                    _coinAmount -= 10;
                }
            }
            else
            {
                Debug.Log("Hit a GUI");
            }
        }
    }

    void SpawnSelectedTower(Vector3 pos, GameObject gameobject)
    {
        float shortestDistance = Mathf.Infinity;
        
        foreach(GameObject tower in tower)
        {
            float distance = (pos - tower.transform.position).magnitude;
            if(distance < shortestDistance)
            {
                shortestDistance = distance;
            }

        }

        if(shortestDistance > _tower.range)
        {
            Instantiate(gameobject, new Vector3(pos.x, pos.y+2f, pos.z), Quaternion.identity);
        }
        else
        {
            string msg = "It is too close to other tower";
            Debug.Log(msg);
        }
    }

    void GetTowers()
    {
        tower = GameObject.FindGameObjectsWithTag("Tower");
    }

    void CoinIncrement()
    {
        _coinAmount++;
    }
}
