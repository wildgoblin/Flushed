using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanButton : MonoBehaviour
{
    [SerializeField] List<Fan> fans = new List<Fan>();
    [SerializeField] float pressWaitTime;

    [SerializeField] Color interactableColor;
    [SerializeField] Color notInteractableColor;

    bool fanOff;

    //references
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        //Initialize
        fanOff = false;

        //Get References
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            if (!fanOff)
            {
                ChangeColor(interactableColor);
            }

            if (other.GetComponent<InputController>().Interact() && !fanOff)
            {
                fanOff = true;
                ChangeColor(notInteractableColor);

                foreach (Fan fan in fans)
                {
                    fan.TurnOffFan();
                }

            }
        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        // Return to normal sprite color
        if (!fanOff)
        {
            ChangeColor(Color.white);
        }
    }

    private void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
    }
}
