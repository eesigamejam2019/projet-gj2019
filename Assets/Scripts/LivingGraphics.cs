using UnityEngine;

public class LivingGraphics : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;

    [SerializeField]
    private int currentSprite;

    private LivingItem livingItem;

    private SpriteRenderer spriteRenderer;

	private void Awake()
	{
		livingItem = GetComponent<LivingItem>();
		this.spriteRenderer = GetComponentInChildren<SpriteRenderer>();
	}
	// Start is called before the first frame update
	void Start()
    {
        this.currentSprite = 0;
        this.spriteRenderer.sprite = sprites[currentSprite];
    }

    // Update is called once per frame
    void Update()
    {
        if (livingItem.isFullLife() && currentSprite != 0) // FULL LIFE
        {
            currentSprite = 0;
            spriteRenderer.sprite = sprites[currentSprite];
        }
        if (livingItem.isMidLife() && currentSprite != 1) // MID LIFE
        {
            currentSprite = 1;
            spriteRenderer.sprite = sprites[currentSprite];
        }
        if (livingItem.isEndLife() && currentSprite != 2) // END LIFE
        {
            currentSprite = 1;
            spriteRenderer.sprite = sprites[currentSprite];
        }
    }
}
