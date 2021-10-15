using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePlayerLives : MonoBehaviour
{
    [SerializeField] private int nbOfLives = 5;
    [SerializeField] private CharacterController characterController;
    [SerializeField] GameManager gameManager;
    private AudioSource audioSource1; //Son de blessure
    private AudioSource audioSource2; //Son de mort
    private bool isInvincible = false;
    private int invincibleTime = 30;

    // Start is called before the first frame update
    void Start()
    {
        audioSource1 = GetComponents<AudioSource>()[0];
        audioSource2 = GetComponents<AudioSource>()[1];
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
            Destroy(collision.gameObject);
            if (characterController.isGrounded || gameObject.transform.position.y <= collision.gameObject.transform.position.y)
            {
                nbOfLives = nbOfLives - 1;
                isInvincible = true;
                Debug.Log("Invincible ON");
                audioSource1.Play();
                gameManager.modifyLifeCounter(nbOfLives);
            }
            if(nbOfLives <= 0)
            {
                audioSource2.Play();
                Destroy(gameObject);
            }
        }
    }
}
