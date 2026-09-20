using NUnit.Framework.Internal;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class carroRaycast : MonoBehaviour
{
    //variaveis
    [SerializeField] private GameObject carro;

    /*[SerializeField] private BoxCollider CarroHitbox;
    [SerializeField] private BoxCollider CaminhaoHitbox;*/

    RaycastHit hitFront; //ray para real calculo
    RaycastHit hitBack; //ray para real calculo
    Ray rayFront; //ray para debug / desenho
    Ray rayBack; //ray para debug / desenho
    [SerializeField] private float rayDistance = 5;
    [SerializeField] private float rayGapFix = 5;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rayFront = new Ray(transform.position, -transform.up);
        Debug.DrawRay(rayFront.origin, rayFront.direction * rayDistance, Color.blue);

        rayBack = new Ray(transform.position, transform.up);
        Debug.DrawRay(rayBack.origin, rayBack.direction * rayDistance, Color.blue);
        /*if(Physics.Raycast(transform.position, transform.up, out hit))
        {
            Debug.Log("Acertou algo!!");
        }*/
    }
}
