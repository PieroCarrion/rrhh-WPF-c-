using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Datos;

namespace Negocios
{
    public class nEmpleo
    {
        dEmpleo empleoDao;
        public nEmpleo()
        {
            empleoDao = new dEmpleo();
        }
        // Agregar un nuevo empleo(el código del empleo debe ser autogenerado)
        public string Agregar(Empleo empleo)
        {
            return empleoDao.Insertar(empleo);
        }
        // Eliminar un empleo.
        public string Eliminar(int codEmpleo)
        {
            return empleoDao.Eliminar(codEmpleo);
        }
        // Modificar el nombre, el salario mínimo y el salario máximo según su código.
        public string Modificar(Empleo empleo)
        {
            return empleoDao.Modificar(empleo);
        }
        // Consultar empleos según el salario mínimo, máximo y el nombre del empleo.
        public List<Empleo> ConsultarTodo()
        {
            return empleoDao.ListarTodo();
        }

    }
}
