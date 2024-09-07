using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] TMP_Text txtScore;
    [SerializeField] TMP_Text[] txtAnswers;

    public void Setup(int[] answers, QuestionData question)
    {
        int _score = 0;

        for (int i = 0; i < answers.Length; i++)
        {
            bool isUserTrue = answers[i] == question.configs[i].rightAnswerIndex;
            string trueAnswer = GetTrueAnswer(question.configs[i]);
            txtAnswers[i].text = trueAnswer;

            if (isUserTrue)
            {
                _score++;
                txtAnswers[i].color = Color.green;
            }
            else
            {
                txtAnswers[i].color = Color.white;
            }
        }

        txtScore.text = _score.ToString() + "/" + question.configs.Count;
    }

    private string GetTrueAnswer(QuestionDataConfig config)
    {
        switch (config.rightAnswerIndex)
        {
            case 0: return config.answer1;
            case 1: return config.answer2;
            case 2: return config.answer3;
            case 3: return config.answer4;
        }

        return "";
    }
}
