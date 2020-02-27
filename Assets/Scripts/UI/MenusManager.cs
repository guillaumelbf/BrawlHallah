using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusManager : MonoBehaviour
{
    private int nbPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ControllerToCharactersLobby()
    {
        GameObject UImanager = GameObject.FindGameObjectWithTag("UIManager");
        for (int i =0; i < UImanager.transform.childCount; i++)
        {
            if (UImanager.transform.GetChild(i).tag == "CharactersLobby")
                UImanager.transform.GetChild(i).gameObject.SetActive(true);
        }
        GameObject.FindGameObjectWithTag("ControllerLobby").SetActive(false);
        nbPlayer = GameObject.FindGameObjectWithTag("ControllerLobby").GetComponent<UIPlayerIconManager>().getNbPlayers();
    }

    public void CharactersToControllerLobby()
    {
        GameObject UImanager = GameObject.FindGameObjectWithTag("UIManager");
        for (int i = 0; i < UImanager.transform.childCount; i++)
        {
            if (UImanager.transform.GetChild(i).tag == "ControllerLobby")
                UImanager.transform.GetChild(i).gameObject.SetActive(true);
        }
        GameObject.FindGameObjectWithTag("CharactersLobby").SetActive(false);
    }

}
