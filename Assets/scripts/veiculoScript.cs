using NUnit.Framework.Internal;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class veiculoScript : MonoBehaviour
{
    //variaveis                                     Podia ser public? Até podia
    [SerializeField] private float veiculoMoveSpeed = 0; //não é 100% necessário mas é boa prática

    [SerializeField] private int ThingToDestroy = -45;

    [SerializeField] private GameObject carro;
    [SerializeField] private GameObject caminhao;

    public Collider truck;
    public Collider car;

    logicScript logica;
    pontosPontos pontos;

    void Awake()
    {
        logica = FindAnyObjectByType<logicScript>();
        pontos = FindAnyObjectByType<pontosPontos>();
    }

    void Start()
    {
        //logica = GameObject.FindGameObjectWithTag("tudoLogica").GetComponent<logicScript>();
        /* FindAnyObjectByType<logicScript>()
         * 
         * BEM MELHOR DO QUE CHAMAR O SCRIPT NA REAL
         * salvando pra copiar*/

    }

    // Update is called once per frame
    void Update()
    {



        transform.position += (Vector3.back * veiculoMoveSpeed) * Time.deltaTime;

        if (carro.transform.position.z < ThingToDestroy)
        {
            //Destroy(carro); //se mostrar erro pode ignorar, prefab n tem risco de perder dados (eu acho)
            DestroyImmediate(carro, true);
        }

        if (caminhao.transform.position.z < ThingToDestroy)
        {
            DestroyImmediate(caminhao, true); //isso você uso quando é destruir sem contato
        }
    }


    private void OnTriggerEnter()
    {
        //só achei mais prático definir pra cada um sla
        datenaDetector(truck);
        datenaDetector(car);
    }

    void datenaDetector(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            logica.pontosSave();
            logica.moedaSave();

            pontos.pontuacao = 0;

            SceneManager.LoadScene(2);
            
        }
        
    }
}
