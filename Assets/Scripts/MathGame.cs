using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>数学のテスト</summary>
public class MathGame : MonoBehaviour
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
    string question;
    int _clearNum;
    int sum;

    [SerializeField]
    [Header("Panel")]
    GameObject _panel;

    int[] _maxNum = { 11,101,1001,10001,100001, };

    int _numID;

    bool _play;
    System.DateTime dt;
    void Start()
    {
        _play = false;
        _answerText.text = "?";
        dt = System.DateTime.Now;
        _statusManager = FindObjectOfType<StatusManager>();
    }

    void Update()
    {
        _dayText.text = "日付" + dt.Year.ToString() + "年" + dt.Month.ToString() + "月" + dt.Day.ToString() + "日";
        _questionText.text = question;
        _answerText.text = answer;
        _resultText.text = _clearNum.ToString();
        _timer.text = _timeLimit.ToString("f0");

        if(_play == true)
        {
            if (_timeLimit <= 0)
            {
                _timeLimit = 0;
                answer = "お疲れ様です。";
                inputField.text = "00000000";
                SceneManager.LoadScene("SecondScene");
            }
            else
            {
                _timeLimit -= Time.deltaTime;
            }
        }

        if (sum == int.Parse(answer))
        {
            Math();
            _clearNum += 1;
            _statusManager.PlusNationa();
        }
    }
    public void GetInputplayerName()
    {     
        answer = inputField.text; //InputFieldからテキスト情報を取得する
        inputField.text = "";//入力フォームのテキストを空にする
        Debug.Log(answer);
    }

    void Math()
    {
        int a = Random.Range(1, _maxNum[_numID]);
        int b = Random.Range(1, _maxNum[_numID]);

        sum = a + b;

        Debug.Log(sum);
        question = a + "+" + b + "=?";
    }

    public void Easy()
    {
        _numID = 0;
        Play();
    }

    public void Normal()
    {
        _numID = 1;
        Play();
    }

    public void Hard()
    {
        _numID = 2;
        Play();
    }

    public void Master()
    {
        _numID = 3;
        Play();
    }
    public void Predator()
    {
        _numID = 4;
        Play();
    }

    public void Play()
    {
        _panel.SetActive(false);
        _play = true;
        Math();
    }
}
