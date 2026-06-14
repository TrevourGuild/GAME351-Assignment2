using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 200f;
    public float turnSpeed = 80f;
    public float hoverHeight = 11f;
    public float tiltStrengthForwardBackward = 7f; 
    public float tiltDistanceCheckForwardBackward = 6f; 
    public float tiltStrengthLeftRight = 9f; 
    public float tiltDistanceCheckLeftRight = 5f; 
     
    public AudioSource engineAudio; // Creating audio source for the engine hum

    void Start()
    {
    }

    void Update()
    {
        Terrain terrain = Terrain.activeTerrain;

        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        // Mathf.Abs turns negative backward inputs into positive numbers
        float currentInput = Mathf.Abs(Input.GetAxis("Vertical")); 

// Base pitch is 1. We add up to 0.5 to the pitch when moving at full speed.
if (engineAudio != null) 
{
            engineAudio.pitch = 1f + (currentInput * 0.5f); 
}

        // W/S movement
        transform.Translate(0, 0, move);

        // A/D turning
        transform.Rotate(0, turn, 0);

        if (terrain != null)
        {
            // Keep hovercraft above terrain
                Vector3 position = transform.position;
                float groundHeight = terrain.SampleHeight(position);

                position.y = groundHeight + hoverHeight;

                transform.position = position;

            // Sample and set the slope of the hovercraft to the slope of the terrain below the hovercraft

                // Set local variables needed for determining slope below hovercraft
                float _moveCheckForwardDistance = 2;
                Vector3 _forwardNode = new Vector3(0f, 0f, tiltDistanceCheckForwardBackward + _moveCheckForwardDistance);
                Vector3 _rearNode = new Vector3(0f, 0f, -tiltDistanceCheckForwardBackward + _moveCheckForwardDistance);
                Vector3 _leftNode = new Vector3(-tiltDistanceCheckLeftRight, 0f, 0f);
                Vector3 _rightNode = new Vector3(tiltDistanceCheckLeftRight, 0f, 0f);

                // Determine the slope under our hovercraft
                float _groundHeightFront = terrain.SampleHeight(position + _forwardNode);
                float _groundHeightBack = terrain.SampleHeight(position + _rearNode);

                float _groundSlopeFB = _groundHeightBack - _groundHeightFront;

                float _groundHeightLeft = terrain.SampleHeight(position + _leftNode);
                float _groundHeightRight = terrain.SampleHeight(position + _rightNode);

                float _groundSlopeLR = _groundHeightLeft - _groundHeightRight;
                
                // Get our current hovercraft angle and save it in a local variable
                Vector3 currentAngles = transform.eulerAngles;
                //Quaternion currentRotation = transform.rotation;
                
                // Determine if we are facing world forward or not
                float isFacingWorldForward = Vector3.Dot(transform.forward, Vector3.forward);

                // Change our currentAngles variable to be the correct slope, accounting for the direction we are facing
                currentAngles.x = _groundSlopeFB * tiltStrengthForwardBackward * isFacingWorldForward; 
                currentAngles.z = _groundSlopeLR * tiltStrengthLeftRight * -isFacingWorldForward; 
             
                // Set our hovercraft to the modified currentAngles variable
                transform.eulerAngles = currentAngles;
        }
        







    }
}