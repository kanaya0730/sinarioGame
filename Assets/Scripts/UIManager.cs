using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class UIManager : MonoBehaviour
{
    /// <summary>シナリオデータ</summary>
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
    Image[] _character;//[0]主人公,[1]主人公TS,[2]幼馴染男,[3]幼馴染女

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

    string _eventName;

    void Start()
    {
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
        switch (_textID)
        {
            case 1:
                _backGraund[0].gameObject.SetActive(true);
                _character[0].gameObject.SetActive(true);
                break;
            case 2:
                _character[2].gameObject.SetActive(true);
                _character[3].gameObject.SetActive(true);
                break;
            case 5:
                _branchTime = true;
                _eventName = "Branch1";
                break;
            case 17:
                _character[3].gameObject.SetActive(false);
                _character[2].gameObject.SetActive(false);
                _backGraund[0].gameObject.SetActive(false);
                _character[0].gameObject.SetActive(false);
                _backGraund[3].gameObject.SetActive(true);
                break;
            case 18:
                _backGraund[4].gameObject.SetActive(true);
                _backGraund[3].gameObject.SetActive(false);
                break;
            case 22:
                _backGraund[4].gameObject.SetActive(false);
                _eventText.text = "～TS生活：0日目～";
                _backGraund[1].gameObject.SetActive(true);
                _character[1].gameObject.SetActive(true);
                break;
            case 45:
                SceneManager.LoadScene("MainScene");
                break;
        }
    }
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
    public void ButtonA()
    {
        _branchTime = false;
        TextReset();
        Buttonfalse();
        StartCoroutine("Cotext");
    }
    public void ButtonB()
    {
        _branchTime = false;
        TextReset();
        Buttonfalse();
        StartCoroutine("Cotext");
    } 
    public void ButtonC()
    {
        _branchTime = false;
        TextReset();
        Buttonfalse();
        StartCoroutine("Cotext");
    }
}