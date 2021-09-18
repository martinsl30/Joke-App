using System;

namespace Joke_Flix
{
    

    public class Joke : EntidadeBase
    {
        // Atrtibutos

        private Tipo Tipo { get; set; }
        
        private string Titulo { get; set; }

        private string Autor { get; set; }

        private string Conteudo { get; set; }

        private bool Excluido { get; set; }
    

    //Métodos

    public Joke(int id,Tipo tipo, string titulo, string autor, string conteudo)
    {
        this.Id = id;
        this.Tipo = tipo;
        this.Titulo = titulo;
        this.Conteudo = conteudo;
        this.Autor = autor;
        this.Excluido = false;
    }

    public override string ToString()
    {

        string retorno ="";
        retorno += "Tipo: " + this.Tipo + Environment.NewLine;
        retorno += "Titulo: " + this.Titulo + Environment.NewLine;
        retorno += "Conteudo: " + this.Conteudo + Environment.NewLine;
        retorno += "Autor: " + this.Autor + Environment.NewLine;
        return retorno;
    }
    
    public string retornaTitulo()
    {
        return this.Titulo;

    }

    public int retornaId()
    {
        return this.Id;
    }

    public bool retornaExcluido()
    {
        return this.Excluido;
    }

    public void Excluir() {
      this.Excluido = true;  
        }
    }
}