using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoodleNPC : MonoBehaviour
{
  
    [SerializeField]
    public DialogData dialogData;


    [SerializeField]
    private Sprite sprite;

    [SerializeField]
    private string name;

    private bool dialogStarted;
    public bool isExausted;

    private DialogSystem dialogSystem;

    private void Awake()
    {
        dialogSystem = FindObjectOfType<DialogSystem>();
        dialogData.currentAnswer = 0;
        dialogData.currentIntroduction = 0;
    }


    public void StartDialogSystem()
    {
        dialogSystem.gameObject.SetActive(true);
        dialogSystem.InitializeDialog(this);
    }
    
    private void OnMouseDown()
    {
        if (!dialogStarted)
        {
            StartDialogSystem();
            dialogStarted = true;
        }
    }



}
