using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	[SerializeField] private Camera UnifiedCamera, Cam1, Cam2, BiomolCam;
	public Camera[] fixedCameras, fixedHalfCameras;
	[SerializeField] private GameObject Player1, Player2;
	private Vector3 Cam1Pos, Cam2Pos, UniCamPos, P1ScreenPos, P2ScreenPos;
	public static bool isBiomolDone = false;

	void Update()
	{
		Cam1Pos = Cam1.transform.position;
		Cam2Pos = Cam2.transform.position;
	    UniCamPos = Cam2Pos + (Cam1Pos - Cam2Pos)/2;
		UnifiedCamera.transform.position = UniCamPos;

		if(Player1.transform.position.x > Player2.transform.position.x)
		{
			Cam1.rect = new Rect(0.5f, 0, 0.5f, 1f);
			Cam2.rect = new Rect(0, 0, 0.5f, 1f);
		}
		else
		{
			Cam1.rect = new Rect(0, 0, 0.5f, 1f);
			Cam2.rect = new Rect(0.5f, 0, 0.5f, 1f);
		}


		P1ScreenPos = UnifiedCamera.WorldToViewportPoint(Player1.transform.position);
		P2ScreenPos = UnifiedCamera.WorldToViewportPoint(Player2.transform.position);

		if((P1ScreenPos.x >= 0 && P1ScreenPos.x <= 1) && (P1ScreenPos.y >= 0 && P1ScreenPos.y <= 1) &&
		(P2ScreenPos.x >= 0 && P2ScreenPos.x <= 1) && (P2ScreenPos.y >= 0 && P2ScreenPos.y <= 1))
			UnifiedCamera.enabled = true;
		else
			UnifiedCamera.enabled = false;

		foreach(var camera in fixedCameras)
		{
			P1ScreenPos = camera.WorldToViewportPoint(Player1.transform.position);
			P2ScreenPos = camera.WorldToViewportPoint(Player2.transform.position);

			if((P1ScreenPos.x >= 0 && P1ScreenPos.x <= 1) && (P1ScreenPos.y >= 0 && P1ScreenPos.y <= 1)
			&& (P2ScreenPos.x >= 0 && P2ScreenPos.x <= 1) && (P2ScreenPos.y >= 0 && P2ScreenPos.y <= 1))
				camera.enabled = true;
			else
				camera.enabled = false;
		}

		foreach(var camera in fixedHalfCameras)
		{
			P1ScreenPos = camera.WorldToViewportPoint(Player1.transform.position);
			P2ScreenPos = camera.WorldToViewportPoint(Player2.transform.position);

			bool isP1OnCamera = (P1ScreenPos.x >= 0.1 && P1ScreenPos.x <= 0.9) && (P1ScreenPos.y >= 0.1 && P1ScreenPos.y <= 0.9);
			bool isP2OnCamera = (P2ScreenPos.x >= 0.1 && P2ScreenPos.x <= 0.9) && (P2ScreenPos.y >= 0.1 && P2ScreenPos.y <= 0.9);

			GameObject PlayerOnLeft;

			if(Player1.transform.position.x >= Player2.transform.position.x)
				PlayerOnLeft = Player2;
			else
				PlayerOnLeft = Player1;

			if(!(isP1OnCamera && isP2OnCamera))
			{
				if(isP1OnCamera)
				{
					if(PlayerOnLeft == Player1)
						camera.rect = new Rect(0, 0, 0.5f, 1);
					else
						camera.rect = new Rect(0.5f, 0, 0.5f, 1);

					camera.enabled = true;
					UnifiedCamera.enabled = false;
				}
				else if(isP2OnCamera)
				{
					if(PlayerOnLeft == Player2)
						camera.rect = new Rect(0, 0, 0.5f, 1);
					else
						camera.rect = new Rect(0.5f, 0, 0.5f, 1);
				
					camera.enabled = true;
					UnifiedCamera.enabled = false;
				}
				else
					camera.enabled = false;
			}
			else
				camera.enabled = false;
		}

		if(BiomolCam.enabled)
		{
			P1ScreenPos = BiomolCam.WorldToViewportPoint(Player1.transform.position);
			P2ScreenPos = BiomolCam.WorldToViewportPoint(Player2.transform.position);

			bool isP1OnCamera = (P1ScreenPos.x >= 0 && P1ScreenPos.x <= 1) && (P1ScreenPos.y >= 0 && P1ScreenPos.y <= 1);
			bool isP2OnCamera = (P2ScreenPos.x >= 0 && P2ScreenPos.x <= 1) && (P2ScreenPos.y >= 0 && P2ScreenPos.y <= 1);

			if(!isP1OnCamera || !isP2OnCamera)
				BiomolCam.depth = -2;
			else if(isP1OnCamera && isP2OnCamera)
				BiomolCam.depth = 3;

			if(isBiomolDone)
			{
				if(!isP1OnCamera && !isP2OnCamera)
					BiomolCam.enabled = false;
			}
		}
	}

}
