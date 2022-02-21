using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{

	Vector3 mouse;
	Vector3 mouse3d;

	void Update()
	{
		// カーソル非表示
		Cursor.visible = false;


		mouse = Input.mousePosition;
		mouse.z = 85f;
		mouse3d = Camera.main.ScreenToWorldPoint(mouse);
		Debug.Log(mouse);
		Debug.Log(mouse3d);
		transform.position = mouse3d;
	}
}