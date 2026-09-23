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


    [HideInInspector] public bool anchor0 = false; //false é bom, true é ruim
    [HideInInspector] public bool anchor1 = false;
    [HideInInspector] public bool anchor2 = false;


    // Update is called once per frame
    void Update()
    {
        //debug rays
        rayFront = new Ray(transform.position, -transform.right);
        Debug.DrawRay(rayFront.origin, rayFront.direction * rayDistance, Color.blue);

        rayBack = new Ray(transform.position, transform.right);
        Debug.DrawRay(rayBack.origin, rayBack.direction * rayDistance, Color.blue);

        /*anchor0 = detectRayTruck_0();
        anchor1 = detectRayTruck_1();
        anchor0 = detectRayTruck_2();*/
        //isso acho que nem vai usar diretamente aqui, provavelmente vai ser no outro masi fica por via das duvidas

    }

    public bool detectRayTruck_0()
    {
        //back ray
        if (Physics.Raycast(transform.position, transform.right, out hitBack, rayDistance))
        {
            //Debug.Log($"Truck is still in reach of {hitBack.collider.gameObject}, can't spawn things");
            return true;

        }
        else
        {
            //Debug.Log("Truck now can spawn stuff");
            return false;

        }

        //front ray
       /*if (Physics.Raycast(transform.position, -transform.right, out hitFront, rayDistance))
        {
            //Debug.Log($"Something is in front of the truck");

        }
        else
        {
            //Debug.Log("Nothing is in front of the truck");

        }*/
    }

    public bool detectRayTruck_1()
    {
        //back ray
        if (Physics.Raycast(transform.position, transform.right, out hitBack, rayDistance))
        {
            //Debug.Log($"Truck is still in reach of {hitBack.collider.gameObject}, can't spawn things");
            return true;

        }
        else
        {
            //Debug.Log("Truck now can spawn stuff");
            return false;

        }
    }

    public bool detectRayTruck_2()
    {
        //back ray
        if (Physics.Raycast(transform.position, transform.right, out hitBack, rayDistance))
        {
            //Debug.Log($"Truck is still in reach of {hitBack.collider.gameObject}, can't spawn things");
            return true;

        }
        else
        {
            //Debug.Log("Truck now can spawn stuff");
            return false;

        }
    }
}
