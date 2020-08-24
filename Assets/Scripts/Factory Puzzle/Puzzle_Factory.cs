using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Puzzle_Factory : MonoBehaviour
{
    public UnityEvent OnClear;

    public int totalPuzzle = 5;
    public int remainPuzzle = 5;

    public void Match()
    {
        remainPuzzle--;
        if (remainPuzzle == 0) OnClear?.Invoke();
    }
}