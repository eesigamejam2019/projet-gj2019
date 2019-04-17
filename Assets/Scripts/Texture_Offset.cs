using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texture_Offset : MonoBehaviour
{ // Scroll main texture based on time

  public  float YScroll = 1.0f;
    public float XScroll = 1.0f;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float Xoffset = Time.time * XScroll;
        float Yoffset = Time.time * YScroll;
        rend.material.SetTextureOffset("_MainTex", new Vector2(Xoffset, Yoffset));
    }
}
