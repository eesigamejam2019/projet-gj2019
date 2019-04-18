using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioSource src0;
	public AudioSource src1;
	public AudioClip hard;
	public AudioClip sweet;

	public float speed = 10;

	public Cursor bad;
    // Start is called before the first frame update
    void Awake()
    {
		src0.clip = sweet;
		src0.volume = 1;
		src1.clip = hard;
		src1.volume = 0;
		src0.Play();
		src1.Play();
		src0.loop = true;
		src1.loop = true;
	}

    // Update is called once per frame
    void Update()
    {
		if (bad.active)
		{
			src0.volume -= Time.deltaTime * speed;			
			src1.volume += Time.deltaTime * speed;
		}
		else
		{
			src0.volume += Time.deltaTime * speed;
			src1.volume -= Time.deltaTime * speed;
		}
		src0.volume = Mathf.Clamp01(src0.volume);
		src1.volume = Mathf.Clamp01(src1.volume);
	}
}
