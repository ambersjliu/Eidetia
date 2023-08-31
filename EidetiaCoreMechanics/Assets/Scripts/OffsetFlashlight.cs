using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetFlashlight : MonoBehaviour
{
    private Vector3 vectOffset;
    [SerializeField] Camera cam;
    [SerializeField] private float speed = 3.0f;


    void Start()
    {
        vectOffset = transform.position - cam.transform.position;
    }




    void Update()
    {
        transform.position = cam.transform.position + vectOffset;
        transform.rotation = Quaternion.Slerp(transform.rotation, cam.transform.rotation, speed * Time.deltaTime);
    }
}