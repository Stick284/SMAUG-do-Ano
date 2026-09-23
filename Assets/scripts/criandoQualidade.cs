using NUnit.Framework.Internal;
using Unity.VisualScripting;
using UnityEngine;

public class criandoQualidade : MonoBehaviour
{
    //váriaveis para criar o mapa e objetos
    [SerializeField] private GameObject mapa;

    //esse tem que ser public pq to usando comunicação entre dois scripts
    public float spawnRate = 2;
    [SerializeField] private float spawnRateObj = 2;

    private float tempoTemporado = 0;
    private float objTemporado = 0;
    private float moedasTemporado = 0;


    [SerializeField] private GameObject[] objetosLista;
    [SerializeField] private Transform[] anchorPoints;
    [SerializeField] private GameObject moedas;
    private int anchor; //deixa vazio pq o Random cuida
    //váriaveis para criar obstáculos


    //chamando scripts
    public caminhaoRaycast rayCaminhao;
    public carroRaycast rayCarro;

    private bool anchorLock0;
    private bool anchorLock1;
    private bool anchorLock2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tempoTemporado = 2; //já pula o timer pra criar uma nova chunk pq ele demora de primeira

        rayCaminhao = GameObject.FindGameObjectWithTag("tudoLogica").GetComponent<caminhaoRaycast>();
        rayCarro = GameObject.FindGameObjectWithTag("tudoLogica").GetComponent<carroRaycast>();

    }

    // Update is called once per frame
    void Update()
    {
        criadorMapa();
        criadorObstaculos();
        criadorMoedas();

        /*anchorLock0 = rayCaminhao.detectRayTruck_0();
        anchorLock1 = rayCaminhao.detectRayTruck_1();
        anchorLock2 = rayCaminhao.detectRayTruck_2();*/
        //isso verifica se pode ou não usar o instantiate
        //NÃO ESTÁ COMPLETO É QUE É 2 DA MADRU E N TO COM CABEÇA QwQ

    }

    void criadorMapa()
    {
        //código que faz a magia
        if (tempoTemporado < spawnRate)
        {
            tempoTemporado += Time.deltaTime;
        }
        else
        {
            Instantiate(mapa, transform.position, transform.rotation); //transform.positon e rotation basicamente faz com que seja a mesma do objeto
            tempoTemporado = 0;
        }
    }

    void criadorObstaculos() //LITERAL UM CTRL C CTRL V KSKSKSKSKSKSKSKS
    {
        if (objTemporado < spawnRateObj)
        {
            objTemporado += Time.deltaTime;
        }
        else
        {
            int anchorRNG = Random.Range(0, anchorPoints.Length); //escolhe qual ancora o objeto vai
            int objRNG = Random.Range(0, objetosLista.Length);

            //var teste = new Vector3(anchorPoints[anchorRNG].position.x, transform.position.y, transform.position.z);

            Instantiate(objetosLista[objRNG], anchorPoints[anchorRNG].transform.position, objetosLista[objRNG].transform.rotation); //transform.positon e rotation basicamente faz com que seja a mesma do objeto
            
            objTemporado = 0;

        }
    }

    void criadorMoedas()
    {
        if (moedasTemporado < spawnRateObj)
        {
            moedasTemporado += Time.deltaTime;
        }
        else
        {
            int anchorRNG = Random.Range(0, anchorPoints.Length); //escolhe qual ancora o objeto vai
            

            Instantiate(moedas, anchorPoints[anchorRNG].transform.position, moedas.transform.rotation); //transform.positon e rotation basicamente faz com que seja a mesma do objeto

            moedasTemporado = 0;

        }
    }
}
