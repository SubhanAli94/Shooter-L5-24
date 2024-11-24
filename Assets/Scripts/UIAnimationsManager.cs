using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIAnimationsManager : MonoBehaviour
{
    //A Static variable which will hold the copy/instance of UIAnimations class.
    public static UIAnimationsManager instance;

    //1. Game Launch Animation
    //2. Game Start Animation : Hide UI Controls
    //3. Game Restart Animation: Show UI Controls & Hide UI Controls

    //Animator to show/hide the UI elements ("Shooter" text and "Play" button.)
    public Animator gameUIContentAnimator;

    void Awake()
    {
        // Ensure there is only one UIAnimations instance (Singleton pattern)
        if (instance == null)
        {

            //This class name is UIAnimations and we'll assign it's copy/instance
            //to the "instance" variable using "this". Down the line it will be easy 
            //for us to call any function of this class objects.
            //For example: UIAnimations.instance.ShowGameOverUIControls();
            instance = this;
        }
        else
        {
            //If another UIAnimations is created then destroy it because we 
            //only one copy/instance of UIAnimations in our game.
            Destroy(gameObject);
        }
    }

    #region Hide Game Start UI Controls & Trigger functions

    //This function is called when the "HideGameStartUIAnimation" ends. For reference, check
    //the last key frame in the Animation window for the "HideGameStartUIAnimation" animation.
    public void OnHideGameStartUIAnimationEnd() {

        //Call the "OnHideGameStartUIAnimationEnd" located inside the GameManager. This
        //function contains the logic to start the game.
        GameManager.instance.OnHideGameStartUIAnimationEnd();
    }

    //Start animation to hide the "Shooter" text and "Play" button when the user
    //clicks on the "Play" button.
    public void HideGameStartUIControls() {

        // "HideStartGameUIControlsTrigger": This trigger is set in the Animator window
        // for HideGameStartUIAnimation Animation.
        gameUIContentAnimator.SetTrigger("HideGameStartUIControlsTrigger");
    }
    #endregion

    #region Show/Hide Game Over UI Controls

    //This function is responsible to trigger the animation "ShowGameOverUIAnimation".
    public void ShowGameOverUIControls() {

        gameUIContentAnimator.SetTrigger("ShowGameOverUIControlsTrigger"); // Trigger Animation
    }

    //Start animation to hide the "Game Over" text and "Play Again" button when the user
    //clicks on the "Play Again" button.
    public void HideGameOverUIControls()
    {
        // "HideGameOverUIControlsTrigger": This trigger is set in the Animator window
        // for HideGameOverUIAnimation Animation.
        gameUIContentAnimator.SetTrigger("HideGameOverUIControlsTrigger");
    }

    //This function is called when the "HideGameStartUIAnimation" ends. For reference, check
    //the last key frame in the Animation window for the "HideGameStartUIAnimation" animation.
    public void OnHideGameOverUIAnimationEnd()
    {
        //Call the "OnHideGameOverUIAnimationEnd" located inside the GameManager. This
        //function contains the logic to restart the game.
        GameManager.instance.OnHideGameOverUIAnimationEnd();
    }
    #endregion
}
