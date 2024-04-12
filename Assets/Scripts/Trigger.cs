using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject Player;
    public GameObject ScriptTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (tag == "Spawn")
        {
            ScriptTarget.GetComponent<SundayScript>().Spawn();
        }
        else if (tag == "En1")
        {
            ScriptTarget.GetComponent<SundayScript>().Enigma1();
        }
        else if (tag == "En2")
        {
            ScriptTarget.GetComponent<SundayScript>().Enigma2();
        }
        else if (tag == "En3")
        {
            ScriptTarget.GetComponent<SundayScript>().Enigma3();
        }
        else if (tag == "Corridor")
        {
            ScriptTarget.GetComponent<SundayScript>().Corridor();
        }
    }
}
