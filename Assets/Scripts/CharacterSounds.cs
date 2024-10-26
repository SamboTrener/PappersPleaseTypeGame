using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSounds : MonoBehaviour
{
    CharacterMover characterMover;
    float footstepTimer;
    float footstepTimerMax = 0.5f;
    bool isWalking;

    private void Awake()
    {
        characterMover = GetComponent<CharacterMover>();
        CharacterMover.OnCharacterStartMove += () => isWalking = true;
        CharacterMover.OnCharacterStopped += () => isWalking = false;
    }

    private void Update()
    {
        footstepTimer -= Time.deltaTime;
        if (footstepTimer < 0f)
        {
            footstepTimer = footstepTimerMax;

            if (isWalking)
            {
                SoundManager.Instance.PlayFootstepsSound(characterMover.transform.position);
            }
        }
    }
}
