using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    StatusManager _statusManager;

    ScenarioManager _scenarioManager;

    /// <summary>ボタンクリック</summary>
    public void ButtonA()
    {
        _statusManager.PlusGirlsFriend();
        _scenarioManager.ButtonClick();
    }

    public void ButtonB()
    {
        _statusManager.PlusBoyFriend();
        _scenarioManager.ButtonClick();
    }

    public void ButtonC()
    {
        _statusManager.PlusArcadeFriend();
        _scenarioManager.ButtonClick();
    }

    public void ButtonD()
    {
        _statusManager.PlusCrazy();
        _scenarioManager.ButtonClick();
    }
}
