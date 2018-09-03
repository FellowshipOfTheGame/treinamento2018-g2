using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {

	[SerializeField] EventSystem eventSystem;
	[SerializeField] GameObject selectedObject;

	private void Start()
	{
		eventSystem.SetSelectedGameObject(selectedObject);
	}
}
