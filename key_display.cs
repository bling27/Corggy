using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class key_display : MonoBehaviour
{
    public static key_display instance;
    public TextMeshProUGUI txt;
    int totalkeys;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void increasekey()
    {
        totalkeys++;
        txt.text = totalkeys.ToString() + "/3";  
    }
}
