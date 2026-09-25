/*esse script basicamente vai cuidar de tudo que não faira ideia de como eu colocaria
 * então isso vai ter TUDO mesmo que não use agora, sla a sorte ajuda quem prepare né?
 */

//bibliotecas
using NUnit.Framework.Internal;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
//bibliotecas


public class logicScript : MonoBehaviour
{
    //váriaveis
    bool debugCheck = false;
    //váriaveis

    public playerMovement playerLogica;
    public pontosPontos menuLogica;
    public GameObject moeda;


    void Start()
    {
        
    }   

    void Awake()
    {
        playerLogica = GameObject.FindGameObjectWithTag("tudoLogica").GetComponent<playerMovement>();
        menuLogica = GameObject.FindGameObjectWithTag("Player").GetComponent<pontosPontos>();
    }

    // Update is called once per frame
    void Update()
    {
        onlyDebug();

    }


    void onlyDebug()
    {
        //Debug.Log($"Debug check -> {debugCheck}");


        if (Input.GetKeyDown(KeyCode.Space) && !debugCheck)
        {
            debugCheck = true;
            playerLogica.player.gameObject.SetActive(false);

        } else if (Input.GetKeyDown(KeyCode.Space) && debugCheck)
        {
            debugCheck = false;
            playerLogica.player.gameObject.SetActive(true);

        }
    }

    void addMoneyCheck()
    {
        //adiciona +30 na pontuação ou algo parecido

        Debug.Log("+30");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(moeda.CompareTag("Player"))
        {
            addMoneyCheck();
            Destroy(moeda); //isso usa em contato
        }
        
    }
}
