using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToAnswerQuestion;
    [SerializeField] float timeToShowCorrectAnswer;
    float currentValue;
    public bool loadNextQuestion;
    public bool isAnsweringQuestion;
    public float fillFraction;

    private void Update()
    {
        UpdateTimerValue();
    }

    public void CancelTimer()
    {
        currentValue = 0;
    }

    private void UpdateTimerValue()
    {
        currentValue -= Time.deltaTime;
        if (currentValue <= 0)
        {
            if (!isAnsweringQuestion)
            {
                currentValue = timeToAnswerQuestion;
                isAnsweringQuestion = true;
                loadNextQuestion = true;
            }
            else
            {
                currentValue = timeToShowCorrectAnswer;
                isAnsweringQuestion = false;
            }
        }
        else
        {
            if (!isAnsweringQuestion)
            {
                fillFraction = currentValue / timeToShowCorrectAnswer;
            }
            else
            {
                fillFraction = currentValue / timeToAnswerQuestion;
            }
        }
    }
}
