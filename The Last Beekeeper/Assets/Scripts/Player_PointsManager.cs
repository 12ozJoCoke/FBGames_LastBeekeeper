using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_PointsManager : MonoBehaviour
{
    public Text pointsCounterUI;
    public int currentPoints, maxPoints;
    // Start is called before the first frame update
    void Start()
    {
        currentPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPoints > maxPoints)
        {
            currentPoints = maxPoints;
        }

        pointsCounterUI.text = currentPoints + " Points";
    }

    public void AddPoints(int earnedpoints)
    {
        currentPoints += earnedpoints;
    }

    public void RemovePoints(int lostpoints)
    {
        currentPoints -= lostpoints;
    }
}
