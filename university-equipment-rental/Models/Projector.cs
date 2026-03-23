namespace university_equipment_rental.Models;

public class Projector : Equipment
{
    public int BrightnessLumens { get; set; }
    public string Resolution { get; set; }

    public Projector(string name, string condition, int brightnessLumens, string resolution)
        : base(name, condition)
    {
        BrightnessLumens = brightnessLumens;
        Resolution = resolution;
    }

    public override string ToString()
    {
        return $"{base.ToString()} | Type: Projector | Brightness: {BrightnessLumens} lm | Resolution: {Resolution}";
    }
}