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


    [HideInInspector] public bool anchor0 = false; //false é bom, true é ruim
    [HideInInspector] public bool anchor1 = false;
    [HideInInspector] public bool anchor2 = false;


    // Update is called once per frame
    void Update()
    {
        //debug rays
        rayFront = new Ray(transform.position, -transform.up);
        Debug.DrawRay(rayFront.origin, rayFront.direction * rayDistance, Color.blue);

        rayBack = new Ray(transform.position, transform.up);
        Debug.DrawRay(rayBack.origin, rayBack.direction * rayDistance, Color.blue);

        /*anchor0 = detectRayCar_0();
        anchor1 = detectRayCar_1();
        anchor2 = detectRayCar_2();*/

    }

    public bool detectRayCar_0()
    {
        //back ray
        if (Physics.Raycast(transform.position, transform.up, out hitBack, rayDistance))
        {
            //Debug.Log($"Car is still in reach of {hitBack.collider.gameObject}, can't spawn things");
            return true;

        }
        else
        {
            //Debug.Log("Car now can spawn stuff");
            return false;

        }

        //hitFront ray
        /*if (Physics.Raycast(transform.position, -transform.up, out hitFront, rayDistance))
        {
            //Debug.Log($"Something is in front of the car");

        }
        else
        {
            //Debug.Log("Nothing is in front of the car");

        }*/

    }

    public bool detectRayCar_1()
    {
        //back ray
        if (Physics.Raycast(transform.position, transform.up, out hitBack, rayDistance))
        {
            //Debug.Log($"Car is still in reach of {hitBack.collider.gameObject}, can't spawn things");
            return true;

        }
        else
        {
            //Debug.Log("Car now can spawn stuff");
            return false;

        }
    }

    public bool detectRayCar_2()
    {
        //back ray
        if (Physics.Raycast(transform.position, transform.up, out hitBack, rayDistance))
        {
            //Debug.Log($"Car is still in reach of {hitBack.collider.gameObject}, can't spawn things");
            return true;

        }
        else
        {
            //Debug.Log("Car now can spawn stuff");
            return false;

        }
    }
}
