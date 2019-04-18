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

    [SerializeField]
    private float RADIUS_LIVING_DETECTION = 1f;

    [SerializeField]
    private float DAMAGE_VALUE = 0.001f;

    [SerializeField]
    private float HEAL_VALUE = 0.001f;
    
    public float RadiusLivingDetection { get { return RADIUS_LIVING_DETECTION; } }

    public float DamageValue { get { return DAMAGE_VALUE; } }

    public float HealValue { get { return HEAL_VALUE; } }

    public float speed;

    public float size;

	public Vector4 bound = new Vector4(-10, -10, 10, 10);

	private Vector2 direction;

	private bool _active = true;
	public bool active {
		get { return _active; }
		set {
			_active = value;
			SetChildEnable(_active);
		}
		}

	private bool isHealing;
	private float lastHealing;
	public bool IsHealing { get { return isHealing; } }

	public bool iaMode = false;

	private void Update() {
		direction = GetDirection();
		transform.position += new Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime;
		Bounds();

		if(Time.time - lastHealing > 0.2f)
		{
			isHealing = false;
		}
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

	public void SetHealing()
	{
		isHealing = true;
		lastHealing = Time.time;
	}


	//ATTENTION C EST MOCHE !
	private void SetChildEnable(bool b)
	{
		foreach(Renderer r in GetComponentsInChildren<Renderer>())
		{
			if(r.GetType() != typeof(ParticleSystemRenderer))
			{
				r.enabled = b;
			}else
			{
				var ps = r.gameObject.GetComponent<ParticleSystem>();
				if (ps)
				{
					var emi =  ps.emission;
					emi.enabled = b;
				}	
			}	
		}
	}

    private Vector2 GetDirection(){
		if (iaMode) return GetIaDirection();
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

	private Vector2 iaPos;
	private Vector2 GetIaDirection()
	{
		Vector2 v = Vector2.zero;
		v.x = Mathf.PerlinNoise(iaPos.x, iaPos.y+10) *2 -1;
		v.y = Mathf.PerlinNoise(iaPos.x+100, iaPos.y) * 2 -1;
		iaPos += Vector2.one * Time.deltaTime * 0.1f;
		return v.normalized;
	}

	public float GetSquareDistance(Vector3 v)
	{
		return Mathf.Pow((v.x - transform.position.x), 2) + Mathf.Pow((v.z - transform.position.z), 2);
	}

	private void OnDrawGizmos()
	{
		Vector3 v1 = new Vector3(bound.x, transform.position.y, bound.y);
		Vector3 v2 = new Vector3(bound.z, transform.position.y, bound.y);
		Vector3 v3 = new Vector3(bound.z, transform.position.y, bound.w);
		Vector3 v4 = new Vector3(bound.x, transform.position.y, bound.w);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(v1, v2);
		Gizmos.DrawLine(v2, v3);
		Gizmos.DrawLine(v3, v4);
		Gizmos.DrawLine(v4, v1);
	}
}
