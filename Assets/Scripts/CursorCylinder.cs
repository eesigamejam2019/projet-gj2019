using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CursorCylinder : MonoBehaviour
{
	public Cursor c;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		transform.localScale = new Vector3(c.RadiusLivingDetection, transform.localScale.y, c.RadiusLivingDetection);
    }
}
