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
		for (int i = 0; i < rend.Length; i++)
		{
			if (rend[i].transform.parent && rend[i].transform.parent.GetComponent<LivingItem>())
			{

				rend[i].sortingOrder = 1000 - (int)rend[i].transform.position.z;
				rend[i].transform.position = new Vector3(rend[i].transform.position.x, 100 - (int)rend[i].transform.position.z / 10, rend[i].transform.position.z);


				float f = (rend[i].transform.localScale.z + 300f) / 495f;
				rend[i].transform.localScale *= Mathf.Lerp(0.8f, 1f, f);
			}
		}
    }
}
