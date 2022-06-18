using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using GameEntity;

public class GameManager : MonoBehaviour
{
    public float minEnemySpawnDelay;
    public float maxEnemySpawnDelay;

    public struct EnemyStruct
    { 
        public Enemy1 enemy1;
    }

    public EnemyStruct enemyStruct;

    public static ObjectPool<Enemy> enemyPool;

    private void Awake()
    {
        enemyStruct.enemy1 = Resources.Load<Enemy1>("Prefab/Enemy1");

        enemyPool = new(
            createFunc: () =>
            {
                var enemy = Instantiate(enemyStruct.enemy1);

                enemy.rigidbody.position = new Vector3(
                    x: Random.Range((float)-9, 9),
                    y: 8
                    );

                enemy.objectPool = enemyPool;

                return enemy;
            },
            actionOnGet: (enemy) =>
            {
                enemy.gameObject.SetActive(true);

                enemy.rigidbody.position = new Vector3(
                    x: Random.Range((float)-9, 9), 
                    y: 8
                    );
            },
            actionOnRelease: (enemy) =>
            {
                enemy.gameObject.SetActive(false);
            },
            actionOnDestroy: (enemy) =>
            {
                Destroy(enemy.gameObject);
            },
            collectionCheck: default,
            defaultCapacity: default,
            maxSize: 30
            );
            
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator EnemySpawner()
    {
        while (true)
        {
            enemyPool.Get();

            yield return new WaitForSeconds(Random.Range(minEnemySpawnDelay, maxEnemySpawnDelay));
        }
    }
}
