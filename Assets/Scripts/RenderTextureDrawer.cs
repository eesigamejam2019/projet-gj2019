﻿using UnityEngine;
using System.Collections;
using UnityEngine.PostProcessing;
public class RenderTextureDrawer : MonoBehaviour
{
	private Texture2D texture;
	public Cursor heal;
	public Cursor damage;
	public Color healColor;
	public Color damageColor;
	public int dmgSize = 30;
	public int healSize = 20;
	public AnimationCurve curve;

	private Vector3 lastHealPos;
	private Vector3 lastDmgPos;

	private ScreenShake shake;
	private PostProcessingBehaviour ppb;

	public PostProcessingProfile hard;
	public PostProcessingProfile normal;
	
	void Start()
	{
		texture = new Texture2D(256, 256);
		Color[] c = new Color[texture.width * texture.height];
		for (int i = 0; i<c.Length; i++) c[i] = new Color(0, 0, 0, 0);
		texture.SetPixels(c);
		GetComponent<Renderer>().material.mainTexture = texture;
		shake = FindObjectOfType<ScreenShake>();
		ppb = FindObjectOfType<PostProcessingBehaviour>();
	}

	private void Update()
	{

		if(lastHealPos != heal.transform.position)
		RaycastDraw(heal.transform.position, -Vector3.up, healSize, healSize, healColor,10);


		if (damage.active && lastDmgPos != damage.transform.position)
		{
			RaycastDraw(damage.transform.position, -Vector3.up, dmgSize, dmgSize, damageColor,1);
			shake.Trigger();	
		}

		if (damage.active)
		{
			ppb.profile = hard;
		}
		else
		{
			ppb.profile = normal;
		}

		lastDmgPos = damage.transform.position;
		lastHealPos = heal.transform.position;
	}

	private void DrawOnTexture(int texPosX, int texPosY, int sizeX, int sizeY, Color c, float drawSpeed)
	{ 

		Color[] array = new Color[sizeX * sizeY];
		
		for (int i = 0; i < array.Length; i++)
		{
			float x = i % sizeX;
			float y = ((float)i /(float) sizeX);
			Color a = texture.GetPixel(texPosX + (int)x, texPosY + (int)y);

			float d = Mathf.Sqrt( Mathf.Pow((x - sizeX/2), 2) + Mathf.Pow((y - sizeY/2), 2));
			d /= sizeX/2;
			array[i] = Color.Lerp(a,ColorToward(a,c,Time.deltaTime * drawSpeed), curve.Evaluate(d));
		}
			
		texture.SetPixels(texPosX, texPosY, sizeX, sizeY, array);
		texture.Apply();	
	}

	private void RaycastDraw(Vector3 pos, Vector3 dir,int sizeX,int sizeY,Color c,float drawSpeed)
	{
		RaycastHit hit;
		if (!Physics.Raycast(pos, dir*1000, out hit))
			return;
		var rtd = hit.transform.gameObject.GetComponent<RenderTextureDrawer>();
		if (rtd != this) return;
		Vector2 pixelUV = hit.textureCoord;
		pixelUV.x *= texture.width;
		pixelUV.y *= texture.height;
		DrawOnTexture((int)pixelUV.x - sizeX/2, (int)pixelUV.y - sizeY/2, sizeX, sizeY, c,drawSpeed);
	}

	private Color ColorToward(Color from, Color to, float speed)
	{
		return new Color(from.r +(to.r - from.r) * speed, from.g + (to.g - from.g) * speed, from.b + (to.b - from.b) * speed, from.a + (to.a - from.a) * speed);
	}
}
