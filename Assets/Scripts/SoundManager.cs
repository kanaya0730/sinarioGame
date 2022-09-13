using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    /// <summary>AudioSource</summary>
    [SerializeField]
    [Header("AudioSource")]
    AudioSource _audioSource;

    public void Awake() => _audioSource = GetComponent<AudioSource>();

    /// <summary>チャイム音</summary>
    public void ChimeSE(AudioClip clip) => _audioSource.PlayOneShot(clip);

    /// <summary>正解音</summary>
    public void AnswerSE(AudioClip clip) => _audioSource.PlayOneShot(clip);

    /// <summary>クリック音</summary>
    public void ClickSE(AudioClip clip) => _audioSource.PlayOneShot(clip);

}
