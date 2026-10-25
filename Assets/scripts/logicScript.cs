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
    private string pagamentoCLT = "Moedas";
    private string pontosPontuados = "Pontuação";

    private int moedaQuantia;
    private int maxPontosQuantia;

    private float tempoSpeed;
    public float contagemSpeed = 0.15f;
    //váriaveis

    pontosPontos pontos; //BEM melhor do que eu fiz antes
    menuScript menu;
    criandoQualidade mapaCriador;
    movementScript mapaSpeed;

    /*void Start()
    {
        menu.pontuacaoPontuada.text = $"Score: {pontos.pontuacao}";
        menu.moedaBoa.text = $"R$ {pontos.economiaBoa},00";
    }*/

    void Awake()
    {
        pontos = FindAnyObjectByType<pontosPontos>();
        menu = FindAnyObjectByType<menuScript>();
        mapaCriador = FindAnyObjectByType<criandoQualidade>();
        mapaSpeed = FindAnyObjectByType<movementScript>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pontos.maxPontos();
        //speedAumenta();

        Debug.Log($"Mapa speed {mapaSpeed.mapaMoveSpeed}");
        Debug.Log($"Mapa spawn {mapaCriador.spawnRate}");
        /*Debug.Log($"");
        Debug.Log($"");
        Debug.Log($"");
        Debug.Log($"");
        Debug.Log($"");
        Debug.Log($"");
        Debug.Log($"");
        Debug.Log($"");
        Debug.Log($"");
        Debug.Log($"");
        Debug.Log($"");
        Debug.Log($"");
        Debug.Log($"");
        Debug.Log($"");*/


        /*if (pontos.contagemPermitida)
        {
            Debug.Log("----------------------------------------------");
            Debug.Log($"Moedas atualmente: {pontos.economiaBoa}");
            Debug.Log($"Pontos atualmente 1: {pontos.pontosTemporado}");
            Debug.Log($"Pontos atualmente 2: {pontos.pontosContagem}");
            Debug.Log($"Pontos atualmente 3: {pontos.pontuacao}");
            
            //debug
             
        }*/
    }

    public void speedAumenta()
    {
        if (tempoSpeed < contagemSpeed)
        {
            tempoSpeed += Time.deltaTime;
        }
        else
        {
            mapaSpeed.mapaMoveSpeed += 0.02f;
            mapaCriador.spawnRate -= 0.002f;
        }

        if (mapaCriador.spawnRate <= 0.2)
        {
            mapaCriador.spawnRate = 0.2f;
        }
        if (mapaSpeed.mapaMoveSpeed >= 30)
        {
            mapaSpeed.mapaMoveSpeed = 30;
        }

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
