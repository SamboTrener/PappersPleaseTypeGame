using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    string[] validGreetings;
    string[] invalidGreetings;

    [SerializeField] GameObject dialogueWindow;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] Button nextCueButton;

    public Action OnNextCueButtonPressed;

    public GameObject GetDialogueWindow() => dialogueWindow;
    public TextMeshProUGUI GetDialogueText() => dialogueText;

    private void Awake()
    {
        Instance = this;
        validGreetings = new string[] { "Слава Заводу!", "Да здравствует завод!", "Механизируем общество!", "Будет жить завод!", "Возвысится завод!", "Мы те, кто делает мир лучше!" };
        invalidGreetings = new string[] { "Завод - мой дом родной!","Я люблю завод!","Я хочу увидеть объект","Я хочу потрогать объект", "Я хочу объект",
            "Я объект", "ОБЪЕКТ", "ОБЪЕКТ ОБЪЕКТ ОБЪЕКТ", "ПУСТИ МЕНЯ НА ОБЪЕКТ", "*нечленораздельное бормотание*", "Здравствуйте, товарищ вахтер!",
            "Доброе утро, вахтер!", "Доброе утро, человек!", "Я человек, как и ты, и ты меня пропустишь?", "Я ваш работник!",
            "Я инспектор, пропусти!", "Я. ХОЧУ. ПРОЙТИ.", "Завод. Да, я работаю на завод. Работать завод!", "Доброе утро", "Будет Завод!",
            "Слава предприятию!", "Мы делаем лучше!", "Мы сделаем завод лучше!", "Заводу будет лучше у нас!", "Я обычный Рабочий этот завод.",
            "Мне очень нужно внутрь", "Пустите в туалет?","Я слышу","Этот звук, звук идёт отсюда","Завод должен пасть","Я вижу разлом над заводом",
            "Мы взметнемся ввысь","Поглотить, поглотить, поглотить","Слава Разлому","Раб поганого завода","Сиди тихо в своей будке",
            "Мы принесем жизнь","Выбери жизнь","Мы разломаем завод","Разлом окутает мир","Цветение не остановить","Ты тоже слышишь этот шепот по ночам?",
            "Мы ждём тебя снаружи","Помнишь меня?","Оно придет, оно близко","Ты будешь с нами","Ты часть нас","Вы не понимаете, что держите тут", 
            "Слава конторе", "Буу, испугался? Не бойся, я друг. Я тебя не обижу", "Иди сюда, иди ко мне, сядь рядом со мной" ,
            "У вас есть семья? Пустите меня к семье!", "Я тоже хочу работать!", "Будет жив завод!", "Парень играет с тем мешком!" };
    }

    private void Start()
    {
        nextCueButton.onClick.AddListener(() => OnNextCueButtonPressed?.Invoke());
    }

    public void ShowNextCueButton() => nextCueButton.gameObject.SetActive(true);
    public void HideNextCueButton() => nextCueButton.gameObject.SetActive(false);

    public string GetRandomInvalidGreeting() => invalidGreetings[UnityEngine.Random.Range(0, invalidGreetings.Length)];
    public string GetRandomValidGreeting() => validGreetings[UnityEngine.Random.Range(0, validGreetings.Length)];
    public string[] GetAllValidGreetings() => validGreetings;
}

