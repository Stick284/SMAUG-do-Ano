using System.Threading;
using UnityEngine;

public class pontosPontos : MonoBehaviour
{

    public int economiaLixo;
    [SerializeField] private int multEconomia = 1;

    public bool contagemPermitida;
    [HideInInspector] public float pontosTemporado = 0;
    public float pontosContagem = 0.15f;

    public int pontuacao;
    public int pontuacaoMaximo;

    logicScript logica; //BEM melhor do que eu fiz antes

    void Awake()
    {
        logica = FindAnyObjectByType<logicScript>();
    }

    void Start()
    {
        /* FindAnyObjectByType<logicScript>()
         * 
         * BEM MELHOR DO QUE CHAMAR O SCRIPT NA REAL
         * salvando pra copiar*/

        logica.moedaLoad();
        logica.pontosLoad();

    }


    public void addMoneyCheck(GameObject moeda)
    {
        economiaLixo += multEconomia;

        //Debug.Log($"Teste -> {economiaLixo}");

        Destroy(moeda); //isso usa em contato

    }

    //falta agora a pont~uação pontuação msm
    public void maxPontos()
    {
        if (contagemPermitida)
        {
            if (pontosTemporado < pontosContagem)
            {
                pontosTemporado += Time.deltaTime;
            }
            else
            {
                pontuacao++;

                pontosTemporado = 0;
            }
        } else
        {
            Debug.Log("-------------------------------------------------");
            Debug.Log($"Quantia de pontos atual: {pontuacao}");
            Debug.Log($"Quantia de pontos MAXIMO atual: {pontuacaoMaximo}");
        }
    }
}
