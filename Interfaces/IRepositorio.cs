using System.Collections.Generic;

namespace Joke_Flix.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T>Lista();
        T RetornaPorId(int id);

        void Insere(T entidade);

        void Exclui(int id);

        void Atualiza(int i, T entidade);

        int ProximoId();
         
    }
}