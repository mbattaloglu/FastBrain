using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestionType
{
    NULL, 
    Operation,
    Information,
    Image,
    TrueFalse,
    YesNo
}

public abstract class Question : MonoBehaviour 
{
    public CoreGame coreGame;
    private QuestionType questionType;
    private bool isShowedAnswerTrue;

    public QuestionType QuestionType { get => questionType; set => questionType = value; }

    public Question()
    {
        this.questionType = QuestionType.NULL;
    }


    public abstract void Initialize();
    public abstract void Initialize(int number);

    public abstract void ProblemSolved();

    public virtual void ProblemNotSolved()
    {
        coreGame.PlayerFailed();
    }


    public override string ToString()
    {
        return "Question Type:" + this.questionType + "\nShowed Answer" + this.isShowedAnswerTrue;
    }

}






