using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    public GameObject Player;
    float yrotation = -20;
    float xrotation = 40;
    public float camRotateSpeed;
    public bool firstPerson = false;
    //public GameObject fpsPlayer;
    //public GameObject tpPlayer;

    void Update()
    {

        //if (firstPerson == false)
        //{
        //    fpsPlayer.SetActive(false);
        //    tpPlayer.SetActive(true);
        //} else
        //{
        //    fpsPlayer.SetActive(true);
        //    tpPlayer.SetActive(false);
        //}

        if (Input.GetKeyDown(KeyCode.C))
        {
            firstPerson = !firstPerson;
        }

        if (Player.transform.position.x >= -25 && Player.transform.position.x <= 25)
        {
            // for camera to move across the whole wall.
            //transform.position = new Vector3(Player.transform.position.x, CamYPos, CamZPos);
            //yrotation = Player.transform.position.x * -1.4583f;
            transform.rotation = Quaternion.Euler(xrotation, yrotation, 0);
        }

        if (Player.transform.position.x < -0.1f && yrotation > -50)
        {
            // rotate camera to -50 on x axis
            yrotation -= Time.deltaTime * camRotateSpeed;
        } else if (Player.transform.position.x > -0.1f && yrotation < -20)
        {
            yrotation += Time.deltaTime * camRotateSpeed;
        }

        if (Input.GetKey(KeyCode.UpArrow) && xrotation >= 20)
        {
            xrotation -= Time.deltaTime * 30;
            transform.rotation = Quaternion.Euler(xrotation, yrotation, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) && xrotation <= 55)
        {
            xrotation += Time.deltaTime * 30;
            transform.rotation = Quaternion.Euler(xrotation, yrotation, 0);
        }

        //for horizontal camera shake; Input.GetAxis("Horizontal") in the camera's quaternion

        
        
    }
}
