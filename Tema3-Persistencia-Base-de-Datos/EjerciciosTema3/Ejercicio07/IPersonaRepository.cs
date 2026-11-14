namespace Ejercicio07
{
    public interface IPersonaRepository
    {
        int Insertar(Persona persona);
        Persona ObtenerPorId(int id);
        List<Persona> ObtenerTodas();
        bool Actualizar(Persona persona);
        bool Eliminar(int id);
    }
}
