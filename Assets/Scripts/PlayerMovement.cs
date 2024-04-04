using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController rb;
    public MeshRenderer playerModel;
    public float mvmntVelocity;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - 90;
            float angle = Mathf.SmoothDampAngle(playerModel.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            playerModel.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            rb.Move(direction * speed * Time.deltaTime);
        }
    }
}
