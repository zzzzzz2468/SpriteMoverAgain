using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 startPos;
    public GameObject player;
    public int speed;
    private bool canMove = true;

    void Start()
    {
        //getting the location of the player on start to return if space pressed
        startPos = player.transform.position;
    }

    void Update()
    {

        //enabling and disabling movement in game
        if (canMove == true && Input.GetKeyDown(KeyCode.P))
            canMove = false;
        else if (canMove == false && Input.GetKeyDown(KeyCode.P))
            canMove = true;


        //Movement
        if (canMove)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            playerMovement(horizontal, vertical);
        }


        //Returning the player to its start position
        if (Input.GetKeyDown(KeyCode.Space))
            player.transform.position = startPos;


        //Setting the player inactive
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(player.activeInHierarchy)
                player.SetActive(false);
            else
            {
                player.SetActive(true);
                player.transform.position = startPos;
            }   
        }


        //Input For exiting the game
        if (Input.GetKeyDown(KeyCode.Escape))
            Exit();


        //Limiting how far the player can move from center
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (player.transform.position.x >= 5 || player.transform.position.x <= -5)
                canMove = false;
            else if (player.transform.position.y >= 5 || player.transform.position.y <= -5)
                canMove = false;
        }


        //allowing the player to move freely again
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (player.transform.position.x >= 5 || player.transform.position.x <= -5)
                canMove = true;
            else if (player.transform.position.y >= 5 || player.transform.position.y <= -5)
                canMove = true;
        }


        if(Input.GetKeyDown(KeyCode.Z))
        {
            GetComponent<Movement>().enabled = false;
        }

        if(GetComponent<Movement>().enabled == false)
        {
            GetComponent<Movement>().enabled = true;
        }

        gridMovement();

    }


    //Exiting the game
    void Exit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }


    //causing the player to be able to move
    private void playerMovement(float hor, float vert)
    {    
        if(canMove == true)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                //detecting if moving diagnal
                if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                {
                    transform.position += transform.up * vert * speed * Time.deltaTime / 2;
                }
                else
                {
                    transform.position += transform.up * vert * speed * Time.deltaTime;
                }
            }
                
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += transform.right * hor * speed * Time.deltaTime;
            }
                
        }

    }


    private void gridMovement()
    {
        Vector3 temp = new Vector3(7.0f, 2.0f, 0);
        if (Input.GetKey(KeyCode.Alpha1))
            player.transform.position = temp;

        temp = new Vector3(4.0f, -1.0f, 0);
        if (Input.GetKey(KeyCode.Alpha2))
            player.transform.position = temp;

        temp = new Vector3(-2.0f, 5.0f, 0);
        if (Input.GetKey(KeyCode.Alpha3))
            player.transform.position = temp;

        temp = new Vector3(-2.0f, -4.0f, 0);
        if (Input.GetKey(KeyCode.Alpha4))
            player.transform.position = temp;

        temp = new Vector3(3.0f, -3.0f, 0);
        if (Input.GetKey(KeyCode.Alpha5))
            player.transform.position = temp;

        temp = new Vector3(7.0f, 3.0f, 0);
        if (Input.GetKey(KeyCode.Alpha6))
            player.transform.position = temp;

        temp = new Vector3(1.0f, 1.0f, 0);
        if (Input.GetKey(KeyCode.Alpha7))
            player.transform.position = temp;

        temp = new Vector3(-2.0f, -3.0f, 0);
        if (Input.GetKey(KeyCode.Alpha8))
            player.transform.position = temp;

        temp = new Vector3(-7.0f, 2.0f, 0);
        if (Input.GetKey(KeyCode.Alpha9))
            player.transform.position = temp;

        temp = new Vector3(-2.0f, -5.0f, 0);
        if (Input.GetKey(KeyCode.Alpha0))
            player.transform.position = temp;
    }
}
