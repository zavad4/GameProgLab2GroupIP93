using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PointsManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI label;
    [SerializeField] int minLevelScore = 5;
    private int points;

    // Update is called once per frame
    void Update()
    {
       label.text = $"Points: {points}";
    }

    public void AddPoint()
    {
        points += 1;
        if (points == minLevelScore)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
