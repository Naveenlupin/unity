using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int CurrentQuestion;
    public Text QuestionTxt;

    public GameObject QuizPanel;
    public GameObject GoPanel;
    public Text ScoreTxt;
    int TotalQuestions = 0;
    public int Score;

    // to call random ques at start
    private void Start()
    {
        TotalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        GenerateQuestion();

    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = Score + "/" + TotalQuestions;
    }

    public void Correct()
    {
        Score += 1;
        QnA.RemoveAt(CurrentQuestion);
        GenerateQuestion();
    }

    public void Wrong()
    {
        QnA.RemoveAt(CurrentQuestion);
        GenerateQuestion();
    }
    // paramertized options and checking
    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[CurrentQuestion].Answers[i];
            if (QnA[CurrentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    // function to choose a random ques
    void GenerateQuestion()
    {
        if (QnA.Count > 0)
        {
            CurrentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[CurrentQuestion].Question;
            SetAnswer();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
    }
}
