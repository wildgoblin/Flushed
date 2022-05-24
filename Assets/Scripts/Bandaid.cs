using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandaid : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.GetComponent<Player>())
        {
            otherCollider.GetComponent<Player>().AddBandaid();
            Destroy(gameObject);
        }
    }
}
