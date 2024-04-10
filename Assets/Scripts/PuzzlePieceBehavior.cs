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
        doorsTags[0] = "FullDoor";
        doorsTags[1] = "PuzzledDoor";
        doorsTags[2] = "OpenedDoor";
        for (int i = 0; i < doors.Length; i++) 
        {
            doors[i] = GameObject.FindGameObjectsWithTag(doorsTags[i])[0];
        }
        if (!hasPuzzleStarted)
        {
            puzzlePiece.SetActive(false);
        }
        else
        {
            puzzlePiece.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].activeSelf == true)
            {
                currentDoor = doors[i];
                break;
            }
            if (currentDoor.tag == doorsTags[0])
            {
                break;
            }
        }
    }
}
