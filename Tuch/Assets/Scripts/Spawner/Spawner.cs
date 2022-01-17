using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _point;
    [SerializeField] private Transform _spawn1;
    [SerializeField] private Transform _spawn2;
    [SerializeField] private float _timeToSpawn = 3;
    [SerializeField] private int _pointSpawn;
    [SerializeField] private float _multiplier;

    private int _spawnedToPoint;
    private float _pastRealTime;
    private float _pastRealTimeToSpawn;

    private void Start()
    {
    }

    private void Update()
    {
        _pastRealTime += Time.deltaTime;
        _pastRealTimeToSpawn += Time.deltaTime;

        if (_pastRealTime >= _timeToSpawn)
        {
            _pastRealTime = 0;
            
            if(_spawnedToPoint >= _pointSpawn)
            {
                GameObject obj = Instantiate(_point, new Vector3(Random.Range(_spawn1.position.x, _spawn2.position.x), this.transform.position.y, this.transform.position.z),Quaternion.identity);
                _spawnedToPoint = 0;
            }
            else
            {
                GameObject obj = Instantiate(_enemy, new Vector3(Random.Range(_spawn1.position.x, _spawn2.position.x), this.transform.position.y, this.transform.position.z), Quaternion.identity);
                _spawnedToPoint++;
            }
        }

       if(_pastRealTimeToSpawn >= 5f)
        {
            _timeToSpawn -= _multiplier;
            _pastRealTimeToSpawn = 0;

         if(_timeToSpawn <= 0.35f)
          {
             _timeToSpawn = 0.35f;
          }
        }
    }


}
