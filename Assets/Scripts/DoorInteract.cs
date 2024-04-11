using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteract : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] puzzlePiece = new GameObject[3];
        //puzzlePiece = GameObject.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            transform.Rotate(0, 90, 0);
            /*SceneManager.LoadScene("First-Puzzle");*/
        }

    }
}
