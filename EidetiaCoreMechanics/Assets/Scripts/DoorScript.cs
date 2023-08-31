using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    private bool opened = false;
    private Animator anim;

    public void openDoor(RaycastHit doorHit)
    {
        //This line will get the Animator from  Parent of the door that was hit by the raycast.
        anim = doorHit.transform.GetComponentInParent<Animator>();

        //This will set the bool the opposite of what it is.
        opened = !opened;

        //This line will set the bool true so it will play the animation.
        anim.SetBool("Opened", !opened);
    }
}