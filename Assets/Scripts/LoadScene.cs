using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>SceneLoader</summary>
public class LoadScene : MonoBehaviour
{
    public void StartGame(string SceneName) => SceneManager.LoadScene(SceneName);
}
