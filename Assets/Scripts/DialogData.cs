using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogData: ScriptableObject
{
    
    [SerializeField]
    private string[] introduction;

    [SerializeField]
    private string[] answers;
    
    public int currentAnswer = 0;
    public int currentIntroduction = 0;

    public string GetNextAnswer()
    {
        if (currentAnswer >= answers.Length)
            return null;
        currentAnswer++;
        return answers[currentAnswer - 1];
    }

    public string GetNextIntroduction()
    {
        if (currentIntroduction >= introduction.Length)
            return null;
        currentIntroduction++;
        return introduction[currentIntroduction - 1];
    }
}
