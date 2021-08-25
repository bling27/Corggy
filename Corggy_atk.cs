using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corggy_atk : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    [SerializeField]
    public Collider2D col;
    public enemyhealth access;
    public bathealth change;
    public int atkdmg = 20;
    float atkspeed = 1f;
    float nextatktime = 0f;

    GameObject lvr;
    
    public Animator levr;
    public Animator gate;
    public GameObject cameramov;
   Camera cam;
    Vector3 pos = new Vector3(53.6f, 7.54f, -6.5f);
    bool open;
    bool down =  false;

    public Animator barrel;
    public barrel brl;
    private void Start()
    {
        lvr = GameObject.Find("lever");
        levr = lvr.GetComponent<Animator>();
        cam = cameramov.GetComponent<Camera>();
    }

    void Update()
    {
        if (Time.time >= nextatktime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                attack();
                nextatktime = Time.time + 1f / atkspeed;
            }
        }
    }
    void attack()
    {
        anim.SetTrigger("attack");
        


    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (this.gameObject.name == "attack")
        {
            if (col.tag == "enemy")
            {
                col.gameObject.GetComponent<enemyhealth>().takedmg(atkdmg);
            }
            if(col.tag == "bat")
            {
                col.gameObject.GetComponent<bathealth>().takedmg(atkdmg); 
            }
            if (col.tag == "button")
            {
                down = !down; 
                levr.SetBool("On", down);
                Invoke("movecamera", 1);
                Invoke("enablecamera", 5);
            }
            if(col.tag == "barrel")
                {
                barrel.SetTrigger("break");
              brl.midtierloot();
                }

        }
    }
    void enablecamera()
    {
        cam.enable = true;
    }
    void movecamera()
    {
       // open = !open;
      //  gate.SetBool("open", !open);
        cam.enable = false;
        cam.transform.position = Vector3.Lerp(cam.transform.position, pos, 100f * Time.fixedDeltaTime);
    }
} 
