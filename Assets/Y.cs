using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Y : MonoBehaviour
{
    public GameObject[] dialogs;

    private bool isPlaying = false;
    private SceneCaller sceneCaller;

    private void Start()
    {
        sceneCaller = GetComponent<SceneCaller>();
    }

    public void PlayScript() 
    {
        if(!isPlaying) StartCoroutine(ScriptPlay());
    }


    IEnumerator ScriptPlay()
    {
        isPlaying = true;

        for (int i = 0; i < dialogs.Length; i++)
        {
            dialogs[i].SetActive(true);

            yield return null;
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            dialogs[i].SetActive(false);
        }

        yield return new WaitForSeconds(2f);

        isPlaying = false;
        sceneCaller.LoadTelephone();
    }
}
