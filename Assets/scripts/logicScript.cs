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
    //váriaveis

    //public pontosPontos pontos;


    void Start()
    {
        //pontos = GetComponent<pontosPontos>();

    }   

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //onlyDebug();
        Debug.Log($"Moedas atualmente: {FindAnyObjectByType<pontosPontos>().economiaLixo}");

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindAnyObjectByType<pontosPontos>().addMoneyCheck(gameObject);
        }
    }

    void moedaSave()
    {
        PlayerPrefs.SetInt(pagamentoCLT, FindAnyObjectByType<pontosPontos>().economiaLixo);
        PlayerPrefs.Save();
    }
    void pontosSave()
    {
        if (FindAnyObjectByType<pontosPontos>().pontuacao > FindAnyObjectByType<pontosPontos>().pontuacaoMaximo)
        {
            FindAnyObjectByType<pontosPontos>().pontuacao = FindAnyObjectByType<pontosPontos>().pontuacaoMaximo;
            PlayerPrefs.SetInt(pontosMax, FindAnyObjectByType<pontosPontos>().pontuacaoMaximo);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt(pontosMin, FindAnyObjectByType<pontosPontos>().pontuacao);
            PlayerPrefs.Save();
            //nem sei onde eu usaria os pontos minimos mas sla depois a gente da uma olhada
        }
    }

    void moedaLoad()
    {
        PlayerPrefs.GetInt(pagamentoCLT, FindAnyObjectByType<pontosPontos>().economiaLixo);
    }
    void pontosLoad()
    {
        PlayerPrefs.GetInt(pontosMax, FindAnyObjectByType<pontosPontos>().pontuacaoMaximo);
    }
}
