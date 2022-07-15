using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;


/// <summary>
/// This is a function to display the information of the top 3 scorer
/// </summary>
public class Scoreboard : MonoBehaviour
{
    /// <summary>
    /// Declare all variable and it's data type
    /// </summary>
    public Text playerName;
    public Text playerScore;
    void Start()
    {
        DisplayName();
        DisplayScore();
    }
    public void DisplayName()
    {
        string path = Application.streamingAssetsPath + "/Score" + ".txt";
        string[] scoreList = File.ReadAllLines(path).ToArray();
        string[] name1 = scoreList[0].Split(' ');
        string[] name2 = scoreList[1].Split(' ');
        string[] name3 = scoreList[2].Split(' ');
        playerName.text = name1[0] + "\n" + name2[0] + "\n" + name3[0] + "\n";
    }

    public void DisplayScore()
    {
        string path = Application.streamingAssetsPath + "/Score" + ".txt";
        string[] scoreList = File.ReadAllLines(path).ToArray();
        string[] score1 = scoreList[0].Split(' ');
        string[] score2 = scoreList[1].Split(' ');
        string[] score3 = scoreList[2].Split(' ');
        playerScore.text = score1[1] + "\n" + score2[1] + "\n" + score3[1] + "\n";
    }
}
