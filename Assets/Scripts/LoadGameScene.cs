using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoadgameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");

    }
}
