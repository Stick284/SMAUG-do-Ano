using NUnit.Framework.Internal;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class veiculoScript : MonoBehaviour
{
    //variaveis                                     Podia ser public? Até podia
    [SerializeField] private float obstaculoSpeed = 0; //não é 100% necessário mas é boa prática

    [SerializeField] private int ThingToDestroy = -45;

    [SerializeField] private GameObject carro;
    [SerializeField] private GameObject caminhao;

    public Collider truck;
    public Collider car;

    logicScript logica;
    pontosPontos pontos;

    void Start()
    {
        logica = FindAnyObjectByType<logicScript>();
        pontos = FindAnyObjectByType<pontosPontos>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += (Vector3.back * obstaculoSpeed) * Time.deltaTime;

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
