using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusManager : MonoBehaviour
{
    public int nbPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void SetNbCharactersLobby()
    {
        for (int i = 0; i < gameObject.transform.parent.parent.childCount; i++)
        {
            GameObject child = gameObject.transform.parent.parent.GetChild(i).gameObject;
            if (child.tag == "CharactersLobby")
            {
                //child.GetComponent<UIClassesManager>().nbPlayer = nbPlayer;
            }
        }
    }

    public void GoToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void CharactersToSettingsLobby()
    {
        GameObject UImanager = GameObject.FindGameObjectWithTag("UIManager");
        for (int i = 0; i < UImanager.transform.childCount; i++)
        {
            if (UImanager.transform.GetChild(i).tag == "SettingsLobby")
                UImanager.transform.GetChild(i).gameObject.SetActive(true);
        }
        GameObject.FindGameObjectWithTag("CharactersLobby").SetActive(false);
    }

    public void SettingsToCharactersLobby()
    {
        GameObject UImanager = GameObject.FindGameObjectWithTag("UIManager");
        for (int i = 0; i < UImanager.transform.childCount; i++)
        {
            if (UImanager.transform.GetChild(i).tag == "CharactersLobby")
                UImanager.transform.GetChild(i).gameObject.SetActive(true);
        }
        GameObject.FindGameObjectWithTag("SettingsLobby").SetActive(false);
    }


}
