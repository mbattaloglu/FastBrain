using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInformationQuestion", menuName = "Information Question")]
public class InformationQuestionObject : ScriptableObject
{
    public string questionText;
    public string[] answers;
    public int answerIndex;
    public float time;
}
