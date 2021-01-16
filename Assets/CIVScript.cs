using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CIVScript : MonoBehaviour
{
    public GameObject playersObject;
    // Start is called before the first frame update

    // This script is entirely for the civilians idle animation.
    void Start()
    {
        // Since I haven't found how to make a animation not play when it starts. I have set the speed of the animation to 0 which does pretty much the same thing.
        GetComponent<Animator>().speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // When the civilians are "saved" and their objects tag is correct, the idle animation plays for them and at quarter speed because 1 speed (100% speed / regular speed) is way too fast. (Line 21 - Line 46)
        if (playersObject.GetComponent<PMScript>().civilian1Saved == 1)
        {
            if (gameObject.tag == "Civilian1")
            {
                GetComponent<Animator>().Play("Civilian Idle");
                GetComponent<Animator>().speed = 0.25f;
            }
        }

        if (playersObject.GetComponent<PMScript>().civilian2Saved == 1)
        {
            if (gameObject.tag == "Civilian2")
            {
                GetComponent<Animator>().Play("Civilian Idle");
                GetComponent<Animator>().speed = 0.25f;
            }
        }

        if (playersObject.GetComponent<PMScript>().civilian3Saved == 1)
        {
            if (gameObject.tag == "Civilian3")
            {
                GetComponent<Animator>().Play("Civilian Idle");
                GetComponent<Animator>().speed = 0.25f;
            }
        }
    }
}
