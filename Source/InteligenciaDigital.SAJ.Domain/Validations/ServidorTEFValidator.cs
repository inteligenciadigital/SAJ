using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using InteligenciaDigital.SAJ.Domain.Entidades;

namespace InteligenciaDigital.SAJ.Domain.Validations
{
    public class ServidorTEFValidator : AbstractValidator<ServidorTEF>
    {
        public ServidorTEFValidator()
        {
            RuleFor(x => x.Nome).NotNull();
            RuleFor(x => x.EnderecoIP).NotNull();
        }
    }
}
