using System.Reflection;

namespace WingsAir_API.Services
{
    public class DinamycMapper
    {
        //método que mapea de forma dinámica diferentes tipos de objetos
        //(Por ejemplo modelos Originales a DOT y viceversa)

        public static TDestination Map<TSource, TDestination>(TSource source)
            where TSource : class //se declara una clase abstracta como tipo de objeto de entrada
            where TDestination : class, new() //se declara una clase abstracta como tipo de objeto de salida
        {
            //Valido si existe y contiene información la clase de origen
            if (source == null) throw new ArgumentNullException("source");

            var destination = new TDestination(); //creo una instancia del tipo de objeto de salida

            //recuperar las propiedades (los atributos de mis elementos) usando la biblioteca system.reflexion
            //Mediante reflexión, puedes acceder a las propiedades de un tipo (clase, estructura, etc.) en tiempo de ejecución, incluso si no conoces el tipo exacto en tiempo de compilación.
            //GetProperties: Devuelve un array con todas las propiedades públicas del tipo especificado.
            //BindingFlags: Opciones que especifican qué miembros buscar(públicos, privados, estáticos, etc.).
            //using System.Reflection;
            var sourceProperties = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var destinationProperties = typeof(TDestination).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //recorro todos los atributos y propiedades del objeto de origen para equipararlos con el objeto de salida
            foreach (var sourceProperty in sourceProperties)
            {
                //recupero cad apropiedad de la clase dond empate tanto el nombre de la propiedad como el tipo de dato (Aquí es donde se mapean los objetos)
                var destinationProperty = destinationProperties.FirstOrDefault(dp =>
                dp.Name.ToLower() == sourceProperty.Name.ToLower()
                &&
                dp.PropertyType == sourceProperty.PropertyType);

                //si la propiedad es accesible y tiene valor, paso el datos del origen al destino
                if (destinationProperty != null && destinationProperty.CanWrite)
                {
                    //GetValue: lee el valor actual de la propiedad par aun objeto
                    //SetValue: Establece un nuevo valor par ala propiedad de un objeto
                    var value = sourceProperty.GetValue(source);
                    destinationProperty.SetValue(destination, value);
                }
            }
            //retorno el nuevo tipo de objeto ya mapeado
            return destination;
        }
    }
}
