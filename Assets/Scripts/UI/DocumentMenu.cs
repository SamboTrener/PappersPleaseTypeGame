using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DocumentMenu : MonoBehaviour
{
    public static DocumentMenu Instance { get; private set; }

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI ageText;
    [SerializeField] TextMeshProUGUI documentDataText;
    [SerializeField] Image documentPhoto;
    [SerializeField] Button documentButton;

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void ShowDocument(EmployeeSO employeeSO)
    {
        if(YGManager.GetLanguageStr() == "ru")
        {
            nameText.text = $"Name : {employeeSO.employeeNameRu}";
        }
        else
        {
            nameText.text = $"Name : {employeeSO.employeeName}";
        }
        ageText.text = $"Age : {employeeSO.age}";
        documentDataText.text = $"ID : {employeeSO.passID}";
        documentPhoto.sprite = employeeSO.baseSprite;

        documentButton.gameObject.SetActive(true);
        documentButton.onClick.AddListener(OpenDocumentMenu);
    }

    public void HideDocument() => documentButton.gameObject.SetActive(false);

    void OpenDocumentMenu()
    {
        SoundManager.Instance.PlayPaperSound(documentButton.gameObject.transform.position);
        gameObject.SetActive(true);
    }
}
