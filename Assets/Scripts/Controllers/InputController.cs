using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    Player player;

    private void Start()
    {        
        player = GetComponent<Player>();
    }
    private void FixedUpdate()
    {
        Movement();
        Interact();
    }

    private void Movement()
    {
        // Movement
        if (Input.GetKey(KeyCode.UpArrow))
        {
            player.MoveByForce(transform.up, 1);
        }

        if (Input.GetKey(KeyCode.DownArrow ) )
        {
            player.MoveByForce(transform.up, -1);
        }

        if (Input.GetKey(KeyCode.RightArrow) )
        {
            player.MoveByForce(transform.right, 1);
        }

        if (Input.GetKey(KeyCode.LeftArrow) )
        {
            player.MoveByForce(transform.right, -1);
        }         

        else 
        {
            player.SetVelocityZero();            
        }

    }

    public  bool Interact()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            return true;
        }
        return false;
    }
}
