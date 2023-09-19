using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**********************************************
 * Component of the Main Camera that keeps it
 * a constant distance from the vehicle
 * 
 * Natalie Kozelkova
 * September 12, 2023
 *********************************************/

public class CameraController : MonoBehaviour
{
    [Tooltip("Drag Vehicle onto Vehicle Transform")]
    [SerializeField] private Transform vehicleTransform;  // to keep track of vehicle's position
    private Vector3 offset;                               // distance camera is from vehicle

    // Initializes the fields at start
    void Start()
    {
        offset = new Vector3(0, 5, -7);

    }

    // Update camera position per frame just after Update
    void LateUpdate()
    {
        transform.position = vehicleTransform.position + offset;
    }
}
