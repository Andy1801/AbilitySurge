using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Do some research as to how to preform better spawning of enemies
public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyList;
    public float spawnRate;
    public int enemySpawnThreshold;

    private float timer;
    private Transform[] enemySpawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnRate;
        enemySpawnPoints = gameObject.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnEnemy();
            timer = spawnRate;
        }
    }

    void SpawnEnemy()
    {
        foreach (Transform transform in enemySpawnPoints)
        {
            bool spawn = Random.Range(0, enemySpawnThreshold) < (enemySpawnThreshold / 2);
            Debug.Log("Position: " + transform.position);

            if (transform.gameObject.CompareTag("Spawnpoint") && spawn)
            {

                float spawnWidthRight = transform.position.x + transform.localScale.x / 2;
                float spawnWidthLeft = transform.position.x - transform.localScale.x / 2;
                float spawnHeightUp = transform.position.y + transform.localScale.y / 2;
                float spawnHeightDown = transform.position.y - transform.localScale.y / 2;


                float horizontalPosition = Random.Range(spawnWidthLeft, spawnWidthRight);
                float verticalPosition = Random.Range(spawnHeightDown, spawnHeightUp);

                Vector3 spawnPosition = new Vector3(horizontalPosition, verticalPosition, 0f);

                Debug.Log("Spawned Enemy in position: " + spawnPosition);

                GameObject enemy = enemyList[0];

                enemy.transform.position = spawnPosition;

                Instantiate(enemy);
            }
        }
    }
}
