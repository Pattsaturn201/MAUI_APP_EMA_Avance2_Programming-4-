using APISEMA.Models;
using System.Collections.Generic;
using System.Linq;

namespace APISEMA.Repositories
{
    public class EmpleadosRepository
    {
        private static readonly List<Empleados> _empleados = new();
        private static int _nextId = 1;

        // Inicializar algunos empleados de ejemplo
        static EmpleadosRepository()
        {
            _empleados.Add(new Empleados
            {
                Id = _nextId++,
                NombreCompleto = "Stephania Alexander",
                ApellidoCompleto = "Alexader Aclivar",
                Correo = "Stepania.Alexander.@yahoo.com",
                Telefono = "111222233",
                datebirth = new DateTime(1990, 5, 10),
                Puesto = "Técnico",
                Cargo = "Soporte"
            });

            _empleados.Add(new Empleados
            {
                Id = _nextId++,
                NombreCompleto = "Pedro Ruiz",
                ApellidoCompleto = "Ruiz Fernández",
                Correo = "Pedro.Ruiz@outlook.com",
                Telefono = "444555666",
                datebirth = new DateTime(1995, 8, 22),
                Puesto = "Supervisor",
                Cargo = "Mantenimiento"
            });
        }

        // Obtener todos los empleados
        public List<Empleados> ObtenerEmpleados()
        {
            return _empleados;
        }

        // Buscar empleado por ID
        public Empleados? ObtenerPorId(int id)
        {
            return _empleados.FirstOrDefault(e => e.Id == id);
        }

        // Agregar nuevo empleado
        public Empleados Add(Empleados empleado)
        {
            empleado.Id = _nextId++;
            _empleados.Add(empleado);
            return empleado;
        }

        // Actualizar un empleado guardado
        public bool Update(Empleados empleado)
        {
            var existing = ObtenerPorId(empleado.Id);
            if (existing == null)
                return false;

            existing.NombreCompleto = empleado.NombreCompleto;
            existing.ApellidoCompleto = empleado.ApellidoCompleto;
            existing.Correo = empleado.Correo;
            existing.Telefono = empleado.Telefono;
            existing.datebirth = empleado.datebirth;
            existing.Puesto = empleado.Puesto;
            existing.Cargo = empleado.Cargo;
            return true;
        }

        // Eliminar empleado
        public bool Delete(int id)
        {
            var empleado = ObtenerPorId(id);
            if (empleado == null)
                return false;

            _empleados.Remove(empleado);
            return true;
        }
    }
}
