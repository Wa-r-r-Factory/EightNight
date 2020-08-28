using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{

    public Puzzle_Factory puzzleBase;
    public int ID;
    private bool isMatched = false;

    private Transform origin;

    private void Start()
    {
        origin = transform;
    }

    
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("PuzzleAnchor"))
        {
            PuzzleAnchor anchor = other.GetComponent<PuzzleAnchor>();

            if(ID == anchor.anchorID && !transform.parent.CompareTag("MainCamera"))
            {
                Debug.Log("지금!");
                StartCoroutine(FixPuzzle(anchor));
            }
        }
    }



    
    IEnumerator FixPuzzle(PuzzleAnchor anchor)
    {
        yield return null;
        transform.position = anchor.transform.position;
        transform.rotation = anchor.transform.rotation;

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        if (!isMatched) puzzleBase.Match();
        isMatched = true;
    }

}
