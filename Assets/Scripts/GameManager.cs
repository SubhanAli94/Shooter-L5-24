using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //A Static variable which will hold the copy/instance of GameManager class.
    public static GameManager instance;

    //This game object is the parent of GameOverText and PlayAgainButton.
    //We need only their parent to display/hide both of them.
    public GameObject gameOverContent;

    //This game object is the parent of StartGameText and PlayButton.
    //We need only their parent to display/hide both of them.
    public GameObject startGameContent;

    //Animator to hide the UI elements when the game starts
    public Animator startGameAnimator;

    //Animator to show the UI elements when the game is over.
    public Animator gameOverAnimator;

    //The Player gameobject is needed to activate the player again
    //when the user clicks the PlayAgain button.
    public GameObject player;
    

    //Score text to display the current score.
    public TextMeshProUGUI scoreText;

    //This variable keeps track of the game status i.e., if it is over or not.
    private bool isGameOver = true;

    //This variable keeps track of the score.
    private int  score = 0;

    void Awake()
    {
        // Ensure there is only one GameManager instance (Singleton pattern)
        if (instance == null)
        {

            //This class name is GameManager and we'll assign it's copy/instance
            //to the "instance" variable using "this". Down the line it will be easy 
            //for us to call any function of this class objects.
            //For example: GameManager.instance.GameOver();
            instance = this;
        }
        else
        {
            //If another GameManager is created then destroy it because we 
            //only one copy/instance of GameManager in our game.
            Destroy(gameObject);
        }
    }

    //This function is called when the user clicks on the PlayAgain Button.
    public void StartGame()
    {
        if (startGameContent.activeSelf)
        {
            //Trigger the GameStarted Animation
            startGameAnimator.SetTrigger("GameStarted");
        }

        if (gameOverContent.activeSelf)
        {
            Debug.Log("Animation Triggered");

            //Trigger the GameStarted Animation
            gameOverAnimator.SetTrigger("GameRestarted");
        }


    }

    public void OnStartGameAnimationEnd() {

        if (startGameContent.activeSelf)
        {
            startGameContent.SetActive(false);
        }
        score = 0; // Set the score to zero.
        scoreText.text = "Score: " + 0; // Display the zero score in the text view.

        isGameOver = false;

        player.SetActive(true); // Activate the Player.

    }

    public void OnGameRestartAnimationEnd() {
        Debug.Log("Animation Ended: GameManager");

        if (gameOverContent.activeSelf)
        {
            gameOverContent.SetActive(false);
        }
        score = 0; // Set the score to zero.
        scoreText.text = "Score: " + 0; // Display the zero score in the text view.

        isGameOver = false; // Game is no longer over.

        gameOverContent.SetActive(false);  // Hide GameOver text and PlayAgain button.

        player.SetActive(true); // Activate the Player.
    }

    //This function is called when the Enemy hits the Player.
    public void GameOver()
    {
        // Play the destruction sound.
        SoundManager.instance.PlayDestroySound();

        isGameOver = true; //Game is over.

        player.SetActive(false); //De-Activate the Player.

        // Show GameOver text and PlayAgain button.
        gameOverContent.SetActive(true);

        // Trigger the GameOver animation.
        gameOverAnimator.SetTrigger("GameOver");
    }

    // Function to check if the game is over
    //This fucntion is called whenever we try to spawn a new Enemy.
    public bool IsGameOver()
    {
        return isGameOver;
    }


    //This function is called whenever a Bullet hits the Enemy.
    public void AddScore() {
        
        //Play the shooting sound.
        SoundManager.instance.PlayShootSound();

        score++; //Increase the score.

        scoreText.text = "Score: " + score.ToString(); //Show the incremented score on UI.
    }
}
