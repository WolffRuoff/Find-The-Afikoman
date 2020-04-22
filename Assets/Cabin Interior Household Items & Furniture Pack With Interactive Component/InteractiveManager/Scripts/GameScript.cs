using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager
{

	public enum GameState
	{
		StartMenu,
		Running,
		Paused
	}

	public static GameState gameState;

	public static void Pause()
	{

		gameState = GameState.Paused;

	}

	public static void Unpause()
	{
		gameState = GameState.Running;
	}

	public static void Quit()
	{
		Application.Quit();
	}

	public static void LoadScene(string scene)
	{
		SceneManager.LoadScene(scene);
	}

}