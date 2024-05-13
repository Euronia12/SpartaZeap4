using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isPlaying = false;
    private static UIManager uiManager = new UIManager();
    public UIManager UI { get { return uiManager; } }
    public GameObject canvas;
    public TextMeshProUGUI timerTxt;
    public TextMeshProUGUI userName;
    public string name {get; set;}

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentDate();
    }

    public void OnLogIn(TMP_InputField inputID)
    {
        name = inputID.text;
        userName.text = name;
        Debug.Log("before");
        isPlaying = true;
    }

    public void GetCurrentDate()
    {
        //yyyy-MM-dd HH:mm:ss tt
        timerTxt.text = DateTime.Now.ToString("HH:mm:ss");
    }

    public void StopIsPlaying()
    {
        isPlaying = false;
    }
}
