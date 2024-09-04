using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    public TMP_Text question;
    public TMP_Text answer1;
    public TMP_Text answer2;
    public TMP_Text answer3;
    public TMP_Text answer4;

    public Image imgAnswer1;
    public Image imgAnswer2;
    public Image imgAnswer3;
    public Image imgAnswer4;

    public AudioSource audioSource;
    public AudioClip correctClip;
    public AudioClip incorrectClip;

    public GameObject questionPanel;
    public GameObject EndPanel;

    private int currentIndex = 0;
    private QuestionData questionData;

    public void StartQuestion(QuestionData questionData)
    {
        questionPanel.SetActive(true);
        EndPanel.SetActive(false);

        this.questionData = questionData;
        this.currentIndex = 0;
        NextQuestion(this.questionData.configs[currentIndex]);
    }

    public void SelectAnswer(int answerIndex)
    {
        if (this.questionData.configs[currentIndex].rightAnswerIndex == answerIndex)
        {
            audioSource.PlayOneShot(correctClip);
            if (currentIndex < this.questionData.configs.Count - 1)
            {
                currentIndex++;
                NextQuestion(this.questionData.configs[currentIndex]);
            }
            else
            {
                questionPanel.SetActive(false);
                EndPanel.SetActive(true);
            }
        }
        else
        {
            audioSource.PlayOneShot(incorrectClip);
        }
    }

    private void NextQuestion(QuestionDataConfig data)
    {
        question.text = data.question;
        answer1.text = data.answer1;
        answer2.text = data.answer2;
        answer3.text = data.answer3;
        answer4.text = data.answer4;

        imgAnswer1.sprite = data.answerSprite1;
        imgAnswer2.sprite = data.answerSprite2;
        imgAnswer3.sprite = data.answerSprite3;
        imgAnswer4.sprite = data.answerSprite4;
    }

    public void BTN_CloseQuestion()
    {
        questionPanel.SetActive(false);
        EndPanel.SetActive(false);
    }
}
