using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject go_DialogBox;
    [SerializeField] GameObject go_DialogNameBox;

    [SerializeField] TextMeshPro txt_Dialog;
    [SerializeField] TextMeshPro txt_Name;

    bool isDialog = false;

    public void Start()
    {
        SettingUI(false);
    }

    public void ShowDialog()
    {
        txt_Dialog.text = "";
        txt_Name.text = "";

        SettingUI(true);
    }

    public void SettingUI(bool p_flag)
    {
        go_DialogBox.SetActive(p_flag);
        go_DialogNameBox.SetActive(p_flag);
    }
}
