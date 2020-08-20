using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Dialog
{
    [Tooltip("대사치는 캐릭터 이름")]
    public string name;

    [Tooltip("대사 내용")]
    public string[] contexts;
}

[System.Serializable]
public class DialogEvenet
{
    public string name;

    public Vector2 line;
    public Dialog[] dialogs;
}
