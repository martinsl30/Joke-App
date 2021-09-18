using System;
using System.Collections.Generic;
using Joke_Flix.Interfaces;

namespace Joke_Flix
{
    public class JokeRepositorio : IRepositorio<Joke>
    {
        
        private List<Joke> listaJoke = new List<Joke>();

        public void Atualiza(int id, Joke objeto)
        {
            listaJoke[id] = objeto;
        }
        public void Exclui(int id)
        {
            listaJoke[id].Excluir();
        }
        public void Insere(Joke objeto)
        {
            listaJoke.Add(objeto);
        }
        public List<Joke> Lista()
        {
            return listaJoke;
        }
        public int ProximoId()
        {
            return listaJoke.Count; 
        }

        public Joke RetornaPorId(int id)
        {
            return listaJoke[id];

        }
    }
    
}