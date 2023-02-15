using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoreGame : Grimanda.Common.CoreGame
{
    public ImageQuestion imageQuestion;
    public InformationQuestion informationQuestion;
    public TrueFalseQuestion trueFalseQuestion;
    public OperationQuestion operationQuestion;
    public YesNoQuestion yesNoQuestion;

    //Index Numbers for Panels:
    //1=> Information
    //2=> Operation
    //3=> Image
    //4=> TrueFalse
    //5=> YesNo 
    public GameObject questionPanels;

    public InformationQuestionConfig informationQuestionConfig;
    public ImageQuestionConfig imageQuestionConfig;
    public TrueFalseQuestionConfig trueFalseQuestionConfig;
    public YesNoQuestionConfig yesNoQuestionConfig;

    private int clickedButton = -1;
    [HideInInspector]
    public int answerIndex;


    private int questionOrder;
    private int informationQuestionNumber;
    private int imageQuestionNumber;
    private int trueFalseQuestionNumber;
    private int yesNoQuestionNumber;

    public TextMeshProUGUI TMPTimeText;
    private float waitingTime;
    private float answeringTime;
    private float time;
    private void Start()
    {
        questionOrder = 0;
        informationQuestionNumber = 0;
        imageQuestionNumber = 0;
        trueFalseQuestionNumber = 0;
        yesNoQuestionNumber = 0;
        GetQuestion();
    }

    private void Update()
    {
        if (isGamePaused)
        {
            //Debug.Log("Game Is Paused");
            return;
        }

        Debug.Log("Game Is Playing:" + Time.time);

        TMPTimeText.text = ((int)time).ToString();
        time -= Time.deltaTime;
        answeringTime += Time.deltaTime;

        if (clickedButton != -1)
        {
            if (clickedButton == answerIndex)
            {
                
                Debug.LogWarning("True");
                if (questionOrder + 1 == 5) questionOrder = 0;
                else questionOrder++;

                //Score Calculation:
                if (answeringTime < waitingTime / 4)
                {
                    IncreaseScore(4);
                }
                else if(answeringTime < 2 * (waitingTime / 4))
                {
                    IncreaseScore(3);
                }
                else if (answeringTime < 3 * (waitingTime / 4))
                {
                    IncreaseScore(2);
                }
                else
                {
                    IncreaseScore(1);
                }
                GetQuestion();
            }
            else
            {
                Debug.LogWarning("False");
                isGamePaused = true;
                PlayerFailed();
            }
            clickedButton = -1;
        }

        if (this.time <= 0)
        {
            Debug.LogWarning("Failed");
            isGamePaused = true;
            PlayerFailed();
        }
    }

    private void GetQuestion()
    {
        switch (this.questionOrder)
        {
            case 0:
                if (informationQuestionNumber < informationQuestionConfig.questions.Length)
                {
                    informationQuestion.Initialize(informationQuestionNumber);
                    this.time = informationQuestion.Time;
                    informationQuestionNumber++;
                }
                else
                {
                    questionOrder++;
                    GetQuestion();
                }
                break;
            case 1:
                if (imageQuestionNumber < imageQuestionConfig.questions.Length)
                {
                    imageQuestion.Initialize(imageQuestionNumber);
                    this.time = imageQuestion.Time;
                    imageQuestionNumber++;
                }
                else
                {
                    questionOrder++;
                    GetQuestion();
                }
                break;
            case 2:
                if (trueFalseQuestionNumber < trueFalseQuestionConfig.questions.Length)
                {
                    trueFalseQuestion.Initialize(trueFalseQuestionNumber);
                    this.time = trueFalseQuestion.Time;
                    trueFalseQuestionNumber++;
                }
                else
                {
                    questionOrder++;
                    GetQuestion();
                }
                break;
            case 3:
                if (yesNoQuestionNumber < yesNoQuestionConfig.questions.Length)
                {
                    yesNoQuestion.Initialize(yesNoQuestionNumber);
                    this.time = yesNoQuestion.Time;
                    yesNoQuestionNumber++;
                }
                else
                {
                    questionOrder++;
                    GetQuestion();
                }
                break;
            case 4:
                operationQuestion.Initialize();
                this.time = 5;                            
                break;
            default:
                break;
        }
        waitingTime = time;
    }


    public void OnClickFirstButton()
    {
        clickedButton = 0;
    }
    public void OnClickSecondButton()
    {
        clickedButton = 1;
    }
    public void OnClickThirdButton()
    {
        clickedButton = 2;
    }
    public void OnClickFourthButton()
    {
        clickedButton = 3;
    }

    /// <summary>
    /// OVERRIDES
    /// Place your code in the necessary methods and functions
    /// </summary>
    public override void DoGameSpecificThingsStart()
    {
        base.DoGameSpecificThingsStart();
        // TODO : Add your Below
    }

    public override void IncreaseScore(int delta)
    {
        base.IncreaseScore(delta);
        // TODO : Add your Below
    }

    public override void PlayerFailed()
    {
        base.PlayerFailed();
        // TODO : Add your Below
    }

    public override void PlayerPaused()
    {
        base.PlayerPaused();
        // TODO : Add your Below
    }

    public override void PlayerQuitedTheGame()
    {
        base.PlayerQuitedTheGame();
        // TODO : Add your Below
    }

    public override void PlayerRestartedGame()
    {
        base.PlayerRestartedGame();
        // TODO : Add your Below
        this.time = 5;
        TMPTimeText.text = ((int)time).ToString();

    }

    public override void SecondChance()
    {
        base.SecondChance();
        // TODO : Add your Below
    }

    public override void ResumeGame()
    {
        base.ResumeGame();
        // TODO : Add your Below
    }

    public override void StartPlayingGame()
    {
        base.StartPlayingGame();
        this.time = 5;
        TMPTimeText.text = ((int)time).ToString();
        // TODO : Add your Below
    }

    /// <summary>
    /// END OF OVERRIDES
    /// </summary>
    ///

}
