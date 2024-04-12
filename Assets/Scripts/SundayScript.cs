using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SundayScript : MonoBehaviour
{
    public Canvas SundayCanvas;
    public BoxCollider bcSpawn;
    public BoxCollider bcEnigma1;
    public BoxCollider bcEnigma2;
    public BoxCollider bcEnigma3;
    public BoxCollider bcCorridor;

    public GameObject door;

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
            if (line == 6 && script == "spawn")
            {
                door.SetActive(false);
            }
            else if (line == 1 && script == "corridor")
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
        script = "spawn";
        txt = new string[7] { " ", " ", " ", " ", " ", " ", " " };

        line = 0;
        isInDialogue = true;

        txt[0] = "Robin! Robin do you hear me? What have you done!";
        txt[1] = "It seems like The Family didn't quite like you peaking where you shouldn't haha.";
        txt[2] = "But don't fret! I'll help you get out of this Dreamscape.";
        txt[3] = "You'll have to solve puzzles and enigmas to do so, but first let me introduce you to the controls.";
        txt[4] = "Move around with Z, Q, S and D. Focus with Right Click and Aim with the Mouse.";
        txt[5] = "You can interact with an item by focusing on it and pressing E next to it.";
        txt[6] = "That should be it! Now move to the next room, I'm opening the door for you.";

        SundayCanvas.gameObject.SetActive(true);
        text.text = txt[line];
        bcSpawn.enabled = false;
    }

    public void Enigma1()
    {
        script = "en1";
        txt = new string[2] { " ", " " };

        line = 0;
        isInDialogue = true;

        txt[0] = "For the door to open in this room, you will need to find three shattered pieces of a dream.";
        txt[1] = "Poor dreams, get enlightened!";

        SundayCanvas.gameObject.SetActive(true);
        text.text = txt[line];
        bcEnigma1.enabled = false;
    }

    public void Enigma2()
    {
        script = "en2";
        txt = new string[3] { " ", " ", " " };

        line = 0;
        isInDialogue = true;

        txt[0] = "Excellent! Now... you should be in a big L-shaped room, right?";
        txt[1] = "Here, you'll have to find 3 gear pieces to get out of the room.";
        txt[2] = "I'll highlight them for you!";

        SundayCanvas.gameObject.SetActive(true);
        text.text = txt[line];
        bcEnigma2.enabled = false;
    }

    public void Enigma3()
    {
        script = "en3";
        txt = new string[3] { " ", " ", " " };

        line = 0;
        isInDialogue = true;

        txt[0] = "Keep at it, you're almost there";
        txt[1] = "To go further, you need to look back on your journey so far.";
        txt[2] = "With the help of the frogs, look behind you one last time.";

        SundayCanvas.gameObject.SetActive(true);
        text.text = txt[line];
        bcEnigma3.enabled = false;
    }

    public void Corridor()
    {
        script = "corridor";
        txt = new string[2] { " ", " " };

        line = 0;
        isInDialogue = true;

        txt[0] = "Do you feel this heavy atmosphere as well? It seems like you're almost out of there!";
        txt[1] = "Huh, what is that??";

        SundayCanvas.gameObject.SetActive(true);
        text.text = txt[line];
        bcCorridor.enabled = false;
    }
}