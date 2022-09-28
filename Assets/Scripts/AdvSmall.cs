using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AdvSmall : MonoBehaviour
{
    [SerializeField]
    Text dialogText;
    [SerializeField]
    TextAsset ScriptTextFile;

    void Start()
    {
        var splitted = ScriptTextFile.text.Replace("\r", "").Split('\n').ToList();
        StartCoroutine(AdvPlay(splitted));
    }
    IEnumerator AdvPlay(List<string> texts)
    {
        foreach(var text in texts)
        {
            dialogText.text = text;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return new WaitForSeconds(0.1f);

        }
    }
}
