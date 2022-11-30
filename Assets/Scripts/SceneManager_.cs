using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_ : MonoBehaviour
{
    public bool menuActive = false;
    // Start is called before the first frame update

    static SceneManager_ instance;  


    private void Awake()
    {
        if(instance != null)
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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            
            SceneManager.LoadScene("MenuPrototype");
            menuActive = true;
        }

        if(Input.GetKeyDown(KeyCode.G) && menuActive == true)
        {
            SceneManager.LoadScene("Dude");
            menuActive = false;
        }
    }
}
