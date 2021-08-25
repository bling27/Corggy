using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coin_display : MonoBehaviour
{
    // Start is called before the first frame update
    public static coin_display instance;
    public TextMeshProUGUI txt;
    int totalcoins;
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
    public void increasecoins()
    {
        totalcoins++;
        txt.text = totalcoins.ToString();
    }
}
