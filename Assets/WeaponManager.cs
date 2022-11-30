using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    static WeaponManager instance;
    public GameObject[] equippedWeapons;
    public WeaponSelector weaponSelector;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("MenuPlayerObject") != null)
        {
            weaponSelector = GameObject.FindWithTag("MenuPlayerObject").GetComponent<WeaponSelector>();
            if(weaponSelector.itemSlots[0].transform.childCount > 0)
        {
            equippedWeapons[0] = weaponSelector.itemSlots[0].transform.GetChild(0).gameObject;
        }
        if(weaponSelector.itemSlots[1].transform.childCount > 0)
        {
            equippedWeapons[1] = weaponSelector.itemSlots[1].transform.GetChild(0).gameObject;
        }
        if(weaponSelector.itemSlots[2].transform.childCount > 0)
        {
            equippedWeapons[2] = weaponSelector.itemSlots[2].transform.GetChild(0).gameObject;
        }
        if(weaponSelector.itemSlots[3].transform.childCount > 0)
        {
            equippedWeapons[3] = weaponSelector.itemSlots[3].transform.GetChild(0).gameObject;
        }
        
        
    }
}

        }

       
        