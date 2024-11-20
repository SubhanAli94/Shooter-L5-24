using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Explosion Particle System GameObject
    public GameObject explosion;

    private void OnCollisionEnter2D(Collision2D other)
    {        
        // Check if the enemy collides with Player
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); // Destroy the Enemy

            //GameOver function is called. This function is located inside the GameManager class.
            GameManager.instance.GameOver();
        }

        // Check if the bullet collides with the Enemy
        if (other.gameObject.CompareTag("Bullet"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);

            Destroy(gameObject); // Destroy the Enemy
            Destroy(other.gameObject); // Destroy the Bullet
            GameManager.instance.AddScore(); // Call GameOver function. This function is located inside the GameManager class.

        }

        // Check if the enemy collides with Enemy Destroyer, located at the bottom of the GamePlay.
        if (other.gameObject.CompareTag("EnemyDiffuser"))
        {
            Destroy(gameObject); // Destroy the Enemy
        }
    }
}
