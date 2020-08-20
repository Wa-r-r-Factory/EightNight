using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;

    [SerializeField] string csv_FileName;

    Dictionary<int, Dialog> dialogDic = new Dictionary<int, Dialog>();

    public static bool isFinish = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DialogParser theParser = GetComponent<DialogParser>();
            Dialog[] dialogs = theParser.Parse(csv_FileName);
            for (int i = 0; i < dialogs.Length; i++)
            {
                dialogDic.Add(i + 1, dialogs[i]);
            }
            isFinish = true;
        }

    }

    public Dialog[] GetDialog(int _StartNum, int _EndNum)
    {
        List<Dialog> dialogList = new List<Dialog>();

        for (int i = 0; i <= _EndNum - _StartNum; i++)
        {
            dialogList.Add(dialogDic[_StartNum + i]);
        }

        return dialogList.ToArray();
    }
}
