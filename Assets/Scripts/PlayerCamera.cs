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

    public CameraStyle currentStyle;

    public Transform aimLookAt;

    public GameObject DefaultCamera;
    public GameObject AimCamera;

    TileInteract colliderHit;

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

    private void FixedUpdate()
    {
        if (currentStyle == CameraStyle.Aim)
        {
            if (Physics.Raycast(AimCamera.transform.position, AimCamera.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, 3))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.DrawRay(AimCamera.transform.position, AimCamera.transform.TransformDirection(Vector3.forward) * Mathf.Infinity, Color.blue);
                    colliderHit = hit.collider.GetComponent<TileInteract>();
                    colliderHit.Interact();
                }

            }

        }
        /*
        if (currentStyle == CameraStyle.Basic)
        {
            
        }
        */
    }

    private void SwitchCam()
    {
        if(currentStyle == CameraStyle.Basic)
        {
            AimCamera.SetActive(false);
            DefaultCamera.SetActive(true);
        }

        else
        {
            AimCamera.SetActive(true);
            DefaultCamera.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            currentStyle = CameraStyle.Aim;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            currentStyle = CameraStyle.Basic;
        }
    }
}
