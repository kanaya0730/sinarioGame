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

    public static StatusManager instance = null;

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

    /// <summary>t冬馬の好感度を+1</summary>
    public void PlusBoyFriend()
    {
        _boyfriend += 2;
    }

    /// <summary>凜の好感度を+1</summary>
    public void PlusGirlsFriend()
    {
        _girlsfriend += 2;
    }

    /// <summary>晶の好感度を+1</summary>
    public void PlusArcadeFriend()
    {
        _arcadefriend += 2;
    }

    /// <summary>神の好感度を+1</summary>
    public void PlusCrazy()
    {
        _crazy += 2;
    }

    /// <summary>国語を+1</summary>
    public void PlusNationa()
    {
        _national += 1;
    }

    /// <summary>数学を+1</summary>
    public void PlusMath()
    {
        _math += 1;
    }

    /// <summary>科学を+1</summary>
    public void PlusScience()
    {
        _science += 1;
    }

    /// <summary>社会を+1</summary>
    public void PlusHistory()
    {
        _history += 1;
    }
}
