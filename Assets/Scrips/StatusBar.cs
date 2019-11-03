using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class StatusBar : MonoBehaviour, Ibar
{

  

    public Text Battery_Text;
    public Text Usage_Text;
    public Text Charging_Text;
    public Text Time_Text;


    public Slider Battery_Slider;
    public Slider Usage_Slider;
    public Slider Charge_Slider;
    public Slider Time_Slider;
    public StandartBattery Battery;

    Text StatusHeader;






    void Start()
    {

        StatusHeader = GetComponent<Text>();

        Battery_Slider.maxValue = Battery.MaxCapacity;
        Usage_Slider.maxValue = Battery.MaxUsage;
        Charge_Slider.maxValue = Battery.MaxChargingSpeed;
        Time_Slider.maxValue = (int)(Battery.MaxCapacity / Battery.MaxUsage);



    }
    public void SetState(bool status)
    {

        StatusHeader.gameObject.SetActive(status);

    }

    void Update()
    {

        Battery_Text.text = string.Format("{0}/{1} A/min", (int)Battery.CurrentCapacity, Battery.MaxCapacity);
        Usage_Text.text = string.Format("{0}/{1} A/min", (int)Battery.Usage, Battery.MaxUsage);
        Charging_Text.text = string.Format("{0}/{1} A/min", (int)Battery.ChargingSpeed, Battery.MaxChargingSpeed);

        if (Battery.Usage > Battery.ChargingSpeed)
            Time_Text.text = string.Format("-{0} Secs", (int)(60 * Battery.CurrentCapacity / (Battery.Usage - Battery.ChargingSpeed)));
        else if (Battery.Usage < Battery.ChargingSpeed)
            Time_Text.text = string.Format("+{0} Secs", (int)(60 * (Battery.MaxCapacity - Battery.CurrentCapacity) / (Battery.ChargingSpeed - Battery.Usage)));


        Battery_Slider.value = Battery.CurrentCapacity;
        Usage_Slider.value = Battery.Usage;
        Charge_Slider.value = Battery.ChargingSpeed;
        Time_Slider.value = Battery.CurrentCapacity;




    }

}
