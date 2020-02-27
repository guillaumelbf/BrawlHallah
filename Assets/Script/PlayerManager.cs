using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerManager : MonoBehaviour
{
	[SerializeField]
    private float speed = 0, jumpForce = 0;
    [SerializeField]
	XboxController Controller1;
	[SerializeField]
	XboxController Controller2;
	[SerializeField]
	XboxController Controller3;
	[SerializeField]
	XboxController Controller4;
	public GameObject[] cubeList = new GameObject[4];
	private Vector3 newPosition;

    float turnSmoothVelocity;

    Vector2 inputDir = Vector2.zero;

    Animator annim;

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

        // To quit the program (with keyboard)
        if (Input.GetKeyUp(KeyCode.Escape))
		{
			Application.Quit();
		}

	}
}
