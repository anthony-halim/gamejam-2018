﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Task ScriptableObjects/Calculator")]
public class CalculatorTaskSO : TaskSO {
    static int NO_ANSWER = -1000000;

    [SerializeField]
    protected int correctAnswer = NO_ANSWER;
    [SerializeField]
    protected string questionText = "";

	public override Task Create()
	{
        if (correctAnswer == NO_ANSWER) {
            GenerateQuestion();
        }
		return new CalculatorTask(
                correctAnswer, 
                questionText, 
                Random.Range(minTimeGiven, maxTimeGiven));

	}

    private void GenerateQuestion() {
        int x = (int)Random.Range(1, 10);
        int y = (int)Random.Range(1, 10);

        int rand = (int) Random.RandomRange(0, 3);
        switch (rand) {
            case 0:
                correctAnswer = x + y;
                questionText = "What is " + x + " + " + y + "?";
                break;
            case 1:
                correctAnswer = x * y;
                questionText = "What is " + x + " * " + y + "?";
                break;
            case 2:
            default:
                correctAnswer = x - y;
                questionText = "What is " + x + " - " + y + "?";
                break;
        }
    }

}
