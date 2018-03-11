using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

//CLASS 04
public class Heranca
{

    public string texto;

    public virtual string RetornarUmTexto()
    {
        return texto;
    }
}

//CLASS 03
public class GuardarResposta : Heranca
{

    public bool estaCorreta;

    public GuardarResposta(string a, bool b)
    {
        texto = a;
        estaCorreta = b;
    }

    public override string RetornarUmTexto()
    {
        return "Pergunta: " + texto + ", Esta correta: " + estaCorreta.ToString();
    }
}


// CLASSE 02
public class Perguntas : Heranca
{

    public int ponto;

    // Respostas
    public GuardarResposta[] GuardarRespostas;


    // Construtor CLASS
    public Perguntas(string t, int p)
    {
        texto = t;
        ponto = p;
    }

    // Método ADD RESPOSTA
    public void AddRespostas(string a, bool estaCorreta)
    {
        if (GuardarRespostas == null)
        {
            GuardarRespostas = new GuardarResposta[4];
        }
        for (int i = 0; i < GuardarRespostas.Length; i++)
        {
            if (GuardarRespostas[i] == null)
            {
                GuardarRespostas[i] = new GuardarResposta(a, estaCorreta);
                break;
            }
        }
    }// FIM - Método ADD RESPOSTA 


    // Método para listar as Respostas
    public void ListaResposta()
    {
        if (GuardarRespostas != null && GuardarRespostas.Length > 0)
        {
            foreach (GuardarResposta a in GuardarRespostas)
            {
                Debug.Log(a);
            }
        }
    }


    // Método para verificar a resposta correta
    public bool ChecarResposta(int checar)
    {
        if (GuardarRespostas != null && GuardarRespostas.Length > checar && checar >= 0)
        {
            return GuardarRespostas[checar].estaCorreta;
        }
        else
        {
            return false;
        }
    }

    // Sobrecarga
    public override string ToString() // override: Sobre escreva
    {
        return "Pergunta: " + texto;
    }

} // FIM DA CLASS 02 - Perguntas


// CLASSE 01 - QUIZ
public class TutorialManager : MonoBehaviour
{

    public Text pergunta;
    public GameObject painelCorreto;
    public GameObject painelErrado;
    public GameObject painelPontos;
    public GameObject Jogo;

    public Button[] botoes = new Button[4];
    public List<Perguntas> listaDePerguntas = new List<Perguntas>();

    private Perguntas perguntaVisualizada;
    private int qtdPerguntas = 0;
    private float tempo = 0f;
    private bool carregaProximaPergunta = false;
    private int pontos = 0;


    // Use this for initialization
    void Start()
    {

        // LISTA DE PERGUNTAS
        Perguntas p1 = new Perguntas("Qual letra representa a nota Dó?", 1);
        p1.AddRespostas("D", false);
        p1.AddRespostas("C", true);
        p1.AddRespostas("E", false);
        p1.AddRespostas("F", false);


        Perguntas p2 = new Perguntas("Qual letra representa a nota Ré?", 1);
        p2.AddRespostas("A", false);
        p2.AddRespostas("F", false);
        p2.AddRespostas("D", true);
        p2.AddRespostas("G", false);

        Perguntas p3 = new Perguntas("Qual letra representa a nota Mi?", 1);
        p3.AddRespostas("E", true);
        p3.AddRespostas("A", false);
        p3.AddRespostas("G", false);
        p3.AddRespostas("F", false);


        Perguntas p4 = new Perguntas("Qual letra representa a nota Fá?", 1);
        p4.AddRespostas("D", false);
        p4.AddRespostas("B", false);
        p4.AddRespostas("F", true);
        p4.AddRespostas("C", false);

        Perguntas p5 = new Perguntas("Qual letra representa a nota Sol?", 1);
        p5.AddRespostas("A", false);
        p5.AddRespostas("G", true);
        p5.AddRespostas("F", false);
        p5.AddRespostas("E", false);

        Perguntas p6 = new Perguntas("Qual letra representa a nota Lá?", 1);
        p6.AddRespostas("A", true);
        p6.AddRespostas("D", false);
        p6.AddRespostas("E", false);
        p6.AddRespostas("C", false);

        Perguntas p7 = new Perguntas("Qual letra representa a nota Si?", 1);
        p7.AddRespostas("D", false);
        p7.AddRespostas("C", false);
        p7.AddRespostas("F", false);
        p7.AddRespostas("B", true);


        // FIM DA LISTA DE PERGUNTAS

        listaDePerguntas.Add(p1);
        listaDePerguntas.Add(p2);
        listaDePerguntas.Add(p3);
        listaDePerguntas.Add(p4);
        listaDePerguntas.Add(p5);
        listaDePerguntas.Add(p6);
        listaDePerguntas.Add(p7);

        perguntaVisualizada = p1;

        ExibirPerguntaParaUsuario();

    }

    // Update is called once per frame
    void Update()
    {

        if (carregaProximaPergunta == true)
        {
            tempo += Time.deltaTime;
            if (tempo > 3)
            {
                tempo = 0;
                carregaProximaPergunta = false;
                qtdPerguntas++;

                if (qtdPerguntas < listaDePerguntas.Count)
                {
                    perguntaVisualizada = listaDePerguntas[qtdPerguntas];
                    ExibirPerguntaParaUsuario();
                    painelCorreto.SetActive(false);
                    painelErrado.SetActive(false);

                }
                else
                {
                    painelPontos.SetActive(true);
                    painelCorreto.SetActive(false);
                    painelErrado.SetActive(false);
                    Jogo.SetActive(false);

                   // painelPontos.transform.GetComponentInChildren<Text>().text = "Acabou: Você acertou: " + pontos.ToString() + " pontos";

                }

            }
        }

    }

    //Exibir
    public void ExibirPerguntaParaUsuario()
    {
        pergunta.text = perguntaVisualizada.texto;
        botoes[0].GetComponentInChildren<Text>().text = perguntaVisualizada.GuardarRespostas[0].texto;
        botoes[1].GetComponentInChildren<Text>().text = perguntaVisualizada.GuardarRespostas[1].texto;
        botoes[2].GetComponentInChildren<Text>().text = perguntaVisualizada.GuardarRespostas[2].texto;
        botoes[3].GetComponentInChildren<Text>().text = perguntaVisualizada.GuardarRespostas[3].texto;
    }

    //Click no botão

    public void ClickNoBotao(int resposta)
    {

            if (perguntaVisualizada.GuardarRespostas[resposta].estaCorreta)
            {
                Debug.Log("Esta correto!!!");
                painelCorreto.SetActive(true);
                pontos += perguntaVisualizada.ponto;
                Debug.Log(pontos);
            }
            else
            {
                Debug.Log("ERRROOOU!!!");
                painelErrado.SetActive(true);
            }

            carregaProximaPergunta = true;
        

    }

    public void ClickParaCarregarOutraCena()
    {
        SceneManager.LoadScene("quiz");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(2);
        painelCorreto.SetActive(false);
        painelErrado.SetActive(false);
        painelPontos.SetActive(false);
        Jogo.SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

}
