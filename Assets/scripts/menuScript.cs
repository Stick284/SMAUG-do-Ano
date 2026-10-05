using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; //ISSO PRECISSA ADICIONAR

public class menuScript : MonoBehaviour
{
    logicScript logica;
    pontosPontos pontos;

    void Awake()
    {
        logica = FindAnyObjectByType<logicScript>();
        pontos = FindAnyObjectByType<pontosPontos>();
    }

    public void startScene()
    {
        pontos.pontuacao = 0;

        SceneManager.LoadScene(1);

        logica.moedaLoad();
        logica.pontosLoad();

    }

    public void endScene()
    {
        pontos.pontuacao = 0;

        Application.Quit();

    }

    public void resetScene() 
    {
        pontos.pontuacao = 0;

        SceneManager.LoadScene(0);

    }

    public void gameOverReturn()
    {
        pontos.pontuacao = 0;

        SceneManager.LoadScene(2);

        logica.moedaLoad();
        logica.pontosLoad();

    }
}