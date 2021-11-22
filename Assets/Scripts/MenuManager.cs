using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public InputField wagaInputName;
    public string weight;
    public InputField wiekInputName;
    public string age;
    public Button[] buttons;
    public Button Excit;
    public int type;
    public int test1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    public void SaveDataName()
    {
        weight = wagaInputName.text;
        GameManager.Instance.weight = weight;
        age = wiekInputName.text;
        GameManager.Instance.age = age;
        GameManager.Instance.type = type;
    }
    public void StartNew()
    {      
        SceneManager.LoadScene(1);
    }
    public void SaveGameType1()
    {
        type = 1;
        GameManager.Instance.type = type;
    }
    public void SaveGameType2()
    {
        type = 2;
        GameManager.Instance.type = type;
    }
    public void SaveGameType3()
    {
        type = 3;
        GameManager.Instance.type = type;
    }
    public void Exit()
    {
        GameManager.Instance.SaveName();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();

#else
        Application.Quit();
#endif
    }
}
