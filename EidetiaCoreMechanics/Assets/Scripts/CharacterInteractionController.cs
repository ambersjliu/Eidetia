using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractionController : MonoBehaviour
{
    public Transform PlayerCamera;
    [Header("Max distance the player can interact from.")]
    public float MaxDistance = 20;

    private Animator anim;
    private DoorScript doorScript;

    // Start is called before the first frame update
    void Start()
    {
        doorScript = GetComponent<DoorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Pressed();
            Debug.Log("R pressed");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "battery")
        {
            AudioController.instance.Play("Item");
            other.gameObject.SetActive(false);
            FlashlightControl.instance.refillBattery();
        }
    }
    void Pressed()
    {
        //This will name the Raycasthit and came information of which object the raycast hit.
        RaycastHit hit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, MaxDistance))
        {

            // if raycast hits, then it checks if it hit an object with the tag Door.
            if (hit.collider.tag == "door" && MazeManager.instance.doorCanOpen)
            {
                doorScript.openDoor(hit);
                GameManager.Instance.UpdateGameState(GameState.win);
            }else if(hit.collider.tag == "minotaur")
            {
                AudioController.instance.Play("Item");
                Debug.Log("Minotaur was found");
                hit.collider.gameObject.SetActive(false);
                MazeManager.instance.updateMazeState(MazeState.minotaurFound);
            }
        }
    }
}
