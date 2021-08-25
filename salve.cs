using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salve : MonoBehaviour
{
    GameObject corggy;
    Life access;
    // Start is called before the first frame update
    void Start()
    {
        corggy = GameObject.Find("Corgyy");
        access = corggy.GetComponent<Life>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            access.heal();
        }
    }
}
