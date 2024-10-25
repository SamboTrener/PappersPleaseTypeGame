using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance {  get; private set; }  

    [SerializeField] AudioSource source;
    [SerializeField] AudioClip ironCurtainDown;
    [SerializeField] AudioClip ironCurtainUp;
    [SerializeField] AudioClip gunshoots;

    private void Awake()
    {
        Instance = this;
    }

    public IEnumerator PlayIronCurtainDownSoundAndWait()
    {
        source.PlayOneShot(ironCurtainDown);
        yield return new WaitForSeconds(ironCurtainDown.length / 2);
    }

    public IEnumerator PlayGunshootsSoundAndWait()
    {
        source.PlayOneShot(gunshoots);
        yield return new WaitForSeconds(gunshoots.length);
    }

    public IEnumerator PlayIronCurtainUpSoundAndWait()
    {
        source.PlayOneShot(ironCurtainUp);
        yield return new WaitForSeconds(ironCurtainUp.length);
    }
}
