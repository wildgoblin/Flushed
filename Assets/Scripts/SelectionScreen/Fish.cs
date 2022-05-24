using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Fish : MonoBehaviour
{
    [SerializeField] Sprite unselectedFish;
    [SerializeField] Sprite selectedFish;

    //references
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = unselectedFish;

        if(!unselectedFish || !selectedFish)
        {
            Debug.Log(gameObject + " does not have all fish selection options added to Fish.cs");
        }
    }

    public void ChangeToSelectedFish()
    {
        spriteRenderer.sprite = selectedFish;
    }

    public void ChangeToUnselectedFish()
    {
        spriteRenderer.sprite = unselectedFish;
    }
}
