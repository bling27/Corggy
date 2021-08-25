using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class soul_disp : MonoBehaviour
{
    // Start is called before the first frame update
    public static soul_disp instance;
    public TextMeshProUGUI txt;
    int totalsouls;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void increasesouls()
    {
        int x = Random.Range(0, 6);
        totalsouls += 5 + x;
        txt.text = totalsouls.ToString();
    }
}
