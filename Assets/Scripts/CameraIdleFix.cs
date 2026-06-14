using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIdleFix : MonoBehaviour
{
    public float lockedHeight = 11f;




    public float tiltStrengthForwardBackward = 7f; 
    public float tiltDistanceCheckForwardBackward = 6f; 
    public float tiltStrengthLeftRight = 9f; 
    public float tiltDistanceCheckLeftRight = 5f; 
    



    /*UnityEngine.Vector3 previousLocation;
    UnityEngine.Vector3 idleStartPosition;
    public float idleFrequency = 100f;
    float idleMagnitude = 0.25f;
    bool startPositionSet = false;*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Terrain terrain = Terrain.activeTerrain;
        UnityEngine.Vector3 position = transform.position;
        
        // Sample and set the slope of the hovercraft to the slope of the terrain below the hovercraft

                // Set local variables needed for determining slope below hovercraft
                float _moveCheckForwardDistance = 2;
                UnityEngine.Vector3 _forwardNode = new UnityEngine.Vector3(0f, 0f, tiltDistanceCheckForwardBackward + _moveCheckForwardDistance);
                UnityEngine.Vector3 _rearNode = new UnityEngine.Vector3(0f, 0f, -tiltDistanceCheckForwardBackward + _moveCheckForwardDistance);
                UnityEngine.Vector3 _leftNode = new UnityEngine.Vector3(-tiltDistanceCheckLeftRight, 0f, 0f);
                UnityEngine.Vector3 _rightNode = new UnityEngine.Vector3(tiltDistanceCheckLeftRight, 0f, 0f);

                // Determine the slope under our hovercraft
                float _groundHeightFront = terrain.SampleHeight(position + _forwardNode);
                float _groundHeightBack = terrain.SampleHeight(position + _rearNode);

                float _groundSlopeFB = _groundHeightBack - _groundHeightFront;

                float _groundHeightLeft = terrain.SampleHeight(position + _leftNode);
                float _groundHeightRight = terrain.SampleHeight(position + _rightNode);

                float _groundSlopeLR = _groundHeightLeft - _groundHeightRight;
                
                // Get our current hovercraft angle and save it in a local variable
                UnityEngine.Vector3 currentAngles = transform.eulerAngles;
                //Quaternion currentRotation = transform.rotation;
                
                // Determine if we are facing world forward or not
                float isFacingWorldForward = UnityEngine.Vector3.Dot(transform.forward, UnityEngine.Vector3.forward);

                // Change our currentAngles variable to be the correct slope, accounting for the direction we are facing
                currentAngles.x = _groundSlopeFB * tiltStrengthForwardBackward * isFacingWorldForward; 
                currentAngles.z = _groundSlopeLR * tiltStrengthLeftRight * -isFacingWorldForward; 
             
                // Set our hovercraft to the modified currentAngles variable

                

                transform.eulerAngles = currentAngles;
        
        
                Vector3 currentPos = transform.position;

                currentPos.y = lockedHeight;

                transform.position = currentPos;
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
       
        /*
        UnityEngine.Vector3 currentAngles = transform.eulerAngles;

        if (currentAngles == previousLocation)
                {
                    if (!startPositionSet)
                    {
                        startPositionSet = true;
                        idleStartPosition = transform.position;
                    }
                    float idleMovement = -Mathf.Sin(Time.time * idleFrequency) * idleMagnitude;
                    transform.position = idleStartPosition + new UnityEngine.Vector3(0, idleMovement, 0);
                }
                previousLocation = currentAngles;
                startPositionSet = false;
                */
    }
}
