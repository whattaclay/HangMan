using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class LetterScript : MonoBehaviour
{   
    [SerializeField] private TextMeshProUGUI _guesedWord;/*угадываемое слово*/
    [SerializeField] private GameObject panel;/* крестик на неправильных буквах */
    [SerializeField] private TextMeshProUGUI _keyText;/* буква с клавиатуры*/

    

    private KeyCode lastKeyPressed;

    
    

    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {

            if (e.keyCode != KeyCode.None && lastKeyPressed != e.keyCode)
            {
                lastKeyPressed = e.keyCode;
                ProcessKey(e.keyCode);
            }
        }
    }

    public void ProcessKey(KeyCode key)//происходит по нажатию клавиши
    {
        char pressedKeyString = key.ToString()[0]; //символьная переменная равная вводимому символу

        string wordUppercase = _guesedWord.text.ToUpper();//переводим угадываемое слово в "словокапсом"
        
       
        if (!wordUppercase.Contains(pressedKeyString) && pressedKeyString == _keyText.text[0]) /*условие: если угадываемое 
        слово не содержит вводимый символ и вводимый символ равен символу с клавиатуры(из сцены)*/
        {
                panel.SetActive(true);//включаем панель на сцене(красный крестик)
        }
        
    }

    
    
} 
    