using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSwitch : MonoBehaviour
{
    [SerializeField] List<Gate> gates = new List<Gate>();
    [SerializeField] float pressWaitTime;

    bool opening;

    private void Start()
    {
        opening = false;
    }

    IEnumerator OnTriggerStay2D(Collider2D other)
    {
        
        if(other.GetComponent<InputController>().Interact() && !opening)
        {
            opening = true;
            foreach (Gate gate in gates)
            {
            gate.ToggleOpenClose();
            }
            yield return new WaitForSeconds(pressWaitTime);
            opening = false;
        }

    }

}
