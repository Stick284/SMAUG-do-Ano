using NUnit.Framework.Internal;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class veiculoScript : MonoBehaviour
{
    //variaveis                                     Podia ser public? Até podia
    [SerializeField] private float veiculoMoveSpeed = 0; //não é 100% necessário mas é boa prática

    private int ThingToDestroy = -45;

    [SerializeField] private GameObject carro;
    [SerializeField] private GameObject caminhao;

    [SerializeField] private Collision CarroHitbox;
    [SerializeField] private Collision CaminhaoHitbox;

    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.back * veiculoMoveSpeed) * Time.deltaTime;

        OnCollisionEnter(CarroHitbox);
        OnCollisionEnter(CaminhaoHitbox);

        if (carro.transform.position.z < ThingToDestroy)
        {
            //Destroy(carro); //se mostrar erro pode ignorar, prefab n tem risco de perder dados (eu acho)
            DestroyImmediate(carro, true);
        }

        if (caminhao.transform.position.z < ThingToDestroy)
        {
            DestroyImmediate(caminhao, true);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Manin morreu");
    }
}
