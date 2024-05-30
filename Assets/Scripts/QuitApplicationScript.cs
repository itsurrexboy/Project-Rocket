using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplicationScript : MonoBehaviour
{
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
        Application.Quit();
            Debug.Log("Escape key is pressed!");
        }
    }
}
