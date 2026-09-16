using UnityEngine;
using UnityEngine.SceneManagement; //ISSO PRECISSA ADICIONAR


public class menuScript : MonoBehaviour
{
    void SceneStart()
    {
        SceneManager.LoadScene(1);
    }

    void SceneEnd()
    {
        Application.Quit();
    }
}
