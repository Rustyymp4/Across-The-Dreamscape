using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunday_Interact : MonoBehaviour
{
    public Transform player;
    public Transform trigger;

    void Update()
    {
        if (player.position.x < trigger.position.x && player.position.z < trigger.position.z)
        {
            Debug.Log("je parle");
        }
    }
}
