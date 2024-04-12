using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteract : MonoBehaviour
{
    public Transform door;
    public bool doorOpening = false;
    public bool doorIsOpen = false;
    public GameObject[] puzzlePieces = new GameObject[3];

    // Start is called before the first frame update

    IEnumerator OpenDoor(Vector3 byAngles, float inTime)
    {
        if (doorOpening)
        {
            var fromAngle = door.rotation;
            var toAngle = Quaternion.Euler(door.eulerAngles + byAngles);
            for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
            {
                door.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
                yield return null;
            }
        }
        doorOpening = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!doorIsOpen && puzzlePieces[0].GetComponent<PuzzlePieceBehavior>().isCollected && puzzlePieces[1].GetComponent<PuzzlePieceBehavior>().isCollected && puzzlePieces[2].GetComponent<PuzzlePieceBehavior>().isCollected)
        {
            doorOpening = true;
            StartCoroutine(OpenDoor(Vector3.up * 90, 0.8f));
            doorIsOpen = true;
        }
    }
}
