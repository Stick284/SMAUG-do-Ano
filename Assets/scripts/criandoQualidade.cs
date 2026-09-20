using NUnit.Framework.Internal;
using Unity.VisualScripting;
using UnityEngine;

public class criandoQualidade : MonoBehaviour
{
    //váriaveis para criar o mapa
    [SerializeField] private GameObject mapa;
    public float spawnRate = 2; //esse tem que ser public pq to usando comunicação entre dois scripts
    private float tempoTemporado = 0;
    //váriaveis para criar o mapa

    //váriaveis para criar obstáculos
    [SerializeField] private float spawnRateObj = 2;
    private float objTemporado = 0;

    [SerializeField] private GameObject[] objetosLista;
    //[SerializeField] private GameObject obstaculo; ainda ñ fiz um item de deslizar

    [SerializeField] private Transform[] anchorPoints;
    private int anchor; //deixa vazio pq o Random cuida
    //váriaveis para criar obstáculos

    //chamando scripts
    public caminhaoRaycast raycastCaminhao;
    public carroRaycast raycastCarro;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tempoTemporado = 2; //já pula o timer pra criar uma nova chunk pq ele demora de primeira

    }

    // Update is called once per frame
    void Update()
    {
        criadorMapa();
        criadorObstaculos();

        /*Debug.Log($"Timer {tempoTemporado}");
        Debug.Log($"Timer Spawn {spawnRate}");
        Debug.Log($"Timer Obj {spawnRateObj}");*/
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

            Instantiate(objetosLista[1], anchorPoints[anchorRNG].transform.position, objetosLista[1].transform.rotation); //transform.positon e rotation basicamente faz com que seja a mesma do objeto
            
            objTemporado = 0;

            /*Debug.Log($"Somente a posição -> {anchorPoints[anchorRNG].position}");
            Debug.Log($"Transformar + Posição -> {anchorPoints[anchorRNG].transform.position}");
            Debug.Log($"Ancoras Random -> {anchorRNG}");
            Debug.Log($"Ancoras Array -> {anchorPoints[anchorRNG]}");*/
        }
    }
}
