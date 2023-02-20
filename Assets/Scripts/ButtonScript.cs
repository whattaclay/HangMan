using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class ButtonScript : MonoBehaviour
    {
        //[SrializeField] - чтобы можно было менять параметр с доступом private  в Unity
        [SerializeField] private string sceneName;

        public void Load()
        {
            //код,чтобы грузить сцену по точному имени - sceneName
            SceneManager.LoadSceneAsync(sceneName);
        }
    }

}
