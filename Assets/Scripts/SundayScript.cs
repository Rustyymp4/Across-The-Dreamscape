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
    string[] txt;
    int line;

    public bool isTalking;
    public bool isInDialogue;

    public void NextLine()
    {
        Debug.Log("NextLine");
        line ++;
        text.text = txt[line];
        SundayCanvas.gameObject.SetActive(true);
    }

    public void FinishLine()
    {
        isTalking = false;
        SundayCanvas.gameObject.SetActive(false);
        Debug.Log(txt.Length + "    " + line);

        if (txt.Length > line)
        {
            NextLine();
        }
        else if (txt.Length == line)
        {
            isInDialogue = false;
        }
    }

    public void Update()
    {

    }

    public void Spawn()
    {
        txt = new string[3] { " ", " ", " " };

        line = 0;
        isInDialogue = true;

        txt[0] = "Excellent! Now... you should be in a big L-shaped room, right?";
        txt[1] = "Here, you'll have to find 3 gear pieces to get out of the room.";
        txt[2] = "I'll highlight them for you!";

        SundayCanvas.gameObject.SetActive(true);
        text.text = txt[line];
    }

    public void Enigma1()
    {
        txt = new string[3] { " ", " ", " " };

        line = 0;
        isInDialogue = true;

        txt[0] = "Excellent! Now... you should be in a big L-shaped room, right?";
        txt[1] = "Here, you'll have to find 3 gear pieces to get out of the room.";
        txt[2] = "I'll highlight them for you!";

        SundayCanvas.gameObject.SetActive(true);
        text.text = txt[line];
    }

    public void Enigma2()
    {
        txt = new string[3] { " ", " ", " "};

        line = 0;
        isInDialogue = true;

        txt[0] = "Excellent! Now... you should be in a big L-shaped room, right?";
        txt[1] = "Here, you'll have to find 3 gear pieces to get out of the room.";
        txt[2] = "I'll highlight them for you!";

        SundayCanvas.gameObject.SetActive(true);
        text.text = txt[line];
    }

    public void Enigma3()
    {
        txt = new string[3] { " ", " ", " " };

        line = 0;
        isInDialogue = true;

        txt[0] = "Excellent! Now... you should be in a big L-shaped room, right?";
        txt[1] = "Here, you'll have to find 3 gear pieces to get out of the room.";
        txt[2] = "I'll highlight them for you!";

        SundayCanvas.gameObject.SetActive(true);
        text.text = txt[line];
    }

    public void Corridor()
    {
        txt = new string[3] { " ", " ", " " };

        line = 0;
        isInDialogue = true;

        txt[0] = "Excellent! Now... you should be in a big L-shaped room, right?";
        txt[1] = "Here, you'll have to find 3 gear pieces to get out of the room.";
        txt[2] = "I'll highlight them for you!";

        SundayCanvas.gameObject.SetActive(true);
        text.text = txt[line];
    }
}
