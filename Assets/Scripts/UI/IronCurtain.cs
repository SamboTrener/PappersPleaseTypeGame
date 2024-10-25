using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronCurtain : MonoBehaviour
{
    public static IronCurtain Instance { get; private set; }

    public Action OnIronCurtainDown;

    Animator animator;

    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        OnIronCurtainDown += IronCurtainDown;
    }

    private void OnDisable()
    {
        OnIronCurtainDown -= IronCurtainDown;
    }

    void IronCurtainDown()
    {
        animator.SetTrigger("IronCurtainDown");
        StartCoroutine(PlaySoundsInOrder());
    }

    IEnumerator PlaySoundsInOrder()
    {
        yield return SoundManager.Instance.PlayIronCurtainDownSoundAndWait();
        yield return SoundManager.Instance.PlayGunshootsSoundAndWait();
        yield return SoundManager.Instance.PlayIronCurtainUpSoundAndWait();
    }
}
