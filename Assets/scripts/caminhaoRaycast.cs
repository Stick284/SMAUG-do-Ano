using NUnit.Framework.Internal;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class caminhaoRaycast : MonoBehaviour
{
    //variaveis
    [SerializeField] private GameObject caminhao;
    

    /*[SerializeField] private BoxCollider CarroHitbox;
    [SerializeField] private BoxCollider CaminhaoHitbox;*/

    //sabendo que preciso de DOIS no minimo vai ter vários rays

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

        rayBack = new Ray(transform.position, transform.right);
        Debug.DrawRay(rayBack.origin, rayBack.direction * rayDistance, Color.blue);

        /*rayBack = new Ray(transform.position, transform.right);
        Debug.DrawRay(rayBack.origin, rayBack.direction * (rayDistance + rayGapFix), Color.blue);*/


        //back ray
        if(Physics.Raycast(transform.position, transform.right, out hitBack, rayDistance))
        {
            Debug.Log($"Still in reach of {hitBack.collider.gameObject}, can't spawn things");

            /*if(hitBack.collider.gameObject != null)
            {
                Debug.Log("Still in reach, can't spawn things");

            } else
            {
                Debug.Log("Now you can spawn stuff!!!");

            }*/

        }
        else
        {
            Debug.Log("Now can spawn stuff");
            
        }

        /*
         * //back ray
        if(Physics.Raycast(transform.position, transform.right, out hitFront, rayDistance))
        {
            Debug.Log("Still in reach, can't spawn things");
        } else
        {
           Debug.Log("Now you can spawn stuff!!!");
        }*/
    }
}
