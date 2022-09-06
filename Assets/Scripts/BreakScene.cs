﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakScene : MonoBehaviour
{
    ScenarioManager _scenarioManager;
    private void Start() => _scenarioManager.BreakScene();
    private void Awake() => _scenarioManager = FindObjectOfType<ScenarioManager>();
}
