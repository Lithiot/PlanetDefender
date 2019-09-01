using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum positionToSpawn
{
    Up, Down, Right, Left
}

public class EnemyManager : GenericSingleton<EnemyManager>
{
    public GenericObjectPool enemyPool;
    public float spawnRate;
    private float internalSpawnClock;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

    public override void Awake()
    {
        base.Awake();
        internalSpawnClock = spawnRate;
    }

    private void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
            if (internalSpawnClock <= 0)
            {
                SpawnEnemy();
                internalSpawnClock = spawnRate;
            }
            else
                internalSpawnClock -= 1 * Time.deltaTime;
        }
    }

    private void SpawnEnemy()
    {
        positionToSpawn side = (positionToSpawn)Random.Range(0, 3);
        Vector3 pos = Vector3.zero;

        switch (side)
        {
            case positionToSpawn.Up:
                pos = new Vector3(Random.Range(minX, maxX), maxY, 0.0f);
                break;
            case positionToSpawn.Down:
                pos = new Vector3(Random.Range(minX, maxX), minY, 0.0f);
                break;
            case positionToSpawn.Right:
                pos = new Vector3(maxX, Random.Range(minY, maxX), 0.0f);
                break;
            case positionToSpawn.Left:
                pos = new Vector3(minX, Random.Range(minY, maxX), 0.0f);
                break;
        }

        GameObject obj = enemyPool.GetObjectFromPool();
        if (obj)
        {
            obj.SetActive(true);
            obj.transform.position = pos;
        }
    }
}
