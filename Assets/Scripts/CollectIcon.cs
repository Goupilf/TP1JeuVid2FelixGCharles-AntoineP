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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "icon")
        {
            collectSoundObject.transform.position = collision.gameObject.transform.position;
            collectSoundObject.GetComponent<AudioSource>().Play();
            collision.gameObject.SetActive(false);
        }
    }
}
