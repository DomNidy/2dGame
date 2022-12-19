using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    // Background Info
    private float length;
    private float startpos;

    // Parallax amount
    public float parallaxEffect;

    // References to Unity Objects
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startpos = transform.position.x;
        
    }

    private void FixedUpdate()
    {
        float dist = (cam.transform.position.x * parallaxEffect);
        float temp = (cam.transform.position.x * (1 - parallaxEffect));

        transform.position = new Vector3 (startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if(temp < startpos - length) startpos -= length;
    }
}
