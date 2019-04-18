using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSlider : MonoBehaviour
{
    private LivingItem[] arbres;
    private int treeCount;
    private int treeAlive;

    // Start is called before the first frame update
    void Start()
    {
        arbres = GameObject.FindObjectsOfType<LivingItem>();
        foreach (LivingItem item in arbres)
        {
            if (item.isEndLife())
            {
                treeAlive++;
            }
        }
        LivingItem.OnChangeLife += ChangeLife;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeLife(int value)
    {
        treeAlive += value;
    }
}
