using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>シナリオ関連の管理マネージャー</summary>
public class ScenarioManager : MonoBehaviour
{
    StatusManager _statusManager;

    public List<string[]> CsvData => _csvData;

    public int TextID => _textID;

    [SerializeField]
    [Header("分岐")]
    Text[] _branch;

    [SerializeField]
    [Header("選択ボタン")]
    Button[] _button;

    [SerializeField]
    [Header("背景")]
    Image[] _backImage;

    [SerializeField]
    [Header("シナリオデータ")]
    TextAsset _textFail;

    [SerializeField]
    [Header("UITextスクリプト")]
    UIText _uitext;

    /// <summary>[0] = 悠希（男）,[1] = 結城（女）,[2] = 冬馬,[3] = 凜,[4] = 神,[5] = 執事,[6] = メイド,[7] = 晶</summary>
    [SerializeField]
    [Header("登場キャラクター")]
    Image[] _character;

    List<string[]> _csvData = new List<string[]>();//CSVデータの保存場所

    int _textID = 1;

    int[] _lineID = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

    bool _eventTime = false;//条件分岐の確認

    public void LoadCSV()
    {
        _statusManager = FindObjectOfType<StatusManager>();

        StringReader reader = new StringReader(_textFail.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            _csvData.Add(line.Split(','));
        }

        Buttonfalse();
    }

    /// <summary>クリックでテキストを一気に表示</summary>
    IEnumerator Skip()
    {
        while (_uitext.Playing) yield return null;
        while (!_uitext.IsClicked()) yield return null;
    }

    IEnumerator Cotext()
    {
        Debug.Log("現在：" + _textID + "行");

        _uitext.DrawText(_csvData[_textID][_lineID[1]], _csvData[_textID][_lineID[2]]); //(名前,セリフ)
        yield return StartCoroutine(Skip());

        _textID++; //次の行へ

        EventCheck();
    }

    void Update()
    {
        if (_eventTime == true)
        {
            switch (_csvData[_textID][_lineID[7]])
            {
                case "100":
                    for (int i = 0; i < _character.Length; i++)
                    {
                        _character[i].gameObject.SetActive(false);
                    }
                    break;

                case "0"://悠希（男）
                    _character[0].gameObject.SetActive(true);
                    break;

                case "1"://結城（女）
                    _character[1].gameObject.SetActive(true);
                    break;

                case "2"://冬馬
                    _character[2].gameObject.SetActive(true);
                    break;

                case "3"://凜
                    _character[3].gameObject.SetActive(true);
                    break;

                case "4"://神
                    _character[4].gameObject.SetActive(true);
                    break;

                case "5"://執事
                    _character[5].gameObject.SetActive(true);
                    break;

                case "6"://メイド
                    _character[6].gameObject.SetActive(true);
                    break;

                case "7"://晶
                    _character[7].gameObject.SetActive(true);
                    break;
            }
        }

        else
        {
            switch (_csvData[_textID][_lineID[0]])
            {
                case "100":
                    for (int i = 0; i < _character.Length; i++)
                    {
                        _character[i].gameObject.SetActive(false);
                    }
                    break;

                case "0"://悠希（男）
                    _character[0].gameObject.SetActive(true);
                    break;

                case "1"://結城（女）
                    _character[1].gameObject.SetActive(true);
                    break;

                case "2"://冬馬
                    _character[2].gameObject.SetActive(true);
                    break;

                case "3"://凜
                    _character[3].gameObject.SetActive(true);
                    break;

                case "4"://神
                    _character[4].gameObject.SetActive(true);
                    break;

                case "5"://執事
                    _character[5].gameObject.SetActive(true);
                    break;

                case "6"://メイド
                    _character[6].gameObject.SetActive(true);
                    break;

                case "7"://晶
                    _character[7].gameObject.SetActive(true);
                    break;
            }
        }
        
        switch (_csvData[_textID][_lineID[3]])
        {
            case "学校（裏）":
                BackImagefalse();
                _backImage[0].gameObject.SetActive(true);
                break;

            case "学校（門）":
                BackImagefalse();
                _backImage[1].gameObject.SetActive(true);
                break;

            case "学校（昇降口）":
                BackImagefalse();
                _backImage[2].gameObject.SetActive(true);
                break;

            case "学校（教室）":
                BackImagefalse();
                _backImage[3].gameObject.SetActive(true);
                break;

            case "学校（廊下）":
                BackImagefalse();
                _backImage[4].gameObject.SetActive(true);
                break;

            case "学校（踊り場）":
                BackImagefalse();
                _backImage[5].gameObject.SetActive(true);
                break;

            case "通学路（朝）":
                BackImagefalse();
                _backImage[6].gameObject.SetActive(true);
                break;

            case "通学路（夕）":
                BackImagefalse();
                _backImage[7].gameObject.SetActive(true);
                break;

            case "通学路（夜）":
                BackImagefalse();
                _backImage[8].gameObject.SetActive(true);
                break;

            case "女の子の部屋（朝）":
                BackImagefalse();
                _backImage[9].gameObject.SetActive(true);
                break;
            case "女の子の部屋（夕）":
                BackImagefalse();
                _backImage[10].gameObject.SetActive(true);
                break;

            case "女の子の部屋（夜）":
                BackImagefalse();
                _backImage[11].gameObject.SetActive(true);
                break;

            case "男の子の部屋":
                BackImagefalse();
                _backImage[12].gameObject.SetActive(true);
                break;

            case "夜空":
                BackImagefalse();
                _backImage[13].gameObject.SetActive(true);
                break;
        }

        switch(_csvData[_textID][_lineID[4]])
        {
            case "TRUE":
                _eventTime = true;
                EventCheck();
                break;
        }
        if(_eventTime == false)
        {
            switch (_csvData[_textID][_lineID[6]])
            {
                case "MathScene":
                    SceneManager.LoadScene("MathScene");
                    break;

                case "NationalScene":
                    SceneManager.LoadScene("NationalScene");
                    break;
            }

        }
    }

