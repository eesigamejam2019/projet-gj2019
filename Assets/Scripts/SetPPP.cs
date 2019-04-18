using UnityEngine;
using System.Collections;
using UnityEngine.PostProcessing;

public class SetPPP : MonoBehaviour
{
	private PostProcessingBehaviour ppb;
	public PostProcessingProfile hard;
	public PostProcessingProfile normal;

	// Use this for initialization
	void Start()
	{
		ppb = FindObjectOfType<PostProcessingBehaviour>();
	}

	public void SetHard()
	{
		ppb.profile = hard;
	}

	public void SetSweet()
	{
		ppb.profile = normal;
	}
}
