using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ChildTest
    {
        [UnityTest]
        public IEnumerator TestObstacleAddStat()
        {
            var gameObject = new GameObject();
            var obstacleTest = gameObject.AddComponent<Obstacle>();
            GameObject.Instantiate(obstacleTest,new Vector3(13, 4, 0), Quaternion.Euler(0,0,0));
            int amount = obstacleTest.AddStat("rock");
            Assert.IsTrue(amount == 100);
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            return null;
        }
        [UnityTest]
        public IEnumerator TestPowerAddStat()
        {
            var gameObject = new GameObject();
            var powerTest = gameObject.AddComponent<Power>();
            GameObject.Instantiate(powerTest, new Vector3(13, 2, 0), Quaternion.Euler(0, 0, 0));
            int amount = powerTest.AddStat("ammo");
            Assert.IsTrue(amount == 5);
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            return null;
        }
    }
}
