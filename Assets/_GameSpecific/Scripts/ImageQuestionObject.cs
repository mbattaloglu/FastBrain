using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewImageQuestion", menuName = "Image Question")]
public class ImageQuestionObject : ScriptableObject
{
    public string questionText;
    public Sprite[] images;
    public int answerIndex;
    public float time;
}
