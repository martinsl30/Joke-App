
using System;

namespace Joke_Flix
{
    class Program
    {
        static JokeRepositorio repositorio = new JokeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarPiadas();
						break;
					case "2":
						InserirPiada();
						break;
					case "3":
						AtualizarPiada();
						break;
					case "4":
						ExcluirPiada();
						break;
					case "5":
						VisualizarPiada();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Volte sempre!!");
			Console.ReadLine();
        }

        private static void ExcluirPiada()
		{
			Console.Write("Digite o id da piada: ");
			int indiceJoke = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceJoke);
		}

        private static void VisualizarPiada()
		{
			Console.Write("Digite o id da piada: ");
			int indiceJoke = int.Parse(Console.ReadLine());

			var joke = repositorio.RetornaPorId(indiceJoke);

			Console.WriteLine(joke);
		}

        private static void AtualizarPiada()
		{
			Console.Write("Digite o id da piada: ");
			int indiceJoke = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Tipo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
			}
			Console.Write("Digite o tipo entre as opções acima: ");
			int entradaTipo = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da piada: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite a piada: ");
			string entradaConteudo = Console.ReadLine();

			Console.Write("Digite o nome do Autor da piada: ");
			string entradaAutor = Console.ReadLine();
			
			Joke AtualizarPiada = new Joke(id: indiceJoke,
										tipo: (Tipo)entradaTipo,
										titulo: entradaTitulo,
										conteudo: entradaConteudo,
										autor: entradaAutor);
										

			repositorio.Atualiza(indiceJoke, AtualizarPiada);
		}
    
        private static void ListarPiadas()
		{
			Console.WriteLine("Listar Piadas");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma piada cadastrada.");
				return;
			}

			foreach (var joke in lista)
			{
                var excluido = joke.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", joke.retornaId(), joke.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirPiada()
		{
			Console.WriteLine("Inserir nova piada");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Tipo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaTipo = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Piada: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite a Piada: ");
			string entradaConteudo = Console.ReadLine();

			Console.Write("Digite o nome do Autor da piada: ");
			string entradaAutor = Console.ReadLine();

			
			Joke novaJoke = new Joke(id: repositorio.ProximoId(),
										tipo: (Tipo)entradaTipo,
										titulo: entradaTitulo,
										conteudo: entradaConteudo,
										autor: entradaAutor);
										

			repositorio.Insere(novaJoke);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Piadas a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar piadas");
			Console.WriteLine("2- Inserir nova piada");
			Console.WriteLine("3- Atualizar piada");
			Console.WriteLine("4- Excluir piada");
			Console.WriteLine("5- Visualizar piada");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
