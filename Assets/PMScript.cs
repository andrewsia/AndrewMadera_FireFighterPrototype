using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMScript : MonoBehaviour
{
    public int playerFacing;
    public Vector3 leftForce;
    public Vector3 rightForce;
    public Vector3 climbForce;

    public GameObject leftBulletPrefab;
    public GameObject rightBulletPrefab;
    public GameObject gameManagerObject;

    public Vector3 leftBulletOffset;
    public Vector3 rightBulletOffset;

    public float gameTimer;

    public bool touchingLadder;
    public int climbingLadder;
    // -1 means not saved, 1 means saved, and 0 means standby (after saved).
    public int civilian1Saved;
    public int civilian2Saved;
    public int civilian3Saved;

    public bool movingRight;
    public bool movingLeft;

    // Start is called before the first frame update
    void Start()
    {
        gameTimer = 45;
        playerFacing = 1;
        GetComponent<Animator>().speed = 0;
        movingLeft = false;
        movingRight = false;
        civilian1Saved = -1;
        civilian2Saved = -1;
        civilian3Saved = -1;
        climbingLadder = -1;
    }

    // Update is called once per frame
    void Update()
    {
        // Starts the game by taking away at the timer.
        gameTimer -= Time.deltaTime;

        // To stop the timer when the game is over. Almost 31,688,765 years.
        if (gameManagerObject.GetComponent<GMScript>().isGameOver == true)
        {
            gameTimer = 1000000;
        }
        // Moves when left arrow key is held
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movingLeft = true;
            GetComponent<Rigidbody2D>().AddForce(leftForce);
            playerFacing = -1;
            GetComponent<SpriteRenderer>().flipX = true;
            if (movingLeft == true)
            {
                GetComponent<Animator>().Play("Player Walking");
                GetComponent<Animator>().speed = 0.5f;
            }
        }

        // Moves when right arrow key is held
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movingRight = true;
            GetComponent<Rigidbody2D>().AddForce(rightForce);
            playerFacing = 1;
            GetComponent<SpriteRenderer>().flipX = false;

            // When touching anything but the ladder aka moving the walking animation is played and at half speed.
            if (movingRight == true)
            {
                GetComponent<Animator>().Play("Player Walking");
                GetComponent<Animator>().speed = 0.5f;
            }
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            movingRight = false;
            GetComponent<Animator>().speed = 0;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            movingLeft = false;
            GetComponent<Animator>().speed = 0;
        }

        // This is for when the player isn't moving the walking animation wont play. (Hopefully) \\
       
        // When the spacebar is pressed the water bullets are shot depending on where the player is facing. -1 means left, 1 means right.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerFacing == -1)
            {
                Instantiate(leftBulletPrefab, GetComponent<Transform>().position + leftBulletOffset, Quaternion.identity);
            }

            if (playerFacing == 1)
            {
                Instantiate(rightBulletPrefab, GetComponent<Transform>().position + rightBulletOffset, Quaternion.identity);
            }
        }

        // The games timer starts at 45 secs but when that timer runs out the player loses.
        if (gameTimer <= 0)
        {
            gameManagerObject.GetComponent<GMScript>().playerLost = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // When the player comes in contact with the Civvies they both get moved to the start of the level and are deeme "saved". (line 112 - line 140)
        if (collision.gameObject.tag == "Civilian1")
        {
            if (civilian1Saved == -1)
            {
                Debug.Log("You've rescued a civilian! Bonus 10,000 points!");
                civilian1Saved = 1;
                collision.gameObject.GetComponent<Transform>().position = gameManagerObject.GetComponent<GMScript>().civ1Pos;
                gameObject.GetComponent<Transform>().position = gameManagerObject.GetComponent<GMScript>().playerPos;
            }
        }

        if (collision.gameObject.tag == "Civilian2")
        {
            if (civilian2Saved == -1)
            {
                Debug.Log("You've rescued a civilian! Bonus 10,000 points");
                civilian2Saved = 1;
                collision.gameObject.GetComponent<Transform>().position = gameManagerObject.GetComponent<GMScript>().civ2Pos;
                gameObject.GetComponent<Transform>().position = gameManagerObject.GetComponent<GMScript>().playerPos;
            }
        }

        if (collision.gameObject.tag == "Civilian3")
        {
            if (civilian3Saved == -1)
            {
                Debug.Log("You've rescued a civilian! Bonus 10,000 points");
                civilian3Saved = 1;
                collision.gameObject.GetComponent<Transform>().position = gameManagerObject.GetComponent<GMScript>().civ3Pos;
                gameObject.GetComponent<Transform>().position = gameManagerObject.GetComponent<GMScript>().playerPos;
            }
        }

        if (collision.gameObject.tag == "Ladder")
        {
            touchingLadder = true;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                climbingLadder = 1;
                GetComponent<Rigidbody2D>().AddForce(climbForce);
            }
        }

        // != for when the player is not touching the Ladder. 
        if (collision.gameObject.tag != "Ladder")
        {
            touchingLadder = false;
            climbingLadder = -1;
        }

        // When the player touches the door at the end of the level they win.
        if (collision.gameObject.tag == "End Door")
        {
            if (gameManagerObject.GetComponent<GMScript>().score >= 32000)
            {
                gameManagerObject.GetComponent<GMScript>().playerWon = true;
            }

            if (gameManagerObject.GetComponent<GMScript>().score < 32000)
            {
                gameManagerObject.GetComponent<GMScript>().playerLost = true;
            }
        }
    }
}
