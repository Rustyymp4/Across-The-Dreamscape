using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInteract : MonoBehaviour
{
    public bool isCollected;

    public void Interact()
    {
        Debug.Log("Interacted");
        isCollected = true;
        this.gameObject.SetActive(false);
    }
}
