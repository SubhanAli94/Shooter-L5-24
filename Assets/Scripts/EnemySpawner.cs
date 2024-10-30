using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Prefab of Enemy GameObject
    public float spawnInterval = 1f; // Desired interval between two spawns or creations of enemies.
    private float spawnTimer; //Timer to keep track of how much time has been lapsed.

    void Update()
    {
        //Increment the timer value
        spawnTimer += Time.deltaTime;

        //If the game is not over
        //AND
        //If the timer has lapsed desired the duration(spawnInternal) between the last spawn and this spawn
        //then Spawn a new Enemy otherwise proceed without doing anything.
        if (!GameManager.instance.IsGameOver() && spawnTimer >= spawnInterval)
        {
            //Spawn the Enemy
            SpawnEnemy();

            //Reset the timer to zero.
            spawnTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        
        float randomX = Random.Range(-7f, 7f); //-7 is the left-most edge +7 is the right most edge.
        // What will happend if we use bigger screen to play the game???
        // We need to update this approach of pickign up location, and we'll learn it down the line in our module.

        Vector2 spawnPosition = new Vector2(randomX, 6f);

        // Spawn the enemy at spawn position.
        // Quaternion.identity: It is used to tell the Instantiate fuction that don't rotate the newly
        // spawned enemy.
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the bullet collides with the BulletDestroyer.
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // Destroy the bullet
        }
    }
}
