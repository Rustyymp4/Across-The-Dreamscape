using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Playercamera : MonoBehaviour
{
    [Header("Referemces")]
    public Transform orientation;
    public Transform player;
    public Transform playerModel;
    public Rigidbody rb;

    public float rotationSpeed;
    public bool cameraLock;

    public CameraStyle currentStyle;

    public Transform aimLookAt;

    public GameObject DefaultCamera;
    public GameObject AimCamera;

    TileInteract tileHit;
    SecondEnigma puzzle2Hit;

    public LayerMask layerAim;

    RaycastHit hit;

    public enum CameraStyle
    {
        Basic,
        Aim
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (cameraLock == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            //Rota orientation
            Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
            orientation.forward = viewDir.normalized;

            if (currentStyle == CameraStyle.Basic)
            {
                //Rota player
                float horInput = Input.GetAxis("Horizontal");
                float verInput = Input.GetAxis("Vertical");
                Vector3 inputDir = orientation.forward * verInput + orientation.right * horInput;

                if (inputDir != Vector3.zero)
                {
                    playerModel.forward = Vector3.Slerp(playerModel.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
                }
            }

            else if (currentStyle == CameraStyle.Aim)
            {
                Vector3 dirAim = aimLookAt.position - new Vector3(transform.position.x, aimLookAt.position.y, transform.position.z);
                orientation.forward = dirAim.normalized;

                playerModel.forward = dirAim.normalized;
            }

            SwitchCam();
    }

            Debug.DrawRay(AimCamera.transform.position, DefaultCamera.transform.rotation * transform.forward * 10, Color.green);

            if (currentStyle == CameraStyle.Aim)
            {
                Physics.Raycast(AimCamera.transform.position, DefaultCamera.transform.rotation * transform.forward, out hit, 10, layerAim);
                {
                    if (Input.GetKeyDown(KeyCode.E) && hit.collider.gameObject != null)
                    {
                        string hitTag = hit.collider.gameObject.tag;
                        if (hitTag == "PickableTile")
                        {
                            tileHit = hit.collider.GetComponent<TileInteract>();
                            if (tileHit != null)
                            {
                                tileHit.PickUp();
                            }

                        }
                        else if (hitTag == "EmptyTile")
                        {
                            Debug.Log("Je tappe une emptyTile");
                            tileHit = hit.collider.GetComponent<TileInteract>();
                            if (tileHit != null)
                            {
                                tileHit.PutPiece();
                            }
                        }
                        else if (hitTag == "Puzzle2")
                        {
                            puzzle2Hit = hit.collider.GetComponent<SecondEnigma>();
                            if (puzzle2Hit != null)
                            {
                                Debug.Log("Je tappe le puzzle 2");
                                puzzle2Hit.PlayEnigma();
                            }
                        }


                    }
                }
            }
        }

        else if (cameraLock == true)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        */
    }


    private void SwitchCam()
    {
        if (currentStyle == CameraStyle.Basic)
        {
            AimCamera.SetActive(false);
            DefaultCamera.SetActive(true);
        }

        else
        {
            AimCamera.SetActive(true);
            DefaultCamera.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            currentStyle = CameraStyle.Aim;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            currentStyle = CameraStyle.Basic;
        }
    }
}