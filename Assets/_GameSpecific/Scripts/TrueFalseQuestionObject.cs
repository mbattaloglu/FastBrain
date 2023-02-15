using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTrueFalseQuestion", menuName = "True False Question")]
public class TrueFalseQuestionObject : ScriptableObject
{
    public string questionText;
    public bool isTrue;
    public float time;
}
