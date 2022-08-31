using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>国語のテスト</summary>
public class NationalGame : MonoBehaviour
{
    StatusManager _statusManager;

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
    string[] question = { "究極","暗黒","終焉","幻想","刹那","虚空","月蝕", "煉獄","混沌","深淵","漆黒","死線","殲滅",};
    /// <summary>問題の答え</summary>
    string[] _clearText = {"きゅうきょく","あんこく","しゅうえん","げんそう","せつな","こくう","げっしょく","れんごく","こんとん","しんえん","しっこく","しせん","せんめつ",};


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

        _questionText.text = question[_iD];

        _timer.text = _timeLimit.ToString("f1");

        if (_play == true)
        {
            if (_timeLimit <= 0)
            {
                _timeLimit = 0;
                answer = "お疲れ様です。";
                inputField.text = "お疲れ様です。";
            }
            else
            {
                _timeLimit -= Time.deltaTime;
            }
        }

        switch (question[_iD])
        {
            case "究極":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                }
                break;
            case "暗黒":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                }
                break;
            case "終焉":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                }
                break;
            case "幻想":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                }
                break;
            case "刹那":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                }
                break;
            case "虚空":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                }
                break;
            case "月蝕":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                }
                break;
            case "煉獄":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                }
                break;
            case "混沌":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                }
                break;
            case "深淵":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                }
                break;
            case "漆黒":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                }
                break;
            case "死線":                
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                }
                break;
            case "殲滅":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
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
        _clearNum += 1;
        _answerText.text = "";
        _statusManager.PlusSmart();
        National();
    }
    /// <summary>ゲームスタート</summary>
    public void Play()
    {
        _panel.SetActive(false);
        _play = true;
    }
}
