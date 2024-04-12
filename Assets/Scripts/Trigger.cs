using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject Player;
    public GameObject ScriptTarget;

    private void OnTriggerEnter(Collider other)
    {
            ScriptTarget.GetComponent<SundayScript>().Enigma2();
    }
}
