using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = this.transform.parent.parent.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool isMoving = rb.velocity.magnitude > 0.1;
        if (!isWalking && isMoving)
        {
            animator.SetBool("isWalking", true);
        }
        if (isWalking && !isMoving)
        {
            animator.SetBool("isWalking", false);
        }
        
    }
}
