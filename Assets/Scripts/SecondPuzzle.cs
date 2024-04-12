using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SecondEnigma : MonoBehaviour
{
    public int insertedPieces;

    public bool isInEnigma;

    public GameObject playerModel;
    public GameObject orthoCam;
    public GameObject freeCam;
    public GameObject aimCam;
    public GameObject door;

    public Camera mainCam;
    public Canvas crosshair;

    public Text text;

    TileInteract tileHit;
    public TileInteract[] tileList;

    public int correctTiles;


    public bool CheckPieces()
    {
        if (insertedPieces == 3)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
            return true;
        }

        return false;
    }

    public void PlayEnigma()
    {
        if (CheckPieces() == true)
        {
            orthoCam.SetActive(true);
            freeCam.SetActive(false);
            aimCam.SetActive(false);

            isInEnigma = true;

            mainCam.orthographic = true;
            mainCam.GetComponent<Playercamera>().cameraLock = true;

            playerModel.SetActive(false);
            crosshair.enabled = false;

            gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    public void ExitEnigma()
    {
        orthoCam.SetActive(false);
        freeCam.SetActive(true);

        isInEnigma = false;

        mainCam.orthographic = false;
        mainCam.GetComponent<Playercamera>().cameraLock = false;

        playerModel.SetActive(true);
        crosshair.enabled = true;

        gameObject.GetComponent<Collider>().enabled = true;
    }

    void CheckWin()
    {
        correctTiles = 0;

        for (int i = 0; i < tileList.Length; i++)
        {
            if (tileList[i].isCorrect == true)
            {
                correctTiles += 1;
            }
        }
        Debug.Log(correctTiles);

        if (correctTiles == tileList.Length)
        {
            Debug.Log("Win!!!!");
            Win();
        }
    }

    void Win()
    {
        for (int i = 0; i < 100; i++)
        {
            gameObject.SetActive(false);
            door.SetActive(false);
        }
        ExitEnigma();
    }

    private void Update()
    {
        if (isInEnigma)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ExitEnigma();
            }

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit, 10, mainCam.GetComponent<Playercamera>().layerAim);

                tileHit = hit.collider.GetComponent<TileInteract>();
                if (tileHit != null)
                {
                    tileHit.RotatePiece();
                    CheckWin();
                }
            }
        }
    }

}
