using NUnit.Framework.Internal;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    //variaveis                                     Podia ser public? Até podia
    [SerializeField] private float moveSpeed = 0; //não é 100% necessário mas é boa prática

    private float speedBase; //vazio por que vamos usar mais tarde e não precissa do inspetor
    private float mediumSpeed1; //^^^^^^

    private int ThingToDestroy = -45;


    public criandoQualidade mapaLogica; //com isso pode mudar a velocidade do mapa que o spawn tbm muda

    void Start()
    {
        mapaLogica = GameObject.FindGameObjectWithTag("mapaLogica").GetComponent<criandoQualidade>(); //esqueçi disso ksksksksk
    }

    // Update is called once per frame
    void Update()
    {
        /*speedBase = moveSpeed / mapaLogica.spawnRate; //media, assim pode alterar um que o outro acompanha
        mediumSpeed1 = moveSpeed;
        float mediumSpeed2 = mediumSpeed1 * speedBase;

        float testeAntigo = speedBase * mapaLogica.spawnRate;

        Debug.Log($"Move speed -> {moveSpeed}");
        Debug.Log($"Base speed -> {speedBase}");
        Debug.Log($"Medium speed part 1 -> {mediumSpeed1}");
        Debug.Log($"Medium speed part 2 -> {mediumSpeed2}"); //TEM QUE SER 15 SE O SPAWN RATE FOR 1.1

        Debug.Log($"Controle de teste -> {testeAntigo}");*/
        //não sei oq eu tô fazendo de errado mais tarde eu termino isso

        transform.position += (Vector3.back * moveSpeed) * Time.deltaTime;

        if(transform.position.z < ThingToDestroy)
        {
            Destroy(gameObject); //funcionou MUITO melhor pegando a posição na real
        }
    }
}
