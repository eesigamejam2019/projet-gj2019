using UnityEngine;
using System.Collections;

public class LivingMove : MonoBehaviour
{
	private LivingItem living;
	public float healShake = 1.5f;

	private void Awake()
	{
		living = GetComponent<LivingItem>();
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

	private void OnHeal(Cursor c, float amount)
	{
		Vector2 r = Random.insideUnitCircle;
		transform.position = living.StartPosition + new Vector3(r.x, 0, r.y) * healShake;
	}

	private void OnDamage(Cursor c, float amount)
	{

	}
}
