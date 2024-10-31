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

    [SerializeField] Button[] switchMusicButtons;

    [SerializeField] Button[] previousStationButtons;
    [SerializeField] Button[] nextStationButtons;

    [SerializeField] Button[] volumeUpButtons;
    [SerializeField] Button[] volumeDownButtons;

    float lastVolume = 1;

    int currentStationID = 0;

    private void Awake()
    {
        Instance = this;   
        musicSource.clip = trackList[currentStationID];
        musicSource.loop = true;
        musicSource.Play();
        for(int i = 0; i < switchMusicButtons.Length; i++)
        {
            switchMusicButtons[i].onClick.AddListener(TurnOnMusic);
            previousStationButtons[i].onClick.AddListener(PreviousStation);
            nextStationButtons[i].onClick.AddListener(NextStation);

            volumeUpButtons[i].onClick.AddListener(VolumeUp);
            volumeDownButtons[i].onClick.AddListener(VolumeDown);
        }
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

        for(int i = 0; i < switchMusicButtons.Length; i++)
        {
            switchMusicButtons[i].onClick.RemoveAllListeners();
            switchMusicButtons[i].onClick.AddListener(TurnOffMusic);
        }
        RevertButtonsInteractable();
    }

    void TurnOffMusic()
    {
        SoundManager.Instance.PlayRadioInteractionSound();
        musicSource.volume = 0;

        for(int i = 0; i < switchMusicButtons.Length; i++)
        {
            switchMusicButtons[i].onClick.RemoveAllListeners();
            switchMusicButtons[i].onClick.AddListener(TurnOnMusic);
        }
        RevertButtonsInteractable();
    }

    void RevertButtonsInteractable()
    {
        for(int i = 0; i < switchMusicButtons.Length; i++)
        {
            previousStationButtons[i].interactable = !previousStationButtons[i].interactable;
            nextStationButtons[i].interactable = !nextStationButtons[i].interactable;

            volumeUpButtons[i].interactable = !volumeUpButtons[i].interactable;
            volumeDownButtons[i].interactable = !volumeDownButtons[i].interactable;
        }
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
