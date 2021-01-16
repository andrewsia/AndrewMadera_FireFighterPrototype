using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public GameObject gameManagerObject;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().volume = 0.4f;
        GetComponent<AudioSource>().loop = true;
        GetComponent<AudioSource>().pitch = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerObject.GetComponent<GMScript>().playerLost == true)
        {
            GetComponent<AudioSource>().pitch = 0.8f;
            GetComponent<AudioSource>().volume = 1f;
        }
    }
}
