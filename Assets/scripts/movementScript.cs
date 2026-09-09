using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    //variaveis                                     Podia ser public? Até podia
    [SerializeField] private float moveSpeed = 0; //não é 100% necessário mas é boa prática
    private int ThingToDestroy = -45;

    //[SerializeField] private criandoQualidade mapaLogica; //com isso pode mudar a velocidade do mapa que o spawn tbm muda

    void Start()
    {
        //mapaLogica = GameObject.FindGameObjectWithTag("mapaLogica").GetComponent<criandoQualidade>(); //esqueçi disso ksksksksk
    }

    // Update is called once per frame
    void Update()
    {
        //float velocidadeMedia = moveSpeed / mapaLogica.spawnRate; //media, assim pode alterar um que o outro acompanha
        //não sei oq eu tô fazendo de errado mais tarde eu termino isso

        transform.position += (Vector3.back * moveSpeed) * Time.deltaTime;

        if(transform.position.z < ThingToDestroy)
        {
            Destroy(gameObject); //funcionou MUITO melhor pegando a posição na real
        }


        


        /*Debug.Log($"Média de spawn rate: {velocidadeMedia}");
        Debug.Log($"Valor verdadeiro: {mapaLogica.spawnRate}");
        Debug.Log($"Velocidade do mapa: {moveSpeed}");*/
    }
   /* private void OnTriggerEnter(Collider other)
    {
        tentei, n sei oq fiz de errado
    }*/
}
