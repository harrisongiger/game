using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    public GameObject[] itemSlots;
    GameObject closest;
    

   
    public GameObject itemBeingEquipped;
    Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<Collider>();     
    }

    // Update is called once per frame
    void Update()
    {
        if (itemBeingEquipped != null && itemBeingEquipped.GetComponent<DraggableComponent>().isBeingDragged == false)
        {
            Invoke("DisableCollider", 0.5f);
        } else
        {
            collider.enabled = true;
        }

    }

    GameObject FindShortestDist()
    {
        closest = null;
        float shortestDist = Mathf.Infinity;
        foreach (GameObject itemSlot in itemSlots)
        {
            float dist = Vector3.Distance(itemSlot.transform.position, itemBeingEquipped.transform.position);
            if (dist < shortestDist)
            {
             
                closest = itemSlot;
                shortestDist = dist;
                
                //Debug "1" "2" "3" ASK ANSEL
            }
        }

        Debug.Log(closest);
        return closest;
       
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject == itemBeingEquipped)
        {
            FindShortestDist();
            Debug.Log("balls");
            if(itemBeingEquipped.GetComponent<DraggableComponent>().isBeingDragged == false && closest.transform.childCount == 0)
            {
                Debug.Log("balloon");
                
                itemBeingEquipped.GetComponent<DraggableComponent>().enabled = false;
                SnapToSlot();
               
            } else
            {
                itemBeingEquipped.transform.parent = null;
            }
        }  
    }

    void SnapToSlot()
    {
        itemBeingEquipped.transform.position = closest.transform.position;
        itemBeingEquipped.GetComponent<DraggableComponent>().enabled = true;
        itemBeingEquipped.transform.parent = closest.gameObject.transform;
        itemBeingEquipped.transform.localRotation = Quaternion.identity;

    }

    void DisableCollider()
    {
        collider.enabled = false;
    }

}
//float dist = Mathf.Abs(itemBeingEquipped.transform.position.x - itemSlot.transform.position.x);

