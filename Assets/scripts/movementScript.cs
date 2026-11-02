using NUnit.Framework.Internal;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    //variaveis                                     
    public float mapaMoveSpeed = 15;

    [HideInInspector] public int ThingToDestroy = -45;

    [SerializeField] private GameObject mapa; //não é 100% necessário mas é boa prática, já que public funciona


    // Update is called once per frame
    void Update()
    {
            transform.position += (Vector3.back * mapaMoveSpeed) * Time.deltaTime;

        if(mapa.transform.position.z < ThingToDestroy)
        {
            //Destroy(mapa); //funcionou MUITO melhor pegando a posição na real
            DestroyImmediate(mapa, true); //para quando não tem colisão agente uso o immediate
        }
    }
}
