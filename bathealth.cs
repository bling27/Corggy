using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bathealth : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    [HideInInspector]
    public bool dead = false;
    [HideInInspector]
    public bool repeat = true;
    public int maxhp = 50;
    int currenthp = 0;

    GameObject brrl;
    barrel access;
    void Start()
    {
        brrl = GameObject.Find("barrel");
        access = brrl.GetComponent<barrel>();
        currenthp = maxhp;
    }

    // Update is called once per frame
    public void takedmg(int dmg)
    {


        anim.SetTrigger("hurt");
        currenthp -= dmg;

        //hurt anim

        if (currenthp <= 0 && repeat)
        {
            repeat = false;
            dead = true;
            anim.SetBool("dead", true);
            int a = Random.Range(0, 3);
            if (a > 1)
            {
                for(int i = a-1; i>0; i--)
                {
                    access.spawncoin(this.gameObject); 
                }
            }

            Invoke("die", 2);

        }

    }
    void die()
    {

        //die anim and destroy

        GetComponent<Collider2D>().enabled = false;
        Destroy(this.gameObject);

    }
}
