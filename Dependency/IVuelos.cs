using Aeropuerto_WingsAir_DTO;
using WingsAir_API.Services;

namespace WingsAir_API.Dependency
{
    public interface IVuelos
    {
        //GET
        List<Vuelos_DTO> GetVuelos();
        //GET
        List<Vuelos_DTO> GetVuelosfiltered(enum_vuelos filter);
        //GETbyID
        Vuelos_DTO GetVuelo(int id);
        //POST
        string insertVuelo(Vuelos_DTO vuelo);
        //PUT
        string updateVuelo(Vuelos_DTO vuelo);
        //DELETE
        string deleteVuelo(int id);
    }
}
