using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Camera position
    [SerializeField] private float camPositionY = -0.11f;
    [SerializeField] private float camPositionZ = -10;

    // Camera behaviour
    [SerializeField] private float interpolationSpeedHorizontal = 0.6f;
    [SerializeField] private float interpolationNormalSpeedHorizontal = 0.6f;
    [SerializeField] private float interpolationCorrectionSpeedHorizontal = 1.2f;
    [SerializeField] private float maxDesiredCameraOffsetHorizontal = 3;

    // Reference to unity objectes
    [SerializeField] private GameObject player;
    [SerializeField] private Camera cam;


    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        // If the camera is more than the maxDesiredCameraOffsetHorizontal
        if(player.transform.position.x - cam.transform.position.x > maxDesiredCameraOffsetHorizontal || cam.transform.position.x - player.transform.position.x > maxDesiredCameraOffsetHorizontal)
        {
            interpolationSpeedHorizontal = interpolationCorrectionSpeedHorizontal;
        }
        else
        {
            interpolationSpeedHorizontal = interpolationNormalSpeedHorizontal;
        }

        cam.transform.position = new Vector3(Mathf.Lerp(Camera.main.transform.position.x, player.transform.position.x, interpolationSpeedHorizontal * Time.deltaTime), camPositionY, camPositionZ);
    }
}
