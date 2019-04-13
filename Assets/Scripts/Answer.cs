using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Answer : ScriptableObject
{
    

    public string[] answers;

    
    private int currentAnswer = 0;

    public string GetNextAnswer()
    {
        return "next";
    }

    public Question nextQuestion;

}
