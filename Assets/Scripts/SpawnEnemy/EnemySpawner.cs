using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Coroutine _coroutine;
    [SerializeField]
    private int _count;
    [SerializeField]
    private int _maxCount;
    [SerializeField]
    private int _minSpawnTime;
    [SerializeField] 
    private int _maxSpawnTime;
    [SerializeField]
    private Enemy _enemy;
    [SerializeField]
    private Transform[] _spawnPoints;

    private void Start()
    {
        
            StartSpawn();
       
    }

    public void StartSpawn()
    {
        StopSpawn();
        _coroutine = StartCoroutine(SpawnCoroutine());
    }
    public void StopSpawn()
    {

    }
    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            if(_count >= _maxCount)
            {
                yield return null;
                continue;
            }
            var spawnTime = GetSpawnTime();
            yield return new WaitForSeconds(spawnTime);

            SpawnEnemy();
            _count++;
        }
    }

    private float GetSpawnTime()
    {
        return Random.Range(_minSpawnTime, _maxSpawnTime);
    }

    private void SpawnEnemy()
    {
        var spawnPoint = GetRandomSpawnPoint();
        var enemy = Instantiate(_enemy, spawnPoint);
        enemy.Construct(this);
    }

    private Transform GetRandomSpawnPoint()
    {
        var spawnPointIndex = Random.Range(0, _spawnPoints.Length);
        var spawnPoint = _spawnPoints[spawnPointIndex];
        return spawnPoint;
    }
    public void OnEnemyDestroy()
    {
        _count--;
    }
}
