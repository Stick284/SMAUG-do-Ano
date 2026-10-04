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
    private string pagamentoCLT = "Moedas Contagem";
    private string pontosMax = "Pontos Maximo";
    private string pontosMin = "Pontos Minímo";

    private int moedaQuantia;
    private int minPontosQuantia;
    private int maxPontosQuantia;
    //váriaveis

    pontosPontos pontos; //BEM melhor do que eu fiz antes

    void Start()
    {

    }   

    void Awake()
    {
        pontos = FindAnyObjectByType<pontosPontos>();
    }

    // Update is called once per frame
    void Update()
    {
        //onlyDebug();
        Debug.Log($"Moedas atualmente: {pontos.economiaLixo}");

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
        PlayerPrefs.SetInt(pagamentoCLT, pontos.economiaLixo);
        PlayerPrefs.Save();
    }
    public void pontosSave()
    {
        if (pontos.pontuacao > pontos.pontuacaoMaximo)
        {
            pontos.pontuacao = pontos.pontuacaoMaximo;
            PlayerPrefs.SetInt(pontosMax, pontos.pontuacaoMaximo);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt(pontosMin, pontos.pontuacao);
            PlayerPrefs.Save();
            //nem sei onde eu usaria os pontos minimos mas sla depois a gente da uma olhada
        }
    }

    public void moedaLoad()
    {
        moedaQuantia = PlayerPrefs.GetInt(pagamentoCLT, 0); //0 é o default, se não encontrar valor define 0
        pontos.economiaLixo = moedaQuantia;
    }
    public void pontosLoad()
    {
        maxPontosQuantia = PlayerPrefs.GetInt(pontosMax, 0);
        pontos.pontuacaoMaximo = maxPontosQuantia;
    }
}
