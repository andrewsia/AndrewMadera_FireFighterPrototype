using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GMScript : MonoBehaviour
{
    public bool playerLost;
    public bool playerWon;
    public bool isGameOver;

    public bool smallFireDestroyed;
    public bool mediumFireDestroyed;
    public bool largeFireDestroyed;

    public bool smallFire2Destroyed;
    public bool mediumFire2Destroyed;
    public bool largeFire2Destroyed;
    public bool allCiviliansSaved;

    public int smallFireHealth;
    public int mediumFireHealth;
    public int largeFireHealth;

    public int smallFire2Health;
    public int mediumFire2Health;
    public int largeFire2Health;

    public int score;

    public GameObject player;
    public GameObject civilian1;
    public GameObject civilian2;
    public GameObject civilian3;

    public GameObject smallFire;
    public GameObject mediumFire;
    public GameObject largeFire;

    public GameObject smallFire2;
    public GameObject mediumFire2;
    public GameObject largeFire2;

    public Vector3 civ1Pos;
    public Vector3 civ2Pos;
    public Vector3 civ3Pos;
    public Vector3 playerPos;

    public TextMeshProUGUI informationtext;
    public TextMeshProUGUI endText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        smallFireHealth = 2;
        mediumFireHealth = 4;
        largeFireHealth = 8;
        score = 0;
        isGameOver = false;
        playerLost = false;
        playerWon = false;
        smallFireDestroyed = false;
        mediumFireDestroyed = false;
        largeFireDestroyed = false;
        smallFire2Health = 2;
        mediumFire2Health = 4;
        largeFire2Health = 8;
        civilian1 = GameObject.Find("First Floor Civilian");
        civilian2 = GameObject.Find("Second Floor Civilian");
        civilian3 = GameObject.Find("Third Floor Civilian");
        allCiviliansSaved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == false)
        {
            // To display the text of the score and the amount of time that is left in the game.
            informationtext.text = "Score: " + score + "\nTime Left: " + player.GetComponent<PMScript>().gameTimer;
            endText.text = "Rooftop Escape";
            if (playerLost == true)
            {
                GetComponent<AudioSource>().Play();
                Debug.Log("You couldn't destroy all the fires in time. You Lose. Your score is " + score);

                if (allCiviliansSaved == false)
                {
                    Destroy(civilian1);
                    Destroy(civilian2);
                    Destroy(civilian3);
                }
                Destroy(player);
                isGameOver = true;
            }

            if (playerWon == true)
            {
                Debug.Log("You win! Your score is " + score + " and you finished with just " + player.GetComponent<PMScript>().gameTimer + " seconds left!");
                isGameOver = true;
            }

            // All the stuff below adds score when the conditions are met aka when the fires are extingushed or the civvies are saved.
            if (smallFireHealth <= 0)
            {
                Destroy(smallFire);
                score += 1000;
                smallFireHealth = 1;
                smallFireDestroyed = true;
                player.GetComponent<AudioSource>().Play();
            }

            if (mediumFireHealth <= 0)
            {
                Destroy(mediumFire);
                score += 5000;
                mediumFireHealth = 1;
                mediumFireDestroyed = true;
                player.GetComponent<AudioSource>().Play();
            }

            if (largeFireHealth <= 0)
            {
                Destroy(largeFire);
                score += 10000;
                largeFireHealth = 1;
                largeFireDestroyed = true;
                player.GetComponent<AudioSource>().Play();
            }


            // For third floor fires


            if (smallFire2Health <= 0)
            {
                Destroy(smallFire2);
                score += 1000;
                smallFire2Health = 1;
                smallFire2Destroyed = true;
                player.GetComponent<AudioSource>().Play();
            }

            if (mediumFire2Health <= 0)
            {
                Destroy(mediumFire2);
                score += 5000;
                mediumFire2Health = 1;
                mediumFire2Destroyed = true;
                player.GetComponent<AudioSource>().Play();
            }

            if (largeFire2Health <= 0)
            {
                Destroy(largeFire2);
                score += 10000;
                largeFire2Health = 1;
                largeFire2Destroyed = true;
                player.GetComponent<AudioSource>().Play();
            }

            if (player.GetComponent<PMScript>().civilian1Saved == 1)
            {
                score += 10000;
                player.GetComponent<PMScript>().civilian1Saved = 0;
                player.GetComponent<AudioSource>().Play();
            }

            if (player.GetComponent<PMScript>().civilian2Saved == 1)
            {
                score += 10000;
                player.GetComponent<PMScript>().civilian2Saved = 0;
                player.GetComponent<AudioSource>().Play();
            }

            if (player.GetComponent<PMScript>().civilian3Saved == 1)
            {
                score += 10000;
                player.GetComponent<PMScript>().civilian3Saved = 0;
                player.GetComponent<AudioSource>().Play();
            }

            if (player.GetComponent<PMScript>().civilian1Saved == 0)
            {
                if (player.GetComponent<PMScript>().civilian2Saved == 0)
                {
                    if (player.GetComponent<PMScript>().civilian3Saved == 0)
                    {
                        allCiviliansSaved = true;
                    }
                } 
            }
        }
    }
}
