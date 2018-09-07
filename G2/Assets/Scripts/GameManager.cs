using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	private static int level = 0;
	public float totalTime, levelTime = 0f;
	public int totalGameOvers = 0, levelGameOvers = 0;
	public AudioClip DefaultSong, VictorySong;
	public AudioSource MusicPlayer;
	public GameObject MagIcon, CrioIcon, BioIcon;
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

	private void Start() {
		
		MusicPlayer.clip = DefaultSong;
		MusicPlayer.Play();
	}
	
	public void NextLevel()
	{
		Time.timeScale = 0f;
		MusicPlayer.Stop();
		MusicPlayer.clip = VictorySong;
		MusicPlayer.Play();

		timer.StopTimer();
		totalTime += levelTime;
		totalGameOvers += levelGameOvers;

		NextStageScreen.transform.GetChild(0).GetComponent<Text>().text = string.Format("{0:00}:{1:00}", levelTime/60, levelTime % 60);
		NextStageScreen.transform.GetChild(1).GetComponent<Text>().text = levelGameOvers.ToString();

		levelGameOvers = 0;
		
		NextStageScreen.SetActive(true);
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.O))	
			CompletedPuzzles++;
	}

	public void InitGame()
	{
		Time.timeScale = 1f;
		//Debug.Log("This doesnt make any sense at all");
		MagIcon.SetActive(false);
		CrioIcon.SetActive(false);
		BioIcon.SetActive(false);

		MusicPlayer.Stop();
		MusicPlayer.clip = DefaultSong;
		MusicPlayer.Play();

		CompletedPuzzles = 0;
		levelTime = 0;
		timer.StartTimer(testTimeLimits[level-1]);
	}

	public void EndGame()
	{
		if(level != 3)
			SceneManager.LoadScene("Nivel" + ++level);
		else
			GameOver(EndCondition.Victory);
	}

	public void EndGame(int nextLevel)
	{
		level = nextLevel;
		SceneManager.LoadScene("Nivel" + nextLevel);
	}

	public void Retry()
	{
		timer.StopTimer();
		EndGame(level);
	}

	public void BackToMenu()
	{
		level = 0;
		totalGameOvers = 0;
		totalTime = 0;
		timer.StopTimer();
		MagIcon.SetActive(false);
		CrioIcon.SetActive(false);
		BioIcon.SetActive(false);
		MusicPlayer.Stop();
		MusicPlayer.clip = DefaultSong;
		MusicPlayer.Play();
		timer.gameObject.SetActive(false);
		SceneManager.LoadScene("Menu_Principal");
	}

	public void GameOver(EndCondition endCondition)
	{
		Time.timeScale = 0f;
		if(endCondition == EndCondition.Victory)
		{
			Text[] info = VictoryScreen.GetComponentsInChildren<Text>();

			info[0].text = string.Format("{0:00}:{1:00}", totalTime/60, totalTime % 60);
			info[1].text = totalGameOvers.ToString();

			totalTime = 0f;
			totalGameOvers = 0;

			VictoryScreen.SetActive(true);
		}
		else if(endCondition == EndCondition.Defeat)
		{
			DefeatScreen.SetActive(true);
			levelGameOvers++;
		}
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
