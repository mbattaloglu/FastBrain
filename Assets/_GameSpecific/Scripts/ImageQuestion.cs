using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ImageQuestion : Question
{
    public QuestionSettings questionSettings;
    public TextMeshProUGUI TMPQuestionText;
    public ImageQuestionConfig config;
    private ImageQuestionObject[] questions;
    private GameObject[] buttons;
    private int questionNumber;
    private float time;

    public int QuestionNumber { get => questionNumber; set => questionNumber = value; }
    public float Time { get => time; set => time = value; }

    //TODO: Burda veya editörde resimlerin boyutundan ötürü büyük-küçük ayarý yapýlmasý gerek.
    public override void Initialize(int number)
    {
        base.QuestionType = QuestionType.Image;

        buttons = new GameObject[coreGame.questionPanels.transform.GetChild(3).GetChild(1).childCount];
        for (int i = 0; i < coreGame.questionPanels.transform.GetChild(3).GetChild(1).childCount; i++)
        {
            buttons[i] = coreGame.questionPanels.transform.GetChild(3).GetChild(1).GetChild(i).gameObject;
            buttons[i].SetActive(false);
        }
        this.questions = config.questions;
        this.questionNumber = this.questions.Length;

        //Image question index = 3
        for (int i = 1; i < coreGame.questionPanels.transform.childCount; i++)
        {
            coreGame.questionPanels.transform.GetChild(i).gameObject.SetActive(false);
        }
        coreGame.questionPanels.transform.GetChild(3).gameObject.SetActive(true);
        coreGame.questionPanels.SetActive(true);
        TMPQuestionText.text = questions[number].questionText;
        coreGame.answerIndex = questions[number].answerIndex;
        if (questions[number].time != 0) this.Time = questions[number].time;
        else this.Time = questionSettings.defaultTime;
        for (int i = 0; i < questions[number].images.Length; i++)
        {
            buttons[i].SetActive(true);
            buttons[i].GetComponent<Image>().sprite = questions[number].images[i];
        }
    }

    public override void ProblemNotSolved()
    {
        Debug.LogWarning("Not Solved");
    }

    public override void ProblemSolved()
    {
        Debug.LogWarning("Solved");
    }

    public override void Initialize()
    {
        throw new System.NotImplementedException();
    }
}
