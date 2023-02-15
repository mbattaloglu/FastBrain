using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewYesNoQuestionConfig", menuName = "Yes No Question Config")]
public class YesNoQuestionConfig : ScriptableObject
{
    public YesNoQuestionObject[] questions;
}
