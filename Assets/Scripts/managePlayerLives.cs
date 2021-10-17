using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ManagePlayerLives : MonoBehaviour
{
    [SerializeField] private int nbOfLives = 5;
    [SerializeField] private CharacterController characterController;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject deathSoundObject;
    [SerializeField] private UnityEvent telekinesis;
    private AudioSource audioSource; //Son de blessure
    private bool isInvincible = false;
    private int invincibleTime = 30;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager.modifyLifeCounter(nbOfLives);
    }

    // Update is called once per frame
    void Update()
    {
        if(isInvincible && invincibleTime <= 0)
        {
            isInvincible = false;
            invincibleTime = 30;
            Debug.Log("Invincible OFF");
        }
        else
        {
            invincibleTime -= 1;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if(collision.gameObject.tag == "alien" && isInvincible == false)
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
            collision.gameObject.SetActive(false);
            telekinesis.Invoke();
            if (characterController.isGrounded || gameObject.transform.position.y <= collision.gameObject.transform.position.y)
            {
                nbOfLives = nbOfLives - 1;
                isInvincible = true;
                Debug.Log("Invincible ON");
                audioSource.Play();
                gameManager.modifyLifeCounter(nbOfLives);
            }
            if(nbOfLives <= 0)
            {
                deathSoundObject.transform.position = gameObject.transform.position;
                deathSoundObject.GetComponent<AudioSource>().Play();
                gameObject.SetActive(false);
            }
        }
    }

    public void increaseLifeBar()
    {
        nbOfLives += 1;
        gameManager.modifyLifeCounter(nbOfLives);
    }
}
