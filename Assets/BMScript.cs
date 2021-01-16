using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMScript : MonoBehaviour
{
    public Vector3 bulletMove;
    public float bulletTimer;

    public GameObject gameManagerObject;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position += bulletMove;

        // When the bullet has existed for more than or for the equivalent of 1 second they bullet is destroyed and the timer is reset.
        bulletTimer += Time.deltaTime;

        if (bulletTimer >= 1f)
        {
            Destroy(gameObject);
            bulletTimer = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // When the bullet touches the fires they lose one health and the bullet is destroyed when it comes into contact with it. (Line 34 - Line 70)
        if (collision.gameObject.tag == "Small Fire")
        {
            gameManagerObject.GetComponent<GMScript>().smallFireHealth -= 1;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Medium Fire")
        {
            gameManagerObject.GetComponent<GMScript>().mediumFireHealth -= 1;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Large Fire")
        {
            gameManagerObject.GetComponent<GMScript>().largeFireHealth -= 1;
            Destroy(gameObject);
        }



        if (collision.gameObject.tag == "Small Fire 2")
        {
            gameManagerObject.GetComponent<GMScript>().smallFire2Health -= 1;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Medium Fire 2")
        {
            gameManagerObject.GetComponent<GMScript>().mediumFire2Health -= 1;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Large Fire 2")
        {
            gameManagerObject.GetComponent<GMScript>().largeFire2Health -= 1;
            Destroy(gameObject);
        }


        // When the water bullet comes into contact with the civilians they bullet gets destroyed and their score gets lowered by 2000. (Line 74 - Line 93)
        if (collision.gameObject.tag == "Civilian1")
        {
            Destroy(gameObject);
            gameManagerObject.GetComponent<GMScript>().score -= 2000;
            Debug.Log("You hurt a civlian! -2000 points");
        }

        if (collision.gameObject.tag == "Civilian2")
        {
            Destroy(gameObject);
            gameManagerObject.GetComponent<GMScript>().score -= 2000;
            Debug.Log("You hurt a civlian! -2000 points");
        }

        if (collision.gameObject.tag == "Civilian3")
        {
            Destroy(gameObject);
            gameManagerObject.GetComponent<GMScript>().score -= 2000;
            Debug.Log("You hurt a civlian! -2000 points");
        }
    }
}
