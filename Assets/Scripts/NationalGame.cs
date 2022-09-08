using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>国語のテスト</summary>
public class NationalGame : MonoBehaviour
{
    StatusManager _statusManager;

    [SerializeField]
    [Header("国語の授業データ")]
    QuestionData _questionData;

    [SerializeField]
    GameObject inputFieldGameObject;

    [SerializeField]
    InputField inputField;

    [SerializeField]
    Text _answerText;

    [SerializeField]
    Text _questionText;

    [SerializeField]
    Text _resultText;

    [SerializeField]
    [Header("制限時間テキスト")]
    Text _timer;

    [SerializeField]
    [Header("制限時間")]
    float _timeLimit;


    [SerializeField]
    [Header("現在の日付")]
    Text _dayText;

    string answer;

    /// <summary>問題内容</summary>
    string　_question;

    /// <summary>問題の答え</summary>
    string _questionAnswer;


    [SerializeField]
    [Header("Panel")]
    GameObject _panel;

    int _iD = 0;

    bool _play;
    System.DateTime dt;

    int _clearNum;
    
    void Start()
    {
        _play = false;
        _answerText.text = "?";
        dt = System.DateTime.Now;
        National();

        Debug.Log(_questionData.Subject);

        _question = _questionData.QuestionDatas[_iD].Question;
        _questionAnswer = _questionData.QuestionDatas[_iD].Answer;

        Debug.Log(_question);
        Debug.Log(_questionAnswer);

        /*for (int i = 0; i < 12; i++)
        {
            //_question[i] = _questionData.QuestionDatas[i].Question;
            //_questionAnswer[i] = _questionData.QuestionDatas[i].Answer;

            _question = _questionData.QuestionDatas[i].Question;
            _questionAnswer = _questionData.QuestionDatas[i].Answer;

        }*/

        _statusManager = FindObjectOfType<StatusManager>();
    }

    void Update()
    {
        _dayText.text = "日付" + dt.Year.ToString() + "年" + dt.Month.ToString() + "月" + dt.Day.ToString() + "日";

        _answerText.text = answer;

        _resultText.text = _clearNum.ToString();

        _questionText.text = _question;

        _timer.text = _timeLimit.ToString("f1");

        if (_play == true)
        {
            if (_timeLimit <= 0)
            {
                _timeLimit = 0;
                answer = "お疲れ様です。";
                inputField.text = "お疲れ様です。";

                SceneManager.LoadScene("ThirdScene");
            }
            else
            {
                _timeLimit -= Time.deltaTime;
            }
        }

        switch (_question)
        {
            case "究極":
                if (_questionAnswer == _answerText.text)
                {
                    Next();
                    _statusManager.PlusNationa(2);
                }
                break;
            case "暗黒":
                if (_questionAnswer == _answerText.text)
                {
                    Next();

                    _statusManager.PlusNationa(2);
                }
                break;
            case "終焉":
                if (_questionAnswer == _answerText.text)
                {
                    Next();
                    _statusManager.PlusNationa(2);
                }
                break;
            case "幻想":
                if (_questionAnswer == _answerText.text)
                {
                    Next();
                    _statusManager.PlusNationa(2);
                }
                break;
            case "刹那":
                if (_questionAnswer == _answerText.text)
                {
                    Next();
                    _statusManager.PlusNationa(2);
                }
                break;
            case "虚空":
                if (_questionAnswer == _answerText.text)
                {
                    Next();
                    _statusManager.PlusNationa(2);
                }
                break;
            case "月蝕":
                if (_questionAnswer == _answerText.text)
                {
                    Next();
                    _statusManager.PlusNationa(2);
                }
                break;
            case "煉獄":
                if (_questionAnswer == _answerText.text)
                {
                    Next();
                    _statusManager.PlusNationa(2);
                }
                break;
            case "混沌":
                if (_questionAnswer == _answerText.text)
                {
                    Next();
                    _statusManager.PlusNationa(2);
                }
                break;
            case "深淵":
                if (_questionAnswer == _answerText.text)
                {
                    Next();
                    _statusManager.PlusNationa(2);
                }
                break;
            case "漆黒":
                if (_questionAnswer == _answerText.text)
                {
                    Next();
                    _statusManager.PlusNationa(2);
                }
                break;
            case "死線":                
                if (_questionAnswer == _answerText.text)
                {
                    Next();
                    _statusManager.PlusNationa(2);
                }
                break;
            case "殲滅":
                if (_questionAnswer == _answerText.text)
                {
                    Next();
                    _statusManager.PlusNationa(2);
                }
                break;
        }
    }

    public void GetInputPlayerName()
    {
        answer = inputField.text; //InputFieldからテキスト情報を取得する
        inputField.text = "";//入力フォームのテキストを空にする
        Debug.Log(answer);
    }
    /// <summary>ランダムに出力</summary>
    public void National()
    {
        _iD = Random.Range(1,13);

        _question = _questionData.QuestionDatas[_iD].Question;
        _questionAnswer = _questionData.QuestionDatas[_iD].Answer;
    }

    /// <summary>次の問題へ</summary>
    public void Next()
    {
        _answerText.text = "";
        _clearNum++;
        National();
    }
    /// <summary>ゲームスタート</summary>
    public void Play()
    {
        _panel.SetActive(false);
        _play = true;
    }
}
