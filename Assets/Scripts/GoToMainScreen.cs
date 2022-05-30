using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMainScreen : MonoBehaviour
{
    public void GoToCharacterSelect()
    {
        GameManager.instance.LoadCharacterSelectScene();
    }
}
