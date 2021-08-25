using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemydealdmg : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject corggy;
    Life access;
    int atkdmg = 20;
    void Start()
    {
        corggy = GameObject.Find("Corgyy");
        access = corggy.GetComponent<Life>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (this.gameObject.name == "reaperatk") if (col.tag == "Player")
            {
                access.takedmg(atkdmg);
            }

    }
}
