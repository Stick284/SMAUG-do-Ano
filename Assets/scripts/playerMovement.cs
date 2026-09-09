using Unity.VisualScripting;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //movimentos em ancoras, n precisa encontrar o X sem dor de cabeça
    [SerializeField] private Transform[] anchorPoints;
    private int anchor = 1;

    /*a fisica do player
     * na real eu...não faço ideia como aplico isso pro olimpio mas faze oq futuro eu descubro depois*/
    [SerializeField] private float playerJump = 10;
    [SerializeField] private Rigidbody playerGrav;
    [SerializeField] private GameObject player;

    private float tempoTemporado;

    //váriaveis que verificam algo
    private bool isGrounded = true;
    private bool canInput = true;

    // Update is called once per frame
    void Update()
    {
        movementPlayer();

        slidePlayer(); //separei pq tava fazendo debug e curti
    }

    void movementPlayer()
    {
        //aqui a magia aconteçe, transformar essa bagunça em switch depois (se conseguir)
        if ((Input.GetKeyDown(KeyCode.A) == true && anchor != 0) && canInput)
        {
            anchor--;
            //travando o Y e Z do player
            player.transform.position = new Vector3(anchorPoints[anchor].position.x, transform.position.y, transform.position.z);
            //player.transform.position = anchorPoints[anchor].position;
        }
        else if ((Input.GetKeyDown(KeyCode.A) == true && anchor == 2) && canInput)
        {
            anchor--;
            player.transform.position = new Vector3(anchorPoints[anchor].position.x, transform.position.y, transform.position.z);
            //player.transform.position = anchorPoints[anchor].position;
        }
        else if ((Input.GetKeyDown(KeyCode.D) == true && anchor != 2) && canInput)
        {
            anchor++;
            player.transform.position = new Vector3(anchorPoints[anchor].position.x, transform.position.y, transform.position.z);
            //player.transform.position = anchorPoints[anchor].position;
        }
        else if ((Input.GetKeyDown(KeyCode.D) == true && anchor == 1) && canInput)
        {
            anchor++;
            player.transform.position = new Vector3(anchorPoints[anchor].position.x, transform.position.y, transform.position.z);
            //player.transform.position = anchorPoints[anchor].position; //versão original, mas deu problema com o pulo
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true; //não vou comentar que gastei todo o meu domingo e NÃO pensei nisso
    }


    private void slidePlayer()
    {
        if ((Input.GetKeyDown(KeyCode.Space) && isGrounded) && canInput)
        {
            isGrounded = false;
            playerGrav.linearVelocity = Vector3.up * playerJump;
        }

        if ((Input.GetKeyDown(KeyCode.S) && isGrounded) && canInput)
        {
            player.transform.Rotate(-90, 0, 0);
            canInput = false;
        } else if (!canInput && tempoTemporado <= 1)
        {
            tempoTemporado += Time.deltaTime;
        }

        if ((Input.GetKeyDown(KeyCode.S) && !isGrounded) && canInput)
        {
            playerGrav.linearVelocity = (Vector3.down * 3) * playerJump;
        }

        if (tempoTemporado >= 1 && !canInput)
        {
            tempoTemporado = 0;
            canInput = true;
            player.transform.Rotate(90, 0, 0);
        }
    }

}
