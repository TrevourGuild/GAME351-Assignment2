using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 200f;
    public float turnSpeed = 80f;
    public float hoverHeight = 10f;
    public float tiltStrengthMultiplier = 5f; // Lower is better for this variable, otherwise we may sample the wrong spot when we go over sharp hills which causes graphical issues
    public float tiltDistanceCheck = 6f; // Lower is better for this variable, otherwise we may sample the wrong spot when we go over sharp hills which causese graphical issues
    
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

//if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit))
        {
         //   Quaternion surfaceRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

            //transform.rotation = surfaceRotation;
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

                // Set local variables needed for determining slope
                Vector3 _forwardNode = new Vector3(0f, 0f, tiltDistanceCheck);
                Vector3 _rearNode = new Vector3(0f, 0f, -tiltDistanceCheck);
                Vector3 _leftNode = new Vector3(-tiltDistanceCheck, 0f, 0f);
                Vector3 _rightNode = new Vector3(tiltDistanceCheck, 0f, 0f);

                // Determine the slope under our hovercraft
                float _groundHeightFront = terrain.SampleHeight(position + _forwardNode);
                float _groundHeightBack = terrain.SampleHeight(position + _rearNode);
                float _groundSlopeFB = _groundHeightBack - _groundHeightFront;

                float _groundHeightLeft = terrain.SampleHeight(position + _leftNode);
                float _groundHeightRight = terrain.SampleHeight(position + _rightNode);
                float _groundSlopeLR = _groundHeightLeft - _groundHeightRight;
                
                // Get our current hovercraft angle and save it in a local variable
                Vector3 currentAngles = transform.eulerAngles;
                
                // Determine if we are facing world forward or not
                bool isFacingWorldForward = Vector3.Dot(transform.forward, Vector3.forward) >= 0f;

                // Determine if we are facing world right or not
                bool isFacingWorldRight = Vector3.Dot(transform.forward, Vector3.forward) >= 0f; // This will be Vector3.right in the near future but requires the same fix needed for the graphical issues with isFacingWorldForward code switching. Leaving it as .forward for the short term reduces the number of graphical issues to 2 (y rot. -90 and +90) instead of 4.

                // Change our currentAngles variable to be the correct slope, accounting for the direction we are facing
                if (isFacingWorldForward)
                {
                    currentAngles.x = _groundSlopeFB * tiltStrengthMultiplier;
                }
                else
                {
                    currentAngles.x = -_groundSlopeFB * tiltStrengthMultiplier;
                }
                if (isFacingWorldRight)
                {
                    currentAngles.z = -_groundSlopeLR * tiltStrengthMultiplier; 
                }
                else
                {
                    currentAngles.z = _groundSlopeLR * tiltStrengthMultiplier;
                }

                // Set our hovercraft to the modified currentAngles variable
                transform.eulerAngles = currentAngles;

        }

        

        
    }
}