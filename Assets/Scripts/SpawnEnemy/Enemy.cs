using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   private EnemySpawner _enemySpawner;

    public void Construct(EnemySpawner enemySpawner)
    {
        _enemySpawner = enemySpawner;
    }
    public void OnDestroy()
    {
        _enemySpawner.OnEnemyDestroy();
    }
}
