using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaApp1.Entidad;
using AgendaApp1.Persistence;

namespace AgendaApp1
{
    public class Servicios
    {
        private Serializacion serializacion;
        private string directory;
        private string filename; 
        public Servicios()
        {
            serializacion = new Serializacion();
            directory = "Personas";
            filename = "Personas.dat";

        }
        public void Add(Persona item)
        {
            repositorio.instancia.personas.Add(item);
            serializacion.Serialize(repositorio.instancia.personas, directory, filename);
        }
        public void Edit(int index, Persona item)
        {
            repositorio.instancia.personas[index] = item;
            serializacion.Serialize(repositorio.instancia.personas, directory, filename);

        }
        public void Delete(int index)
        {

            repositorio.instancia.personas.RemoveAt(index);
            serializacion.Serialize(repositorio.instancia.personas, directory, filename);
        }
        public Persona GetByid(int index)
        {
            return repositorio.instancia.personas[index];

        }
        public List<Persona> GetAll()
        {
            
            return repositorio.instancia.personas;
            
        }
    }
}
