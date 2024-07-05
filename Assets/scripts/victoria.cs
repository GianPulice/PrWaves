using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class victoria : MonoBehaviour
{
    public float countdownDuration = 60f;
    public Image timerImage;
    private float currentTime = 0f;
    private bool timerActive = false;

    void Start()
    {
        Invoke("StartTimer", 1f); 
    }

    void StartTimer()
    {
        currentTime = countdownDuration;
        timerActive = true;
    }

    void Update()
    {
        if (timerActive)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerUI();

            if (currentTime <= 0f)
            {
                ChangeScene();
            }
        }
     
    }

    void UpdateTimerUI()
    {
        float fillAmount = currentTime / countdownDuration;
        timerImage.fillAmount = fillAmount;
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Win");
    }
}

