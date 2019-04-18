using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameState
{
	// Temps à dépasser pour passer à l'étape suivante
	public float time;
	public float desactiveTime;
	public float activeTime;
}