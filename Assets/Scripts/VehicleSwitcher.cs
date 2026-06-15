using UnityEngine;
using Cinemachine;

public class VehicleSwitcher : MonoBehaviour
{
    // This creates an array (a list) in the Inspector where you can drag your 3 cars
    public GameObject[] vehicles; 
    public int currentVehicleNum;
    // Virtual camera references
    [SerializeField] CinemachineVirtualCamera Cam1;
    [SerializeField] CinemachineVirtualCamera Cam2;
    [SerializeField] CinemachineVirtualCamera Cam3;    
    GameObject currentActiveHoverCraft;
    Vector3 spawnPoint = new Vector3(500, 60, 415);
    private CinemachineTransposer transposer;


    void Start()
    {
        // When the game starts, make sure only the first car (Index 0) is turned on
        Cam1.m_Priority = 5;
        Cam2.m_Priority = 0;
        Cam3.m_Priority = 0;
        SpawnNewVehicle(0);
        ResetCameraToTargetBack(Cam1);
    }

    void Update()
    {
        // Press the 1, 2, or 3 keys on your keyboard to switch cars
        
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            SpawnNewVehicle(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            SpawnNewVehicle(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            SpawnNewVehicle(2);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (currentVehicleNum + 1 == 3)
            {
                currentVehicleNum = -1;
            }
            currentVehicleNum++;
            SpawnNewVehicle(currentVehicleNum);
            
            

        }

        // Switches the active virtual camera depending on which vehicle is active.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Cam1.m_Priority = 5;
            Cam2.m_Priority = 0;
            Cam3.m_Priority = 0;

            ResetCameraToTargetBack(Cam1);

        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2)) 
         {
            Cam1.m_Priority = 0;
            Cam2.m_Priority = 5;
            Cam3.m_Priority = 0;

            ResetCameraToTargetBack(Cam2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) 
         {
            Cam1.m_Priority = 0;
            Cam2.m_Priority = 0;
            Cam3.m_Priority = 5;

            ResetCameraToTargetBack(Cam3);
        }
        if (currentVehicleNum == 0)
        {
            Cam1.m_Priority = 5;
            Cam2.m_Priority = 0;
            Cam3.m_Priority = 0;

            ResetCameraToTargetBack(Cam1);
        }
        
        if (currentVehicleNum == 1) 
         {
            Cam1.m_Priority = 0;
            Cam2.m_Priority = 5;
            Cam3.m_Priority = 0;

            ResetCameraToTargetBack(Cam2);
        }
        if (currentVehicleNum == 2) 
         {
            Cam1.m_Priority = 0;
            Cam2.m_Priority = 0;
            Cam3.m_Priority = 5;

            ResetCameraToTargetBack(Cam3);
        }
    }

    // The function that does the actual swapping
    void SwitchVehicle(int index)
    {
        // Loop through all the cars in the list
        //for (int i = 0; i < vehicles.Length; i++)
        {
            // If the car's number matches the key we pressed, turn it ON (true). 
            // If it doesn't match, turn it OFF (false).
            //vehicles[i].SetActive(i == index);
            
            //if (i == index)
            {
                //Debug.Log("" + i + "");
            }
        }
    }

    void SpawnNewVehicle(int index)
    {
        SwitchVehicle(index);
        currentVehicleNum = index;

        Destroy(currentActiveHoverCraft);
        currentActiveHoverCraft = Instantiate(vehicles[index], spawnPoint, Quaternion.identity);
    }

    void ResetCameraToTargetBack(CinemachineVirtualCamera cam)
    {
        cam.Follow = currentActiveHoverCraft.transform;
        cam.LookAt = currentActiveHoverCraft.transform;
        transposer = cam.GetCinemachineComponent<CinemachineTransposer>();
        transposer.m_FollowOffset = new Vector3(0f, 20f, -53f);
    }
}