using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batAI : MonoBehaviour
{
    Transform player;
    public float agrorange = 4f;
    public float ms = 2f;
    Rigidbody2D rb2d;
    
    public bathealth access;
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
        RaycastHit2D hit = Physics2D.Linecast(transform.position, player.position, 1 << LayerMask.NameToLayer("physical" ));
        
        
        if (hit.collider.gameObject.CompareTag("Player"))
            if (disttoplayer < agrorange ) 
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
    void chaseplayer()
    {
        if (player.position.x - transform.position.x > 0.1f && player.position.y - transform.position.y > 0.05f)
        {
            rb2d.velocity = new Vector2(ms, ms);
            transform.localScale = new Vector2(-1, 1);
        }
        if (player.position.x - transform.position.x > 0.1f && transform.position.y - player.position.y > 0.05f)
        {
            rb2d.velocity = new Vector2(ms, -ms);
            transform.localScale = new Vector2(-1, 1);
        }
        if (transform.position.x - player.position.x > 0.1f && player.position.y - transform.position.y > 0.05f)
        {
            rb2d.velocity = new Vector2(-ms, ms);
            transform.localScale = new Vector2(1, 1);
        }
        if (transform.position.x - player.position.x > 0.1f && transform.position.y - player.position.y > 0.05f)
        {
            rb2d.velocity = new Vector2(-ms, -ms);
            transform.localScale = new Vector2(1, 1);
        }


        



    }
   




}

