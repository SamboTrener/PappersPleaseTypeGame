using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using YG;

public static class YGManager
{
    public static string GetLanguageStr() => YandexGame.EnvironmentData.language;
}
