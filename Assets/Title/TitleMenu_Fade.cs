using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //パネルのイメージを操作するのに必要

public class TitleMenu_Fade : MonoBehaviour
{
	public Text fadeText;                //透明度を変更したいテキスト

	float red, green, blue, alfa;   //色、透明度を管理

	public bool isFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ

	

	public float fadeSpeed = 0.005f;        //透明度が変わるスピードを管理

	public float span = 3f;   //開始時間
	public float range = 10f;  //終了時間

	public float alfaRange = 160;   //透明度が変わる制限値
	
	private float T;   //タイマー

	void Start()
	{
		fadeText = GetComponent<Text>();
		
		red = fadeText.color.r;
		green = fadeText.color.g;
		blue = fadeText.color.b;
		alfa = fadeText.color.a;
	}


	void Update()
	{
		T += Time.deltaTime;

		if (T > span && T < range && isFadeOut && alfa <= alfaRange)
		{
			StartFadeOut();
		}
	}


	void StartFadeOut()
	{
		fadeText.enabled = true;  // a)パネルの表示をオンにする
		alfa += fadeSpeed;         // b)不透明度を徐々にあげる
		SetAlpha();               // c)変更した透明度をパネルに反映する
		if (alfa == 160)
		{             // 処理を抜ける
			isFadeOut = false;
		}
	}

	void SetAlpha()
	{
		fadeText.color = new Color(red, green, blue, alfa);
	}
}