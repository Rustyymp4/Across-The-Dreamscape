using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LastEnigma : MonoBehaviour
{

    IEnumerator RotateFrog(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t+= Time.deltaTime/inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
    }

    /*public Transform FrogStatue;
    public float speed = 1.0f;
    public void rotateStatue()
    {
        *//*//Vector3 targetDirection = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y + 90, transform.eulerAngles.z);
        Vector3 targetDirection = FrogStatue.position - transform.position;
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.eulerAngles, targetDirection, singleStep, 0.0f);

        if (Input.GetKeyDown(KeyCode.F))
        {
            *//*newDirection = Vector3.RotateTowards(transform.eulerAngles, rotation, 90, 90);*//*
            transform.rotation = Quaternion.LookRotation(newDirection);
        }*//*

    }*/

    /* 
     * 	IEnumerator RotateMe(Vector3 byAngles, float inTime) 
	    {	var fromAngle = transform.rotation;
		    var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
		    for(var t = 0f; t < 1; t += Time.deltaTime/inTime) {
			    transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
			    yield return null;
		    }
	    }
        void Update () 
        {
	        if(Input.GetKeyDown("e")){
	        StartCoroutine(RotateMe(Vector3.up * 90, 0.8f));
	        }
	        if(Input.GetKeyDown("q")){
	        StartCoroutine(RotateMe(Vector3.up * -90, 0.8f));
	        }
          }
        }
     * 
     * 
     * 
     * void Update()
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = target.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }*/

    public Transform frog;
    public Transform door;
    public Vector3 correctRotation;
    public bool doorOpening = false;

    public void openDoor()
    {
        if (doorOpening)
        {
            door.Rotate(0, 90, 0);
            doorOpening = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        { 
            StartCoroutine(RotateFrog(Vector3.up * 90, 0.8f));
            //frog.Rotate(0, 90, 0);
            //transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        Debug.Log(frog.eulerAngles.y);
        Debug.Log(correctRotation.y + 1);

        if (frog.eulerAngles.y < correctRotation.y + 1 && frog.eulerAngles.y > correctRotation.y - 1)
        {
            doorOpening = true;
            openDoor();
        }
    }
}
