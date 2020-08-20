using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject go_DialogBox;
   // [SerializeField] GameObject go_DialogNameBox;

    [SerializeField] TextMeshProUGUI txt_Dialog;
   // [SerializeField] TextMeshPro txt_Name;

    Dialog[] dialogs;

    bool isDialog = false; // 대화창이 떠있는지
    bool isNext = false; // 다음 키 입력 대기

    int lineCount = 0; // 대화 카운트
    int contextCount = 0; // 대사 카운트

    public void Start()
    {
        SettingUI(false);
        dialogs = GetComponent<InteractionEvent>().GetDialog();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowDialog();
        }
    }

    public void ShowDialog()
    {
        txt_Dialog.text = "";
       // txt_Name.text = "";

        StartCoroutine(TypeWriter());
    }

    IEnumerator TypeWriter()
    {
        SettingUI(true);

        string t_ReplaceText = dialogs[lineCount].contexts[contextCount];
        t_ReplaceText = t_ReplaceText.Replace("'", ",");

        txt_Dialog.text = t_ReplaceText;

        isNext = true;
        yield return null;
    }

    public void SettingUI(bool p_flag)
    {
        go_DialogBox.SetActive(p_flag);
        //go_DialogNameBox.SetActive(p_flag);
    }
}
