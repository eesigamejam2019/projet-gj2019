using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingItem : MonoBehaviour, Damagable
{
    [SerializeField]
    private const float MAX_HEALTH = 100f;

    [SerializeField]
    private float health;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float f)
    {
        if (health > 0)
        {
            health -= f;
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
        } else
        {
            health = MAX_HEALTH;
        }
    }


}
