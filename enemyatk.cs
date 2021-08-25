using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyatk : MonoBehaviour
{

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            anim.SetBool("attack", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            anim.SetBool("attack", false);
        }
    }
}