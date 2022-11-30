using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableComponent : MonoBehaviour
{
    public GameObject playerObject;
    private Vector3 mOffset;
    private float mZCoord;
    public bool isBeingDragged = false;

    private void Start()
    {
        playerObject = GameObject.FindWithTag("MenuPlayerObject");
    }


    private void OnMouseDown()
    {
        isBeingDragged = true;

        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
        if (isBeingDragged == true)
        {
            playerObject.GetComponent<WeaponSelector>().itemBeingEquipped = gameObject;
        } else
        {
            playerObject.GetComponent<WeaponSelector>().itemBeingEquipped = null;
        }
    }
    // Start is called before the first frame update

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);


    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }

    private void OnMouseUp()
    {
        isBeingDragged = false;
    }
}

