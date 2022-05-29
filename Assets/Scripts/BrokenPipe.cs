using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPipe : MonoBehaviour
{
    enum Direction { up, down, left, right };
    [SerializeField] Direction waterDirection;

    [SerializeField] int forcePower;

    [SerializeField] AudioClip patchHoleSound;
    [SerializeField] AudioClip deathSFX;

    bool holeIsPatched;

    private void Start()
    {
        transform.GetChild(0).gameObject.SetActive(true); // Water Steram
        transform.GetChild(1).gameObject.SetActive(false); //bandaid patch
        transform.GetChild(2).gameObject.SetActive(true); // Whoosh Lines
        holeIsPatched = false;
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // TODO if player has bandaid

        
        if (otherCollider.GetComponent<Player>())
        {
            Player player = otherCollider.GetComponent<Player>();

            if (player.GetBandaidCount() >= 1)
            {
                player.RemoveBandaid();
                PatchHoleWithBandaid();
            }

            else if(!holeIsPatched)
            {
                //If Player does not have bandaid
                switch (waterDirection)
                {
                    case Direction.up:
                        player.DeathByBrokenPipe(Vector3.up, forcePower);
                        break;
                    case Direction.down:
                        player.DeathByBrokenPipe(Vector3.down, forcePower);
                        break;
                    case Direction.left:
                        player.DeathByBrokenPipe(Vector3.left, forcePower);
                        break;
                    case Direction.right:
                        player.DeathByBrokenPipe(Vector3.right, forcePower);
                        break;
                    default:
                        break;
                }

                StartCoroutine(WaitThenReloadScene());
            } 
            
            

            IEnumerator WaitThenReloadScene()
            {
                AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
                yield return new WaitForSeconds(2);
                GameManager.instance.ReloadScreen();
            }
            //WaitForSeconds and restart
        }
    }
    private void PatchHoleWithBandaid()
    {
        if(patchHoleSound == null)
        {
            Debug.Log("Missing AudioClip on " + this);
        }
        else
        {
            AudioSource.PlayClipAtPoint(patchHoleSound, Camera.main.transform.position);
        }

        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(false);
        holeIsPatched = true;
    }
}
