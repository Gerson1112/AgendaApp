using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace AgendaApp1.Persistence
{
    public class Serializacion
    {

        public void Serialize(object obj, string directory, string filename)
        {

            CreateDirectory(directory);

            IFormatter formatter = new BinaryFormatter();

            Stream stream = new FileStream(directory + "/" + filename, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, obj);
            stream.Close();
            stream.Dispose();
            
        }
        public void Deserialize(string directory, string filename)
        {
            CreateDirectory(directory);

            object retorno = null;

            if(File.Exists(directory + "/" + filename))
            {
                IFormatter formatter = new BinaryFormatter();

                Stream Stream = new FileStream(directory + "/" + filename, FileMode.Open, FileAccess.Read);
                 retorno = formatter.Deserialize(Stream);
                Stream.Close();
                Stream.Dispose();
            }

        }


        private void CreateDirectory(string directory)
        {
            if(!Directory.Exists(directory))
            {

                Directory.CreateDirectory(directory);

            }

        }

    }
}
