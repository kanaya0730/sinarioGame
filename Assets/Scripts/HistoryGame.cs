using System.Collections;
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
    string[] question = { "家督争いの混乱を収めた後に、桶狭間の戦いで今川義元を討ち取り、勢力を拡大した。\nこの人物は誰？"
                         ,"「織田信長」から絶大な信頼を得て、低い身分から一国一城の主へと出世した戦国武将。この人物は誰？"
                         ,"最初の身分は低く、まったく無名の存在でしたが、次第に頭角をあらわして次々と功績をあげ、やがて「織田信長」の重臣となった。\nこの人物は誰？"
                         ,"信濃国に生まれた戦国大名で、豊臣家に生涯忠誠を誓った人物として英雄視されていた。\nこの人物は誰？"
                         ,"最強ともいわれた騎馬隊を率い、織田信長も恐れるほどの武力を誇った武将。\nこの人物は誰？"
                         ,"戦国時代に郡山城を拠点として中国地方のほぼ全域を制覇し、一代で大国を築き上げた「戦国の雄」と称された戦国大名。\nこの人物は誰？"
                         ,"「海道一の弓取り」（東海道一の優れた武士）と評され、武田 信玄、北条 氏康（うじやす）とも互角に渡り合い、諸国に恐れられていた名将。\nこの人物は誰？"
                         ,"東北を平定して仙台藩を開いた。\nこの人物は誰？"
                         ,"江戸幕府の初代将軍です。 初めは三河（愛知県東部）岡崎の小大名・松平広忠の子として生まれましたが、後に織田信長と同盟を結んで勢力を拡大した。\nこの人物は誰？"
                         ,"内乱が長く続いた越後国を平定し、繁栄させるために尽力した。この人物は誰？"
                         ,"明治・大正期の細菌学者。福島県のまずしい農家に生まれる。幼児期に火傷をして手が不自由になったが、手術を受けて全治したことから、医者を志すようになった。\nこの人物は誰？"
                         ,"1901年66歳で生涯を閉じた日本の蘭学者、啓蒙思想家、教育者。\nこの人物は誰？"
                         ,""};

    /// <summary>問題の答え</summary>
    string[] _clearText = { "織田信長", "明智光秀","豊臣秀吉","真田幸村", "武田信玄", "毛利元就", "今川義元", "伊達政宗","徳川家康","上杉謙信","野口英世","福沢諭吉",""};

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
                    _statusManager.PlusNationa(2);
                }
                break;
            case "明智光秀":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa(2);
                }
                break;
            case "豊臣秀吉":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa(2);
                }
                break;
            case "真田幸村":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa(2);
                }
                break;
            case "武田信玄":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa(2);
                }
                break;
            case "毛利元就":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa(2);
                }
                break;
            case "今川義元":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa(2);
                }
                break;
            case "伊達政宗":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa(2);
                }
                break;
            case "徳川家康":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa(2);
                }
                break;
            case "上杉謙信":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa(2);
                }
                break;
            case "野口英世":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa(2);
                }
                break;
            case "福沢諭吉":                
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa(2);
                }
                break;
            case "殲滅":
                if (_clearText[_iD] == _answerText.text)
                {
                    Next();
                    _clearNum += 1;
                    _statusManager.PlusNationa(2);
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
