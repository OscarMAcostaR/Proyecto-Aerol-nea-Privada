using Aeropuerto_WingsAir_DTO;
using System.Data.Entity.Validation;
using WingsAir_API.Dependency;
using WingsAir_API.Models;

namespace WingsAir_API.Services
{
    public class VuelosService : IVuelos
    {
        //creo una variable para el contexto y la inicializo con un constructor
        private readonly Aeropuerto_WingsAirContext _context;

        public VuelosService(Aeropuerto_WingsAirContext context)
        {
            _context = context;
        }

        public string deleteVuelo(int id)
        {
            //primero debo recuperar el vuelo que deseo eliminar
            Vuelos _vuelo = _context.Vuelos.Find(id);
            //valido si realmente existe el vuelo
            if (_vuelo == null)
            {
                return $"No se encontró el elemento con id {id}";
            }
            try
            {
                //proceso a retirarlo del contexto
                _context.Vuelos.Remove(_vuelo);
                //impacto la BD
                _context.SaveChanges();
                //respondo
                return "Vuelo eliminado con éxito";

            }
            catch (DbEntityValidationException ex)
            {
                string resp = "";
                //recorro todos los posibles errores de la entidad referencial
                foreach (var error in ex.EntityValidationErrors)
                {
                    //recorro los detalles de cada error
                    foreach (var validationError in error.ValidationErrors)
                    {
                        resp = "Error en la Entidad: " + error.Entry.Entity.GetType().Name;
                        resp += validationError.PropertyName;
                        resp += validationError.ErrorMessage;
                    }
                }
                return resp;
            }
        }

        public Vuelos_DTO GetVuelo(int id)
        {
            //recuper el objeto que busco
            Vuelos _vuelo = _context.Vuelos.Find(id);
            //valido que existe el objeto
            if (_vuelo == null)
            {
                return null;
            }
            try
            {
                //procedo a mapear el objeto del modelo original a un modelo DTO
                Vuelos_DTO _salida = DinamycMapper.Map<Vuelos, Vuelos_DTO>(_vuelo);
                _salida.fecha_hora = (DateTime)_vuelo.fecha_hora;
                return _salida;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Vuelos_DTO> GetVuelos()
        {
            //recupero la lsita de los vuelos directamente del contexto en función del filtro aplicado
            List<Vuelos> _list = _context.Vuelos.ToList();
            //valido que la lista contenga elementos
            if (_list == null)
            {
                return new List<Vuelos_DTO>();
            }
            //creo una lsita de objetos DTO
            List<Vuelos_DTO> lista_salida = new List<Vuelos_DTO>();
            //recorro cada vuelo de la lsita originnal y lo convierto a un objeto DTO usnado DinamycMapper
            foreach (var vuelo in _list)
            {
                Vuelos_DTO x = DinamycMapper.Map<Vuelos, Vuelos_DTO>(vuelo);
                x.fecha_hora = (DateTime)vuelo.fecha_hora;
                lista_salida.Add(x);
            }
            return lista_salida;
        }

        public List<Vuelos_DTO> GetVuelosfiltered(enum_vuelos filter)
        {
            //recupero la lsita de los vuelos directamente del contexto en función del filtro aplicado
            List<Vuelos> _list = _context.Vuelos.Where(x => x.estatus == filter.ToString()).ToList();
            //valido que la lista contenga elementos
            if (_list == null)
            {
                return new List<Vuelos_DTO>();
            }
            //creo una lsita de objetos DTO
            List<Vuelos_DTO> lista_salida = new List<Vuelos_DTO>();
            //recorro cada vuelo de la lsita originnal y lo convierto a un objeto DTO usnado DinamycMapper
            foreach (var vuelo in _list)
            {
                Vuelos_DTO x = DinamycMapper.Map<Vuelos, Vuelos_DTO>(vuelo);
                x.fecha_hora = (DateTime)vuelo.fecha_hora;
                lista_salida.Add(x);
            }
            return lista_salida;
        }

        public string insertVuelo(Vuelos_DTO vuelo)
        {
            try
            {
                //Creo un objeto del modelo original
                Vuelos _vuelo = new Vuelos();
                //El fomrato del código de un vuelo es
                //(3 dígitos del orignen + 3 dígitos del Detino - Hora en formato Militar)
                string origen = (from ae in _context.Aeropuertos where ae.id_aeropuerto == vuelo.id_origen select ae.estado).FirstOrDefault();
                string destino = (from ae in _context.Aeropuertos where ae.id_aeropuerto == vuelo.id_destino select ae.estado).FirstOrDefault();

                // Formatear la hora del vuelo en formato militar
                string horaVuelo = vuelo.fecha_hora.ToString("HHmm");
                // Asegurarnos de obtener los primeros 3 caracteres (en mayúsculas para consistencia)
                string codigoOrigen = origen.Substring(0, 3).ToUpper();
                string codigoDestino = destino.Substring(0, 3).ToUpper();
                // Combinar las partes para formar el código del vuelo
                string codigoVuelo = $"{codigoOrigen}{codigoDestino}-{horaVuelo}";
                //asigno el valor del c+odigo generado
                vuelo.codigo_vuelo = codigoVuelo;
                //asigno por default el estatus
                vuelo.estatus = enum_vuelos.waiting.ToString();


                //mapeo el objeto a un objeto original
                _vuelo = DinamycMapper.Map<Vuelos_DTO, Vuelos>(vuelo);
                try
                {
                    //asigno la fecha_hora de forma manual
                    _vuelo.fecha_hora = vuelo.fecha_hora;
                    //lo agrego al contexto
                    _context.Vuelos.Add(_vuelo);
                    //impacto la BD
                    _context.SaveChanges();

                    //respondo
                    return "Vuelo insertado con éxito";
                }
                catch (DbEntityValidationException ex)
                {
                    string resp = "";
                    //recorro todos los posibles errores de la entidad referencial
                    foreach (var error in ex.EntityValidationErrors)
                    {
                        //recorro los detalles de cada error
                        foreach (var validationError in error.ValidationErrors)
                        {
                            resp = "Error en la Entidad: " + error.Entry.Entity.GetType().Name;
                            resp += validationError.PropertyName;
                            resp += validationError.ErrorMessage;
                        }
                    }
                    return resp;
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string updateVuelo(Vuelos_DTO vuelo)
        {
            try
            {
                //Creo un objeto del modelo original
                Vuelos _vuelo = new Vuelos();
                //mapeo el objeto a un objeto original
                _vuelo = DinamycMapper.Map<Vuelos_DTO, Vuelos>(vuelo);
                try
                {
                    //asigno la fecha_hora de forma manual
                    _vuelo.fecha_hora = vuelo.fecha_hora;
                    //modifico la entrada del contexto
                    _context.Entry(_vuelo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    //impacto la BD
                    _context.SaveChanges();

                    //respondo
                    return "Vuelo actualizado con éxito";
                }
                catch (DbEntityValidationException ex)
                {
                    string resp = "";
                    //recorro todos los posibles errores de la entidad referencial
                    foreach (var error in ex.EntityValidationErrors)
                    {
                        //recorro los detalles de cada error
                        foreach (var validationError in error.ValidationErrors)
                        {
                            resp = "Error en la Entidad: " + error.Entry.Entity.GetType().Name;
                            resp += validationError.PropertyName;
                            resp += validationError.ErrorMessage;
                        }
                    }
                    return resp;
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
