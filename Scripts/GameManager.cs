using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject endPanel;
    public GameObject correctAnswer;
    public GameObject wrongAnswer;
    public GameObject Jogo;


    //metodo para puxar as perguntas do Quiz.
    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private Text factText;

    [SerializeField]
    private float timeBetweenQuestions = 1f;

    //Metodo para armazenar a sequencia de notas usada pela usuario.

    public SpriteRenderer[] Notas;

    private int notasSelect;

    public float stayLit;
    private float stayLitCounter;

    public float waitBetweenLights;
    private float waitBetweenCounter;

    private bool shouldBeLit;
    private bool shouldBeDark;
    private int positionInSequence;

    private bool gameActive;
    private int inputInSequence;


    void Start()
    {   
        // metodo para carregar a pergunta que estiver disponível na lista de perguntas não respondidas.
        if (unansweredQuestions == null )
        {
            unansweredQuestions = questions.ToList<Question>();

        }

        if (unansweredQuestions.Count == 0)
        {
            endPanel.SetActive(true);
            Jogo.SetActive(false);
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();
        
        // Metodo para zerar a sequencia utilizada na resposta anterior.
        positionInSequence = 0;
        inputInSequence = 0;
        stayLitCounter = stayLit;
        shouldBeLit = true;

    }

    void SetCurrentQuestion()
    {
        //metodo para selecionar a próxima pergunta de forma aleatoria.
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;

    }

    IEnumerator TransitionToNextQuestion()
    {   
        //Timer para carregar a próxima pergunta.
        correctAnswer.SetActive(false);
        wrongAnswer.SetActive(false);
        Jogo.SetActive(true);
        unansweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds(timeBetweenQuestions);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    void Update()
    {
        //Aqui é comparado a sequencia correta para a resposta da pergunta que estiver ativa.
        if (shouldBeLit)
        {
            stayLitCounter -= Time.deltaTime;

            if (stayLitCounter < 0)
            {
                shouldBeLit = false;
                shouldBeDark = true;
                waitBetweenCounter = waitBetweenLights;

                positionInSequence++;
            }
        }

        if (shouldBeDark)
        {
            waitBetweenCounter -= Time.deltaTime;

            if (positionInSequence >= currentQuestion.anwsers.Count)
            {
                shouldBeDark = false;
                gameActive = true;
            }
            else
            {
                if (waitBetweenCounter < 0)
                {
                    stayLitCounter = stayLit;
                    shouldBeLit = true;
                    shouldBeDark = false;
                }
            }
        }

        
    }

    public void NotasPressed(int whichButton)
    {
        //Aqui é feita a comparação entre o botão apertado com a sequencia correta da pergunta.
        if (gameActive)
        {
            if (currentQuestion.anwsers[inputInSequence] == whichButton)
            {
                Debug.Log("Correto");

                inputInSequence++;


                if (inputInSequence >= currentQuestion.anwsers.Count)
                {
                    positionInSequence = 0;
                    inputInSequence = 0;

                    stayLitCounter = stayLit;
                    shouldBeLit = true;

                    gameActive = false;
                    StartCoroutine(TransitionToNextQuestion());
                    correctAnswer.SetActive(true);
                }
            }
            else
            {
                Debug.Log("Errado");
                gameActive = false;
                StartCoroutine(TransitionToNextQuestion());
                wrongAnswer.SetActive(true);
            }

        }

    }

    public void PlayAgain()
    {
        //Recarregar a mesma cena e jogar novamente.
        SceneManager.LoadScene(3);
        endPanel.SetActive(false);
        wrongAnswer.SetActive(false);
        correctAnswer.SetActive(false);
        Jogo.SetActive(true);
    }

    public void Menu ()
    {
        //voltar para o menu.
        SceneManager.LoadScene(0);
    }

}
