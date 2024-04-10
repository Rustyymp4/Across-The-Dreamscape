using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool movePressed = Input.GetKey(KeyCode.Z);
        if (!isWalking && movePressed)
        {
            animator.SetBool("isWalking", true);
        }
        if (isWalking && !movePressed)
        {
            animator.SetBool("isWalking", false);
        }
        
    }
}
