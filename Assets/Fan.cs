using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] int fanPushPower;


    public void TurnOffFan()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public int GetFanPushPower()
    {
        return fanPushPower;
    }

}
