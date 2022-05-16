using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BackgroundScrollScript : MonoBehaviour
{
    [SerializeField] private float ScrollSpeed;
    private MeshRenderer meshRenderer;
    private float yScore;
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        yScore = Time.time * ScrollSpeed;
        
        Vector2 offset = new Vector2(0f, yScore);
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
