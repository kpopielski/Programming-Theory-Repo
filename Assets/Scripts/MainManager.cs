using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    private bool m_GameOver = false;
    public int points;
    [SerializeField] private int m_Points;
    [SerializeField] private float weight;
    [SerializeField] private float age;
    [SerializeField] private float height;
    public Text Score;
    // Start is called before the first frame update
    void Start()
    {
        age = float.Parse(GameManager.Instance.age);
        weight = float.Parse(GameManager.Instance.weight);
        height = float.Parse(GameManager.Instance.height);
        m_Points = Mathf.RoundToInt(66f + (13.7f * weight)+(5*height)-(6.8f*age));
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = $"Calories : {m_Points}";
    }
    void AddPoint(int point)
   {
     m_Points -= point;
     Score.text = $"Calories : {m_Points}";
    }
   // public void GameOver()
    //{
      //  m_GameOver = true;
       // GameOverText.SetActive(true);
    //}
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
