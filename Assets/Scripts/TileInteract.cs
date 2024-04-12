using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInteract : MonoBehaviour
{
    public GameObject pickUpTile;
    public GameObject actualTile;
    public GameObject puzzleObject;
    public Vector3[] correctTilePos;
    public int tilePos;

    public bool isCollected;
    public bool isInserted;
    public bool isCorrect;

    Quaternion fromAngle;
    Quaternion toAngle;

    public void PickUp()
    {

        Debug.Log("Interacted");
        isCollected = true;
        gameObject.SetActive(false);
    }

    public void PutPiece()
    {
        if (pickUpTile.GetComponent<TileInteract>().isCollected == true)
        {
            Debug.Log("Placed");
            actualTile.GetComponent<TileInteract>().isInserted = true;
            actualTile.SetActive(true);
            gameObject.SetActive(false);

            if (puzzleObject.GetComponent<SecondEnigma>().CheckPieces() == false)
            {
                puzzleObject.GetComponent<SecondEnigma>().insertedPieces += 1;
                puzzleObject.GetComponent<SecondEnigma>().CheckPieces();
            }
        }
    }

    public void RotatePiece()
    {

        if (tilePos == 0)
        {
            toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(90, 0, 0));
            tilePos = 1;
        }
        else if (tilePos == 1)
        {
            toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(-90, 0, 0));
            tilePos = 2;
        }
        else if (tilePos == 2)
        {
            toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(-90, 0, 0));
            tilePos = 3;
        }
        else if (tilePos == 3)
        {
            toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(90, 0, 0));
            tilePos = 0;
        }

        for (var t = 0f; t < 1; t += Time.deltaTime / 30)
        {
            fromAngle = transform.rotation;
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
        }
        Debug.Log(transform.rotation.eulerAngles.x);

        if (correctTilePos.Length == 1)
        {
            if (correctTilePos[0] == transform.rotation.eulerAngles)
            { isCorrect = true; }
            else
            { isCorrect = false; }
        }
        else if (correctTilePos.Length == 2)
        {
            if (correctTilePos[0] == transform.rotation.eulerAngles)
            { isCorrect = true; }
            else if (correctTilePos[1] == transform.rotation.eulerAngles)
            { isCorrect = true; }
            else 
            { isCorrect = false; }
        }
        else if (correctTilePos.Length == 4)
        {
            isCorrect = true;
        }
    }
}
