using UnityEngine;

public class pontosPontos : MonoBehaviour
{

    public int economiaLixo;
    [SerializeField] private int multEconomia = 1;
    [HideInInspector] public int pontuacao;
    [HideInInspector] public int pontuacaoMaximo;

    //public GameObject moeda;

   void Start()
    {
        /* FindAnyObjectByType<logicScript>()
         * 
         * BEM MELHOR DO QUE CHAMAR O SCRIPT NA REAL
         * salvando pra copiar*/
    }


    public void addMoneyCheck(GameObject moeda)
    {
        economiaLixo += multEconomia;

        //Debug.Log($"Teste -> {economiaLixo}");

        Destroy(moeda); //isso usa em contato

        //adiciona +30 na moeda ou algo parecido
        //Debug.Log("+30");
    }

    //falta agora a pont~uação pontuação msm
}
