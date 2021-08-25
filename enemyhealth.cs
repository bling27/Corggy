using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    [HideInInspector]
    public bool dead = false;
    [HideInInspector]
    public bool repeat = true;
    public int maxhp = 100;
    int currenthp = 0;

    GameObject brrl;
    barrel access;
    GameObject souldisp;
    soul_disp souls;
    void Start() 
    {
        brrl = GameObject.Find("barrel");
        access = brrl.GetComponent<barrel>();
        souldisp = GameObject.Find("overlay");
        souls = souldisp.GetComponent<soul_disp>();
        currenthp = maxhp;
        GameObject g = this.gameObject;
    }

    // Update is called once per frame
    public void takedmg(int dmg)
    {
        if (currenthp > 0) 
        { 
        anim.SetTrigger("hurt");
        currenthp -= dmg;
        }
            //hurt anim
           
            if (currenthp <= 0 && repeat)
            {
            repeat = false;
            dead = true;

            StartCoroutine(access.spawnlt(this.gameObject));
            souls.increasesouls();
           
            StartCoroutine(die());

        }
        
    }
    IEnumerator die()
    {
        anim.SetBool("dead", true);
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
