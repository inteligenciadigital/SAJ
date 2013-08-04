using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteligenciaDigital.SAJ.Domain.Entidades;

namespace InteligenciaDigital.SAJ.FakeObjects
{
    public static class ServidorTEFFakes
    {
        public static ServidorTEF servidorTEF1 = new ServidorTEF()
            {
                EnderecoIP = "192.168.1.1",
                Nome = "Servidor TEF 1"
            };

        public static ServidorTEF servidorTEF2 = new ServidorTEF()
            {
                EnderecoIP = "192.168.1.2",
                Nome = "Servidor TEF 2"
            };

        public static ServidorTEF servidorTEF3 = new ServidorTEF()
            {
                EnderecoIP = "192.168.1.3",
                Nome = "Servidor TEF 3"
            };
    }
}
