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


    void Start()
    {
        
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


    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(2);
    }
}
