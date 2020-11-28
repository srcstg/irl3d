using System.Collections.Generic;
using UnityEngine;

public class LerpMaterialColour : MonoBehaviour
{
    private MeshRenderer renderer;
    [Range(0, 1)] public float lerpTime;

    public Color[] color;
    int colorIndex = 0;
    float time;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        renderer.material.color = Color.Lerp(renderer.material.color, color[colorIndex], lerpTime * Time.deltaTime);

        time = Mathf.Lerp(time, 1f, lerpTime * Time.deltaTime);
        if(time > 0.9f)
        {
            time = 0;
            colorIndex++;
            colorIndex = (colorIndex >= color.Length) ? 0 : colorIndex;
        }
    }
    
}