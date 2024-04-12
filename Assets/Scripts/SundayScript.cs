using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SundayScript : MonoBehaviour
{
    public Canvas SundayCanvas;
    public BoxCollider bcEnigma2;

    public Text text;
    string txt;

    public void Enigma2()
    {
        SundayCanvas.gameObject.SetActive(true);

        text.text = "Excellent! Now... you should be in a big L-shaped room, right? Here, you'll have to find 3 gear pieces to get out of the room.";
        //text.text = "Here, you'll have to find 3 gear pieces to get out of the room.";
        //text.text = "I'll highlight them for you!";
    }
}
