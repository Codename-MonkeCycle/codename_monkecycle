using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMenu : MonoBehaviour
{
    public GameObject menu;

    public void ActiveMenu()
    {
        menu.SetActive(true);
    }

    public void DisableMenu()
    {
        menu.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (menu.activeInHierarchy == false)
            {
                ActiveMenu();
            }
            else
            {
                DisableMenu();
            }
        }
    }
}
