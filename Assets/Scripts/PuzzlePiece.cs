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
        Debug.Log("지금이야");

        if (Input.GetMouseButtonDown(0))
        {
            if (other.CompareTag("PuzzleAnchor"))
            {
                PuzzleAnchor anchor = other.GetComponent<PuzzleAnchor>();

                if(ID == anchor.anchorID)
                {
                    transform.position = anchor.transform.position;
                    transform.rotation = anchor.transform.rotation;

                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    if (!isMatched) puzzleBase.Match();
                    isMatched = true;

                    Debug.Log("닿았다");
                }
            }
        }
    }
}
