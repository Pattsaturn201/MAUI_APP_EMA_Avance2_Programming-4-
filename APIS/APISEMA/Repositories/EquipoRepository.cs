using APISEMA.Models;
using System.Collections.Generic;
using System.Linq;

namespace APISEMA.Repositories
{
    public class EquipoRepository
    {
        private static readonly List<Equipo> _equipos = new();
        private static int _nextId = 1;

        // Inicializar algunos equipos de ejemplo
        static EquipoRepository()
        {
            _equipos.Add(new Equipo
            {
                Id = _nextId++,
                Nombre = "Compresor Industrial",
                Marca = "Atlas Copco",
                Modelo = "GA90",
                Serial = "AC12345",
                FechaAdquisicion = new DateTime(2020, 1, 15),
                FechaBaja = new DateTime(2025, 1, 15),
            });

            _equipos.Add(new Equipo
            {
                Id = _nextId++,
                Nombre = "Generador Eléctrico",
                Marca = "Caterpillar",
                Modelo = "CAT3500",
                Serial = "CT98765",
                FechaAdquisicion = new DateTime(2019, 3, 10),
                FechaBaja = new DateTime(2027, 3, 10),
            });
        }

        // Obtener todos los equipos
        public List<Equipo> ObtenerEquipos()
        {
            return _equipos;
        }

        // Obtener un equipo por ID
        public Equipo? ObtenerPorId(int id)
        {
            return _equipos.FirstOrDefault(e => e.Id == id);
        }

        // Agregar un nuevo equipo
        public Equipo Add(Equipo equipo)
        {
            equipo.Id = _nextId++;
            _equipos.Add(equipo);
            return equipo;
        }

        // Actualizar un equipo existente
        public bool Update(Equipo equipo)
        {
            var existing = ObtenerPorId(equipo.Id);
            if (existing == null)
                return false;

            existing.Nombre = equipo.Nombre;
            existing.Marca = equipo.Marca;
            existing.Modelo = equipo.Modelo;
            existing.Serial = equipo.Serial;
            existing.FechaAdquisicion = equipo.FechaAdquisicion;
            existing.FechaBaja = equipo.FechaBaja;
            return true;
        }

        // Eliminar un equipo por ID
        public bool Delete(int id)
        {
            var equipo = ObtenerPorId(id);
            if (equipo == null)
                return false;

            _equipos.Remove(equipo);
            return true;
        }
    }
}
