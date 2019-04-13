using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoodleNPC : MonoBehaviour
{
  
    [SerializeField]
    private Question openingQuestion;


    [SerializeField]
    private Sprite sprite;

    [SerializeField]
    private string name;

    private bool dialogStarted;


    private DialogSystem dialogSystem;

    private void Awake()
    {
        dialogSystem = FindObjectOfType<DialogSystem>();
    }


    public void StartDialogSystem()
    {
        dialogSystem.gameObject.SetActive(true);
        dialogSystem.InitializeDialog(openingQuestion);
    }



    private void OnMouseDown()
    {
        StartDialogSystem();
        dialogStarted = true;
    }



}
