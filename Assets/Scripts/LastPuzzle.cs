using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LastEnigma : MonoBehaviour
{
    public Transform frog;
    public Transform door;
    public Vector3 correctRotation;
    public bool doorOpening = false;
    public bool doorIsOpen = false;
    public bool frogRotating = false; 

    IEnumerator RotateFrog(Vector3 byAngles, float inTime)
    {
        var fromAngle = frog.rotation;
        var toAngle = Quaternion.Euler(frog.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t+= Time.deltaTime/inTime)
        {
            frog.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        frogRotating = false;
    }

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        { 
            if (!frogRotating)
            {
                frogRotating = true;
                StartCoroutine(RotateFrog(Vector3.up * 90, 0.8f));
            }
        }

        /*Debug.Log(frog.eulerAngles.y);
        Debug.Log(correctRotation.y + 1);*/

        if (frog.eulerAngles.y < correctRotation.y + 1 && frog.eulerAngles.y > correctRotation.y - 1 && doorIsOpen == false)
        {
            doorOpening = true;
            StartCoroutine(OpenDoor(Vector3.up * 90, 0.8f));
            doorIsOpen = true;
            //StopCoroutine(OpenDoor(Vector3.up * 90, 0.8f));
        }
    }
}
