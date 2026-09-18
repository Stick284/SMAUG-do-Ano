using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; //ISSO PRECISSA ADICIONAR


//[RequireComponent(typeof(OnButtonClick))]
public class menuScript : MonoBehaviour
{
    public void startScene()
    {
        SceneManager.LoadScene(1);
    }

    public void endScene()
    {
        Application.Quit();
    }
}