using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomGenerator : MonoBehaviour
{

    [SerializeField]
    GameObject startingRoom;
    // door at +z, -x
    [SerializeField]
    GameObject cornerRoom;
    // door at -x
    [SerializeField]
    GameObject oneDoorRoom;
    // door at -x, +x
    [SerializeField]
    GameObject twoDoorRoom;
    // door at -x, -z, +z
    [SerializeField]
    GameObject threeDoorRoom;
    // door in all directions
    [SerializeField]
    GameObject fourDoorRoom;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
