using APISEMA.Models;
using System.Collections.Generic;
using System.Linq;

namespace APISEMA.Repositories
{
    public class OrdenTrabajoRepository
    {
        private static readonly List<OrdenTrabajo> _ordenes = new();
        private static int _nextId = 1;

        // Inicializar algunas órdenes de trabajo de ejemplo
        static OrdenTrabajoRepository()
        {
            _ordenes.Add(new OrdenTrabajo
            {
                Id = _nextId++,
                NombreEquipo = "Compresor Industrial",
                CodigoEquipo = "C-1001",
                TipoMantenimiento = "Preventivo",
                FechaIngreso = DateTime.Now.AddDays(-5),
                FechaEntrega = null,
                DescripcionProblema = "Revisión general y cambio de filtros.",
                Observaciones = "Equipo en buen estado.",
                Estado = EstadoDeOrden.Pendiente
            });

            _ordenes.Add(new OrdenTrabajo
            {
                Id = _nextId++,
                NombreEquipo = "Generador Eléctrico",
                CodigoEquipo = "G-2002",
                TipoMantenimiento = "Correctivo",
                FechaIngreso = DateTime.Now.AddDays(-2),
                FechaEntrega = null,
                DescripcionProblema = "No enciende, posible falla eléctrica.",
                Observaciones = "Niguna",
                Estado = EstadoDeOrden.EnProceso
            });
        }

        // Obtener todas las órdenes de trabajo
        public List<OrdenTrabajo> ObtenerOrdenes()
        {
            return _ordenes;
        }

        // Obtener una orden de trabajo por ID
        public OrdenTrabajo? ObtenerPorId(int id)
        {
            return _ordenes.FirstOrDefault(o => o.Id == id);
        }

        // Agregar una nueva orden de trabajo
        public OrdenTrabajo Add(OrdenTrabajo orden)
        {
            orden.Id = _nextId++;
            _ordenes.Add(orden);
            return orden;
        }

        // Actualizar una orden de trabajo existente
        public bool Update(OrdenTrabajo orden)
        {
            var existing = ObtenerPorId(orden.Id);
            if (existing == null)
                return false;

            existing.NombreEquipo = orden.NombreEquipo;
            existing.CodigoEquipo = orden.CodigoEquipo;
            existing.TipoMantenimiento = orden.TipoMantenimiento;
            existing.FechaIngreso = orden.FechaIngreso;
            existing.FechaEntrega = orden.FechaEntrega;
            existing.DescripcionProblema = orden.DescripcionProblema;
            existing.Observaciones = orden.Observaciones;
            existing.Estado = orden.Estado;
            return true;
        }

        // Eliminar una orden de trabajo por ID
        public bool Delete(int id)
        {
            var orden = ObtenerPorId(id);
            if (orden == null)
                return false;

            _ordenes.Remove(orden);
            return true;
        }
    }
}
