using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultySelector : MonoBehaviour
{
    public enum difficulties
    {
        CouldntKillALarvae = 1,
        BeekeepingIntern = 2,
        LetsGetEm = 3,
        UltraViolence = 4,
        LordOfTheWasps = 5
    };

    public difficulties difficulty;
    public KeyCode boundStartKey;
    public Sprite[] difficultyVisuals;
    public List<Image> difficultyButtons;
    public Color selectedDiffButtonColor, unselectedDiffButtonColor;
    public Text pressKeyBeginText;
    public Image difficultyUIindicator;
    public int difficultyInt, maxDiffInt;
    public string[] difficulty_SceneNames;

    // Start is called before the first frame update
    void Start()
    {
        SetDifficultySelection(difficultyInt);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Image diffbutton in difficultyButtons)
        {
            if (difficultyButtons.IndexOf(diffbutton) != difficultyInt - 1)
            {
                diffbutton.color = selectedDiffButtonColor;
            }else
            {
                diffbutton.color = unselectedDiffButtonColor;
            }
        }

        pressKeyBeginText.text = "Press " + "[" + boundStartKey + "]" + " to Begin!";

        //if (Input.GetKeyDown(boundStartKey))
        //{
        //    LoadScene();
        //}
    }

    public void nextDifficulty()
    {
        difficultyInt++;
        SetDifficultySelection(difficultyInt);
    }

    public void lastDifficulty()
    {
        difficultyInt--;
        SetDifficultySelection(difficultyInt);
    }

    public void SetDifficultySelection(int f)
    {
        if (f > maxDiffInt)
        {
            f = 1;
        } else if (f < 1)
        {
            f = maxDiffInt;
        }

        difficulty = (difficulties)f;
        difficultyInt = f;
        difficultyUIindicator.sprite = difficultyVisuals[f - 1];
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(difficulty_SceneNames[difficultyInt - 1]);
    }
}
