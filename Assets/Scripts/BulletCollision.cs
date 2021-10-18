using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private float period = 0.0f;
    private float timeroffset = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //if (period > timeroffset)
        //{
        //    this.gameObject.SetActive(false);
        //    period = 0;
       // }
        // period += UnityEngine.Time.deltaTime;

    }
    private void OnTriggerEnter(Collider other)
    {
       Debug.Log("test collision 2");
       this.gameObject.SetActive(false);
    }
}
