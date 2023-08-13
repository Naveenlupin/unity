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
  // to call random ques at start
    private void Start()
    {
      GenerateQuestion();
    }

    public void Correct()
    {
        //Score += 1;
        QnA.RemoveAt(CurrentQuestion);
        GenerateQuestion();
    }

    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[CurrentQuestion].Answers[i];
            if (QnA[CurrentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
                Debug.Log(options[i].GetComponent<AnswerScript>().isCorrect);
            }
        }
    }

    // function to choose a random ques
    void GenerateQuestion()
    {
        CurrentQuestion = Random.Range(0, QnA.Count);
        QuestionTxt.text = QnA[CurrentQuestion].Question;
        SetAnswer();       
    }
}
