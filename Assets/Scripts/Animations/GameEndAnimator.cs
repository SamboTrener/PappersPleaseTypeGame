using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndAnimator : MonoBehaviour
{
    public static GameEndAnimator Instance { get; private set; }

    Animator animator;

    public Action OnGameEndAnimation;

    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        OnGameEndAnimation += SetGameEndAnimationTrigger;
    }

    void SetGameEndAnimationTrigger()
    {
        animator.SetTrigger("GameEnd");
        StartCoroutine(PLaySoundsInOrder());
    }

    IEnumerator PLaySoundsInOrder()
    {
        SoundManager.Instance.PlayMonsterAttackSound();
        yield return new WaitForSeconds(2.5f);
        SoundManager.Instance.PlayPortalSound();
    }
}
