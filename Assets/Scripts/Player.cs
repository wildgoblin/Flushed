using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] float maxVelocity;

    //references
    Rigidbody2D rb2D;

    bool floatingAway;
    int bandaids;

    private float sqrMaxVelocity;
    private void Start()
    {
        SetMaxVelocity(maxVelocity);
        rb2D = GetComponent<Rigidbody2D>();

        //Initialize
        floatingAway = false;
        bandaids = 0;
        
    }
    public void SetMaxVelocity(float maxVelocity)
    {
        this.maxVelocity = maxVelocity;
        sqrMaxVelocity = maxVelocity * maxVelocity;
    }

    public void MoveByForce(Vector2 direction, int multiplier)
    {
        rb2D.AddForce(direction * (multiplier * speed));
    }

    public void DeathByBrokenPipe(Vector2 direction, float multipler)
    {
        floatingAway = true;
        DisableCollider();
        DisableInput();
        rb2D.velocity = Vector2.zero;
        rb2D.AddForce(direction * (multipler * speed));
    }

    public void DisableCollider()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void DisableInput()
    {
        GetComponent<InputController>().enabled = false;
    }

    public void FloatingAway()
    {
        floatingAway = true;
    }

    public void AddBandaid()
    {
        bandaids += 1;
    }

    public void RemoveBandaid()
    {
        if(bandaids > 0)
        {
            bandaids -= 1;
        }        
    }

    public int GetBandaidCount()
    {
        return bandaids;
    }

    public void SetVelocityZero()
    {
        rb2D.velocity = Vector2.zero;
    }

    void FixedUpdate()
    {
        if (!floatingAway)
        {
            var v = rb2D.velocity;
            if (v.sqrMagnitude > sqrMaxVelocity)
            { // Equivalent to: rigidbody.velocity.magnitude > maxVelocity, but faster.
              // Vector3.normalized returns this vector with a magnitude 
              // of 1. This ensures that we're not messing with the 
              // direction of the vector, only its magnitude.
                rb2D.velocity = v.normalized * maxVelocity;
            }
        }
    }
}
