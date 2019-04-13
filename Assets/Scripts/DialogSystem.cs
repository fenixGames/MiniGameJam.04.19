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
    private GameObject[] choicePanel;

    private NoodleNPC activeNoodle;

    private int currentChoice;


    enum State { opening, questions, answers };

    private State currentState;
   


    public void InitializeDialog(NoodleNPC noodle)
    {
        DeactivateChoiceText();
        
        activeNoodle = noodle;
        currentState = State.opening;
        npcSpeech.text = noodle.dialogData.GetNextIntroduction();
        npcSpeech.gameObject.SetActive(true);
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
        if(Input.GetKeyDown(KeyCode.Space))
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
            }

        }



        if (Input.GetKeyDown(KeyCode.DownArrow))
            MoveArrowDown();
        if (Input.GetKeyDown(KeyCode.UpArrow))
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
            currentChoice --;
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

    public void ChoiceSelected()
    {
       // questionData.answer[arrowPosition]
    }


    




}
