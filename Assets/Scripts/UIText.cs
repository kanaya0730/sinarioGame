using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIText : MonoBehaviour
{
    public bool Playing => _playing;

    /// <summary>喋っている人の名前</summary>
    [SerializeField]
    [Header("喋っている人の名前")]
    Text nameText;

    /// <summary>喋っている内容やナレーション</summary>
    [SerializeField]
    [Header("喋っている内容やナレーション")]
    Text talkText;

    /// <summary>テキストエフェクト</summary>
    [SerializeField]
    [Header("テキストエフェクト")]
    GameObject triangle;

    bool _playing = false;

    /// <summary>テキストの表示速度</summary>
    float textSpeed = 0.1f;

    void Update()
    {
        switch(_playing)
        {
            case true:
                triangle.SetActive(false);
                break;

            case false:
                triangle.SetActive(true);
                break;
        }
    }
    /// <summary>クリックで次のページを表示させる</summary>
    public bool IsClicked()
    {
        if (Input.GetMouseButtonDown(0)) return true;
        return false;
    }
    public void DrawText(string name, string text)
    {
        nameText.text = name;
        StartCoroutine(CoDrawText(text));
    }
    /// <summary>テキストがヌルヌル出てくるためのコルーチン</summary>
    IEnumerator CoDrawText(string text)
    {
        _playing = true;
        float time = 0;
        while (true)
        {
            yield return null;
            time += Time.deltaTime;

            // クリックされると一気に表示
            if (IsClicked()) break;

            int len = Mathf.FloorToInt(time / textSpeed);
            if (len > text.Length) break;
            talkText.text = text.Substring(0, len);
        }
        talkText.text = text;
        yield return null;
        _playing = false;
    }
}
