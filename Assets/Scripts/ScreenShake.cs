using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
	public Cursor dmg;
	private Transform cam;
	private Vector3 initialPos;
	public float shakeMagnitude = 1.7f;
	public float shakeDuration = 1;

	private float shakeTime;


	private void Awake()
	{
		cam = Camera.main.transform;
		initialPos = transform.position;
	}

	private void Update()
	{ 

		if (shakeTime > 0)
		{
			transform.position = initialPos + Random.insideUnitSphere * shakeMagnitude;
			shakeTime -= Time.deltaTime;
		}else
		{
			shakeTime = 0;
		}
	}

	public void Trigger()
	{
		shakeTime = shakeDuration;
	}
}
