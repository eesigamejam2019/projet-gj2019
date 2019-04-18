using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
	public void Loadlevel(int l)
	{
		SceneManager.LoadScene(l);
	}
	public void LoadMenu()
	{
		Loadlevel(0);
	}
	public void LoadGame()
	{
		Loadlevel(1);
	}
	public void Exit()
	{
		Application.Quit();
	}
}
