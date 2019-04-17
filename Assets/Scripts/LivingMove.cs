using UnityEngine;
using System.Collections;

public class LivingMove : MonoBehaviour
{
	private LivingItem living;

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

	}

	private void OnDamage(Cursor c, float amount)
	{

	}
}
