using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndConditionManager : MonoBehaviour
{
    public PauseManager pm;
    public Text youWonText, reasonText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void triggerLoss(string reason)
    {
        pm.permaPause();
        youWonText.text = "You Lost!";
        reasonText.text = "You lost by " + reason;
    }

    public void triggerWin(string reason)
    {
        pm.permaPause();
        youWonText.text = "You Won!";
        reasonText.text = "You won by " + reason;
    }
}
