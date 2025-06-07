using APISEMA.Models;
using System.Collections.Generic;
using System.Linq;

namespace APISEMA.Repositories
{
    public class EmpresaRepository
    {
        private static readonly List<Empresa> _empresas = new();
        private static int _nextId = 1;

        // Inicializar empresas de ejemplo
        static EmpresaRepository()
        {
            _empresas.Add(new Empresa
            {
                Id = _nextId++,
                NombreEmpresa = "Technolutions",
                Direccion = "Av. Central 100",
                Telefono = "555123456",
                Correo = "info@technolutions.com"
            });

            _empresas.Add(new Empresa
            {
                Id = _nextId++,
                NombreEmpresa = "ServiIndustrial",
                Direccion = "AV 6 de Dicembre",
                Telefono = "555987654",
                Correo = "contacto@serviciosind.com"
            });
        }

        // Obtener todas las empresas
        public List<Empresa> ObtenerEmpresas()
        {
            return _empresas;
        }

        // Obtener una empresa por ID
        public Empresa? ObtenerPorId(int id)
        {
            return _empresas.FirstOrDefault(e => e.Id == id);
        }

        // Agregar una nueva empresa
        public Empresa Add(Empresa empresa)
        {
            empresa.Id = _nextId++;
            _empresas.Add(empresa);
            return empresa;
        }

        // Actualizar una empresa existente
        public bool Update(Empresa empresa)
        {
            var existing = ObtenerPorId(empresa.Id);
            if (existing == null)
                return false;

            existing.NombreEmpresa = empresa.NombreEmpresa;
            existing.Direccion = empresa.Direccion;
            existing.Telefono = empresa.Telefono;
            existing.Correo = empresa.Correo;
            return true;
        }

        // Eliminar una empresa por ID
        public bool Delete(int id)
        {
            var empresa = ObtenerPorId(id);
            if (empresa == null)
                return false;

            _empresas.Remove(empresa);
            return true;
        }
    }
}
