using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraDepthRender : MonoBehaviour
{
	private Camera cam;
	// Use this for initialization
	void Start()
	{
		cam = GetComponent<Camera>();
		cam.depthTextureMode = DepthTextureMode.Depth | DepthTextureMode.DepthNormals;

	}

	// Update is called once per frame
	void Update()
	{

	}
}
