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

    private Question questionData;

    private int currentChoice;


    [SerializeField]
    private Color choiceBackGroundcolor;




    private enum State { opening, choices, answers };

    private State currentState;
   


    public void InitializeDialog(Question question)
    {
        DeactivateChoiceText();
        
        questionData = question;
        currentState = State.opening;
        npcSpeech.text = question.openingStatement;
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
                    Showchoices();
                    currentState ++;
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



        for (int i = 0; i < choicePanel.Length; i++)
        {
            choicePanel[i].SetActive(true);
        }
    }



    private void MoveArrowUp()
    {
        if (currentChoice > 0)
        {
            currentChoice --;

            //arrow.transform.position = playerChoices[arrowPosition].transform.position;
            //arrow.transform.position -= new Vector3(arrowOffset, 0, 0);
        }
    }

    private void MoveArrowDown()
    {
        if (currentChoice < questionData.choices.Length)
        {
            currentChoice++;
            //arrow.transform.position = playerChoices[arrowPosition].transform.position;
            //arrow.transform.position -= new Vector3(arrowOffset, 0, 0);
        }
    }

    public void ChoiceSelected()
    {
       // questionData.answer[arrowPosition]
    }


    




}
