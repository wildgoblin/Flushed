using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] float maxVelocity;

    //references
    Rigidbody2D rb2D;

    private float sqrMaxVelocity;
    private void Start()
    {
        SetMaxVelocity(maxVelocity);
        rb2D = GetComponent<Rigidbody2D>();
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

    public void SetVelocityZero()
    {
        rb2D.velocity = Vector2.zero;
    }

    void FixedUpdate()
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
