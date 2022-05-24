using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            //references
            Player player = collision.GetComponent<Player>();
            Rigidbody2D playerRB = collision.GetComponent<Rigidbody2D>();
            Fan fan = transform.parent.GetComponent<Fan>();

            //Pushes player back
            player.MoveByForce(-playerRB.velocity.normalized, fan.GetFanPushPower());
        }
    }
}
