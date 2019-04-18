using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public GameState[] gameState;
	private CursorTime cursorTime;

	private int currentState;
	private float time = 0;
	void Start()
	{
		cursorTime = FindObjectOfType<CursorTime>();
	}

	void Update()
	{
		if(time >= gameState[currentState].time && gameState.Length - 1 != currentState)
		{
			switchState();
			applyState();
		}
		time += Time.deltaTime;
	}

	private void switchState()
	{
		if (currentState + 1 >= gameState.Length)
		{
			currentState = gameState.Length - 1;
		} else
		{
			currentState++;
		}
	}

	private void applyState()
	{
		cursorTime.activeTime = gameState[currentState].activeTime;
		cursorTime.desactiveTime = gameState[currentState].desactiveTime;
	}
}


