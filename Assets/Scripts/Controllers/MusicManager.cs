using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [SerializeField] AudioClip aquariumMusic;
    [SerializeField] AudioClip mainGameMusic;
    [SerializeField] AudioClip endScreenMusic;

    AudioSource audioSource;
    
    void Awake()
    {
        //references
        audioSource = GetComponent<AudioSource>();

        Initialize();
    }

    void Initialize()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }


    public void ToggleMute()
    {
        audioSource.mute = !audioSource.mute;
    }

    public IEnumerator StartMainGameMusic()
    {
        yield return new WaitForSeconds(0);
        audioSource.clip = mainGameMusic;
        ToggleMute();
        audioSource.Play();        
    }

}
