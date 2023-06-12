using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public float gameTimer;
    bool canTiming;
    public int findedObjs;
    public GameObject endObj;
    public TextMeshProUGUI t_Timer;
    public bool isStart;
    public GameObject startWindow;
    public GameObject objsNames;
    private void Start()
    {
        endObj.SetActive(false);
        canTiming = false;
        isStart = false;
        objsNames.SetActive(false);
        startWindow.SetActive(true);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isStart == false)
        {
            isStart = true;
        }
        if (isStart == true)
        {
            startWindow.SetActive(false);
            objsNames.SetActive(true);
            canTiming = true;
        }
        if (isStart == false)
        {
            canTiming = false;
        }
        if (canTiming == true)
        {
            gameTimer += Time.deltaTime;
        }
        if(findedObjs >= 30)
        {
            EndTheGame(gameTimer);
        }
    }
    void EndTheGame(float endedTime)
    {
        isStart = false;
        canTiming = false;
        t_Timer.text = "Time: " + gameTimer.ToString();
        endObj.SetActive(true);
    }
}
