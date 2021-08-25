using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public int ms = 5;
    public int jumppwr = 1250;
    public int totaljumps = 3;
    public int availablejumps;
    bool multijump = false;
    public bool right = true;
    public bool onground = true;
    
    public Animator anim;
    void Awake()
    {
        availablejumps = totaljumps;
       
    }
    
    // Update is called once per frame

    void Update()
    {

        move();
        if (Input.GetButtonDown("Jump"))
        {
            jump();
        }
        if ((Input.GetAxis("Horizontal") > 0.0f && right == false) || (Input.GetAxis("Horizontal") < 0.0f && right == true))
        {
            flip();
        }
        if (!onground)
        {
            anim.SetBool("pump", true);
        }
        else
        {
            anim.SetBool("pump", false);
        }

    }
    void move()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * ms, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
    }

    void jump()
    {
        if (onground)
        {
            multijump = true;
            availablejumps--;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumppwr);
            anim.SetBool("pump", true);
        }
        else
        {
            
            if(multijump && availablejumps > 0)
            {
                availablejumps--;
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * (jumppwr));
                anim.SetBool("pump", true);
            }
        }
    }
    void flip()
    {
        right = !right;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

    }
    public void stopfn()
    {
        this.enabled = false;
    }

    

}
