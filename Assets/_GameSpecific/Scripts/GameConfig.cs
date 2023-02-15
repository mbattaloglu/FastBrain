using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New GameConfig", menuName = "Game Config", order = 51)]
public class GameConfig : Grimanda.Common.CommonGameConfig
{
    [Header("Game Specific Settings")]
    public int GameSpecific;
}
