using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTrueFalseQuestionConfig", menuName = "True False Question Config")]

public class TrueFalseQuestionConfig : ScriptableObject
{
    public TrueFalseQuestionObject[] questions;
}
