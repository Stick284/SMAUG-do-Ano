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
    menuScript menu;
    criandoQualidade mapaCriador;
    movementScript mapaSpeed;
    veiculoScript obstaculoLogica;

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
        obstaculoLogica = FindAnyObjectByType<veiculoScript>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pontos.maxPontos();
        //dificuladeAumenta();

        Debug.Log($"-------------------------------------------------");
        Debug.Log($"Mapa speed {mapaSpeed.mapaMoveSpeed}");
        Debug.Log($"Mapa spawn {mapaCriador.spawnRate}");
        //Debug.Log($"Obstaculo speed {obstaculoLogica.obstaculoSpeed}");
        Debug.Log($"Obstaculo spawn {mapaCriador.spawnRateObj}");
        Debug.Log($"timer speed {tempoSpeed}");
        Debug.Log($"timer dificuldade {timerDificuldade}");
        Debug.Log($"-------------------------------------------------");
    }

    public void dificuladeAumenta()
    {
        /*if (tempoSpeed < 2 && dificuldadeCheck!)
        {
            tempoSpeed -= Time.deltaTime;
        } else
        {
            dificuldadeCheck = true;
        } //isso basicamente resolve o jogo travando logo na cara*/

        if (tempoSpeed < timerDificuldade)
        {
            tempoSpeed -= Time.deltaTime;
        }
        else
        {
            tempoSpeed = 0;

            mapaSpeed.mapaMoveSpeed += 0.2f;
            obstaculoLogica.obstaculoSpeed += 0.2f;

            if (mapaSpeed.mapaMoveSpeed >= 60 || obstaculoLogica.obstaculoSpeed >= 76)
            {
                mapaSpeed.mapaMoveSpeed = 60;
                obstaculoLogica.obstaculoSpeed = 76;

                mapaCriador.spawnRate = 0.25f;
                mapaCriador.spawnRateObj = 0.5f;
            }

            mapaCriador.spawnRate = mapaEspaço / mapaSpeed.mapaMoveSpeed;

            mapaCriador.spawnRateObj = mapaEspaço / obstaculoLogica.obstaculoSpeed;
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
