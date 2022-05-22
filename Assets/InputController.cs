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
    }

    private void Movement()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //rb2D.velocity = Vector2.zero;
                player.MoveByForce(transform.up, 1);
            }

            if (Input.GetKey(KeyCode.DownArrow ) )
            {
                //rb2D.velocity = Vector2.zero;
                player.MoveByForce(transform.up, -1);
            }

            if (Input.GetKey(KeyCode.RightArrow) )
            {
                //rb2D.velocity = Vector2.zero;
                player.MoveByForce(transform.right, 1);
            }

            if (Input.GetKey(KeyCode.LeftArrow) )
            {
                //rb2D.velocity = Vector2.zero;
                player.MoveByForce(transform.right, -1);
            }
        }
        else 
        {
            player.SetVelocityZero();
            
        }

    }
}
