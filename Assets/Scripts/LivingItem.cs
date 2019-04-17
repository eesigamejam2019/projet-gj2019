using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingItem : MonoBehaviour, Damagable
{
    [SerializeField]
    private const float MAX_HEALTH = 100f;

    [SerializeField]
    private float health;

    public float Health { get { return health; } }

	public float Max_Health { get { return MAX_HEALTH; } }

    private Cursor healCursor;

    private Cursor damageCursor;

    private Vector3 startPosition;

    public delegate void HealEvent(Cursor healCursor, float f);
    public event HealEvent onHeal;

    public delegate void DamageEvent(Cursor damageCursor, float f);
    public event DamageEvent onDamage;
	
    // Start is called before the first frame update
    void Start()
    {
        health = MAX_HEALTH;
        startPosition = transform.position;
        this.healCursor = GameObject.FindGameObjectWithTag("Player").GetComponent<Cursor>();
        this.damageCursor = GameObject.FindGameObjectWithTag("Balle").GetComponent<Cursor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healCursor.GetSquareDistance(startPosition) < Mathf.Pow(healCursor.RadiusLivingDetection, 2))
        {
            Heal(healCursor.HealValue);
        }
        if (damageCursor.GetSquareDistance(startPosition) < damageCursor.RadiusLivingDetection)
        {
            Damage(damageCursor.DamageValue);
        }
    }

    public void Damage(float f)
    {
        if (health > 0)
        {
            health -= f;
            if (onDamage != null)
            {
                onDamage(damageCursor, f);
            }
        } else
        {
            health = 0;
        }
    }

    public void Heal(float f)
    {
        if (health < MAX_HEALTH)
        {
            health += f;
            if (onHeal != null)
            {
                onHeal(healCursor, f);
            }
        } else
        {
            health = MAX_HEALTH;
        }
    }
}
