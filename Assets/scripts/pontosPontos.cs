using UnityEngine;

public class pontosPontos : MonoBehaviour
{
    [HideInInspector] public int pontos;
    [HideInInspector] public int pontosMaximo;
    
    public int economiaLixo;
    private string pagamentoCLT = "Moedas Contagem";
    private string pontosMax = "Pontos Maximo";
    private string pontosMin = "Pontos Minímo";

    public GameObject moeda;

    private void Start()
    {
         
    }

    public void addMoneyCheck()
    {
        if (moeda.CompareTag("Player"))
        {
            Destroy(moeda); //isso usa em contato

            economiaLixo++;
        }

        //adiciona +30 na pontuação ou algo parecido
        //Debug.Log("+30");
    }


    void moedaSave()
    {
        PlayerPrefs.SetInt(pagamentoCLT, economiaLixo);
        PlayerPrefs.Save();
    }
    void pontosSave()
    {
        if(pontos > pontosMaximo)
        {
            pontos = pontosMaximo;
            PlayerPrefs.SetInt(pontosMax, pontosMaximo);
            PlayerPrefs.Save();
        } else
        {
            PlayerPrefs.SetInt(pontosMin, pontos);
            PlayerPrefs.Save();
            //nem sei onde eu usaria os pontos minimos mas sla depois a gente da uma olhada
        }
    }

    void moedaLoad()
    {
        PlayerPrefs.GetInt(pagamentoCLT, economiaLixo);
    }
    void pontosLoad()
    {
        PlayerPrefs.GetInt(pontosMax, pontosMaximo);
    }
}
