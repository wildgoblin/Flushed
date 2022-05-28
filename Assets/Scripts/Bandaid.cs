using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandaid : MonoBehaviour


{

    [SerializeField] AudioClip pickUpSound;
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.GetComponent<Player>())
        {
            if(pickUpSound == null)
            { Debug.Log("Need AudioClip on " + this); }
            else 
            { AudioSource.PlayClipAtPoint(pickUpSound, Camera.main.transform.position); }
            
            otherCollider.GetComponent<Player>().AddBandaid();
            Destroy(gameObject);
        }
    }
}
