namespace university_equipment_rental.Models;

public class Laptop : Equipment
{
    public int RamGb { get; set; }
    public string Processor { get; set; }

    public Laptop(string name, string condition, int ramGb, string processor)
        : base(name, condition)
    {
        RamGb = ramGb;
        Processor = processor;
    }

    public override string ToString()
    {
        return $"{base.ToString()} | Type: Laptop | RAM: {RamGb} GB | CPU: {Processor}";
    }
}