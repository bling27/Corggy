using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Slider slider;
    public void setmaxhp(float hp)
    {
        slider.maxValue = hp;
        slider.value = hp;
    }
    public void sethealth(float health)
    {
        slider.value = health;
    }
    public void Update()
    {
        fix();
    }
    private void fix()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = targetPosition;
    }

}
