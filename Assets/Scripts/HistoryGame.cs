﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>国語のテスト</summary>
public class HistoryGame : MonoBehaviour
{
    StatusManager _statusManager;

    [SerializeField]
    GameObject inputFieldGameObject;

    [SerializeField]
    InputField inputField;

    [SerializeField]
    Text _answerText;

    [SerializeField]
    Image _questionImage;

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
    [SerializeField]
    [Header("問題画像")]
    Image[] question;

    /// <summary>問題の答え</summary>
    string[] _clearText = { "織田信長", "明智光秀","豊臣秀吉","真田幸村", "武田信玄", "毛利元就", "今川義元", "伊達政宗","徳川家康","上杉謙信"};

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

        _statusManager = FindObjectOfType<StatusManager>();
    }

    void Update()
    {
        _dayText.text = "日付" + dt.Year.ToString() + "年" + dt.Month.ToString() + "月" + dt.Day.ToString() + "日";

        _answerText.text = answer;

        _resultText.text = _clearNum.ToString();

        _questionImage = question[_iD];

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

        switch (_clearText[_iD])
        {
            case "織田信長":

                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa();
                }
                break;
            case "暗黒":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa();
                }
                break;
            case "終焉":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa();
                }
                break;
            case "幻想":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa();
                }
                break;
            case "刹那":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa();
                }
                break;
            case "虚空":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa();
                }
                break;
            case "月蝕":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa();
                }
                break;
            case "煉獄":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa();
                }
                break;
            case "混沌":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa();
                }
                break;
            case "深淵":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa();
                }
                break;
            case "漆黒":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa();
                }
                break;
            case "死線":                
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa();
                }
                break;
            case "殲滅":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa();
                }
                break;
        }
    }

    public void GetInputplayerName()
    {
        answer = inputField.text; //InputFieldからテキスト情報を取得する
        inputField.text = "";//入力フォームのテキストを空にする
        Debug.Log(answer);
    }
    /// <summary>ランダムに出力</summary>
    public void National()
    {
        _iD = Random.Range(1,13);
    }

    /// <summary>次の問題へ</summary>
    public void Next()
    {
        _answerText.text = "";
        National();
    }
    /// <summary>ゲームスタート</summary>
    public void Play()
    {
        _panel.SetActive(false);
        _play = true;
    }
}