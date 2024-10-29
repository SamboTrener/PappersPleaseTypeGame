using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [SerializeField] AudioSource musicSource;

    [SerializeField] AudioClip[] trackList;

    [SerializeField] Button switchMusicButton;

    [SerializeField] Button previousStationButton;
    [SerializeField] Button nextStationButton;

    [SerializeField] Button volumeUpButton;
    [SerializeField] Button volumeDownButton;

    float lastVolume = 1;

    int currentStationID = 0;

    private void Awake()
    {
        Instance = this;   
        musicSource.clip = trackList[currentStationID];
        musicSource.loop = true;
        musicSource.Play();
        switchMusicButton.onClick.AddListener(TurnOnMusic);
        previousStationButton.onClick.AddListener(PreviousStation);
        nextStationButton.onClick.AddListener(NextStation);

        volumeUpButton.onClick.AddListener(VolumeUp);
        volumeDownButton.onClick.AddListener(VolumeDown);
    }

    void VolumeUp()
    {
        SoundManager.Instance.PlayRadioInteractionSound();
        musicSource.volume += 0.1f;
        lastVolume = musicSource.volume;
    }

    void VolumeDown()
    {
        SoundManager.Instance.PlayRadioInteractionSound();
        musicSource.volume -= 0.1f;
        lastVolume = musicSource.volume;
    }

    void PreviousStation()
    {
        if (currentStationID != 0)
        {
            SoundManager.Instance.PlayRadioInteractionSound();
            musicSource.clip = trackList[currentStationID - 1];
            currentStationID--;
            musicSource.Play();
        }
    }
    void NextStation()
    {
        if (currentStationID != trackList.Length - 1)
        {
            SoundManager.Instance.PlayRadioInteractionSound();
            musicSource.clip = trackList[currentStationID + 1];
            currentStationID++;
            musicSource.Play();
        }
    }

    void TurnOnMusic()
    {
        SoundManager.Instance.PlayRadioInteractionSound();
        musicSource.volume = lastVolume;

        switchMusicButton.onClick.RemoveAllListeners();
        switchMusicButton.onClick.AddListener(TurnOffMusic);
        RevertButtonsInteractable();
    }

    void TurnOffMusic()
    {
        SoundManager.Instance.PlayRadioInteractionSound();
        musicSource.volume = 0;

        switchMusicButton.onClick.RemoveAllListeners();
        switchMusicButton.onClick.AddListener(TurnOnMusic);
        RevertButtonsInteractable();
    }

    void RevertButtonsInteractable()
    {
        previousStationButton.interactable = !previousStationButton.interactable;
        nextStationButton.interactable = !nextStationButton.interactable;

        volumeUpButton.interactable = !volumeUpButton.interactable;
        volumeDownButton.interactable = !volumeDownButton.interactable;
    }

    public void UnPauseMusic()
    {
        musicSource.UnPause();
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }
}
