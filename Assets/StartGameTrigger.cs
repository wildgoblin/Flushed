using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameTrigger : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(MusicManager.instance.StartMainGameMusic());
    }

}
