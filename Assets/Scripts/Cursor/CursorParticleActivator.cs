using UnityEngine;
using System.Collections;

public class CursorParticleActivator : MonoBehaviour
{
	public ParticleSystem ps;
	private Cursor c;
	// Use this for initialization
	void Awake()
	{
		c = GetComponent<Cursor>();
	}

	// Update is called once per frame
	void Update()
	{
		var emi = ps.emission;
		emi.enabled = c.IsHealing;
	}
}
