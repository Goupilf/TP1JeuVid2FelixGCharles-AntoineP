using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectIcon : MonoBehaviour
{
    [SerializeField] GameObject collectSoundObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Soit Heal, Rocket ou Multi
        if (other.gameObject.tag == "icon")
        {
            collectSoundObject.transform.position = other.gameObject.transform.position;
            collectSoundObject.GetComponent<AudioSource>().Play();
            if(other.gameObject.GetComponent<ManageIcon>().getTypeOfItem() == "Heal")
            {
                gameObject.GetComponent<ManagePlayerLives>().increaseLifeBar();
            }
            else if(other.gameObject.GetComponent<ManageIcon>().getTypeOfItem() == "Multi")
            {

            }

            else if (other.gameObject.GetComponent<ManageIcon>().getTypeOfItem() == "Rocket")
            {

            }
            other.gameObject.SetActive(false);
        }
    }
}
