using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class HangManScript : MonoBehaviour
{
   // [SerializeField] - чтобы можно было менять private переменную в приложении Unity

    [SerializeField] private TextMeshProUGUI _hints;
    [SerializeField] private TextMeshProUGUI _hpText; /*TextMeshProUGUI- текстовый класс Unity*/
    [SerializeField] private TextMeshProUGUI _textForScript;
    [SerializeField] private TextMeshProUGUI _textField;
    [SerializeField] private int hp = 7;
    
    
    
    private List<char> guessedLetters = new List<char>();/* массив типа List постоянно увеличивающийя 
                                                           с добавлением в него новых переменных*/
    
    private List<char> wrongTriedLetter = new List<char>();

    /* массив типа String. в нем хранятся переменные строчного типа(слова)*/
    private string[] words =
    {
        "Ball",
        "Girl",
        "Suspect",
        "Mouse",
        "Glitch",
        "Grenade",
        "Pencil",
        "Flowers",
        "Tea",
        "Pig",
        "Mushrooms"
    };
    
    private string[] hints =
    {
        "A round object used in different games.",
        "Boys and ...",
        "People at crime case.",
        "Animal and computer device.",
        "A short-lived fault in a system.",
        "Round weapon that explodes after time.",
        "Cylinder thing for drawing.",
        "Girls love gift like that.",
        "England people like to drink.",
        " 'SALO' ",
        "Grows in forests on the ground."
    };

   
    private string hintWord = "Hint:";
    
    private string wordToGuess = "";/*задаем угадываемуму слову тип String*/

    private KeyCode lastKeyPressed;

    private void Start()
    {
        /*задаем параметр randomIndex равным рандомному порядковому числу переменной в массиве words*/
        int randomIndex = Random.Range(0, words.Length);
        /*присваиваем слово из массива с порядковым номером randomIndex, угадываемому слову*/
        wordToGuess = words[randomIndex];
        
        hintWord += hints[randomIndex];/*добавляем слово из массива подсказок с порядковым номером randomIndex к подсказке*/
        /*задем строковую переменную initialWord(начальное слово)*/
        string initialWord = "";
        for (int i = 0; i < wordToGuess.Length; i++)/*создаем цикл, в котором добовляем в переменную 
        iniialWord " _" за каждую букву в угадываемом слове wordToGuess */
        {                                            
            initialWord += " _";
        }
        /*присваеваем получившееся значение начального слова к тексту в сцене Unity */
        _textField.text = initialWord;
        /*присваеваем угадываемое слово (большими буквами) к спрятанному тексту в сцене, для скрипта
         отображения нажатых клавиш*/
        _textForScript.text = wordToGuess.ToUpper();
        /*присваиваю значение hp тексту в сцене, попутно переведя переменную типа integer в string*/
        _hpText.text = hp.ToString();

        _hints.text = hintWord;
    }
    
    private void OnGUI()/* код для чтения вводимых клавиш с клавиатуры*/
    {
        Event e = Event.current;
        if (e.isKey)
        {
            
            if (e.keyCode != KeyCode.None && lastKeyPressed != e.keyCode)/*условие: если вводимый символ не равен
            None и последний вводимый символ не равен вводимому символу*/
            {
                ProcessKey(e.keyCode);
                
                lastKeyPressed = e.keyCode;/*тогда последний вводимый символ равен вводимому символу*/
                //Debug.Log("detected key code:" + e.keyCode);
            }
        }
    }

    
    
    private void ProcessKey(KeyCode key)
    {
        print("Key Pressed: " + key);/*вывоит в консоль набранный символ*/

        char pressedKeyString = key.ToString()[0];/*символьная переменная pressedKeyString равная
        первому символу KeyCode вводимому с клавиатуры*/

        string wordUppercase = wordToGuess.ToUpper();/*переводим угадываемое слово в "словоКапсом"*/

        bool wordContainsPressedKey = wordUppercase.Contains(pressedKeyString);/*задаю логическую переменную: 
        если угадываемое слово содержит вводимый символ,то true*/

        bool letterWasGuessed = guessedLetters.Contains(pressedKeyString);/* задаю логическую переменную:
        если вводимый символ содержится в массиве List, то выводит true */

        if (!wordContainsPressedKey && !wrongTriedLetter.Contains(pressedKeyString))/* условие : если угадываемое
        слово не содержит вводимый символ и массив List с неправильно введенными символами не содержит вводимый символ*/
        {
            wrongTriedLetter.Add(pressedKeyString);/*добавляем в массив неправильных букв (List) вводимый символ*/
            hp -= 1; /*отнимаем у значения переменной HP единицу*/

            if (hp <= 0)
            {
                SceneManager.LoadSceneAsync(sceneBuildIndex: 2); /*если значение HP меньше либо равно 0, то грузим
                сцену №2 из BuildSettings*/
            }
            else
            {
                _hpText.text = hp.ToString();/*в другом случае выводим  значение HP через текст в сцене Unity*/
            }
            
        }
        

        if (wordContainsPressedKey && !letterWasGuessed)/*если угадываемое слово содержит вводимый символ и
        буква не была угадана*/
        {
            guessedLetters.Add(pressedKeyString);/*добавляем в массив угаданных букв List введенную букву*/
        }

        string stringToPrint = "";

        for (int i = 0; i < wordUppercase.Length; i++) /*цикл  в котором проверяется каждая буква угадываемого слова*/
        {
            char letterInWord = wordUppercase[i]; /*добавляем символьную переменную равную букве из угадываемого слова 
            под номером "i"*/

            if (guessedLetters.Contains(letterInWord))/* условие: если массив с угаданными буквами содержит букву  из 
            угадываемого слова,то ..*/
            {
                stringToPrint += letterInWord; /*то добавляем в выводимую строку угаданную букву*/
            }
            else
            {
                stringToPrint += " _"; /*то выводим "_" вместо буквы*/
            }
        }

        if (wordUppercase == stringToPrint) /* если выводимая строка равна угадываемому слову, то выводим сцену №3 из 
        BuildSettings*/
        {
            SceneManager.LoadSceneAsync(sceneBuildIndex: 3);
        }
        
        _textField.text = stringToPrint; //выводим строку в сцену 
    }
}
