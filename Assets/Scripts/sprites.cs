using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

using Button = UnityEngine.UI.Button;

namespace DefaultNamespace
{
    public class sprites : MonoBehaviour
    {
        [SerializeField] private Button hmGameObject;
        private int hp;
        [SerializeField] private TextMeshProUGUI hpCounter;
        public Sprite[] spriteImages;
        void Update()
        {
            hp = hpCounter.text[0];
            
           
            switch (hp)
            {
                case 54: 
                    hmGameObject.image.sprite = spriteImages[0];
                    
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