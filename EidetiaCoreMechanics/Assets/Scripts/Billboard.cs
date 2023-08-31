using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Camera mainCam;
    private Transform camLocation;

    private void Start()
    {
        mainCam = Camera.main;
        camLocation = mainCam.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + camLocation.forward);
    }
}
