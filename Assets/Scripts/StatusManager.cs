using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>隠しステータス管理</summary>
public class StatusManager : MonoBehaviour
{
    public int Love => _love;

    public int Smart => _smart;

    public int Cute => _cute;

    public int Cool => _cool;

    public static StatusManager instance = null;

    /// <summary>好感度</summary>
    [SerializeField]
    [Header("好感度")]
    int _love = 0;

    /// <summary>賢さ</summary>
    [SerializeField]
    [Header("賢さ")]
    int _smart = 0;

    /// <summary>可愛さ</summary>
    [SerializeField]
    [Header("可愛さ")]
    int _cute = 0;

    /// <summary>カッコ良さ</summary>
    [SerializeField]
    [Header("カッコ良さ")]
    int _cool = 0;

    /// <summary>クレイジー</summary>
    [SerializeField]
    [Header("クレイジー")]
    int _crazy = 0;
    /// <summary>ビルド時に呼ばれる</summary>
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void PlusLove()
    {
        _love += 1;
    }

    public void PlusSmart()
    {
        _smart += 1;
    }

    public void PlusCute()
    {
        _cute += 1;
    }
    public void PlusCool()
    {
        _cool += 1;
    }
    public void PlusCrazy()
    {
        _crazy += 1;
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(Love + "," + Smart + "," + Cute + "," + Cool);
        }
    }
}
