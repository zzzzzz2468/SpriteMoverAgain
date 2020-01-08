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
        startPos = player.transform.position;
    }

    void Update()
    {
        if (canMove && Input.GetKeyDown(KeyCode.P))
            canMove = false;

        if (!canMove && Input.GetKeyDown(KeyCode.P))
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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (player.transform.position.x >= 5 || player.transform.position.x <= -5)
            {
                canMove = false;
                Debug.Log(canMove);
                
            }
            else if (player.transform.position.y >= 5 || player.transform.position.y <= -5)
            {
                canMove = false;
                Debug.Log(canMove);
            }
            else
            {
                canMove = true;
            }
        }
    }


    //Exiting the game
    void Exit()
    {
        Application.Quit();
    }

    private void playerMovement(float hor, float vert)
    {    
        if(canMove == true)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                transform.position += transform.up * vert * speed * Time.deltaTime;
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
                transform.position += transform.right * hor * speed * Time.deltaTime;
        }

    }
}
