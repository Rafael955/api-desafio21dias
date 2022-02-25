
using System.Collections.Generic;

namespace webapi.ModelViews
{
    public record HomeView
    {
        // public string Informacao { get { return "Bem-Vindo ao Sistema!"; } }
        public string Informacao => "Bem-Vindo ao Sistema!";

        public List<dynamic> Endpoints =>  new List<dynamic>() 
        { 
            new
            {
                Item = new 
                {
                    Documentacao =  "/swagger"
                }
            },
            new
            {
                Item = new 
                {
                    Path =  "/alunos/api/listar-alunos"
                }
            },
            new
            {
                Item = new 
                {
                    Path =  "/professores/api/listar-professores"
                }
            }
        };
    }
}
