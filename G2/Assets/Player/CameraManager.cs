using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	[SerializeField]
	private Camera UnifiedCamera, Cam1, Cam2;
	[SerializeField]
	private GameObject Player1, Player2;
	private Vector3 Cam1Pos, Cam2Pos, UniCamPos, P1ScreenPos, P2ScreenPos;

	void Update()
	{
		Cam1Pos = Cam1.transform.position;
		Cam2Pos = Cam2.transform.position;
	    UniCamPos = Cam2Pos + (Cam1Pos - Cam2Pos)/2;
		UnifiedCamera.transform.position = UniCamPos;

		P1ScreenPos = UnifiedCamera.WorldToViewportPoint(Player1.transform.position);
		P2ScreenPos = UnifiedCamera.WorldToViewportPoint(Player2.transform.position);

		if((P1ScreenPos.x >= 0 && P1ScreenPos.x <= 1) && (P1ScreenPos.y >= 0 && P1ScreenPos.y <= 1) &&
		(P2ScreenPos.x >= 0 && P2ScreenPos.x <= 1) && (P2ScreenPos.y >= 0 && P2ScreenPos.y <= 1))
			UnifiedCamera.enabled = true;
		else
			UnifiedCamera.enabled = false;
	}
}