    /// <summary>イベントフラグが立っているか確認</summary>
    public void EventCheck()
    {
        if(_eventTime == false) //イベントフラグが立っていない
        {
            StartCoroutine(Cotext()); //繰り返す
        }

        else //イベントフラグが立っている
        {
            switch (_csvData[_textID][_lineID[5]])
            {
                case "分岐1":
                    for(int i = 0; i < _branch.Length; i++)
                    {
                        _branch[i].text = _csvData[i + 1][_lineID[9]];
                        _button[i].gameObject.SetActive(true);
                    }
                    break;

                case "分岐2":
                    if(_statusManager.Math >= 20)
                    {
                        _statusManager.PlusGirlsFriend(3);
                        _statusManager.PlusBoyFriend(3);
                        _statusManager.PlusArcadeFriend(3);
                        _textID = 59;
                        StartCoroutine(MathText());
                    }

                    else if(_statusManager.Math >= 11 && _statusManager.Math <= 19)
                    {
                        _statusManager.PlusCrazy(2);
                        _textID = 62;
                        StartCoroutine(MathText());
                    }

                    else if(_statusManager.Math >= 0 && _statusManager.Math <= 10)
                    {
                        _statusManager.PlusCrazy(5);
                        _textID = 65;
                        StartCoroutine(MathText());
                    }
                    break;

                case "分岐3":
                    if (_statusManager.National >= 20)
                    {
                        _statusManager.PlusGirlsFriend(3);
                        _statusManager.PlusBoyFriend(3);
                        _statusManager.PlusArcadeFriend(3);
                        _textID = 59;
                        StartCoroutine(NationalText());
                    }

                    if (_statusManager.National >= 11 && _statusManager.National <= 19)
                    {
                        _statusManager.PlusCrazy(2);
                        _textID = 62;
                        StartCoroutine(NationalText());
                    }
                    if (_statusManager.National >= 5 && _statusManager.National <= 10)
                    {
                        _statusManager.PlusCrazy(5);
                        _textID = 65;
                        StartCoroutine(NationalText());
                    }
                    break;
            }
        }
    }

    /// <summary>ボタンUIを非表示</summary>
    public void Buttonfalse()
    {
        for (int i = 0; i < _button.Length; i++)
        {
            _button[i].gameObject.SetActive(false);
        }
    }

    public void BackImagefalse()
    {
        for (int i = 0; i < _backImage.Length; i++)
        {
            _backImage[i].gameObject.SetActive(false);
        }
    }

    /// <summary>ボタンクリック</summary>
    public void ButtonClick()
    {
        _eventTime = false;
        Buttonfalse();
        StartCoroutine(Cotext());
    }

    /// <summary>休み時間のストーリーから</summary>
    public void BreakScene()
    {
        LoadCSV();
        _textID = 59;
        _eventTime = true;
    }

    /// <summary>放課後のストーリーから</summary>
    public void AfterSchoolText()
    {
        LoadCSV();
        _textID = 66;
        StartCoroutine(Cotext());
    }

    /// <summary>最初のストーリーから</summary>
    public void FirstText()
    {
        LoadCSV();
        StartCoroutine(Cotext());
    }

    public void ButtonA()
    {
        _statusManager.PlusGirlsFriend(4);
        ButtonClick();
    }

    public void ButtonB()
    {
        _statusManager.PlusBoyFriend(4);
        ButtonClick();
    }

    public void ButtonC()
    {
        _statusManager.PlusArcadeFriend(4);
        ButtonClick();
    }

    public void ButtonD()
    {
        _statusManager.PlusCrazy(4);
        ButtonClick();
    }

    IEnumerator MathText()
    {
        _uitext.DrawText(_csvData[_textID][_lineID[8]], _csvData[_textID][_lineID[9]]); //(名前,セリフ)
        yield return StartCoroutine(Skip());
        _textID++; //次の行へ

        if(_textID == 61 || _textID == 64 || _textID == 67 && _eventTime == true)
        {
            _textID = 60;
            _eventTime = false;
            StartCoroutine(Cotext());
        }

        else
        {
            StartCoroutine(MathText());
        }
    }

    IEnumerator NationalText()
    {
        _uitext.DrawText(_csvData[_textID][_lineID[8]], _csvData[_textID][_lineID[9]]); //(名前,セリフ)
        yield return StartCoroutine(Skip());
        _textID++; //次の行へ

        if (_textID == 61 || _textID == 64 || _textID == 67 && _eventTime == true)
        {
            _textID = 66;
            _eventTime = false;
            StartCoroutine(Cotext());
        }

        else
        {
            StartCoroutine(NationalText());
        }
    }

}