using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TrueFalseQuestion : Question
{
    public QuestionSettings questionSettings;
    public TrueFalseQuestionConfig config;
    public TextMeshProUGUI TMPQuestionText;
    private TrueFalseQuestionObject[] questions;
    private GameObject[] buttons;
    private int questionNumber;
    private float time;

    public int QuestionNumber { get => questionNumber; set => questionNumber = value; }
    public float Time { get => time; set => time = value; }

    public override void Initialize(int number)
    {
        base.QuestionType = QuestionType.TrueFalse;

        buttons = new GameObject[coreGame.questionPanels.transform.GetChild(4).GetChild(1).childCount];
        for (int i = 0; i < coreGame.questionPanels.transform.GetChild(4).GetChild(1).childCount; i++)
        {
            buttons[i] = coreGame.questionPanels.transform.GetChild(4).GetChild(1).GetChild(i).gameObject;
            buttons[i].SetActive(false);
        }
        this.questions = config.questions;
        this.questionNumber = this.questions.Length;


        //True False question index = 4
        for (int i = 1; i < coreGame.questionPanels.transform.childCount; i++)
        {
            coreGame.questionPanels.transform.GetChild(i).gameObject.SetActive(false);
        }
        coreGame.questionPanels.SetActive(true);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }
        coreGame.questionPanels.transform.GetChild(4).gameObject.SetActive(true);
        TMPQuestionText.text = questions[number].questionText;
        coreGame.answerIndex = questions[number].isTrue ? 0 : 1;
        if (questions[number].time != 0) this.Time = questions[number].time;
        else this.Time = questionSettings.defaultTime;
    }

    public override void Initialize()
    {
        throw new System.NotImplementedException();
    }

    public override void ProblemNotSolved()
    {
        Debug.LogWarning("Not Solved");
    }

    public override void ProblemSolved()
    {
        Debug.LogWarning("Solved");
    }
}
