using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : MonoBehaviour
{
    public GameObject coinprefab;
    public GameObject salveprefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void midtierloot()
    {
        StartCoroutine(spawnlt(this.gameObject));
        StartCoroutine(Dodestroy());

    }
   public  void spawncoin(GameObject g)
    {
        int u = Random.Range(-2, 2);
        int v = Random.Range(0, 2);
        Vector3 randmov = new Vector3(u, v, 0);
        int x = Random.Range(-5, 5);
        int y = Random.Range(0, 10);
        GameObject a = Instantiate(coinprefab) as GameObject;
        a.transform.position = g.transform.position + randmov;
        a.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);

    }
   public void spawnsalve(GameObject g)
    {
        int x = Random.Range(-5, 5);
        int y = Random.Range(0, 10);
        GameObject a = Instantiate(salveprefab) as GameObject;
        a.transform.position = g.transform.position;
        a.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);
    }
    IEnumerator Dodestroy() 
    {

        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

   public IEnumerator spawnlt(GameObject f)
    {
        yield return new WaitForSeconds(.5f);
        int p = Random.Range(0, 5);
        Debug.Log(p);
        p = 5;
        if (p == 5)
        {
            for (int i = 8; i > 0; i--)
            {
                spawncoin(f);
               
            }
        }
        else
            for (int i = p; i > 0; i--)
            {
                spawncoin(f);
               
            }
        int q = Random.Range(0, 5);
        if (q != 0)
        {
            spawnsalve(f);
        }

    }

}
