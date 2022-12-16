using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponManager : MonoBehaviour
{
    // 1 = lazer

    static WeaponManager instance;
    [SerializeField]
    int[] equippedWeaponsData;

    [SerializeField]
    GameObject[] inGameItemSlots;

    public GameObject[] weapons;
    


    [SerializeField]
    WeaponSelector weaponSelector;
    GameObject thing0;

    public bool weaponSelectorAssigned = false;

    public GameObject player;
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

    // Update is called once per frame
    void Update()
    {

       

        

        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        Scene scene = SceneManager.GetActiveScene();

       

        if (scene.name == "MenuPrototype")
        {
            if(weaponSelector == null && weaponSelectorAssigned == false)
            {
                SetWeaponSelector();
            }
           
        }

        
        if (GameObject.FindWithTag("MenuPlayerObject") != null)
        {
           
            if (weaponSelector.itemSlots[0].transform.childCount > 0)
            {
                thing0= weaponSelector.itemSlots[0].transform.GetChild(0).gameObject;
                equippedWeaponsData[0] = int.Parse(thing0.name[0].ToString());               
                
            }
            else
            {
                equippedWeaponsData[0] = -1;
            }
            if (weaponSelector.itemSlots[1].transform.childCount > 0)
            {
                equippedWeaponsData[1] = int.Parse(weaponSelector.itemSlots[1].transform.GetChild(0).name[0].ToString());
               
            }
            else
            {
                equippedWeaponsData[1] = -1;
            }
            if (weaponSelector.itemSlots[2].transform.childCount > 0)
            {
                equippedWeaponsData[2] = int.Parse(weaponSelector.itemSlots[2].transform.GetChild(0).name[0].ToString());
               
            }
            else
            {
                equippedWeaponsData[2] = -1;
            }
            if (weaponSelector.itemSlots[3].transform.childCount > 0)
            {
                equippedWeaponsData[3] = int.Parse(weaponSelector.itemSlots[3].transform.GetChild(0).name[0].ToString());
               
            }
            else
            {
                equippedWeaponsData[3] = -1;
            }



        }

        int p = 0;
        for (p = 0; p < inGameItemSlots.Length; p++)
        {
            if (scene.name != "MenuPrototype")
            {
                inGameItemSlots[p] = player.transform.GetChild(p).transform.gameObject;
            }
      
                 }
            for (int c = 0; c < equippedWeaponsData.Length; c++)
                   {
                if (equippedWeaponsData[c] != -1 && inGameItemSlots[p-1] != null)
            {
                Debug.Log("Working");
                GameObject clone = Instantiate(weapons[equippedWeaponsData[c]], inGameItemSlots[p-1].transform.position, Quaternion.identity);
                clone.transform.SetParent(inGameItemSlots[p-1].transform);
            }

                
            }


            //        for (int i = 0; i < equippedWeaponsData.Length; i++)
            //        {
            //            //the slod id is i
            //               {
            //                if (equippedWeaponsData[i] != -1)
            //                {
            //                    for(int p = 0; p < inGameItemSlots.Length; p++)
            //                {
            //                    if (scene.name != "MenuPrototype")
            //                    {
            //                        inGameItemSlots[p] = player.transform.GetChild(i).transform.gameObject;
            //                    }         

            //                    weapons[equippedWeaponsData[i]].transform.SetParent(inGameItemSlots[i].transform);
            //            }

            //        }
            //    }
            //}


    }

    void SetWeaponSelector()
    {
        weaponSelector = GameObject.FindWithTag("MenuPlayerObject").GetComponent<WeaponSelector>();
        weaponSelectorAssigned = true;
    }
}
