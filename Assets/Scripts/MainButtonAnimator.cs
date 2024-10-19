using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainButtonAnimator : MonoBehaviour
{
    Animator animator;
    Button button;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        button = GetComponent<Button>();
        button.onClick.AddListener(PlayPressAnimation);
    }

    void PlayPressAnimation()
    {
        Debug.Log("Trigger set");
        animator.SetTrigger("ButtonPress");
    }
}
