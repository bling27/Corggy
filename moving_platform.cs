using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_platform : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target; 
    private Vector3 offset;
    bool enable = false;
    void Start()
    {

    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
            enable = true;

        offset = target.transform.position - transform.position;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
            enable = false;
    }
    void FixedUpdate()
    {
        if(enable)  
        {
            target.transform.position = transform.position + offset;
        }
    }
    
    
    

}
