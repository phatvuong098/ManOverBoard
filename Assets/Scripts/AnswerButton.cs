using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] private int answerIndex;
    [SerializeField] private QuestionController questionController;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            questionController.SelectAnswer(answerIndex);
        });
    }
}
