// <copyright file="PauseMenu.cs" company="DIS Copenhagen">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>Benno Lueders</author>
// <date>14/08/2017</date>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;


/// <summary>
/// Pause menu script. Provides functionality to Pause and Unpause the game and Go Back to the Main Menu. Controlled by buttons from the Unity UI.
/// Pressing ESC will also open and close the menu.
/// </summary>
public class PauseMenu : MonoBehaviour
{

	private GameObject pauseMenuCanvas;
	private bool running;
	public FirstPersonController firstPersonController;



	void Start()
	{
		pauseMenuCanvas = GameObject.Find("Pause Screen");
		pauseMenuCanvas.SetActive(false);
		running = true;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.RightShift))
		{
			if (running)
			{
				Pause();
			}
			else if (running == false)
			{
				UnPause();
			}
		}
	}

	public void Pause()
	{
		firstPersonController.mouseLookEnabled = false;
		pauseMenuCanvas.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
		Time.timeScale = 0;
		running = false;
	}

	public void UnPause()
	{
		firstPersonController.mouseLookEnabled = true;
		pauseMenuCanvas.SetActive(false);
		Time.timeScale = 1;
		running = true;
	}

	public void GoToMainMenu()
	{
		pauseMenuCanvas.SetActive(false);
		Time.timeScale = 1;
		GameManager.gameState = GameManager.GameState.StartMenu;
		GameManager.LoadScene("Main Menu");
	}

	public void Restart()
	{
		pauseMenuCanvas.SetActive(false);
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void OnClick()
	{
		if (running)
		{
			Pause();
		}
		else if (running == false)
		{
			UnPause();
		}
	}
}
