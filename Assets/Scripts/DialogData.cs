using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogData: ScriptableObject
{
    
    [SerializeField]
    [TextArea(3, 10)]
    private string[] introduction;

    [SerializeField]
    private Answers[] answers;
    
    public int currentAnswer = 0;
    public int currentIntroduction = 0;


    public int rightAnswer;


    public string GetNextAnswer(int choice)
    {
        if (currentAnswer >= answers[choice].answers.Length)
            return null;
        currentAnswer++;
        return answers[choice].answers[currentAnswer -1];
    }

    public string GetNextIntroduction()
    {
        if (currentIntroduction >= introduction.Length)
            return null;
        currentIntroduction++;
        return introduction[currentIntroduction - 1];
    }
}
