using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameManager gameManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "alien")
        {
           
            // fait perdre vie alien
            // faire en sorte que si pdv alien == 0 il soit desactiver
        }
        else if (other.gameObject.tag == "spawner")
        {
            // fait perdre vie spawner
            // faire en sorte que si pdv spawner == 0 il soit desactiver
        }
        // desactive la balle pou quelle soit reutilliser
    }
}
