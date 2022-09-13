using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//パネルのイメージを操作するのに必要

public class FadeController : MonoBehaviour
{
	public bool IsFadeIn => _isFadeIn;
	public bool IsFadeOut => _isFadeOut;

	[SerializeField]
	float _fadeSpeed = 0.02f;  
	//透明度が変わるスピードを管理
	float red, green, blue, alfa;   //パネルの色、不透明度を管理

	[SerializeField]
	bool _isFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ
	[SerializeField]
	bool _isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ

	Image _fadeImage;                //透明度を変更するパネルのイメージ

    void Start()
	{
		_fadeImage = GetComponent<Image>();
		red = _fadeImage.color.r;
		green = _fadeImage.color.g;
		blue = _fadeImage.color.b;
		alfa = _fadeImage.color.a;
	}

	void Update()
	{
		if (_isFadeIn)
		{
			StartFadeIn();
		}

		if (_isFadeOut)
		{
			StartFadeOut();
		}
	}

	public void StartFadeIn()
	{
		alfa -= _fadeSpeed;                //a)不透明度を徐々に下げる
		SetAlpha();                      //b)変更した不透明度パネルに反映する
		if (alfa <= 0)
		{                    //c)完全に透明になったら処理を抜ける
			_isFadeIn = false;
			_fadeImage.enabled = false;    //d)パネルの表示をオフにする
		}
	}

	public void StartFadeOut()
	{
		_fadeImage.enabled = true;  // a)パネルの表示をオンにする
		alfa += _fadeSpeed;         // b)不透明度を徐々にあげる
		SetAlpha();               // c)変更した透明度をパネルに反映する
		if (alfa >= 1)
		{             // d)完全に不透明になったら処理を抜ける
			_isFadeOut = false;
		}
	}

	public void SetAlpha()
	{
		_fadeImage.color = new Color(red, green, blue, alfa);
	}
}