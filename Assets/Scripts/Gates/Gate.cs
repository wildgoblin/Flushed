using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] bool open;
    


    private void Start()
    {
        ToggleOpenClose();
    }
    public void ToggleOpenClose()
    {
        open = !open;
        
        this.gameObject.SetActive(open);
    }
}
