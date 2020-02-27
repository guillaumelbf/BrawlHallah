using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIPlayerIconManager : MonoBehaviour
{
    public int nbPlayer;
    GameObject[] controllerIcons;
    // Start is called before the first frame update
    void Start()
    {
        controllerIcons = GameObject.FindGameObjectsWithTag("ControllerIcon");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
            nbPlayer++;
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            nbPlayer--;
        int idxIcon = 0;
        while (idxIcon < 4)
        {
            if (idxIcon < nbPlayer)
            {
                controllerIcons[idxIcon].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
            }
            else
                controllerIcons[idxIcon].GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
            idxIcon++;
        }

    }

    public int getNbPlayers()
    {
        return nbPlayer;
    }
}
