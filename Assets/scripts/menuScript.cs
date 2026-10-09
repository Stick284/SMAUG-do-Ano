using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; //ISSO PRECISSA ADICIONAR

public class menuScript : MonoBehaviour
{
    logicScript logica;
    pontosPontos pontos;
    
    public TextMeshPro pontuacaoPontuada;
    public TextMeshPro moedaBoa;
    public bool menuContagem;

    void Awake()
    {
        logica = FindAnyObjectByType<logicScript>();
        pontos = FindAnyObjectByType<pontosPontos>();
    }

    void FixedUpdate()
    {
        if (menuContagem)
        {
            pontuacaoPontuada.SetText($"Highscore: {pontos.pontuacaoMaximo}");
            moedaBoa.SetText($"R$ {pontos.economiaBoa},00");
        }
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