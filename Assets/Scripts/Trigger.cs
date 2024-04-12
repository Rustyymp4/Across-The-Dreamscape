using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject Player;
    public GameObject ScriptTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (tag == "TriggerSpawn")
        {
            ScriptTarget.GetComponent<SundayScript>().Spawn();
        }
        else if (tag == "TriggerEn1")
        {
            ScriptTarget.GetComponent<SundayScript>().Enigma1();
        }
        else if (tag == "TriggerEn2")
        {
            ScriptTarget.GetComponent<SundayScript>().Enigma2();
        }
        else if (tag == "TriggerEn3")
        {
            ScriptTarget.GetComponent<SundayScript>().Enigma3();
        }
        else if (tag == "TriggerCorridor")
        {
            ScriptTarget.GetComponent<SundayScript>().Corridor();
        }
    }
}
