using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int fishCharacterSeleectIndex = 99; // TODO Fix. Hacky was to avoid disabling fish 0 on first game start. 

    private Sprite characterSprite;
    void Awake()
    {
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

    
    public void SetCharacterSprite(Sprite sprite)
    {
        characterSprite = sprite;
    }

    public Sprite GetCharacterSprite()
    {
        return characterSprite;
    }

    public void NextScene()
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        if(activeScene == 11) // Level 10
        {
            MusicManager.instance.GetComponent<AudioSource>().Stop();
        }
        SceneManager.LoadScene(activeScene + 1);
    }

   public void ReloadScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadCharacterSelectScene()
    {
        SceneManager.LoadScene(1); // Character Select
    }

    public void UpdateFishCharacterSelectIndex(int index)
    {
        fishCharacterSeleectIndex = index;
    }

    public int GetFishCharacterSelectIndex()
    {
        return fishCharacterSeleectIndex;
    }


}
