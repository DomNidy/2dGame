using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHealthBar : MonoBehaviour
{
    // This npcs stats object
    [SerializeField] private NPCStats stats;

    // Reference to sprite renderer
    private SpriteRenderer render;

    public void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        // TODO: Adjust the health bar visual based on npc hp here
    }
}
