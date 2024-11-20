using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimations : MonoBehaviour
{
    public void OnStartGameAnimationEnd() {
        GameManager.instance.OnStartGameAnimationEnd();
    }

    public void OnGameRestartAnimationEnd()
    {
        Debug.Log("Animation Ended: UIAnimations");
        GameManager.instance.OnGameRestartAnimationEnd();
    }
}
