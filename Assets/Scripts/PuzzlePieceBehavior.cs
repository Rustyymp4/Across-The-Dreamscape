using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePieceBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hasPuzzleStarted = false;
    public bool hasBeenCaught = false;
    public GameObject puzzlePiece;
    public GameObject[] doors = new GameObject[3];
    public static string[] doorsTags = new string[3];
    GameObject currentDoor;

    void Start()
    {
        puzzlePiece.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
