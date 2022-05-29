using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Fan : MonoBehaviour
{
    [SerializeField] int fanPushPower;
    [SerializeField] Sprite defaultSprite;

    private void Start()
    {
        //GetComponent<AudioSource>().Play();
    }
    public void TurnOffFan()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        
        GetComponent<Animator>().enabled = false;
        if(!defaultSprite)
        {
            Debug.Log("No Default Sprite Added!");
        }
        else
        {
            //GetComponent<AudioSource>().Stop();
            GetComponent<SpriteRenderer>().sprite = defaultSprite;
        }
        
    }

    public int GetFanPushPower()
    {
        return fanPushPower;
    }

}
