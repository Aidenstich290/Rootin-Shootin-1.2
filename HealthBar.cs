using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HealthBar : MonoBehaviour
{
    public Slider slider; // Asigns Health Slider

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health; // Sets the Value for Max Health 
        
        slider.value = health; // Sets the health value for the slider
    }
    
    public void SetHealth(int health)
    {
        slider.value = health; // Sets the value for the slider
    }
   
}
