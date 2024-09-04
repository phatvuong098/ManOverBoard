using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestionDataConfig
{
    public string question;
    public string answer1;
    public string answer2;
    public string answer3;
    public string answer4;
    public Sprite answerSprite1;
    public Sprite answerSprite2;
    public Sprite answerSprite3;
    public Sprite answerSprite4;
    public int rightAnswerIndex;
}

[CreateAssetMenu(fileName = "QuestionData", menuName = "ScriptableObjects/QuestionData", order = 1)]
public class QuestionData : ScriptableObject
{
    public List<QuestionDataConfig> configs;
}
