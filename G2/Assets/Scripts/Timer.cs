using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	Text time;
	public GameObject panel;
	public int currentTime {get; set;}
	private void Awake()
	{
		time = GetComponent<Text>();
	}

	private void OnEnable() {
		panel.SetActive(true);
	}

	private void OnDisable() {
		panel.SetActive(false);
	}
	public void StartTimer(int timeLimit)
	{
		Debug.Log("Start");
		currentTime = timeLimit;
		InvokeRepeating("UpdateTimer", 0f, 1f);
	}

	private void UpdateTimer()
	{
		currentTime--;
		GameManager.instance.levelTime++;

		if(currentTime <= 0)
		{
			GameManager.instance.GameOver(GameManager.EndCondition.Defeat);
			StopTimer();
		}

		time.text = string.Format("{0:00}:{1:00}", currentTime/60, currentTime % 60);
	}

	public void StopTimer()
	{
		CancelInvoke();
	}
}
