using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour
{

    enum Direction { up, down, left, right };
    [SerializeField] Direction bubbleDirection;

    Player player;

    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.GetComponent<Player>();
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {

            Rigidbody2D playerRB = collision.GetComponent<Rigidbody2D>();
            Fan fan = transform.parent.GetComponent<Fan>();

            //Pushes player back
            //player.MoveByForce(-playerRB.velocity.normalized, fan.GetFanPushPower());

            

            switch (bubbleDirection)
            {
                case Direction.up:
                    player.transform.position = new Vector2(this.transform.position.x, player.transform.position.y);
                    playerRB.AddForce(Vector3.up * fan.GetFanPushPower());
                    
                    break;
                case Direction.down:
                    player.transform.position = new Vector2(this.transform.position.x, player.transform.position.y);
                    playerRB.AddForce(Vector3.down * fan.GetFanPushPower());
                    break;
                case Direction.left:
                    player.transform.position = new Vector2(player.transform.position.x, this.transform.position.y);
                    playerRB.AddForce(Vector3.left * fan.GetFanPushPower());
                    break;
                case Direction.right:
                    player.transform.position = new Vector2(player.transform.position.x, this.transform.position.y);
                    playerRB.AddForce(Vector3.right * fan.GetFanPushPower());
                    break;
                default:
                    break;
            }
            
        }
    }
}
