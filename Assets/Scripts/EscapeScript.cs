using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeScript : MonoBehaviour
{
   
  
    void Update()
    {
        //код, который работает при нажатии на кнопку Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        { /*код, который загружает сцену №0 из BuildSettings*/
            SceneManager.LoadSceneAsync(sceneBuildIndex: 0);
            
        }
    }
}