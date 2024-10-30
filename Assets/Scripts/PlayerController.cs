using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    //Player
    public Rigidbody2D playerRigidBody; //RigidBody of the Player
    public float moveSpeed = 5f; // Player's movement speed
    private float inputMoveX; // Class-level variable to store input direction

    //Bullet
    public Transform firePoint; // Assign a fire point (the position where bullets should spawn)
    public float bulletSpeed = 10f; // Speed of the bullet
    public GameObject bulletPrefab; //A Prefab of bullet object


    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.IsGameOver())
        {
            inputMoveX = Input.GetAxisRaw("Horizontal"); // Returns -1 for Left, +1 for Right

            //If the Space button is pressed on Keybaord then call the Shoot function.
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot(); //Call Shoot function.
            }
        }
    }

    void FixedUpdate()
    {
        // Apply movement to the player using its Rigidbody2D
        playerRigidBody.velocity = new Vector2(inputMoveX, 0f) * moveSpeed;
    }

    //This function creates a bullet and shoot it up.
    private void Shoot()
    {
        // Create a copy/instance of Bullet from it's Prefab(prefabricated form).
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        // Access the RigidBody from newly created Bullet instance.
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

        // Add upward velocity to the bullet with the speed stored in the bulletSpeed variable.
        bulletRigidbody.velocity = firePoint.up * bulletSpeed; 
    }
}
