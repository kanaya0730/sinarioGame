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

    string answer;
    string question;
    int _clearNum;
    int sum;
    void Start()
    {
        _answerText.text = "?";
        tinpo();
    }

    // Update is called once per frame
    void Update()
    {
        _timer.text = _timeLimit.ToString("f1");

        if (_timeLimit <= 0)
        {
            _timeLimit = 0;
        }
        else
        {
            _timeLimit -= Time.deltaTime;
        }
        _questionText.text = question;
        _answerText.text = answer;
        //switch(question)
        //{
        //    case "1+1=?":
        //        if(answer == "2")
        //        {
        //            //正解音
        //            _questionText.text = "3×8=?";
        //            answer = "";
        //            //_clearNum += 1;
        //        }
        //        break;
        //    case "3×8=?":
        //        if(answer == "24")
        //        {
        //            //正解音
        //            _questionText.text = "10+8+5+4=?";
        //            answer = "";
        //            //_clearNum += 1;
        //        }
        //        break;
        //    case "10+8+5+4=?":
        //        if (answer == "27")
        //        {
        //            //正解音
        //            _questionText.text = "10×8×5×4=?";
        //            answer = "";
        //            //_clearNum += 1;
        //        }
        //        break;
        //    case "10×8×5×4=?":
        //        if (answer == "1600")
        //        {
        //            //正解音
        //            _questionText.text = "100+7+54-20=?";
        //            answer = "";
        //            //_clearNum += 1;
        //        }
        //        break;
        //    case "100+7+54-20=?":
        //        if (answer == "141")
        //        {
        //            //正解音
        //            _questionText.text = "10×8×5×4=?";
        //            answer = "";
        //            //_clearNum += 1;
        //        }
        //        break;
        //}
    }
    public void GetInputplayerName()
    {
        //InputFieldからテキスト情報を取得する
        answer = inputField.text;
        Debug.Log(answer);
        //入力フォームのテキストを空にする
        inputField.text = "";
    }

    void tinpo()
    {
        int a = Random.Range(1,11);
        int b = Random.Range(1, 11);

        int sum = a + b;

        Debug.Log(a);
        Debug.Log(b);
        Debug.Log(sum);
        

        question = $"{a}+{b}=?";

        if(sum == int.Parse(answer))
        {
            print("おめでとうございます");
            tinpo();
        }
    }
}
