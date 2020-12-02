using System.Collections.Generic;

namespace curso.api.Models
{
    public class ValidaCampoViewModelOutput
    {
        public IEnumerable<string> Erros { get; private set; }

        public ValidaCampoViewModelOutput(IEnumerable<string> erros)
        {
            Erros = erros;
        }
    }
}
