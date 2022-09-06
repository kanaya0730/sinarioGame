using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>隠しステータス管理</summary>
public class StatusManager : MonoBehaviour
{
    public int National => _national;

    public int Math => _math;

    public int Scienece => _science;

    public int Boyfriend => _boyfriend;

    public int Girlsfriend　=> _girlsfriend;

    public int Arcadefriend => _arcadefriend;

    public static StatusManager instance = null;

    /// <summary>冬馬の好感度</summary>
    [SerializeField]
    [Header("冬馬の好感度")]
    int _boyfriend = 0;

    /// <summary>凜の好感度</summary>
    [SerializeField]
    [Header("凜の好感度")]
    int _girlsfriend = 0;

    /// <summary>晶の好感度</summary>
    [SerializeField]
    [Header("晶の好感度")]
    int _arcadefriend = 0;

    /// <summary>神の好感度</summary>
    [SerializeField]
    [Header("クレイジー")]
    int _crazy = 0;

    /// <summary>国語の合計正解数</summary>
    [SerializeField]
    [Header("国語")]
    int _national = 0;

    /// <summary>数学の合計正解数</summary>
    [SerializeField]
    [Header("数学")]
    int _math = 0;

    /// <summary>科学の合計正解数</summary>
    [SerializeField]
    [Header("科学")]
    int _science = 0;

    /// <summary>社会の合計正解数</summary>
    [SerializeField]
    [Header("歴史")]
    int _history = 0;

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
        _crazy += 1;
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
