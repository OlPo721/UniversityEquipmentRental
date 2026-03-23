namespace university_equipment_rental.Models;

public class Camera : Equipment
{
    public int Megapixels { get; set; }
    public bool HasTripod { get; set; }

    public Camera(string name, string condition, int megapixels, bool hasTripod)
        : base(name, condition)
    {
        Megapixels = megapixels;
        HasTripod = hasTripod;
    }

    public override string ToString()
    {
        return $"{base.ToString()} | Type: Camera | Megapixels: {Megapixels} | Tripod: {HasTripod}";
    }
}