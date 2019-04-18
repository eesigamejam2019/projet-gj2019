using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTime : MonoBehaviour
{
	public float activeTime = 3;
	public float desactiveTime = 5;
	private float time;

	private Cursor c;

	// Start is called before the first frame update
	void Start()
	{
		c = GetComponent<Cursor>();
		c.active = false;
		time = 0;
	}

    // Update is called once per frame
    void Update()
    {
		time += Time.deltaTime;
		Debug.Log(time);
		c.active = time <= activeTime;
		if(time > activeTime+ desactiveTime)
		{
			time = 0;
		}
    }

	public void ResetTime()
	{
		time = 0;
	}
}
