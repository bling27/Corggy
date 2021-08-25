using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    float maxhp = 100;
    float currenthp;
    public healthbar hp;
     public Rigidbody2D rigidbody;

    Move moveaccess;

    void Start()
    {
        currenthp = maxhp;
        hp.setmaxhp(maxhp); 
    }

    // Update is called once per frame
    void Update()
    {
           
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
             if (col.tag == "lava")
            {
                anim.SetTrigger("firedeath");
            rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                Invoke("dead", 1);
            }
             if(col.tag == "spike")
            {
            takedmg(10);
            }
             if(col.tag == "deathspike")
            {
            anim.SetBool("dead", true);
            rigidbody.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
            Invoke("dead", 1);
            }
             if(col.tag == "jumppad")
            {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            }

    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "spike")
        {
            takedmg(0.2f);
        }
    }

    public void takedmg(float dmg)
    {
        anim.SetTrigger("hurt");
        currenthp -= dmg;
        hp.sethealth(currenthp);
        if(currenthp <= 0)
        {
            moveaccess.stopfn();
            anim.SetBool("dead",true);
            rigidbody.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
            Invoke("dead", 1);
        }
    }
    public void heal()
    {
        currenthp = maxhp;
        hp.sethealth(currenthp);
    }
    void dead()
    {  
        SceneManager.LoadScene("Genesis_3");
    }
}
