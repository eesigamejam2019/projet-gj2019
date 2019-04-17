using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingGraphics : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;

    [SerializeField]
    private int currentSprite;

    private LivingItem livingItem;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        this.currentSprite = 0;
        this.spriteRenderer.sprite = sprites[currentSprite];
    }

    // Update is called once per frame
    void Update()
    {
        if (livingItem.isFullLife() && currentSprite != 0) // FULL life
        {
            currentSprite = 0;
            spriteRenderer.sprite = sprites[currentSprite];
        }
        if (livingItem.isMidLife() && currentSprite != 1) // MID life
        {
            currentSprite = 1;
            spriteRenderer.sprite = sprites[currentSprite];
        }
    }
}
