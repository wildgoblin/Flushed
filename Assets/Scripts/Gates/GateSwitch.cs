using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] List<Gate> gates = new List<Gate>();

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (Event.current.Equals(Event.KeyboardEvent("interact")))
        {
            Debug.Log("Space was pressed in trigger range");
        }
    }

    public void Interact()
    {

    }
}
