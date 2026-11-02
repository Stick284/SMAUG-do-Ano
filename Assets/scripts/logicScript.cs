/*esse script basicamente vai cuidar de tudo que não faira ideia de como eu colocaria
 * então isso vai ter TUDO mesmo que não use agora, sla a sorte ajuda quem prepare né?
 */

//bibliotecas
using NUnit.Framework.Internal;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
//bibliotecas


public class logicScript : MonoBehaviour
{
    //váriaveis
    private bool dificuldadeCheck = false;
    private string pagamentoCLT = "Moedas";
    private string pontosPontuados = "Pontuação";

    private int moedaQuantia;
    private int maxPontosQuantia;

    private float tempoSpeed = 2;
    public float timerDificuldade = 2;


   [SerializeField] float mapaEspaço = 15f; //sabendo que 1 spawn rate e 15 mapa speed ficam basicamente perfeitos.
    //váriaveis

    pontosPontos pontos; //BEM melhor do que eu fiz antes
    
    /*void Start()
    {
        menu.pontuacaoPontuada.text = $"Score: {pontos.pontuacao}";
        menu.moedaBoa.text = $"R$ {pontos.economiaBoa},00";
    }*/

    void Awake()
    {
        pontos = FindAnyObjectByType<pontosPontos>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pontos.maxPontos();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pontos.addMoneyCheck(gameObject);
        }
    }

    public void moedaSave()
    {
        PlayerPrefs.SetInt(pagamentoCLT, pontos.economiaBoa);
        PlayerPrefs.Save();
    }
    public void pontosSave()
    {
        if (pontos.pontuacao >= pontos.pontuacaoMaximo)
        {
            pontos.pontuacaoMaximo = pontos.pontuacao;
        }

        PlayerPrefs.SetInt(pontosPontuados, pontos.pontuacaoMaximo);
        PlayerPrefs.Save();

        /*PlayerPrefs.SetInt(pontosPontuados, pontos.pontuacao);
        PlayerPrefs.Save();*/
    }

    public void moedaLoad()
    {
        moedaQuantia = PlayerPrefs.GetInt(pagamentoCLT, 0); //0 é o default, se não encontrar valor define 0
        pontos.economiaBoa = moedaQuantia;
    }
    public void pontosLoad()
    {
        maxPontosQuantia = PlayerPrefs.GetInt(pontosPontuados, 0);
        pontos.pontuacaoMaximo = maxPontosQuantia;

    }
}
