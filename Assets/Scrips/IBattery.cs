
public interface IBattery
{

    float MaxCapacity { get; }
    float CurrentCapacity { get; set; }

    float Usage { get; set; } //measured in Amps per minute
    float MaxUsage { get; }
    float ChargingSpeed { get; }
    float MaxChargingSpeed { get; }
    float Charging_multiplayer { get; set; }


    

   

}


