using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Cursor : MonoBehaviour
{
    [SerializeField]private KeyCode inputForward = KeyCode.UpArrow;
    [SerializeField]private KeyCode inputBackward = KeyCode.DownArrow;
	[SerializeField]private KeyCode inputLeft = KeyCode.LeftArrow;
	[SerializeField]private KeyCode inputRight = KeyCode.RightArrow;

	public float speed;

    public float size;

	public Vector4 bound = new Vector4(-10, -10, 10, 10);

	private Vector2 direction;

	private void Update() {
		direction = GetDirection();
		transform.position += new Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime;
		Bounds();
    }

	private void Bounds()
	{
		Vector3 pos = transform.position;
		if(pos.x < bound.x)
		{
			pos.x = bound.z;
		}
		if (pos.x > bound.z)
		{
			pos.x = bound.x;
		}
		if (pos.z < bound.y)
		{
			pos.z = bound.w;
		}
		if (pos.z > bound.w)
		{
			pos.z = bound.y;
		}
		transform.position = pos;
	}

    private Vector2 GetDirection(){
		Vector2 v = Vector2.zero;
		if (Input.GetKey(inputForward))
		{
			v.y += 1;
		}
		if (Input.GetKey(inputBackward))
		{
			v.y -= 1;
		}
		if (Input.GetKey(inputLeft))
		{
			v.x -= 1;
		}
		if (Input.GetKey(inputRight))
		{
			v.x += 1;
		}
		return v;
    }

	public float GetSquareDistance(Transform t)
	{
		return Mathf.Pow((t.position.x - transform.position.x), 2) + Mathf.Pow((t.position.z - transform.position.z), 2);
	}
}
