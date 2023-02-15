using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewYesNoQuestion",menuName ="Yes-No Question")]
public class YesNoQuestionObject : ScriptableObject
{
    public Sprite questionSprite = null;
    public string questionText;
    public int answerIndex;
    public float time;
}
