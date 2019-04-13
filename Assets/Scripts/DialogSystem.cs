using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{

    [SerializeField]
    private Text npcSpeech;

    [SerializeField]
    private int numberOfTurns;

    private int currentTurn;

    [SerializeField]
    private GameObject[] choicePanel;

    private NoodleNPC activeNoodle;

    private int currentChoice;


    enum State { opening, questions, answers };

    private State currentState;

    private void Awake()
    {
        currentTurn = 0;
    }

    public void InitializeDialog(NoodleNPC noodle)
    {
        if (currentTurn >= numberOfTurns)
            return;

        gameObject.SetActive(true);
        DeactivateChoiceText();
        noodle.dialogData.currentAnswer = 0;
        noodle.dialogData.currentIntroduction = 0;
        activeNoodle = noodle;
        currentState = State.opening;
        npcSpeech.text = noodle.dialogData.GetNextIntroduction();
        npcSpeech.gameObject.SetActive(true);

        activeNoodle.GetComponent<BlinkingNPC>().isBlinking = true;

        
    }

    private void DeactivateChoiceText()
    {
        for (int i = 0; i < choicePanel.Length; i++)
        {
            choicePanel[i].SetActive(false);
        }
    }





    private void Update()
    {
        if (activeNoodle == null)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (currentState)
            {
                case State.opening:
                    string text = activeNoodle.dialogData.GetNextIntroduction();
                    if (text != null)
                    {
                        npcSpeech.text = text;
                    }
                    else
                    {
                        Showchoices();
                        currentState++;
                    }
                    break;

                case State.questions:
                    currentState++;

                    foreach (var panel in choicePanel)
                        panel.SetActive(false);

                    npcSpeech.gameObject.SetActive(true);
                    npcSpeech.text = activeNoodle.dialogData.GetNextAnswer(currentChoice);
                    break;

                case State.answers:

                    string answerText = activeNoodle.dialogData.GetNextAnswer(currentChoice);
                    if (answerText != null)
                    {
                        npcSpeech.text = answerText;
                    }
                    else
                    {
                        EndDialog();
                        currentState++;
                    }
                    break;


            }

        }



        if (Input.GetKeyDown(KeyCode.DownArrow) && currentState == State.questions)
            MoveArrowDown();
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentState == State.questions)
            MoveArrowUp();

    }



    private void Showchoices()
    {
        npcSpeech.gameObject.SetActive(false);
        currentChoice = 0;
        ActivateChoice();


        for (int i = 0; i < choicePanel.Length; i++)
        {
            choicePanel[i].SetActive(true);
        }
    }


    private void ActivateChoice()
    {
        foreach (var panel in choicePanel)
            panel.GetComponent<Image>().enabled = false;

        choicePanel[currentChoice].GetComponent<Image>().enabled = true;
    }

    private void MoveArrowUp()
    {
        if (currentChoice > 0)
        {
            currentChoice--;
            ActivateChoice();
        }
    }

    private void MoveArrowDown()
    {
        if (currentChoice < choicePanel.Length - 1)
        {
            currentChoice++;
            ActivateChoice();
        }
    }  


    private void EndDialog()
    {
        if(currentChoice == activeNoodle.dialogData.rightAnswer)
            activeNoodle.isExausted = true;

        BlinkingNPC blinking = activeNoodle.GetComponent<BlinkingNPC>();
        blinking.isBlinking = false;
        activeNoodle.GetComponent<AudioSource>().Stop();

        activeNoodle.dialogStarted = false;
        gameObject.SetActive(false);
        activeNoodle = null;

        currentTurn++;
        if (currentTurn >= numberOfTurns)
        {
            GameObject outro = GameObject.Find("Outro");
        }
    }

}
