using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SundayScript : MonoBehaviour
{
    public GameObject door;
    public Canvas SundayCanvas;
    public BoxCollider bcSpawn;
    public BoxCollider bcEnigma1;
    public BoxCollider bcEnigma2;
    public BoxCollider bcEnigma3;
    public BoxCollider bcCorridor;

    public Text text;
    string[] txt;
    string script;
    int line;

    public bool isTalking;
    public bool isInDialogue;

    public void NextLine()
    {
        Debug.Log("NextLine");
        line++;
        text.text = txt[line];
        SundayCanvas.gameObject.SetActive(true);
    }

    public void FinishLine()
    {
        isTalking = false;
        SundayCanvas.gameObject.SetActive(false);
        Debug.Log(txt.Length + "    " + line);

        if (txt.Length - 1 > line)
        {
            NextLine();
        }
        else if (txt.Length - 1 == line)
        {
            if (script == "spawn")
            {
                door.SetActive(false);
            }
            if (script == "corridor")
            {
                SceneManager.LoadScene("MainMenu");
            }
            isInDialogue = false;
        }
    }

    public void Update()
    {

    }

    public void Spawn()
    {
        txt = new string[7] { " ", " ", " ", " ", " ", " ", " " };
        script = "spawn";

        line = 0;
        isInDialogue = true;

        txt[0] = "Robin! Robin do you hear me? What have you done?!";
        txt[1] = "It seems like The Family didn't quite like you peaking where you shouldn't.";
        txt[2] = "But don't fret! I'll help you get out of this Dreamscape.";
        txt[3] = "You'll have to solve puzzle and enigmas to do so, but first let me show you the controls.";
        txt[4] = "Move around with Z, Q, S and D. Focus with Right Click and Aim with the Mouse.";
        txt[5] = "You can interact with an item by focusing on it and pressing E.";
        txt[6] = "That should be it! Now move to the next room, I'm opening the door for you.";

        SundayCanvas.gameObject.SetActive(true);
        bcSpawn.enabled = false;
        text.text = txt[line];
    }

    public void Enigma1()
    {
        txt = new string[2] { " ", " " };
        script = "en1";

        line = 0;
        isInDialogue = true;

        txt[0] = "For the door to open in this room, you will need to find three shattered pieces of a dream.";
        txt[1] = "Poor dreams, get enlightened !";

        SundayCanvas.gameObject.SetActive(true);
        bcEnigma1.enabled = false;
        text.text = txt[line];
    }

    public void Enigma2()
    {
        txt = new string[3] { " ", " ", " " };
        script = "en2";

        line = 0;
        isInDialogue = true;

        txt[0] = "Excellent! Now... you should be in a big L-shaped room, right?";
        txt[1] = "Here, you'll have to find 3 gear pieces to get out of the room.";
        txt[2] = "I'll highlight them for you!";

        SundayCanvas.gameObject.SetActive(true);
        bcEnigma2.enabled = false;
        text.text = txt[line];
    }

    public void Enigma3()
    {
        txt = new string[3] { " ", " ", " " };
        script = "en3";

        line = 0;
        isInDialogue = true;

        txt[0] = "Keep at it, you're almost there.";
        txt[1] = "To go further, you need to look back on your journey so far.";
        txt[2] = "With the help of the frogs, look behind you one last time.";

        SundayCanvas.gameObject.SetActive(true);
        bcEnigma3.enabled = false;
        text.text = txt[line];
    }

    public void Corridor()
    {
        txt = new string[2] { " ", " "};
        script = "corrior";

        line = 0;
        isInDialogue = true;

        txt[0] = "Hey, do you feel this super heavy pressure as well? It seems like you're soon out of there!";
        txt[1] = "Huh, what's this?";

        SundayCanvas.gameObject.SetActive(true);
        bcCorridor.enabled = false;
        text.text = txt[line];
    }
}