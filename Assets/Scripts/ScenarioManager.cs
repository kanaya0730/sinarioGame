using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>シナリオ管理</summary>
public class ScenarioManager : MonoBehaviour
{
    StatusManager _statusManager;

    [SerializeField]
    [Header("シナリオデータ")]
    TextAsset _textFail;

    [SerializeField]
    [Header("UITextスクリプト")]
    UIText _uitext;

    [SerializeField]
    [Header("分岐")]
    Text[] _branch;

    [SerializeField]
    [Header("登場キャラクター")]
    Image[] _character;

    [SerializeField]
    [Header("背景")]
    Image[] _backGraund;

    /// <summary>現在のイベント</summary>
    [SerializeField]
    [Header("現在のイベント")]
    Text _eventText;

    [SerializeField]
    [Header("選択ボタン")]
    Button[] _button;

    List<string[]> _csvData = new List<string[]>();//CSVデータの保存場所

    int _textID = 1;

    bool _branchTime;//条件分岐の確認

    string _eventName;//現在のイベント

    void Start()
    {
        _statusManager = FindObjectOfType<StatusManager>();
        //_textFail = Resources.Load(_fileName) as TextAsset;
        StringReader reader = new StringReader(_textFail.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            _csvData.Add(line.Split(','));
        }

        _eventText.text = "～オープニング～";
        Buttonfalse();
        TextReset();
        StartCoroutine(Cotext());
    }
    /// <summary>クリックでテキストを一気に表示</summary>
    IEnumerator Skip()
    {
        while (_uitext.Playing) yield return null;
        while (!_uitext.IsClicked()) yield return null;
    }

    IEnumerator Cotext()
    {
        _uitext.DrawText(_csvData[_textID][0], _csvData[_textID][1]); //(名前,セリフ)
        yield return StartCoroutine(Skip());
        _textID++; //次の行へ
        TextCheck();
    }
    public void Buttonfalse()
    {
        for (int i = 0; i < _button.Length; i++) //ボタンテキストの消去
        {
            _button[i].gameObject.SetActive(false);
        }
    }
    public void TextReset()
    {
        for (int i = 0; i < _branch.Length; i++) //ボタンテキストの消去
        {
            _branch[i].text = "";
        }
    }
    void Update()
    {
        switch(_csvData[_textID][0])
        {
            case "悠希(ゆうき)":
                _character[0].gameObject.SetActive(true);
                break;
            case "悠希":
                _character[1].gameObject.SetActive(true);
                break;
            case "冬馬":
                _character[2].gameObject.SetActive(true);
                break;
            case "凜":
                _character[3].gameObject.SetActive(true);
                break;
        }

        switch (_textID)
        {
            case 1:
                _backGraund[0].gameObject.SetActive(true);
                break;

            case 5:
                _branchTime = true;
                _eventName = "Branch1";
                break;

            case 17:
                _backGraund[0].gameObject.SetActive(false);
                _backGraund[3].gameObject.SetActive(true);
                for (int i = 0; i < 4; i++)
                {
                    _character[i].gameObject.SetActive(false);
                }
                break;

            case 18:
                _backGraund[3].gameObject.SetActive(false);
                _backGraund[4].gameObject.SetActive(true);
                break;

            case 22:
                _backGraund[4].gameObject.SetActive(false);
                _eventText.text = "～日常？～";
                _backGraund[1].gameObject.SetActive(true);
                break;

            case 45:
                _backGraund[1].gameObject.SetActive(false);
                _backGraund[7].gameObject.SetActive(true);
                break;

            case 46:
                _backGraund[9].gameObject.SetActive(true);
                break;

            case 49:
                _backGraund[7].gameObject.SetActive(false);
                _backGraund[9].gameObject.SetActive(false);
                _backGraund[8].gameObject.SetActive(true);
                //チャイム音
                break;

            case 53:
                //ミニゲーム
                _branchTime = true;
                SceneManager.LoadScene("MathScene");
                break;

            case 54:
                _backGraund[9].gameObject.SetActive(true);
                break;

            case 65:
                _branchTime = true;
                SceneManager.LoadScene("NationalScene");
                break;

            case 66:
                _eventText.text = "～放課後～";
                break;
            case 72:
                for (int i = 0; i < 4; i++)
                {
                    _character[i].gameObject.SetActive(false);
                }
                break;
        }
    }

    /// <summary>イベントフラグが立っているか確認</summary>
    public void TextCheck()
    {
        if(_branchTime == false)
        {
            StartCoroutine(Cotext()); //繰り返す
        }
        else
        {
            switch (_eventName)
            {
                case "Branch1":
                    _button[0].gameObject.SetActive(true);
                    _button[1].gameObject.SetActive(true);
                    _button[2].gameObject.SetActive(true);
                    _branch[0].text = _csvData[1][2];
                    _branch[1].text = _csvData[2][2];
                    _branch[2].text = _csvData[3][2];
                    break;
            }
        }
    }
    /// <summary>ボタンクリック</summary>
    public void Button()
    {
        ButtonClick();
    }
    public void ButtonClick()
    {
        _branchTime = false;
        TextReset();
        Buttonfalse();
        StartCoroutine("Cotext");
    }
    /// <summary>休み時間のストーリーから</summary>
    public void BreakText()
    {
        _textID = 54;
        _branchTime = false;
        StartCoroutine("Cotext");
    }

    /// <summary>放課後のストーリーから</summary>
    public void AfterSchoolText()
    {
        _textID = 66;
        _branchTime = false;
        StartCoroutine("Cotext");
    }
}