using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SpriteFaceCamera : MonoBehaviour
{
	private Camera cam;
	// Use this for initialization
	void Start()
	{
		cam = Camera.main;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		transform.rotation= cam.transform.rotation;
	}
}
