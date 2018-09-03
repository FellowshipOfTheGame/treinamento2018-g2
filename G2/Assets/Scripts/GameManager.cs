using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	private static int level = 1;
	public float totalTime = 0f;
	public int totalDeaths = 0, totalGameOvers = 0;

	private int completedPuzzles;
	public int CompletedPuzzles
	{
		get { return completedPuzzles; } 
		set {
				completedPuzzles = value;
				if(completedPuzzles >= 3)
					Destroy(ElevatorDoor);
			}
	}

	public GameObject ElevatorDoor, DefeatScreen, NextStageScreen, VictoryScreen;
	public enum EndCondition {Victory, Defeat};
	public Timer timer;
	private int[] testTimeLimits = new int[3] {300, 420, 600};

	private void Awake()
	{
		if(instance == null)
			instance = this;
		else if(instance != this)
		{
			Destroy(gameObject);
			Destroy(this);
		}

		DontDestroyOnLoad(gameObject);
		Debug.Log("Run");
		//InitGame();
	}

	public void NextLevel()
	{
		//Time.timeScale = 0f;
		timer.StopTimer();
		NextStageScreen.SetActive(true);
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.O))	
			CompletedPuzzles++;
	}

	public void InitGame()
	{
		//Time.timeScale = 1f;
		Debug.Log("This doesnt make any sense at all");
		CompletedPuzzles = 0;
		timer.StartTimer(testTimeLimits[level-1]);
	}

	public void EndGame()
	{
		if(level != 3)
			SceneManager.LoadScene("Nivel" + ++level);
		else
			GameOver(EndCondition.Victory);
	}

	void EndGame(int nextLevel)
	{
		SceneManager.LoadScene("Nivel" + nextLevel);
	}

	public void Retry()
	{
		EndGame(level);
	}

	public void GameOver(EndCondition endCondition)
	{
		//Time.timeScale = 0f;
		if(endCondition == EndCondition.Victory)
		{
			Text[] info = VictoryScreen.GetComponentsInChildren<Text>();

			info[0].text = totalTime.ToString();
			info[1].text = totalDeaths.ToString(); 
			info[2].text = totalGameOvers.ToString();

			totalTime = 0f;
			totalDeaths = 0;
			totalGameOvers = 0;

			VictoryScreen.SetActive(true);
		}
		else if(endCondition == EndCondition.Defeat)
		{
			DefeatScreen.SetActive(true);
		}
	}

}
