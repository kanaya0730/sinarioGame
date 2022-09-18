using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCredit : MonoBehaviour
{
    [SerializeField]
    GameObject _panel;

    [SerializeField]
    GameObject _sound;

    [SerializeField]
    Animator _animation;

    bool _nowPanel;
    void Update()
    {
        if (_nowPanel == true)
        {
            _sound.SetActive(true);
            PlayAnim();
        }
    }
    public void PlayAnim()
    {
        _animation.Play("credit");
    }
    public void OpenCreditPanel()
    {
        _nowPanel = true;
        _panel.SetActive(true);
    }
    public void CloseCreditpanel()
    {
        _nowPanel = false;
        _panel.SetActive(false);
        _sound.SetActive(false);
    }
}
