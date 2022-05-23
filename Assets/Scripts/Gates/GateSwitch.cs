using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSwitch : MonoBehaviour
{
    [SerializeField] List<Gate> gates = new List<Gate>();
    [SerializeField] float pressWaitTime;

    [SerializeField] Color interactableColor;
    [SerializeField] Color notInteractableColor;

    bool opening;

    //references
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        //Initialize
        opening = false;

        //Get References
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    IEnumerator OnTriggerStay2D(Collider2D other)
    {
        
        if(other.GetComponent<InputController>().Interact() && !opening)
        {
            opening = true;
            ChangeColor(notInteractableColor);
            foreach (Gate gate in gates)
                {
                gate.ToggleOpenClose();
                }
            yield return new WaitForSeconds(pressWaitTime);
            ChangeColor(interactableColor);
            opening = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Player>())
        {
            ChangeColor(interactableColor);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Return to normal sprite color
        ChangeColor(Color.white); 
    }

    private void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
    }

}
