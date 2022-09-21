using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PrologueScene : MonoBehaviour
{
    SoundManager _soundManager;

    FadeController _fadeController;

    [SerializeField]
    [Header("シナリオデータ")]
    TextAsset _textFail;

    [SerializeField]
    [Header("UITextスクリプト")]
    UIText _uitext;

    List<string[]> _csvData = new List<string[]>();//CSVデータの保存場所

    int _textID = 1;

    int[] _lineID = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

    void Awake()
    {
        _soundManager = FindObjectOfType<SoundManager>();

        _fadeController = FindObjectOfType<FadeController>();

        LoadCSV();

        StartCoroutine(Cotext());
    }
    void Update()
    {
        if(_textID == 27)
        {
            StartCoroutine(ChangeScene());
        }
    }
    public void LoadCSV()
    {
        StringReader reader = new StringReader(_textFail.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            _csvData.Add(line.Split(','));
        }
    }

    IEnumerator Cotext()
    {
        Debug.Log("現在：" + _textID + "行");//現在出力している行数の表示

        _uitext.DrawText(_csvData[_textID][_lineID[0]], _csvData[_textID][_lineID[1]]); //(名前,セリフ)
        yield return new WaitForSeconds(5);//五秒待機
        _textID++; //次の行へ

        StartCoroutine(Cotext());
    }

    IEnumerator ChangeScene()
    {
        _fadeController.StartFadeOut();
        yield return new WaitForSeconds(3);//三秒待機
        SceneManager.LoadScene("FirstScene");
    }
}
