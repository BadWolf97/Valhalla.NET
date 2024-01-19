namespace FPH.ValhallaNET.Enums
{
    // An enum to represent the type of location
    public enum LocationType
    {
        Break, // A location that allows u-turns and generates legs and maneuvers
        Through, // A location that does not allow u-turns or generate legs or maneuvers
        Via, // A location that allows u-turns but does not generate legs or maneuvers
        Break_Through // A location that does not allow u-turns but generates legs and maneuvers
    }
}
