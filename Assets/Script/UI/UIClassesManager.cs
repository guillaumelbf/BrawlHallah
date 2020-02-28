using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;

public class UIClassesManager : MonoBehaviour
{
    [SerializeField]
    XboxController Controller1;
    [SerializeField]
    XboxController Controller2;
    [SerializeField]
    XboxController Controller3;
    [SerializeField]
    XboxController Controller4;
    public GameObject[] cubeList = new GameObject[4];
    private int nbPlayer = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (XCI.GetButtonDown(XboxButton.A, Controller1) && cubeList[0] == null)
        {
            cubeList[0] = Instantiate(Resources.Load<GameObject>("Player"));
            cubeList[0].transform.Translate(new Vector3(0, 6, 0));
            cubeList[0].GetComponent<PlayerController>().ctrl = Controller1;
        }
        if (XCI.GetButtonDown(XboxButton.A, Controller2) && cubeList[1] == null)
        {
            cubeList[1] = Instantiate(Resources.Load<GameObject>("Player"));
            cubeList[1].transform.Translate(new Vector3(0, 6, 0));
            cubeList[1].GetComponent<PlayerController>().ctrl = Controller2;
        }
        if (XCI.GetButtonDown(XboxButton.A, Controller3) && cubeList[2] == null)
        {
            cubeList[2] = Instantiate(Resources.Load<GameObject>("Player"));
            cubeList[2].transform.Translate(new Vector3(0, 6, 0));
            cubeList[2].GetComponent<PlayerController>().ctrl = Controller3;
        }
        if (XCI.GetButtonDown(XboxButton.A, Controller4) && cubeList[3] == null)
        {
            cubeList[3] = Instantiate(Resources.Load<GameObject>("Player"));
            cubeList[3].transform.Translate(new Vector3(0, 6, 0));
            cubeList[3].GetComponent<PlayerController>().ctrl = Controller4;
        }

        int modifiedBanners = 0;
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject child = gameObject.transform.GetChild(i).gameObject;
            if (child.tag == "CharacterBanner")
            {
                if (cubeList[modifiedBanners] != null)
                {
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

                modifiedBanners++;

            }
        }
    }

    void modifyBannerColor(GameObject Banner, int playerID, bool reset = false)
    {
        if (!reset)
        {
            if (playerID == 0)
            {
                Banner.GetComponent<Image>().color = new Vector4(0.196f, 0.647f, 1.0f, 1.0f);
            }
            if (playerID == 1)
            {
                Banner.GetComponent<Image>().color = new Vector4(1.0f, 0.0f, 0.156f, 1.0f);
            }
            if (playerID == 2)
            {
                Banner.GetComponent<Image>().color = new Vector4(0.0f, 0.901f, 0.352f, 1.0f);
            }
            if (playerID == 3)
            {
                Banner.GetComponent<Image>().color = new Vector4(1.0f, 0.933f, 0.0f, 1.0f);
            }
        }
        else
            Banner.GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
    }
}
