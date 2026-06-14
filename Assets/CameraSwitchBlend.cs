using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitchBlend : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera Cam1;
    [SerializeField] CinemachineVirtualCamera Cam2;
    [SerializeField] CinemachineVirtualCamera Cam3;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Cam1.m_Priority = 5;
            Cam2.m_Priority = 0;
            Cam3.m_Priority = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2)) 
         {
            Cam1.m_Priority = 0;
            Cam2.m_Priority = 5;
            Cam3.m_Priority = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) 
         {
            Cam1.m_Priority = 0;
            Cam2.m_Priority = 0;
            Cam3.m_Priority = 5;
        }
    }
}

