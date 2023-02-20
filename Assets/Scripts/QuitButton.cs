using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
   
    public void QuitGame()
    {
        Application.Quit();/* если нажать на кнопку, игра закроется(в сцене на "on click" добавляем кнопку на которую по
        нажатию хотим выйти и выбираем QuitGame()*/
    }
  
}