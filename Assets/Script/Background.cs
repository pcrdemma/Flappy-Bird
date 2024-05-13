using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    private MeshRenderer meshRenderer;
    public float animationBackgroundSpeed = 0.1f;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();  
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationBackgroundSpeed * Time.deltaTime, 0);
    }


}
