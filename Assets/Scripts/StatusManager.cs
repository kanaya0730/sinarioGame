using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>隠しステータス管理</summary>
public class StatusManager : MonoBehaviour
{
    public float National => _national;

    public float Math => _math;

    public float Scienece => _science;

    public float Boyfriend => _boyfriend;

    public float Girlsfriend　=> _girlsfriend;

    public float Arcadefriend => _arcadefriend;

    public static StatusManager instance = null;//シングルトンを使いましょう

    /// <summary>冬馬の好感度</summary>
    [SerializeField]
    [Header("冬馬の好感度")]
    float _boyfriend = 0f;

    /// <summary>凜の好感度</summary>
    [SerializeField]
    [Header("凜の好感度")]
    float _girlsfriend = 0f;

    /// <summary>晶の好感度</summary>
    [SerializeField]
    [Header("晶の好感度")]
    float _arcadefriend = 0f;

    /// <summary>神の好感度</summary>
    [SerializeField]
    [Header("神の好感度")]
    float _crazy = 0f;

    /// <summary>国語の合計正解数</summary>
    [SerializeField]
    [Header("国語")]
    float _national = 0f;

    /// <summary>数学の合計正解数</summary>
    [SerializeField]
    [Header("数学")]
    float _math = 0f;

    /// <summary>科学の合計正解数</summary>
    [SerializeField]
    [Header("科学")]
    float _science = 0f;

    /// <summary>社会の合計正解数</summary>
    [SerializeField]
    [Header("歴史")]
    float _history = 0f;

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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("現在のステータス：" + "冬馬の好感度" + _boyfriend + "凜の好感度" + _girlsfriend + "晶の好感度" + _arcadefriend + "神の好感度" + _crazy);
            Debug.Log("国語" + _national + "数学" + _math + "科学" + _science + "社会" + _history);
        }
    }

    /// <summary>t冬馬の好感度を+</summary>
    public void PlusBoyFriend(int love)
    {
        _boyfriend += love;
    }

    /// <summary>凜の好感度を+</summary>
    public void PlusGirlsFriend(int love)
    {
        _girlsfriend += love;
    }

    /// <summary>晶の好感度を+</summary>
    public void PlusArcadeFriend(int love)
    {
        _arcadefriend += love;
    }

    /// <summary>神の好感度を+</summary>
    public void PlusCrazy(int love)
    {
        _crazy += love;
    }

    /// <summary>国語を+</summary>
    public void PlusNationa(int national)
    {
        _national += national;
    }

    /// <summary>数学を+</summary>
    public void PlusMath(int math)
    {
        _math += math;
    }

    /// <summary>科学を+</summary>
    public void PlusScience(int science)
    {
        _science += science;
    }

    /// <summary>社会を+</summary>
    public void PlusHistory(int history)
    {
        _history += history;
    }
}
