using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour 
{
	//This script controls all of the menu buttons.
	// Using the inspector, string gameLevel will be assigned to a Scene

	//1 - On a scene create an empty object ,eg MenuObj, and drag this script to it.
	//2 - Afterwards assign the MenuObj to a button's onClick() event
	//3 - Select the correct MenuController.<BUTTON HERE> from the drop down
	//4 - Enter a scene value to switch to in the string gameLevel text field.

	//Play Button
	public void NewGameButton(string gameLevel)
	{
		SceneManager.LoadScene(gameLevel);
	}
	//Credits Button
	public void CreditsButton(string gameLevel)
	{
		SceneManager.LoadScene(gameLevel);
	}
	//Back to Main Menu from Credits scene
	public void CreditsMenuButton(string gameLevel)
	{
		SceneManager.LoadScene(gameLevel);
	}
	// Exit the game
	public void ExitGameButton()
	{
		Application.Quit();
		Debug.Log("Quit button was pressed.");
	}
	//Back to Main Menu
	public void MainMenuButton(string gameLevel)
	{
		SceneManager.LoadScene(gameLevel);
	}
	//Restart Current Scene
	public void RestartScene()
	{
		Scene currentScene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene(currentScene.name);
	}
}
