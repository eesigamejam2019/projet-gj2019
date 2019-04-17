using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LivingItem),typeof(Rigidbody))]
public class LivingPhysics : MonoBehaviour
{
	private LivingItem living;
	private Rigidbody rb;

	private bool isHealing;
	private float lastHealing = 0;

	private void Awake()
	{
		living = GetComponent<LivingItem>();
		rb = GetComponent<Rigidbody>();
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
		living.onHeal += OnHeal;
		living.onDamage += OnDamage;
	}

	private void OnDisable()
	{
		living.onHeal -= OnHeal;
		living.onDamage -= OnDamage;
	}

	private void Update()
	{
		
		if(living.Health >= living.Max_Health)
		{
			//sleep
			rb.Sleep();
		}

		if (isHealing)
		{
			if(Time.time - lastHealing < 0.5f)
			{
				isHealing = false;
			}
		}

		rb.isKinematic = isHealing;
		
	}

	private void OnDamage(Cursor c, float amount)
	{
		if (living.Health <= 0)
		{
			Vector3 dir = c.transform.position - transform.position;
			rb.AddForce(dir.normalized * 100,ForceMode.Impulse);
		}
	}

	private void OnHeal(Cursor c, float amount)
	{
		rb.isKinematic = true;
		transform.position += (living.StartPosition - transform.position) * 10 * Time.deltaTime;
		transform.localScale += (living.StartScale - transform.localScale) * 10 * Time.deltaTime;
		transform.rotation = Quaternion.RotateTowards(transform.rotation, living.StartRotation, 300 * Time.deltaTime);
		rb.Sleep();
		isHealing = true;
		lastHealing = Time.time;
	}


}
