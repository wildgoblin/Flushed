using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSwitch : MonoBehaviour
{
    [SerializeField] List<Gate> gates = new List<Gate>();
    [SerializeField] float pressWaitTime;

    [SerializeField] Color interactableColor;
    [SerializeField] Color notInteractableColor;

    [SerializeField] AudioClip turningWheelSFX;

    [SerializeField] AudioClip togglingGateSFX;

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
        if (other.GetComponent<Player>())
        {
            if(!opening)
            {
                ChangeColor(interactableColor);
            }
            
            if (other.GetComponent<InputController>().Interact() && !opening)
            {
                opening = true;
                ChangeColor(notInteractableColor);

                AudioSource.PlayClipAtPoint(turningWheelSFX, Camera.main.transform.position);

                GetComponent<Animator>().SetTrigger("turnWheel");

                StartCoroutine(ToggleGates());


                yield return new WaitForSeconds(pressWaitTime);
                opening = false;
            }
        }

    }

    IEnumerator ToggleGates()
    {
        yield return new WaitForSeconds(1);
        AudioSource.PlayClipAtPoint(togglingGateSFX, Camera.main.transform.position);
        foreach (Gate gate in gates)
        {
            gate.ToggleOpenClose();
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
