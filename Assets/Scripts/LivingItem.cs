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
	private Quaternion startRotation;
	private Vector3 startScale;

	public Vector3 StartPosition { get { return startPosition; } }
	public Quaternion StartRotation { get { return startRotation; } }
	public Vector3 StartScale { get { return startScale; } }

    public delegate void HealEvent(Cursor healCursor, float f);
    public event HealEvent onHeal;

    public delegate void DamageEvent(Cursor damageCursor, float f);
    public event DamageEvent onDamage;

    public delegate void ChangeLife(int value);
    public static event ChangeLife OnChangeLife;

    private LifeSlider lifeSlider;
	
    // Start is called before the first frame update
    void Start()
    {
        health = MAX_HEALTH;
        startPosition = transform.position;
		startScale = transform.localScale;
		startRotation = transform.rotation;
        this.healCursor = GameObject.FindGameObjectWithTag("Player").GetComponent<Cursor>();
        this.damageCursor = GameObject.FindGameObjectWithTag("Ball").GetComponent<Cursor>();
        lifeSlider = GameObject.FindObjectOfType<LifeSlider>();
    }

    // Update is called once per frame
    void Update()
    {
		if (healCursor.active && healCursor.GetSquareDistance(startPosition) < Mathf.Pow(healCursor.RadiusLivingDetection, 2))
        {
            Heal(healCursor.HealValue);
        }
		if (damageCursor.active && damageCursor.GetSquareDistance(startPosition) < Mathf.Pow(damageCursor.RadiusLivingDetection, 2))
        {
            Damage(damageCursor.DamageValue);
        }
    }

    public void Damage(float f)
    {
        if (health > 0)
        {
            health -= f * Time.deltaTime;
            if (onDamage != null)
            {
                onDamage(damageCursor, f);
            }
        } else if (health - f <= 0)
        {
            health = 0;
            if (OnChangeLife != null)
            {
                OnChangeLife(-1);
            }
        }
    }

    public void Heal(float f)
    {
        if (health < MAX_HEALTH)
        {
            health += f * Time.deltaTime;
            if (onHeal != null)
            {
                onHeal(healCursor, f);
            }
        } else if (health + f >= MAX_HEALTH)
        {
            health = MAX_HEALTH;
            if (OnChangeLife != null)
            {
                OnChangeLife(1);
            }
        }
    }

    public bool isFullLife()
    {
        return health >= MAX_HEALTH - 0.1 * MAX_HEALTH;
    }

    public bool isMidLife()
    {
		// return health <= 0.5 * MAX_HEALTH + 0.1 * MAX_HEALTH && health >= 0.5 * MAX_HEALTH - 0.1 * MAX_HEALTH;
		return health <= 0.5f * MAX_HEALTH;
    }

    public bool isEndLife()
    {
        return health <= 0.5 * MAX_HEALTH + 0.1 * MAX_HEALTH;
    }
}
