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

    public playerMovement playerLogic;



    void Start()
    {
        playerLogic = GameObject.FindGameObjectWithTag("tudoLogica").GetComponent<playerMovement>();
    }   

    void Awake()
    {
        
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
            playerLogic.player.gameObject.SetActive(false);

        } else if (Input.GetKeyDown(KeyCode.Space) && debugCheck)
        {
            debugCheck = false;
            playerLogic.player.gameObject.SetActive(true);

        }
    }

    void addScore()
    {
        //adiciona +30 na pontuação ou algo parecido
    }
}
