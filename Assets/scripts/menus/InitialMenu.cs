using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InitialMenu : MonoBehaviour
{

    public string sceneName;
    public float delay = 2f;
    private bool countdownStarted = false;
    public Text textComponent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !countdownStarted)
        {
            countdownStarted = true;
            Invoke("ChangeScene", delay);

            if (textComponent != null)
            {
                textComponent.color = Color.black;
            }
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
