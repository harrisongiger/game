using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRoomScript : MonoBehaviour
{
    [SerializeField]
    GameObject room;
    private Vector3 roomTransform;
    Vector3 roomVertex;
    Vector3 roomVertex2;
    public Vector3 roomCenter;

    // Start is called before the first frame update
    void Start()
    {
        roomTransform = room.transform.position;
        roomVertex = new Vector3(roomTransform.x + 1.5f, roomTransform.y, roomTransform.z + 1.5f);
        roomVertex2 = new Vector3(roomVertex.x - 9f, roomVertex.y, roomVertex.z - 9f);
        roomCenter = (roomVertex + roomVertex2) / 2;
        Debug.Log(roomVertex);
        Debug.Log(roomVertex2);
        Debug.Log(roomCenter);


    }

    // Update is called once per frame
    void Update()
    {

    }
}
