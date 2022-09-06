using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundManager : MonoBehaviour
{
    ScenarioManager _scenarioManager;

    public static BackGroundManager instance = null;

    [SerializeField]
    [Header("背景")]
    Image[] _backImage;

    private void Start()
    {
        BackImagefalse();
        _scenarioManager = FindObjectOfType<ScenarioManager>();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        switch(_scenarioManager.CsvData[_scenarioManager.TextID][3])
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

            case "通学路（夕）":

                _backImage[6].gameObject.SetActive(true);

                break;

            case "通学路（夜）":

                _backImage[7].gameObject.SetActive(true);

                break;

            case "女の子の部屋":

                _backImage[8].gameObject.SetActive(true);

                break;

            case "男の子の部屋":

                _backImage[9].gameObject.SetActive(true);

                break;

            case "夜空":

                _backImage[10].gameObject.SetActive(true);

                break;
        }

    }

    public void BackImagefalse()
    {
        for (int i = 0; i < _backImage.Length; i++) //ボタンテキストの消去
        {
            _backImage[i].gameObject.SetActive(false);
        }
    }
}
