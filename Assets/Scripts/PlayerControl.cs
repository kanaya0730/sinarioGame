using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public int MoveCount { get => _moveCount; set => _moveCount = value; }

    ScenarioManager _scenarioManager;

    [SerializeField]
    [Header("UITextスクリプト")]
    UIText _uitext;

    /// <summary>シナリオデータ</summary>
    [SerializeField]
    [Header("シナリオデータ")]
    TextAsset _textFail;

    [SerializeField]
    [Header("GameManagerスクリプト")]
    PlayRoulette _playRoulette;

    List<string[]> _csvData = new List<string[]>();//CSVデータの保存場所

    int _moveCount = 0;

    float _speed = 2.5f;

    int ID = 1;

    bool Goal = false;
    void Start()
    {
        _scenarioManager = FindObjectOfType<ScenarioManager>();

        //_textFail = Resources.Load(_fileName) as TextAsset;
        StringReader reader = new StringReader(_textFail.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            _csvData.Add(line.Split(','));
        }
    }
    /// <summary>クリックでテキストを一気に表示</summary>
    IEnumerator Skip()
    {
        while (_uitext.Playing) yield return null;
        while (!_uitext.IsClicked()) yield return null;
    }
    void Update()
    {

        Vector2 position = transform.position;
        if (transform.position.y > 2.7f)
        {
            if (transform.position.x <= 16f)
            {
                if (Input.GetKeyDown(KeyCode.Space) && MoveCount > 0)
                {
                    position.x += _speed;
                    MoveCount--;
                    ChangeRoulette();
                }
            }
            else if (transform.position.y >= 2.7f)
            {
                if (Input.GetKeyDown(KeyCode.Space) && MoveCount > 0)
                {
                    position.y -= _speed;
                    MoveCount--;
                    ChangeRoulette();
                }
            }
        }
        if(transform.position.y >= -7f && transform.position.y <= 2.7f)
        {
            if (transform.position.x >= -15.5f)
            {
                if(Input.GetKeyDown(KeyCode.Space) && MoveCount > 0)
                {
                    position.x -= _speed;
                    MoveCount--;
                    ChangeRoulette();
                }
            }
            else if (transform.position.y >= -7.2f)
            {
                if (Input.GetKeyDown(KeyCode.Space) && MoveCount > 0)
                {
                    position.y -= _speed;
                    MoveCount--;
                    ChangeRoulette();
                }
            }
        }
        if(transform.position.y <= -7.3f)
        {
            if (transform.position.x <= -6f)
            {
                if (Input.GetKeyDown(KeyCode.Space) && MoveCount > 0)
                {
                    position.x += _speed;
                    MoveCount--;
                    ChangeRoulette();
                }
            }
            else if (transform.position.x == -3.5f && Goal == false)
            {
                Goal = true;
                StartCoroutine(Goaltext());
            }
        }
        transform.position = position;
    }
    IEnumerator Goaltext()
    {
        _uitext.DrawText(_csvData[ID][7], _csvData[ID][8]); //(名前,セリフ)
        yield return StartCoroutine(Skip());
        ID++;

        if(ID == 4)
        {
            SceneManager.LoadScene("SecondScene");
        }
        StartCoroutine(Goaltext());
    }
    public void ChangeRoulette()
    {
        _playRoulette.RouletteText.text = MoveCount.ToString();
        if (MoveCount <= 0)
        {
            _playRoulette.ChangeSubCamera();
        }
    }
}
