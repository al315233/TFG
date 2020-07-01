using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    public static float GameVolume = 1f;

    public static List<string> LevelsWithCursor = new List<string> (new string[] { JIGSAWPUZZLE_SCENE_KEY });

    public const string LABYRINTH_SCENE_KEY = "puzzle1";
    public const string CREDITSSCREEN_SCENE_KEY = "CreditsScene";
    public const string FIRSTMENU_SCENE_KEY = "FirstMenu";
    public const string OPTIONSCREEN_SCENE_KEY = "OptionScreen";
    public const string PAUSESCREEN_SCENE_KEY = "PauseScreen";
    public const string JIGSAWPUZZLE_SCENE_KEY = "puzzle2.3";
    public const string MUSEUM_SCENE_KEY = "scene1";

    public static bool GamePaused;

}




