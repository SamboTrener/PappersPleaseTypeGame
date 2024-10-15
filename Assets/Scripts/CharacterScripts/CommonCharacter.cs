using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class CommonCharacter : MonoBehaviour
{
    protected Image baseImage;

    [SerializeField] protected GameObject dialogeWindow;
    [SerializeField] protected TextMeshProUGUI dialogeText;

    protected void Awake()
    {
        baseImage = GetComponent<Image>();
    }

    protected void Start()
    {
        dialogeWindow.SetActive(false);
        Debug.Log("hide dialogue window");
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
