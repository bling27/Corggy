using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck: MonoBehaviour
{
    // Start is called before the first frame update
    public Move access;
    GameObject Corggy;
    public Animator pumper;
    void Start()
    {
        Corggy = gameObject.transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Corggy.GetComponent<Move>().onground = true;
            access.availablejumps = access.totaljumps;
            pumper.SetBool("pump", false);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Corggy.GetComponent<Move>().onground = false;
        }
    }
}
