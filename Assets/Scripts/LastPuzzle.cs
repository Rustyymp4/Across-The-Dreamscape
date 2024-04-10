using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LastEnigma : MonoBehaviour
{
    public Transform FrogStatue;
    public float speed = 1.0f;
    public void rotateStatue()
    {
        //Vector3 targetDirection = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y + 90, transform.eulerAngles.z);
        Vector3 targetDirection = FrogStatue.position - transform.position;
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.eulerAngles, targetDirection, singleStep, 0.0f);

        if (Input.GetKeyDown(KeyCode.F))
        {
            /*newDirection = Vector3.RotateTowards(transform.eulerAngles, rotation, 90, 90);*/
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    /* void Update()
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

    void Update()
    {
        rotateStatue();
    }
}
