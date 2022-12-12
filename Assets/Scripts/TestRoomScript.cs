using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRoomScript : MonoBehaviour
{
    [SerializeField]
    GameObject room;
    private Vector3 roomTransform;
    [SerializeField]
    GameObject roomCenter;

    // Start is called before the first frame update
    void Start()
    {
        roomTransform = room.transform.position;
        roomCenter.transform.position = new Vector3(roomTransform.x - 3f, roomTransform.y, roomTransform.z - 3f);
        room.transform.SetParent(roomCenter.transform);
    }
}
