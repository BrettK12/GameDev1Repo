using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public static int pointValue;
    public static Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("PointsID"))
            pointValue = PlayerPrefs.GetInt("PointsID");
        else
            pointValue = 50;


        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "Points: " + pointValue.ToString();
    }

    public static int GetPointValue()
    {
        return pointValue;
    }

    public static void increasePoints(int points)
    {
        pointValue += points;
        Debug.Log(points.ToString() + " Points added");
        scoreText.text = "Points: " + pointValue.ToString();
    }

    public static void decreasePoints(int points)
    {
        pointValue -= points;
        Debug.Log(points.ToString() + " Points spent");
        scoreText.text = "Points: " + pointValue.ToString();
    }
    
}
