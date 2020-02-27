using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIClassesManager : MonoBehaviour
{
    [Range(1, 4)]
    private int nbPlayer = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
            nbPlayer++;
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            nbPlayer--;

        int modifiedBanners = 0;
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject child = gameObject.transform.GetChild(i).gameObject;
            if (child.tag == "CharacterBanner")
            { 
                if (modifiedBanners < nbPlayer)
                {
                    modifiedBanners++;
                    modifyBannerColor(child, modifiedBanners);
                    child.transform.GetChild(0).gameObject.SetActive(true);
                    child.transform.GetChild(1).gameObject.SetActive(true);
                }
                else
                {
                    modifyBannerColor(child, modifiedBanners, true);
                    child.transform.GetChild(0).gameObject.SetActive(false);
                    child.transform.GetChild(1).gameObject.SetActive(false);
                    child.GetComponent<Image>().color = new Vector4(0.4f, 0.4f, 0.4f, 1.0f);
                }
            }
        }
        
    }

    void modifyBannerColor(GameObject Banner, int playerID, bool reset = false)
    {
        if (!reset)
        {
            if (playerID == 1)
            {
                Banner.GetComponent<Image>().color = new Vector4(0.196f, 0.647f, 1.0f, 1.0f);
            }
            if (playerID == 2)
            {
                Banner.GetComponent<Image>().color = new Vector4(1.0f, 0.0f, 0.156f, 1.0f);
            }
            if (playerID == 3)
            {
                Banner.GetComponent<Image>().color = new Vector4(0.0f, 0.901f, 0.352f, 1.0f);
            }
            if (playerID == 4)
            {
                Banner.GetComponent<Image>().color = new Vector4(1.0f, 0.933f, 0.0f, 1.0f);
            }
        }
        else
            Banner.GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);

    }
}
