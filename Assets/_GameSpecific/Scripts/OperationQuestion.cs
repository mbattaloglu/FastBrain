using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OperationQuestion : Question
{
    public QuestionSettings questionSettings;
    public TextMeshProUGUI TMPQuestionText;
    private GameObject[] buttons;
    private int number1;
    private int number2;
    private int operationType;
    private int realAnswer;
    private int fakeAnswer;
    private int showingAnswer;
    private string operation;
    private string operationSign;
    private float time;

    public int Number1 { get => number1; set => number1 = value; }
    public int Number2 { get => number2; set => number2 = value; }
    public int OperationType { get => operationType; set => operationType = value; }
    public int Answer { get => realAnswer; set => realAnswer = value; }
    public string OperationSign { get => operationSign; set => operationSign = value; }
    public int ShowingAnswer { get => showingAnswer; set => showingAnswer = value; }
    public string Operation { get => operation; set => operation = value; }
    public float Time { get => time; set => time = value; }

    public override void Initialize()
    {
        base.QuestionType = QuestionType.Operation;
        this.buttons = new GameObject[coreGame.questionPanels.transform.GetChild(2).GetChild(1).childCount];
        for (int i = 0; i < coreGame.questionPanels.transform.GetChild(2).GetChild(1).childCount; i++)
        {
            buttons[i] = coreGame.questionPanels.transform.GetChild(2).GetChild(1).GetChild(i).gameObject;
            buttons[i].SetActive(false);
        }

        this.operationType = Random.Range(0, 4);
        this.operationSign = this.operationType == 0 ? " + " : (this.operationType == 1 ? " - " : (this.operationType == 2 ? " x " : " / "));
        switch (operationType)
        {
            //Addition
            case 0:
                this.number1 = Random.Range(1, 21);
                this.number2 = Random.Range(1, 21);
                this.realAnswer = this.number1 + this.number2;
                break;
            //Subtraction
            case 1:
                this.number1 = Random.Range(1, 21);
                this.number2 = Random.Range(1, number1 + 1);
                this.realAnswer = this.number1 - this.number2;
                break;
            //Multiplication
            case 2:
                this.number1 = Random.Range(1, 11);
                this.number2 = Random.Range(1, 11);
                this.realAnswer = this.number1 * this.number2;
                break;
            //Division
            case 3:
                this.number1 = Random.Range(5, 31);
                List<int> divisiors = new List<int>();
                for (int i = 1; i < Mathf.Sqrt(this.number1); i++)
                {
                    if (number1 % i == 0)
                        divisiors.Add(i);
                }
                this.number2 = divisiors[Random.Range(0, divisiors.Count)];
                this.realAnswer = this.number1 / this.number2;
                break;
            default:
                break;
        }
        do
        {
            this.fakeAnswer = Random.Range(1, 21);
        } while (this.realAnswer == this.fakeAnswer);

        
        int trueFalseChance = Random.Range(0, 2);
        
        if (trueFalseChance == 1)
        {
            int realAnswerChance = Random.Range(0, 2);
            if (realAnswerChance == 0)
            {
                this.showingAnswer = this.realAnswer;
                this.operation = this.number1 + this.operationSign + this.number2 + " = " + this.realAnswer + "\n";
            }
            else
            {
                this.showingAnswer = this.fakeAnswer;
                this.operation = this.number1 + this.operationSign + this.number2 + " = " + this.fakeAnswer + "\n";
            }
            coreGame.answerIndex = realAnswerChance;
            buttons[0].GetComponentInChildren<TextMeshProUGUI>().text = "True";
            buttons[1].GetComponentInChildren<TextMeshProUGUI>().text = "False";
            buttons[0].SetActive(true);
            buttons[1].SetActive(true);
        }
        else
        {
            this.operation = this.number1 + this.operationSign + this.number2;
            int answerIndex = Random.Range(0, 4);
            buttons[answerIndex].GetComponentInChildren<TextMeshProUGUI>().text = this.realAnswer.ToString();
            coreGame.answerIndex = answerIndex;
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i == answerIndex) continue;
                else buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = Random.Range(0, 21).ToString();
            }

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(true);
            }
        }

        for (int i = 1; i < coreGame.questionPanels.transform.childCount; i++)
        {
            coreGame.questionPanels.transform.GetChild(i).gameObject.SetActive(false);
        }
        TMPQuestionText.GetComponent<TextMeshProUGUI>().text = operation;
        coreGame.questionPanels.transform.GetChild(2).gameObject.SetActive(true);
        coreGame.questionPanels.SetActive(true);
        this.Time = questionSettings.defaultTime;
    }

    public override void Initialize(int number)
    {
        throw new System.NotImplementedException();
    }

    public override void ProblemNotSolved()
    {

    }

    public override void ProblemSolved()
    {

    }

    public override string ToString()
    {
        return this.operation + base.ToString();
    }
}
