using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePlayerLives : MonoBehaviour
{
    [SerializeField] private int nbOfLives = 5;
    [SerializeField] private CharacterController characterController;
    [SerializeField] GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if(collision.gameObject.tag == "alien")
        {
            Destroy(collision.gameObject);
            if (characterController.isGrounded || gameObject.transform.position.y <= collision.gameObject.transform.position.y)
            {
                nbOfLives = nbOfLives - 1;
                Debug.Log(nbOfLives);
                gameManager.modifyLifeCounter(nbOfLives);
            }
        }
    }
}
