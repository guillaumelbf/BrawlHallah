using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsRound : MonoBehaviour
{
    public int nbRounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject child = gameObject.transform.GetChild(i).gameObject;
            if (child.tag == "RoundsValue")
            {
                child.GetComponent<Text>().text = nbRounds.ToString();
            }
        }
    }

    public void UpNbRounds()
    {
        if (gameObject.transform.parent.GetComponent<SettingsRound>().nbRounds < 999)
            gameObject.transform.parent.GetComponent<SettingsRound>().nbRounds++;
    }

    public void DownNbRounds()
    {
        if (gameObject.transform.parent.GetComponent<SettingsRound>().nbRounds > 1)
            gameObject.transform.parent.GetComponent<SettingsRound>().nbRounds--;
    }
}
