using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int lives = 5;
    private int multiTimer = 0;
    private int rocketAmmo = 0;
    [SerializeField] Text uiLivesTexts;
    [SerializeField] Text uiRocketTexts;
    [SerializeField] Text uiMultiTexts;
    // Start is called before the first frame update
    void Start()
    {
        uiLivesTexts.text = lives.ToString();
        uiRocketTexts.text = rocketAmmo.ToString();
        uiMultiTexts.text = multiTimer.ToString();
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
        uiLivesTexts.text = lives.ToString();
    }

    public void modifyMultiTimer(int nbOTimeRemaining)
    {
        multiTimer = nbOTimeRemaining;
        uiMultiTexts.text = multiTimer.ToString();
    }

    public void modifyRocketCounter(int nbOfAmmoRemaining)
    {
        rocketAmmo = nbOfAmmoRemaining;
        uiRocketTexts.text = rocketAmmo.ToString();
    }
}
