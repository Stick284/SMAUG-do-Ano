using UnityEngine;

public class pontosPontos : MonoBehaviour
{

    public int economiaLixo;
    [SerializeField] private int multEconomia = 1;
    [HideInInspector] public int pontuacao;
    [HideInInspector] public int pontuacaoMaximo;

    //public GameObject moeda;

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

    }

    public void minPontos()
    {

    }
}
