using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>国語のテスト</summary>
public class ScienceGame : MonoBehaviour
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
    string[] question = { "H","C","N","O","Na","Mg","Ca","Ti","Fe","Ag","Pt","Au","Hg",};

    /// <summary>問題の答え</summary>
    string[] _clearText = {"水素","炭素","窒素","酸素","ナトリウム","マグネシウム","カルシウム","チタン","鉄","銀","白金","金","水銀",};


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
       Science();

        _statusManager = FindObjectOfType<StatusManager>();
    }

    void Update()
    {
        _dayText.text = "日付" + dt.Year.ToString() + "年" + dt.Month.ToString() + "月" + dt.Day.ToString() + "日";

        _answerText.text = answer;

        _resultText.text = _clearNum.ToString();

        _questionText.text = question[_iD];

        _timer.text = _timeLimit.ToString("f0");

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
            case "H":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusScience();
                }
                break;
            case "C":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusScience();
                }
                break;
            case "N":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusScience();
                }
                break;
            case "O":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusScience();
                }
                break;
            case "Na":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusScience();
                }
                break;
            case "Mg":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusScience();
                }
                break;
            case "Ca":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusScience();
                }
                break;
            case "Ti":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusScience();
                }
                break;
            case "Fe":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusScience();
                }
                break;
            case "Ag":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusScience();
                }
                break;
            case "Pt":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusScience();
                }
                break;
            case "Au":                
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusScience();
                }
                break;
            case "Hg":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusScience();
                }
                break;
        }
    }

    /// <summary>InputFileldの入力</summary>
    public void GetInputplayerName()
    {
        answer = inputField.text; //InputFieldからテキスト情報を取得する
        inputField.text = "";//入力フォームのテキストを空にする
        Debug.Log(answer);
    }

    /// <summary>ランダムに出力</summary>
    public void Science()
    {
        _iD = Random.Range(1,13);
    }

    /// <summary>次の問題へ</summary>
    public void Next()
    {
        _answerText.text = "";
        Science();
    }
    /// <summary>ゲームスタート</summary>
    public void Play()
    {
        _panel.SetActive(false);
        _play = true;
    }
}
