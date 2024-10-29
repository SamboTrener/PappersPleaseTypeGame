using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance {  get; private set; }  

    [SerializeField] AudioSource source;
    [SerializeField] AudioClip ironCurtainDown;
    [SerializeField] AudioClip ironCurtainUp;
    [SerializeField] AudioClip gunshoots;
    [SerializeField] AudioClip acceptButtonSound;
    [SerializeField] AudioClip declineButtonSound;
    [SerializeField] AudioClip radioInteractionSound;
    [SerializeField] AudioClip stepSound;
    [SerializeField] AudioClip paperSound;
    [SerializeField] AudioClip monsterAttackSound;
    [SerializeField] AudioClip portalOpenedSound;

    [SerializeField] AudioClip gameEndSound;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayMonsterAttackSound()
    {
        source.PlayOneShot(monsterAttackSound);
    }

    public void PlayPortalSound()
    {
        source.PlayOneShot(portalOpenedSound);
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

    public void PlayAcceptSound()
    {
        source.PlayOneShot(acceptButtonSound);
    }

    public void PlayDeclineSound()
    {
        source.PlayOneShot(declineButtonSound);
    }

    public void PlayRadioInteractionSound()
    {
        source.PlayOneShot(radioInteractionSound);
    }

    public void PlayFootstepsSound(Vector2 position)
    {
        AudioSource.PlayClipAtPoint(stepSound, position, 1f);
    }

    public void PlayPaperSound(Vector2 position)
    {
        AudioSource.PlayClipAtPoint(paperSound, position, 1f);
    }

    public void PlayGameEndSoundLooped()
    {
        source.clip = gameEndSound;
        source.loop = true;
        source.Play();
    }

    public void UnPauseSounds()
    {
        source.UnPause();
    }

    public void PauseSounds()
    {
        source.Pause();
    }
}
