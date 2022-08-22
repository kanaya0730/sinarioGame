using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text RouletteText => _rouletteText;

    [SerializeField]
    [Header("Rouletteスクリプト")]
    RouletteManager _roulette;

    [SerializeField]
    Camera _subCamera;

    [SerializeField]
    Camera _mainCamera;

    [SerializeField]
    Text _rouletteText;

    void Start()
    {
        ChangeSubCamera();
        _roulette.StartSpin();
    }

    public void ChangeMainCamera()
    {
        _subCamera.gameObject.SetActive(false);
        _mainCamera.gameObject.SetActive(true);
        _roulette.StartSpin();
    }
    public void ChangeSubCamera()
    {
        _mainCamera.gameObject.SetActive(false);
        _subCamera.gameObject.SetActive(true);
    }
}
