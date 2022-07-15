using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class RegisterScore : MonoBehaviour
{
    /// <summary>
    ///  Declare all variable and it's data type
    /// </summary>
    public string playerName;
    public GameObject inputField;

    /// <summary>
    /// Record the player name and score, if the player score is within the top 3 , the name on the score will be updated
    /// </summary>
    public void StoreName()
    {
        playerName = inputField.GetComponent<Text>().text;
        string path1 = Application.streamingAssetsPath + "/curName" + ".txt";
        File.WriteAllText(path1, playerName);
        string path2 = Application.streamingAssetsPath + "/Score" + ".txt";
        string[] scoreList = File.ReadAllLines(path2).ToArray();
        string[] top1 = scoreList[0].Split(' ');
        string[] top2 = scoreList[1].Split(' ');
        string[] top3 = scoreList[2].Split(' ');
        string path3 = Application.streamingAssetsPath + "/curScore" + ".txt";
        string[] curScore = File.ReadAllLines(path3).ToArray();
        int cur = int.Parse(curScore[0]);
        int first = int.Parse(top1[1]);
        int second = int.Parse(top2[1]);
        int third = int.Parse(top3[1]);
        if (cur > first)
        {
            top3[0] = top2[0];
            top3[1] = top2[1];
            top2[0] = top1[0];
            top2[1] = top1[1];
            top1[0] = playerName;
            top1[1] = curScore[0];
        }
        else if (cur > second)
        {
            top3[0] = top2[0];
            top3[1] = top2[1];
            top2[0] = playerName;
            top2[1] = curScore[0];
        }
        else if(cur > third)
        {
            top3[0] = playerName;
            top3[1] = curScore[0];
        }
        string latest = top1[0] + " " + top1[1] + "\n" + top2[0] + " " + top2[1] + "\n" + top3[0] + " " + top3[1] + "\n";
        File.WriteAllText(path2, latest);
        SceneManager.LoadScene("Scoreboard");
    }
    
}
