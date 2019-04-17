﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LivingItem),typeof(Rigidbody))]
public class LivingPhysics : MonoBehaviour
{
	private LivingItem living;
	private Rigidbody rb;


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
	}

	private void OnDamage(Cursor c, float amount)
	{
		if (living.Health <= 0)
		{
			Vector3 dir = c.transform.position - transform.position;
			rb.AddForce(dir * 10);
		}
	}

	private void OnHeal(Cursor c, float amount)
	{
		transform.position = living.StartPosition;
		transform.localScale = living.StartScale;
		transform.rotation = living.StartRotation;
		rb.Sleep();
	}


}
