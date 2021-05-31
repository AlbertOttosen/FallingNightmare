using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float Speed;
    float offset_y = 0;
    Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        offset_y += Time.deltaTime;
        Vector2 offset = new Vector2(0, -offset_y * Speed);
        material.mainTextureOffset = offset;
    }
}
