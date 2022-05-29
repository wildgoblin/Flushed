using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   public void ReloadScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
