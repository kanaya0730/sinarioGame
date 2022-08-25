using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour
{
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
        //_timer.text = System.DateTime.Now.ToString();
        dt = System.DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        _dayText.text = dt.Year.ToString() + "年" + dt.Month.ToString() + "月" + dt.Day.ToString() + "日";
        _questionText.text = question;
        _answerText.text = answer;
        _resultText.text = _clearNum.ToString();
        _timer.text = _timeLimit.ToString("f1");

        if(_play == true)
        {
            if (_timeLimit <= 0)
            {
                _timeLimit = 0;
                answer = "お疲れ様です。";
                inputField.text = "00000000";
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
        _panel.SetActive(false);
        _play = true;
        Math();
    }

    public void Normal()
    {
        _numID = 1;
        _panel.SetActive(false);
        _play = true;
        Math();
    }

    public void Hard()
    {
        _numID = 2;
        _panel.SetActive(false);
        _play = true;
        Math();
    }

    public void Master()
    {
        _numID = 3;
        _panel.SetActive(false);
        _play = true;
        Math();
    }
    public void Predator()
    {
        _numID = 4;
        _panel.SetActive(false);
        _play = true;
        Math();
    }

}
