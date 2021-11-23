using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    [SerializeField] private bool m_GameOver = false;
    public int points;
    [SerializeField] private int m_Points;
    [SerializeField] private float weight;
    [SerializeField] private float age;
    [SerializeField] private float height;
    public Text Score;
    public GameObject GameOverText;
    GameObject spawnManagerObj;
    SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        spawnManagerObj = GameObject.Find("SpawnManager");
        spawnManager = spawnManagerObj.GetComponent<SpawnManager>();
        m_Points =  StartGame();


    }

    // Update is called once per frame
    void Update()
    {
        AddPoint(points);
        points = 0;
        if (spawnManager.isGameActive == false)
        {
            GameOver();
        }
    }
    void AddPoint(int point)
   {
     m_Points -= point;
     Score.text = $"Calories : {m_Points}";
    }
    public void GameOver()
   {
     m_GameOver = true;
    GameOverText.SetActive(true);
   }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    private int StartGame()
    {
        m_GameOver = false;
        GameOverText.SetActive(false);
        age = float.Parse(GameManager.Instance.age);
        weight = float.Parse(GameManager.Instance.weight);
        height = float.Parse(GameManager.Instance.height);
        int type = GameManager.Instance.type;
        m_Points = Mathf.RoundToInt(66f + (13.7f * weight) + (5 * height) - (6.8f * age));
        switch (type) {
            case  1:
                m_Points -= 200;
                break;
            case 2:
                m_Points = m_Points;
                break;

            case 3:
                m_Points += 200;
                break;
                }
        return m_Points;
    }
}
