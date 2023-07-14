using MagicVilla_API.Models.Dto;

namespace MagicVilla_API.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> VillaList = new List<VillaDto> 
        {   
            new VillaDto {Id=1, Name="Pablo", Occupants=3, SquareMeter=10},
            new VillaDto {Id=2,Name="Goku", Occupants=5, SquareMeter=50}
        };
    }
}
