using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool _mouseState;
    public bool isCorrectlyPlaced;
    private GameObject target;
    public Vector3 correctlyPlacedPieceCoords;
    public Vector3 screenSpace;
    public Vector3 offset;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isCorrectlyPlaced);
        if (Input.GetMouseButtonDown(0) && !this.isCorrectlyPlaced)
        {
            //Debug.Log("je peux bouger :)");
            RaycastHit hitInfo;
            target = GetClickedObject(out hitInfo);
            if (target != null)
            {
                //Debug.Log(target.transform.position);
                _mouseState = true;
                Cursor.visible = false;
                screenSpace = Camera.main.WorldToScreenPoint(target.transform.position);
                offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
            }
            else if (correctlyPlacedPieceCoords.x == target.transform.position.x + 0.1f || correctlyPlacedPieceCoords.x == target.transform.position.x - 0.1f 
                || correctlyPlacedPieceCoords.z == target.transform.position.z + 0.1f || correctlyPlacedPieceCoords.z == target.transform.position.z - 0.1f)
            {
                //Debug.Log("Bien placé");
                isCorrectlyPlaced = true;
                target.transform.position = correctlyPlacedPieceCoords;
            }
        }
        if (Input.GetMouseButtonUp(0) || isCorrectlyPlaced)
        {
            _mouseState = false;
            Cursor.visible = true;
        }
        if (_mouseState)
        {
            //keep track of the mouse position
            var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

            //convert the screen mouse position to world point and adjust with offset
            var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

            //update the position of the object in the world
            target.transform.position = curPosition;
        }
    }


    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }

        return target;
    }
}