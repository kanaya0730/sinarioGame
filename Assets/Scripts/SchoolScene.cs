using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolScene : MonoBehaviour
{
    ScenarioManager _scenarioManager;
    void Start() => _scenarioManager.SchoolText();
    private void Awake() => _scenarioManager = FindObjectOfType<ScenarioManager>();
}
