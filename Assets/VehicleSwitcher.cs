using UnityEngine;
using Cinemachine;

public class VehicleSwitcher : MonoBehaviour
{
    // This creates an array (a list) in the Inspector where you can drag your 3 cars
    public GameObject[] vehicles; 
    [SerializeField] CinemachineVirtualCamera Cam1;
    [SerializeField] CinemachineVirtualCamera Cam2;
    [SerializeField] CinemachineVirtualCamera Cam3;

    void Start()
    {
        // When the game starts, make sure only the first car (Index 0) is turned on
        SwitchVehicle(0);
    }

    void Update()
    {
        // Press the 1, 2, or 3 keys on your keyboard to switch cars
        
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            SwitchVehicle(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            SwitchVehicle(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            SwitchVehicle(2);
        }

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

    // The function that does the actual swapping
    void SwitchVehicle(int index)
    {
        // Loop through all the cars in the list
        for (int i = 0; i < vehicles.Length; i++)
        {
            // If the car's number matches the key we pressed, turn it ON (true). 
            // If it doesn't match, turn it OFF (false).
            vehicles[i].SetActive(i == index);
            
            //if (vehicles[i].Active)
            {
                //Debug.Log("" + i + "");
            }
        }
    }
}