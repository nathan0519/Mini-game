using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a script that is responsible to spawn object in the game
/// </summary>
public class Window : MonoBehaviour
{
    /// <summary>
    /// Declare all variable and it's data type
    /// </summary>
    public GameObject rockPrefab;
    public GameObject conePrefab;
    public GameObject heartPrefab;
    public GameObject ammoPrefab;
    public GameObject snailPrefab;
    public Vector3 spawnValues;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (SpawnObject());
    }
    /// <summary>
    /// This is a function that spawn different types of obstacle and power
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnObject()
    {
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 spawnPositionR = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion spawnRotationR = Quaternion.identity;
                Instantiate(rockPrefab, spawnPositionR, spawnRotationR);
                Vector3 spawnPositionC = new Vector3(spawnValues.x + 2, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion spawnRotationC = Quaternion.identity;
                Instantiate(conePrefab, spawnPositionC, spawnRotationC);
                Vector3 spawnPositionH = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Vector3 spawnPositionA = new Vector3(spawnValues.x + 2, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Vector3 spawnPositionS = new Vector3(spawnValues.x + 4, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion spawnRotationH = Quaternion.identity;
                Quaternion spawnRotationA = Quaternion.identity;
                Quaternion spawnRotationS = Quaternion.identity;
                if (i == 3)
                {
                    Instantiate(heartPrefab, spawnPositionH, spawnRotationH);
                }
                if (i == 6){
                    Instantiate(ammoPrefab, spawnPositionA, spawnRotationA);
                }
                if(i == 9)
                {
                    Instantiate(snailPrefab, spawnPositionS, spawnRotationS);
                }
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
