using CRUD_Personal.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personal.Repositorios
{
    internal interface IPersonaRepository
    {
        int Insertar(Persona p);                      // devuelve el Id generado
        Persona? ObtenerPorId(int id);                // null si no existe
        List<Persona> ObtenerTodas();                 // solo las activas
        List<Persona> BuscarPorNombre(string texto);
        bool Actualizar(Persona p);                   // false si el Id no existe
        bool DarDeBaja(int id);                       // borrado lógico
        bool Eliminar(int id);                        // borrado físico
    }
}
