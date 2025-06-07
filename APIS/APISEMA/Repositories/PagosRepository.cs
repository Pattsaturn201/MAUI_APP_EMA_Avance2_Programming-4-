using APISEMA.Models;
using System.Collections.Generic;
using System.Linq;

namespace APISEMA.Repositories
{
    public class PagosRepository
    {
        private static readonly List<Pagos> _pagos = new();
        private static int _nextId = 1;

        // Inicializar algunos pagos de ejemplo
        static PagosRepository()
        {
            _pagos.Add(new Pagos
            {
                Id = _nextId++,
                // ClienteId = 1,
                // Monto = 100.00m,
                // FechaPago = DateTime.Now.AddDays(-1),
                // Metodo = "Efectivo"
            });

            _pagos.Add(new Pagos
            {
                Id = _nextId++,
                // ClienteId = 2,
                // Monto = 250.00m,
                // FechaPago = DateTime.Now.AddDays(-1),
                // Metodo = "Transferencia"
            });
        }

        // Obtener todos los pagos
        public List<Pagos> ObtenerPagos()
        {
            return _pagos;
        }

        // Obtener un pago por ID
        public Pagos? ObtenerPorId(int id)
        {
            return _pagos.FirstOrDefault(p => p.Id == id);
        }

        // Agregar un nuevo pago
        public Pagos Add(Pagos pago)
        {
            pago.Id = _nextId++;
            _pagos.Add(pago);
            return pago;
        }

        // Actualizar un pago existente
        public bool Update(Pagos pago)
        {
            var existing = ObtenerPorId(pago.Id);
            if (existing == null)
                return false;

            // Ajusta las propiedades según tu modelo
            // existing.ClienteId = pago.ClienteId;
            // existing.Monto = pago.Monto;
            // existing.FechaPago = pago.FechaPago;
            // existing.Metodo = pago.Metodo;
            return true;
        }

        // Eliminar un pago por ID
        public bool Delete(int id)
        {
            var pago = ObtenerPorId(id);
            if (pago == null)
                return false;

            _pagos.Remove(pago);
            return true;
        }
    }
}
