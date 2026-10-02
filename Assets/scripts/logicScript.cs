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

    private playerMovement playerLogica;
    private pontosPontos pontos;
    

    

    void Start()
    {
        pontos = GameObject.FindGameObjectWithTag("tudoLogica").GetComponent<pontosPontos>();
        playerLogica = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();

    }   

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onlyDebug();
        //Debug.Log($"Moedas atualmente: {pontos.economiaLixo}");
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

    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Teste");

        pontos.addMoneyCheck();
    }

}
