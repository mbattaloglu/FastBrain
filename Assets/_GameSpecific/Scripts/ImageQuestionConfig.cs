using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewImageQuestionConfig", menuName = "Image Question Config")]
public class ImageQuestionConfig : ScriptableObject
{
    public ImageQuestionObject[] questions;
}
