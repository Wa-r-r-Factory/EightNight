using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    [SerializeField] DialogEvenet dialog;

    private void Start()
    {
        GetDialog();
    }

    public Dialog[] GetDialog()
    {
        dialog.dialogs = DatabaseManager.instance.GetDialog((int)dialog.line.x, (int)dialog.line.y);

        return dialog.dialogs;
    }
}
