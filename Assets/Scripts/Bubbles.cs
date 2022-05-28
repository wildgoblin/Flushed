using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour
{

    enum Direction { up, down, left, right };
    [SerializeField] Direction bubbleDirection;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            //references
            Player player = collision.GetComponent<Player>();
            Rigidbody2D playerRB = collision.GetComponent<Rigidbody2D>();
            Fan fan = transform.parent.GetComponent<Fan>();

            //Pushes player back
            //player.MoveByForce(-playerRB.velocity.normalized, fan.GetFanPushPower());

            

            switch (bubbleDirection)
            {
                case Direction.up:
                    playerRB.AddForce(Vector3.up * fan.GetFanPushPower());
                    break;
                case Direction.down:
                    playerRB.AddForce(Vector3.down * fan.GetFanPushPower());
                    break;
                case Direction.left:
                    playerRB.AddForce(Vector3.left * fan.GetFanPushPower());
                    break;
                case Direction.right:
                    playerRB.AddForce(Vector3.right * fan.GetFanPushPower());
                    break;
                default:
                    break;
            }
            player.transform.position = new Vector2(this.transform.position.x, player.transform.position.y);
        }
    }
}
