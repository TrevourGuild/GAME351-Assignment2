using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 200f;
    public float turnSpeed = 80f;
    public float hoverHeight = 4f;

    void Start()
    {
    }

    void Update()
    {
        Terrain terrain = Terrain.activeTerrain;

        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        // W/S movement
        transform.Translate(0, 0, move);

        // A/D turning
        transform.Rotate(0, turn, 0);

        // Keep hovercraft above terrain
        if (terrain != null)
        {
            Vector3 position = transform.position;
            float groundHeight = terrain.SampleHeight(position);

            position.y = groundHeight + hoverHeight;

            transform.position = position;
        }
    }
}