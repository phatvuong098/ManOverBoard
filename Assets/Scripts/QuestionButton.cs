using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionButton : MonoBehaviour
{
    [SerializeField] QuestionData questionData;
    [SerializeField] QuestionController questioncontroller;

    public void BTN_OnClick()
    {
        questioncontroller.StartQuestion(questionData);
    }
}
