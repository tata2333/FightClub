using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void MaxHealth(int health) 
    {
        slider.value = health;
        slider.maxValue = health;
    }
   public void SetHealth(int health) 
   {
        slider.value = health;
   }
}
