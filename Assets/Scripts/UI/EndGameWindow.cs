using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameWindow : MonoBehaviour
{
    public static EndGameWindow Instance { get; private set; }

    [SerializeField] TextMeshProUGUI textContainer;
    [SerializeField] Image imageContainer;
    [SerializeField] Sprite[] factoryEndingSprites;
    [SerializeField] Sprite[] riftEndingSprites;
    [SerializeField] Button nextButton;
    [SerializeField] TextMeshProUGUI nextButtonText;

    string[] endingText;
    Sprite[] endingSprites;

    int iter;
    bool isFactoryEnding;


    private void Awake()
    {
        Instance = this;
        nextButton.onClick.AddListener(ShowNextEndingInfo);
        gameObject.SetActive(false);
    }

    public void ShowGameEndWindow(bool isFactoryEnding)
    {
        SoundManager.Instance.PlayGameEndSoundLooped();
        MusicManager.Instance.StopMusic();
        this.isFactoryEnding = isFactoryEnding;
        iter = -1;
        FillEndingData(isFactoryEnding);
        gameObject.SetActive(true);
        ShowNextEndingInfo();
    }

    void ShowNextEndingInfo()
    {
        ++iter;
        if (iter >= endingSprites.Length - 1 || iter >= endingText.Length - 1)
        {
            nextButton.onClick.RemoveAllListeners();
            nextButton.onClick.AddListener(() => SceneManager.LoadScene("Menu"));
            if (YGManager.GetLanguageStr() == "ru")
            {
                nextButtonText.text = isFactoryEnding ? "Слава Заводу!" : "Слава Разлому!";
            }
            else
            {
                nextButtonText.text = isFactoryEnding ? "Glory to the Factory!" : "Glory to the Rift!";
            }
        }
        textContainer.text = endingText[iter];
        imageContainer.sprite = endingSprites[iter];
    }

    void FillEndingData(bool isFactoryEnding)
    {
        if (YGManager.GetLanguageStr() == "ru")
        {
            if (isFactoryEnding)
            {
                endingText = new string[]
                {
                    "Вы ликвидировали представителя комитета Регулирования Аномальных Зон и Ликвидации Опасных Материй. " +
                    "Позже выяснилось, что о таком комитете  не слышал ни один человек в государственном аппарате. " +
                    "Сразу после ликвидации, большая группа, состоящая из (((них))), попыталась прорваться на Завод.",
                    "Вы остановили прорыв ценой своей жизни и посмертно были награждены орденом третьей степени " +
                    "“За защиту интересов человечества” директором Завода.",
                    "Завод, в свою очередь, стал предприятием особой важности и продолжил свою деятельность в невиданных ранее масштабах",
                    "После попытки провокации неизвестных сил, контроль за Заводом усилился в стократном размере. " +
                    "Недоброжелатели извне стали говорить о том, что деятельность Завода использует Объект исключительно для создания " +
                    "машин по порабощению населения и захвату соседних стран.",
                    "Но слова завистников проходят мимо ушей порядочных граждан. " +
                    "За вклад в наступление Великого Будущего, на территории вашего завода был поставлен памятник директору из " +
                    "чистого золота высотой в 14 метров.",
                    "В награду за вашу жертву на благо Завода, руководство позволило вам продолжить службу даже после вашей кончины. " +
                    "Не без помощи Объекта, ваш уцелевший мозг был внедрен в механизм вечного поддержания жизни. " +
                    "Вы стали бессмертным и бессменным вахтером Завода. Вы были удостоены чести до скончания веков охранять Завод от недоброжелателей. " +
                    "Слава Заводу!"
                };
                endingSprites = factoryEndingSprites;
            }
            else
            {
                endingText = new string[] { };
                endingSprites = riftEndingSprites;
            }
        }
        else
        {
            if (isFactoryEnding)
            {
                endingText = new string[] { };
                endingSprites = factoryEndingSprites;
            }
            else
            {
                endingText = new string[] { };
                endingSprites = riftEndingSprites;
            }
        }
    }

    public IEnumerator ShowGameEndWindowAfterWait(bool isGoodEnding)
    {
        yield return new WaitForSeconds(GameManager.Instance.StandartTimeToWait);
        ShowGameEndWindow(isGoodEnding);
    }
}
