using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSlider : MonoBehaviour
{
    private LivingItem[] arbres;
    private int treeCount;
    private int treeAlive;

    public Slider slider;

    // Start is called before the first frame update
    void Awake()
    {
        arbres = GameObject.FindObjectsOfType<LivingItem>();
        foreach (LivingItem item in arbres)
        {
            if (item.Alive)
            {
                treeAlive++;
            }
        }
        treeCount = arbres.Length;
        UpdateSlider();
		Debug.Log(treeCount + "  " + treeAlive);
    }

    private void OnEnable()
    {
        LivingItem.OnChangeLife += ChangeLife;
    }

    private void OnDisable()
    {
        LivingItem.OnChangeLife -= ChangeLife;
    }

    private void ChangeLife(int value)
    {
        treeAlive += value;
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        slider.value = (float)treeAlive / (float)treeCount;
    }
}
