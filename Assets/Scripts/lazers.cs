using UnityEngine;

public class lazers : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform firePoint;

    public float laserSpeed = 250f;
    public float fireRate = 0.05f;   // Smaller number = faster firing

    private float nextFireTime = 0f;

    void Update()
    {
        // Hold Space to continuously fire
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            GameObject laser = Instantiate(
                laserPrefab,
                firePoint.position,
                firePoint.rotation
            );

            laser.transform.SetParent(null);

            Rigidbody rb = laser.GetComponent<Rigidbody>();

            if (rb == null)
            {
                rb = laser.AddComponent<Rigidbody>();
            }

            rb.useGravity = false;
            rb.velocity = firePoint.forward * laserSpeed;

            Destroy(laser, 3f);
        }
    }
}