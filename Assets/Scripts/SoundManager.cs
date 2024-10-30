using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //A Static variable which will hold the copy/instance of SoundManager class.
    public static SoundManager instance;


    public AudioClip shootSound;  // Sound track or Clip for the shooting.
    public AudioClip destroySound;  // Sound track or Clip for the when enemy is destroyed.
    public AudioSource audioSource; //A Speaker or Sound track player. Our DJ Boy :D

    void Awake()
    {
        // Ensure there is only one SoundManager instance (Singleton pattern)
        if (instance == null)
        {
            //This class name is SoundManager and we'll assign it's copy/instance
            //to the "instance" variable using "this". Down the line it will be easy 
            //for us to call any function of this class objects.
            //For example: SoundManager.instance.PlayShootSound();
            instance = this;
        }
        else
        {
            //If another SoundManager is created then destroy it because we 
            //only one copy/instance of SoundManager in our game.
            Destroy(gameObject);
        }
    }

    //This function is responsible to play Shooting sound. 
    //It's public and can be accessed from other classes in our game.
    public void PlayShootSound()
    {
        //DJ Boy (AudioSource) will play the sound here by passing the Shooting Sound track
        //into its "PlayOneShot" function.
        audioSource.PlayOneShot(shootSound);
    }

    //This function is responsible to play Destroy sound. 
    //It's public and can be accessed from other classes in our game.
    public void PlayDestroySound()
    {
        //DJ Boy (AudioSource) will play the sound by passing the Destroy Sound track
        //into its "PlayOneShot" function.
        audioSource.PlayOneShot(destroySound);
    }
}
