using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using YG;

public static class YGManager
{
    public static string GetLanguageStr() => YandexGame.EnvironmentData.language;

    public static void SendEndShiftMetrica(int id, DifficultyLevel difficultyLevel)
    {
        var metricaParams = new Dictionary<string, string>
        {
            { "Shift ID", $"{id}"},
            { "Difficulty Level", $"{difficultyLevel}" }
        };
        YandexMetrica.Send("endShift", metricaParams);
    }

    public static void SendEndGameMetrica(bool isFactoryEnding)
    {
        if (isFactoryEnding)
        {
            var metricaParams = new Dictionary<string, string>
            {
                { "Ending", "Factory"},
            };
            YandexMetrica.Send("endGame", metricaParams);
        }
        else
        {
            var metricaParams = new Dictionary<string, string>
            {
                { "Ending", "Rift"},
            };
            YandexMetrica.Send("endGame", metricaParams);
        }
    }
}
