using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaApp1.Entidad;

namespace AgendaApp1
{
    public class repositorio
    {

        public List<Persona> personas { get; set; } = new List<Persona>();
        public static repositorio instancia { get; } = new repositorio();
        private repositorio()
        {
            

        }


    }
}
