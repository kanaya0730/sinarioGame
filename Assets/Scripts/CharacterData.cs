using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(
  fileName = "CharacterData",
  menuName = "ScriptableObject/CharacterData")]
public class CharacterData : ScriptableObject
{
    public List<Characters> CharacterDatas => _characterDatas;

    [SerializeField]
    List<Characters> _characterDatas = new List<Characters>();
}
[System.Serializable]
public class Characters
{
    public string Name => _name;
    public string Gender => _gender;
    public int Old => _old;
    public string Like => _like;
    public string Hate => _hate;
    public string Joy => _joy;
    public string Anger => _anger;
    public string Sad => _sad;
    public string Fun => _fun;

    [SerializeField]
    [Header("名前")]
    string _name = "";

    [Header("性別")]
    [SerializeField]
    string _gender = "";

    [SerializeField]
    [Header("年齢")]
    int _old = 0;

    [SerializeField]
    [Header("好き")]
    string _like = "";

    [SerializeField]
    [Header("嫌い")]
    string _hate = "";

    [SerializeField]
    [Header("喜")]
    string _joy = "";

    [SerializeField]
    [Header("怒")]
    string _anger = "";

    [SerializeField]
    [Header("哀")]
    string _sad = "";

    [SerializeField]
    [Header("楽")]
    string _fun = "";
}
