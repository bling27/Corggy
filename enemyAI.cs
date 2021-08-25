using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    Transform player;
    public enemyhealth access;
    public float agrorange = 4f;
    public float ms = 2f;
    Rigidbody2D rb2d;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float disttoplayer = Vector2.Distance(transform.position, player.position);
        RaycastHit2D hit = Physics2D.Linecast(transform.position, player.position, 1 << LayerMask.NameToLayer("physical"));


        if (hit.collider.gameObject.CompareTag("Player"))
        {
            if (disttoplayer < agrorange)
            {
                chaseplayer();
            }
            else if (disttoplayer > agrorange * 2)
            {
                rb2d.velocity = Vector2.zero;
            }
            if (access.dead == true)
            {
                this.enabled = false;
            }
        }
        else
            rb2d.velocity = Vector2.zero;
    }
    void chaseplayer()
    {
        if (player.position.x - transform.position.x > 0.05f)
        {
            rb2d.velocity = new Vector2(ms, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        else if(transform.position.x - player.position.x > 0.05f)
        {
            rb2d.velocity = new Vector2(-ms, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);
        }
    }


  
    
}
