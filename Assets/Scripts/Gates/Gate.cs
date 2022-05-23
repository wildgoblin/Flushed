using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] bool closed;


    private void Start()
    {
        ToggleOpenClose();
    }
    public void ToggleOpenClose()
    {
        closed = !closed;
        this.gameObject.SetActive(closed);
    }
}
