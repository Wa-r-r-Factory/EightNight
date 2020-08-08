using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private Transform playerCharacter = null;

    private void Awake()
    {
        playerCharacter = GameObject.FindWithTag("Player").transform;
    }

    public void ResetPosition()
    {
        playerCharacter.position = Vector3.zero;
    }


}
