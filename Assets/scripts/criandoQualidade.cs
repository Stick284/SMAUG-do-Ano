using Unity.VisualScripting;
using UnityEngine;

public class criandoQualidade : MonoBehaviour
{
    //mesma coisa do outro script
    [SerializeField] private GameObject mapa;
    [SerializeField] private float spawnRate = 2;
    private float tempoTemporado = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(mapa, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        criadorMapa();
    }

    void criadorMapa()
    {
        //código que faz a magia
        if (tempoTemporado < spawnRate)
        {
            tempoTemporado += Time.deltaTime;
        }
        else
        {
            Instantiate(mapa, transform.position, transform.rotation); //transform.positon e rotation basicamente faz com que seja a mesma do objeto
            tempoTemporado = 0;
        }
    }
}
