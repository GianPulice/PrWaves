using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadScene : MonoBehaviour
{
    public KeyCode reloadKey = KeyCode.R;

    void Update()
    {
        if (Input.GetKeyDown(reloadKey))
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
