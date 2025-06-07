using APISEMA.Models;

namespace APISEMA.Repositories
{
    public class ClientesRepository
    {
        // Lista en memoria para almacenar los clientes
        private static readonly List<Clientes> _clientes = new();
        private static int _nextId = 1;


        //Clientes de ejemplo 
        static ClientesRepository()
        {
            _clientes.Add(new Clientes
            {
                Id = _nextId++,
                NombreCompleto = "Carlos Moreta",
                ApellidoCompleto = "Moreta",
                Correo = "Carlos.moreta@gmail.com",
                Telefono = "123456779",
                Direccion = "Calle 123",
                MetodosDePago = new List<string> { "Efectivo", "Tarjeta de Crédito" }
            });

            _clientes.Add(new Clientes
            {
                Id = _nextId++,
                NombreCompleto = "Edwin Masin",
                ApellidoCompleto = "Masin Cueva",
                Correo = "Edwin.Masin@hotmail.com",
                Telefono = "987654351",
                Direccion = "Calle 324",
                MetodosDePago = new List<string> { "Transferencia" }
            });
        }

        // para inicializar algunos clientes de ejemplo
        public List<Clientes> ObtenerClientes()
        {
            return _clientes;
        }

        // para obtener un cliente por ID
        public Clientes? ObtenerporId(int id)
        {
            return _clientes.FirstOrDefault(c => c.Id == id);
        }

        // Se agrega un nuevo cliente
        public Clientes Add(Clientes cliente)
        {
            cliente.Id = _nextId++;
            _clientes.Add(cliente);
            return cliente;
        }

        // Actualizar un cliente guardado
        public bool Update(Clientes cliente)
        {
            var existing = ObtenerporId(cliente.Id);
            if (existing == null)
                return false;

            existing.NombreCompleto = cliente.NombreCompleto;
            existing.ApellidoCompleto = cliente.ApellidoCompleto;
            existing.Correo = cliente.Correo;
            existing.Telefono = cliente.Telefono;
            existing.Direccion = cliente.Direccion;
            existing.MetodosDePago = new List<string>(cliente.MetodosDePago);
            return true;
        }

        // Eliminar un cliente por ID
        public bool Delete(int id)
        {
            var cliente = ObtenerporId(id);
            if (cliente == null)
                return false;

            _clientes.Remove(cliente);
            return true;
        }
    }
}
