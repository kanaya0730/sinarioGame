using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterScene : MonoBehaviour
{
    ScenarioManager _scenarioManager;
    private void Awake()
    {
        _scenarioManager = FindObjectOfType<ScenarioManager>();
        _scenarioManager.AfterSchoolText();
    }
}
