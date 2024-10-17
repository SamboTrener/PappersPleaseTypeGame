using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class CommonCharacter : MonoBehaviour
{
    protected Image baseImage;

    protected void Awake()
    {
        baseImage = GetComponent<Image>();
    }

    protected void Start()
    {
        DialogueManager.Instance.GetDialogueWindow().SetActive(false);
    }
    private void OnEnable()
    {
        CharacterMover.OnCharacterStopped += Come;
        CharacterMover.OnCharacterStartMove += Leave;
    }

    private void OnDisable()
    {
        CharacterMover.OnCharacterStopped -= Come;
        CharacterMover.OnCharacterStartMove -= Leave;
    }

    protected abstract void Come();
    protected abstract void Leave();

    public abstract bool HasPermission();
}
