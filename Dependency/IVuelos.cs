using Aeropuerto_WingsAir_DTO;

namespace WingsAir_API.Dependency
{
    public interface IVuelos
    {
        //GET
        List<Vuelos_DTO> GetVuelos();
        //GETbyID
        Vuelos_DTO GetVuelo();
        //POST
        string insertVuelo(Vuelos_DTO vuelo);
        //PUT
        string updateVuelo(Vuelos_DTO vuelo);
        //DELETE
        string deleteVuelo(int id);
    }
}
