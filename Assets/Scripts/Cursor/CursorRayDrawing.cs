using UnityEngine;
using System.Collections;

public class CursorRayDrawing : MonoBehaviour
{
	private Cursor c;

	private void Awake()
	{
		c = GetComponent<Cursor>();
	}
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		// Only if we hit something, do we continue
		RaycastHit hit;
		if (Physics.Raycast(transform.position, -Vector3.up,out hit))
		{


			// Just in case, also make sure the collider also has a renderer
			// material and texture. Also we should ignore primitive colliders.
			Renderer rend  = hit.collider.GetComponent<Renderer>();
			var meshCollider = hit.collider as MeshCollider;


			Texture mainTexture = rend.material.mainTexture;
			Texture2D texture2D = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);

			RenderTexture currentRT = RenderTexture.active;

			RenderTexture renderTexture = new RenderTexture(mainTexture.width, mainTexture.height, 32);
			Graphics.Blit(mainTexture, renderTexture);

			RenderTexture.active = renderTexture;
			texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
			texture2D.Apply();

			Color[] pixels = texture2D.GetPixels();

			RenderTexture.active = currentRT;

			rend.material.mainTexture = mainTexture;
		}
	}
}
