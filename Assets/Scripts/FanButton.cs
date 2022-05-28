using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanButton : MonoBehaviour
{
    [SerializeField] List<Fan> fans = new List<Fan>();
    [SerializeField] Sprite unPressedSprite;
    [SerializeField] Sprite pressedSprite;
    [SerializeField] float pressWaitTime;

    [SerializeField] Color interactableColor;

    bool fanOff;

    //references
    SpriteRenderer spriteRenderer;

    private void Awake()
    {


        //Get References
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Initialize
        fanOff = false;
        spriteRenderer.sprite = unPressedSprite;

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
                spriteRenderer.sprite = pressedSprite;
                ChangeColor(Color.white);

                GetComponent<AudioSource>().Play();

                foreach (Fan fan in fans)
                {
                    fan.TurnOffFan();

                }

            }
        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        ChangeColor(Color.white);

    }

    private void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
    }
}
