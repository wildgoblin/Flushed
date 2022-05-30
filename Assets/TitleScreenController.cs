using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenController : MonoBehaviour
{
    [SerializeField] float timeToWait = 2;

    private void Start()
    {
        
        StartCoroutine(WaitToLoad());
    }

    IEnumerator WaitToLoad()
    {
        yield return new WaitForSeconds(timeToWait);
        
        GameManager.instance.NextScene();
    }
}
