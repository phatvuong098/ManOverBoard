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

    [Header("Reference")]
    public GameObject wellcomePanel;
    public GameObject questionPanel;
    public GameObject scorePanel;
    public GameObject endPanel;

    private int currentIndex = 0;
    private QuestionData questionData;
    private int[] userAnswers;

    public void StartQuestion(QuestionData questionData)
    {
        wellcomePanel.SetActive(true);
        questionPanel.SetActive(false);
        scorePanel.SetActive(false);
        endPanel.SetActive(false);

        this.questionData = questionData;
        this.currentIndex = 0;
        this.userAnswers = new int[questionData.configs.Count];
        NextQuestion(this.questionData.configs[currentIndex]);
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

    public void BTN_SelectAnswer(int answerIndex)
    {
        userAnswers[currentIndex] = answerIndex;

        if (currentIndex < this.questionData.configs.Count - 1)
        {
            currentIndex++;
            NextQuestion(this.questionData.configs[currentIndex]);
        }
        else
        {
            questionPanel.SetActive(false);
            scorePanel.SetActive(true);
            scorePanel.GetComponent<ScorePanel>().Setup(userAnswers, questionData);
        }

        if (this.questionData.configs[currentIndex].rightAnswerIndex == answerIndex)
        {
            audioSource.PlayOneShot(correctClip);
        }
        else
        {
            audioSource.PlayOneShot(incorrectClip);
        }
    }

    public void BTN_ShowQuestionPanel()
    {
        wellcomePanel.SetActive(false);
        questionPanel.SetActive(true);
    }

    public void BTN_ShowEndPanel()
    {
        questionPanel.SetActive(false);
        endPanel.SetActive(true);
    }

    public void BTN_CloseQuestion()
    {
        wellcomePanel.SetActive(false);
        questionPanel.SetActive(false);
        scorePanel.SetActive(false);
        endPanel.SetActive(false);
    }
}
