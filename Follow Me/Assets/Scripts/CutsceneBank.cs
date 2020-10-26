using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CutsceneSprites")]

public class CutsceneBank : ScriptableObject
{

    public const string CUTSCENE1 = "Cutscene1";
    public const string CUTSCENE2 = "Cutscene2";
    public const string CUTSCENE3 = "Cutscene3";

    public string cutsceneName;
    public Sprite cutscene1, cutscene2, cutscene3;
    
    public Sprite GetCutscene(string cutscene)
    {
        switch (cutscene)
        {
            default:
            case CUTSCENE1: return cutscene1;
            case CUTSCENE2: return cutscene2;
            case CUTSCENE3: return cutscene3;
        }
    }
}
