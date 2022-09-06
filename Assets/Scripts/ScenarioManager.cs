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

    /// <summary>現在のイベント</summary>
    [SerializeField]
    [Header("現在のイベント")]
    Text _eventText;

    List<string[]> _csvData = new List<string[]>();//CSVデータの保存場所

    int _textID = 1;

    bool _eventTime = false;//条件分岐の確認

    string _eventName;//現在のイベント

    public static ScenarioManager instance = null;

    void Start()
    {
        _statusManager = FindObjectOfType<StatusManager>();

        StringReader reader = new StringReader(_textFail.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            _csvData.Add(line.Split(','));
        }

        _eventText.text = "～オープニング～";
        Buttonfalse();
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
        _uitext.DrawText(_csvData[_textID][1], _csvData[_textID][2]); //(名前,セリフ)
        yield return StartCoroutine(Skip());
        _textID++; //次の行へ
        EventCheck();

        yield return new WaitForSeconds(4);
    }
    void Update()
    {
        switch(_csvData[_textID][0])
        {
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
        
        switch (_csvData[_textID][3])
        {
            case "学校（裏）":
                _backImage[0].gameObject.SetActive(true);
                break;

            case "学校（門）":
                _backImage[1].gameObject.SetActive(true);
                break;

            case "学校（昇降口）":
                _backImage[2].gameObject.SetActive(true);
                break;

            case "学校（教室）":
                _backImage[3].gameObject.SetActive(true);
                break;

            case "学校（廊下）":
                _backImage[4].gameObject.SetActive(true);
                break;

            case "学校（踊り場）":
                _backImage[5].gameObject.SetActive(true);
                break;

            case "通学路（朝）":
                _backImage[6].gameObject.SetActive(true);
                break;

            case "通学路（夕）":
                _backImage[7].gameObject.SetActive(true);
                break;

            case "通学路（夜）":
                _backImage[8].gameObject.SetActive(true);
                break;

            case "女の子の部屋（朝）":
                _backImage[9].gameObject.SetActive(true);
                break;
            case "女の子の部屋（夕）":
                _backImage[10].gameObject.SetActive(true);
                break;

            case "女の子の部屋（夜）":
                _backImage[11].gameObject.SetActive(true);
                break;

            case "男の子の部屋":
                _backImage[12].gameObject.SetActive(true);
                break;

            case "夜空":
                _backImage[13].gameObject.SetActive(true);
                break;
        }
        switch (_textID += 1)
        {
            case 59:
                SceneManager.LoadScene("MathScene");
                break;
        }

    }

    /// <summary>イベントフラグが立っているか確認</summary>
    public void EventCheck()
    {
        if(_eventTime == false)//イベントフラグが立っていない
        {
            StartCoroutine(Cotext()); //繰り返す
        }

        else//イベントフラグが立っている
        {
            switch (_csvData[_textID][4])
            {
                case "1":
                    for(int i = 0; i > _branch.Length; i++)
                    {
                        _branch[i].text = _csvData[i += 1][6];
                        _button[i].gameObject.SetActive(true);
                    }
                    break;

                case "2":
                    if(_statusManager.Math >= 20)
                    {
                        _textID = 58;
                        MathText();
                    }

                    if(_statusManager.Math >= 11 && _statusManager.Math <= 19)
                    {
                        _textID = 61;
                        MathText();
                    }
                    if(_statusManager.Math >= 5 && _statusManager.Math <= 10)
                    {
                        _textID = 64;
                        MathText();
                    }
                    break;
                case "3":
                    if (_statusManager.National >= 20)
                    {
                        _textID = 58;
                        NationalText();
                    }

                    if (_statusManager.National >= 11 && _statusManager.National <= 19)
                    {
                        _textID = 61;
                        NationalText();
                    }
                    if (_statusManager.National >= 5 && _statusManager.National <= 10)
                    {
                        _textID = 64;
                        NationalText();
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

    /// <summary>ボタンクリック</summary>
    public void ButtonClick()
    {
        _eventTime = false;
        Buttonfalse();
        StartCoroutine("Cotext");
    }

    /// <summary>休み時間のストーリーから</summary>
    public void BreakScene()
    {
        _textID = 58;
        _eventTime = true;
    }

    /// <summary>放課後のストーリーから</summary>
    public void AfterSchoolText()
    {
        _textID = 64;
        _eventTime = true;
    }

    public void ButtonA()
    {
        _statusManager.PlusGirlsFriend();
        ButtonClick();
    }

    public void ButtonB()
    {
        _statusManager.PlusBoyFriend();
        ButtonClick();
    }

    public void ButtonC()
    {
        _statusManager.PlusArcadeFriend();
        ButtonClick();
    }

    public void ButtonD()
    {
        _statusManager.PlusCrazy();
        ButtonClick();
    }

    IEnumerator MathText()
    {
        _uitext.DrawText(_csvData[_textID][6], _csvData[_textID][7]); //(名前,セリフ)
        yield return StartCoroutine(Skip());
        _textID++; //次の行へ

        if(_textID == 60 || _textID == 63 || _textID == 66)
        {
            _textID = 59;
            StartCoroutine(Cotext());
        }

        StartCoroutine(MathText());
    }
    IEnumerator NationalText()
    {
        _uitext.DrawText(_csvData[_textID][6], _csvData[_textID][7]); //(名前,セリフ)
        yield return StartCoroutine(Skip());
        _textID++; //次の行へ

        if (_textID == 60 || _textID == 63 || _textID == 66)
        {
            _textID = 65;
            StartCoroutine(Cotext());
        }

        StartCoroutine(NationalText());
    }

}