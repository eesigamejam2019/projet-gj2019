using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeOrder : MonoBehaviour
{
	private SpriteRenderer[] rend;
    // Start is called before the first frame update
    void Start()
    {
		rend = FindObjectsOfType<SpriteRenderer>();
		for(int i = 0; i< rend.Length; i++)
		{
			rend[i].sortingOrder = 1000 - (int)rend[i].transform.position.z;
		}
    }
}
