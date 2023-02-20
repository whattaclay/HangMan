using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

using Button = UnityEngine.UI.Button;

namespace DefaultNamespace
{
    public class Sprites : MonoBehaviour
    {
        [SerializeField] private Button hmGameObject;//добавляю кнопку, котрая будет менять на себе спрайты
        private int hp;//переменная, чтобы считывать показания HP с текста в сцене
        [SerializeField] private TextMeshProUGUI hpCounter;//переменная, чтобы работать с текстом hp со сцены
        public Sprite[] spriteImages;//задаем массив спрайтов
        void Update()
        {
            hp = hpCounter.text[0];//собственно считываем текст hp со сцены;
            
           
            switch (hp)//если хп соответствует  case(true) то выполняется действие
            {
                case 54: 
                    hmGameObject.image.sprite = spriteImages[0];//загружается картинка из массива под номером "0"
                    
                    break;
                case 53: 
                    hmGameObject.image.sprite = spriteImages[1];
                    
                    break;
                case 52: 
                    hmGameObject.image.sprite = spriteImages[2];
                    
                    break;
                case 51: 
                    hmGameObject.image.sprite = spriteImages[3];
                  
                    break;
                case 50: 
                    hmGameObject.image.sprite = spriteImages[4];
                    
                    break;
                case 49: 
                    hmGameObject.image.sprite = spriteImages[5];
                   
                    break;
        
        
            }
        }
    }
}