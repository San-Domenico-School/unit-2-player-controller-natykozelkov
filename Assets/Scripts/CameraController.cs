using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/********************************************
 * Component of the main camera that keeps it 
 * a constant distance from the vehicle
 * 
 * Bryce Haddock
 * September 12,2023 Version 1.0
 *******************************************/

public class CameraController : MonoBehaviour

{   [Tooltip("drag vehicle onto Vehicle Transform")]
    [SerializeField] private Transform vehicleTransform;// to keep track of vehicle's position
    private Vector3 offset;// distance camera is from vehicle

    // Initializes the field at start
    void Start()
    {
        offset = new Vector3(0, 5, -7);// Camera's offset position
    }

    // Updates camera position per frame just after Update
    void LateUpdate()
    {
        transform.position = vehicleTransform.position + offset;// to keep camera following vehicle position
    }
}
