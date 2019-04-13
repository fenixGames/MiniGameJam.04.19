using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoodleNPC : MonoBehaviour
{
  
    [SerializeField]
    public DialogData dialogData;

    [SerializeField]
    private string name;

    public bool dialogStarted;

    public bool isExausted;

    [SerializeField]
    private DialogSystem dialogSystem;

    public void StartDialogSystem()
    {
        dialogSystem.InitializeDialog(this);
    }
    
    private void OnMouseDown()
    {
        if (!dialogStarted && ! isExausted)
        {
            StartDialogSystem();
            dialogStarted = true;
        }
    }



}
