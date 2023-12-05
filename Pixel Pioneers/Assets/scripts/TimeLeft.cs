using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLeft : MonoBehaviour
{
    private Text time1;
    public static float timer = 10f;

    public bool timeUp = false;

    void Start()
    {
        time1 = GetComponent<Text>();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            //Time.timeScale = 0;
            timeUp = true;
        }
        time1.text = "Time Left : " + Mathf.Round(timer);
    }
}
