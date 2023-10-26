using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField] Transform holeLocation;

    [SerializeField] float cameraXLocation;
    [SerializeField] float cameraYLocation;
    [SerializeField] float cameraZLocation;

    void Update()
    {
        transform.position = holeLocation.transform.position + new Vector3(cameraXLocation, cameraYLocation, cameraZLocation);
    }
}
