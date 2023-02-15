using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InformationQuestion : Question
{
    public QuestionSettings questionSettings;
    public TextMeshProUGUI TMPQuestionText;
    public InformationQuestionConfig config;
    private InformationQuestionObject[] questions;
    private GameObject[] buttons;
    private int questionNumber;
    private float time;
    public int QuestionNumber { get => questionNumber; set => questionNumber = value; }
    public float Time { get => time; set => time = value; }

    public override void Initialize(int number)
    {
        base.QuestionType = QuestionType.Information;

        buttons = new GameObject[coreGame.questionPanels.transform.GetChild(1).GetChild(1).childCount];
        for (int i = 0; i < coreGame.questionPanels.transform.GetChild(1).GetChild(1).childCount; i++)
        {
            buttons[i] = coreGame.questionPanels.transform.GetChild(1).GetChild(1).GetChild(i).gameObject;
            buttons[i].SetActive(false);
        }
        this.questions = config.questions;
        this.questionNumber = this.questions.Length;

        //Information question index = 1
        for (int i = 1; i < coreGame.questionPanels.transform.childCount; i++)
        {
            coreGame.questionPanels.transform.GetChild(i).gameObject.SetActive(false);
        }
        coreGame.questionPanels.SetActive(true);
        coreGame.questionPanels.transform.GetChild(1).gameObject.SetActive(true);
        TMPQuestionText.text = questions[number].questionText;
        coreGame.answerIndex = questions[number].answerIndex;

        if (questions[number].time == 0) this.Time = questionSettings.defaultTime;
        else this.Time = questions[number].time;

        for (int i = 0; i < questions[number].answers.Length; i++)
        {
            buttons[i].SetActive(true);
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = questions[number].answers[i];
        }
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
