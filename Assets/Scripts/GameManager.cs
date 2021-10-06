using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private string fixedText1 = "Lives: ";
    private int lives = 5;

    [SerializeField] Text uiLivesTexts;
    // Start is called before the first frame update
    void Start()
    {
        uiLivesTexts.text = fixedText1 + lives;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Escape has been pressed");
            Application.Quit();
        }
    }

    public void modifyLifeCounter(int nbOfLivesRemaining)
    {
        lives = nbOfLivesRemaining;
        uiLivesTexts.text = fixedText1 + lives;
    }
}
