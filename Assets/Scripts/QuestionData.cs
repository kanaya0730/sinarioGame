using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
  fileName = "QuestionData",
  menuName = "ScriptableObject/QuestionData")]
public class QuestionData : ScriptableObject
{
    public List<Questions> QuestionDatas => _questionDatas;
    public string Subject => _subject;

    [SerializeField]
    [Header("教科")]
    string _subject = "";

    [SerializeField]
    List<Questions> _questionDatas = new List<Questions>();
}

[System.Serializable]
public class Questions
{
    public string Question => _question;
    public string Answer => _answer;

    [SerializeField]
    [Header("問題")]
    string _question = "";

    [Header("回答")]
    [SerializeField] 
    string _answer = "";
}
