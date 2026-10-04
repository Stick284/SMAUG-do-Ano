using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; //ISSO PRECISSA ADICIONAR

public class menuScript : MonoBehaviour
{
    logicScript logica;

    void Awake()
    {
        logica = FindAnyObjectByType<logicScript>();
    }

    public void startScene()
    {
        logica.moedaLoad();
        logica.pontosLoad();
        SceneManager.LoadScene(1);

    }

    public void endScene()
    {
        Application.Quit();
    }

    public void resetScene() 
    {
        SceneManager.LoadScene(0);
    }

    public void gameOverReturn()
    {
        logica.moedaLoad();
        logica.pontosLoad();
        SceneManager.LoadScene(2);

    }
}