using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isPlaying = false;
    public GameObject canvas;
    public TextMeshProUGUI timerTxt;
    public TextMeshProUGUI userName;
    public TextMeshProUGUI userVisitorName;
    public TextMeshProUGUI visitorTxt;
    public GameObject visitorObject;
    public GameObject visitorStorage;
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


    void Update()
    {
        GetCurrentDate();
    }

    public void OnLogIn(TMP_InputField inputID)
    {
        name = inputID.text;
        userName.text = name;
        AddNewVisitor(inputID.text);
        isPlaying = true;
    }

    public void GetCurrentDate()
    {
        //yyyy-MM-dd HH:mm:ss tt
        timerTxt.text = DateTime.Now.ToString("HH:mm:ss");
    }
    public void ChangeName(TMP_InputField inputID)
    {
        name = inputID.text;
        userName.text = name;
        userVisitorName.text = name;
        isPlaying = true;
    }

    public void AddNewVisitor(string name)
    {
        GameObject go = Instantiate(visitorObject, visitorStorage.transform);
        TextMeshProUGUI tempTxt = Instantiate(visitorTxt, go.transform);
        tempTxt.text = name;
    }

    public void StopIsPlaying()
    {
        isPlaying = false;
    }
}
