﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>国語のテスト</summary>
public class HistoryGame : MonoBehaviour
{
    StatusManager _statusManager;

    [SerializeField]
    [Header("歴史の授業データ")]
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
    string _question;

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
        History();

        _question = _questionData.QuestionDatas[_iD].Question;
        _questionAnswer = _questionData.QuestionDatas[_iD].Answer;

        Debug.Log(_questionAnswer);
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

                SceneManager.LoadScene("");
            }
            else
            {
                _timeLimit -= Time.deltaTime;
            }
        }

        if (_questionAnswer == _answerText.text)
        {
            _answerText.text = "";
            History();
            _clearNum++;
            _statusManager.PlusNationa(2);
        }
    }

    public void GetInputplayerName()
    {
        answer = inputField.text; //InputFieldからテキスト情報を取得する
        inputField.text = "";//入力フォームのテキストを空にする
        Debug.Log(answer);
    }

    /// <summary>ランダムに出力</summary>
    public void History()
    {
        _iD = Random.Range(1,13);

        _question = _questionData.QuestionDatas[_iD].Question;
        _questionAnswer = _questionData.QuestionDatas[_iD].Answer;

        Debug.Log(_questionAnswer);
    }

    /// <summary>ゲームスタート</summary>
    public void Play()
    {
        _panel.SetActive(false);
        _play = true;
    }
}
