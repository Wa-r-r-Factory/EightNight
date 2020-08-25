using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDialogManager : MonoBehaviour
{
    public GameObject[] dialogList;


    private void Start()
    {
        for (int i = 0; i < dialogList.Length; i++)
        {
            HideDialog(i);
        }
    }

    public void ShowDialogOneShot(int index)
    {
        StartCoroutine(PlayScript(index));
    }

    public void ShowDialog(int index)
    {
        dialogList[index].SetActive(true);
    }

    public void HideDialog(int index)
    {
        dialogList[index].SetActive(false);
    }

    IEnumerator PlayScript(int index)
    {
        ShowDialog(index);

        yield return new WaitForSeconds(3.5f);

        HideDialog(index);
    }
}
