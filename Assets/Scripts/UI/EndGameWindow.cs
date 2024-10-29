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
        MusicManager.Instance.PauseMusic();
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
                    "   Вы ликвидировали представителя комитета Регулирования Аномальных Зон и Ликвидации Опасных Материй. " +
                    "Позже выяснилось, что о таком комитете  не слышал ни один человек в государственном аппарате. ",
                    "   Сразу после ликвидации, большая группа, состоящая из [них], попыталась прорваться на Завод." +
                    " Вы остановили прорыв ценой своей жизни и посмертно были награждены орденом третьей степени " +
                    "“За защиту интересов человечества” директором Завода.",
                    "   Завод, в свою очередь, стал предприятием особой важности и продолжил свою деятельность в невиданных ранее масштабах",
                    "   После попытки провокации неизвестных сил, контроль за Заводом усилился в стократном размере. " +
                    "Недоброжелатели извне стали говорить о том, что деятельность Завода использует Объект исключительно для создания " +
                    "машин по порабощению населения и захвату соседних стран.",
                    "   Но слова завистников проходят мимо ушей порядочных граждан. " +
                    "За вклад в наступление Великого Будущего, на территории вашего завода был поставлен памятник директору из " +
                    "чистого золота высотой в 14 метров.",
                    "   В награду за вашу жертву на благо Завода, руководство позволило вам продолжить службу даже после вашей кончины. " +
                    "Не без помощи Объекта, ваш уцелевший мозг был внедрен в механизм вечного поддержания жизни.",
                    "   Вы стали бессмертным и бессменным вахтером Завода. Вы были удостоены чести до скончания веков охранять Завод от недоброжелателей."
                };
                endingSprites = factoryEndingSprites;
            }
            else
            {
                endingText = new string[] 
                {
                    "   Вы пропустили представителя комитета Регулирования Аномальных Зон и Ликвидации Опасных Материй. " +
                    "Позже выяснилось, что о таком комитете  не слышал ни один человек в государственном аппарате.",
                    "   Вместе с представителем зашла армия, состоящая из [них]. Завод был разрушен, сотрудники уничтожены, а Объект пропал без вести.",
                    "   На руинах завода начался буйный рост растительности. Местные фермеры доложили о самом урожайном году в истории. ",
                    "   Воздух очистился от отходов работы Завода и люди наконец-то выдохнули с облегчением. " +
                    "Казалось, с падением завода, жизнь только улучшилась, и мир обошелся без страшных последствий.",
                    "   Казалось…",
                    "   О вахтере после событий штурма никто не слышал. Быть может, он сгинул жертвой того, что сам натворил, " +
                    "а может не смог перенести позора от содеянного и ушел в горизонт. Этого мы никогда не узнаем."
                };
                endingSprites = riftEndingSprites;
            }
        }
        else
        {
            if (isFactoryEnding)
            {
                endingText = new string[] 
                {
                    "   You eliminated a representative of the Regulation of Incident and Fast Troubleshooting committee. " +
                    "Later it turned out that no one in the state apparatus had ever heard of such a committee.",
                    "   Immediately after the elimination, a large group consisting of [them] tried to break into the Factory. " +
                    "You stopped the breakthrough at the cost of your life and were posthumously awarded the Order of the third degree" +
                    " “For Protecting the interests of Humanity” by the director of the Factory.",
                    "   The Factory, in turn, became an enterprise of special importance and continue its activities on a scale never seen before",
                    "   After an attempt to provoke by unknown forces, control over the Factory increased a hundredfold. " +
                    "Detractors began to say that the Factory's activities use the Object exclusively to create machines to enslave the population and capture neighboring countries.",
                    "   But the words of envious people pass by the ears of decent citizen. " +
                    "For his contribution to the Great Future, a 14-meter-high monument to the director was erected on the territory of Factory.",
                    "   As a reward for your sacrifice for the benefit of the Factory, the management allowed you to continue your service even after your death. " +
                    "With the help of the Object, your uninjured brain was embedded in the mechanism of eternal life support.",
                    "   You have become an immortal and permanent watchman of the Factory. You were honored to protect the Factory from detractors until the end of time."
                };
                endingSprites = factoryEndingSprites;
            }
            else
            {
                endingText = new string[] 
                {
                    "   You let in a representative of the Regulation of Incident and Fast Troubleshooting committee. " +
                    "Later it turned out that no one in the state apparatus had ever heard of such a committee.",
                    "   Together with the representative, an army consisting of [them] came in. The Factory was destroyed, the employees were annihilated, and the Object was missing",
                    "   Vegetation began to grow violently on the ruins of the Factory. Local farmers reported on the most productive year in history.",
                    "   The air was cleared of waste from the Factory and people finally breathed a sigh of relief. " +
                    "It seemed that with the fall of the Factory, life only improved, and the world did without terrible consequences.",
                    "   It seemed...",
                    "   No one has heard about the watchman after the events of the assault. Maybe he died a victim of what he had done, " +
                    "or maybe he couldn't bear the shame of what he had done and went into the horizon. We'll never know."
                };
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
