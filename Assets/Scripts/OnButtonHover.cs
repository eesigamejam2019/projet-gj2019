using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnButtonHover : MonoBehaviour
{
	private AudioSource src;
	public AudioClip clip;
    // Start is called before the first frame update
    void Awake()
    {
		src = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySound()
	{
		src.PlayOneShot(clip);
	}
}
