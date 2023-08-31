using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    private Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    public void Throw(Vector3 initialVelocity, Vector3 gravity)
    {
        rb.velocity = initialVelocity;
        Physics.gravity = gravity;
    }
}
