namespace ValorantSorteio.Models
{
    public class PersonagemModel
    {
        public string Nome { get; set; }
        public Funcoes Funcao { get; set; }

        #region ListaPersonagens
        private readonly List<PersonagemModel> _listaPersonagens = new List<PersonagemModel>();
        public List<PersonagemModel> ListaPersonagens { get { return _listaPersonagens; } }

        public void AddPersonagem(PersonagemModel arg)
        {
            if (!_listaPersonagens.Contains(arg))
            {
                _listaPersonagens.Add(arg);
            }
        }
        #endregion ListaPersonagens

        #region ListaTime1
        private readonly List<PersonagemModel> _listaTime1 = new List<PersonagemModel>();
        public List<PersonagemModel> ListaTime1 { get { return _listaTime1; } }

        public void AddTime1(List<PersonagemModel> arg)
        {
            _listaTime1.AddRange(arg);
        }
        #endregion ListaTime1

        #region ListaTime2
        private readonly List<PersonagemModel> _listaTime2 = new List<PersonagemModel>();
        public List<PersonagemModel> ListaTime2 { get { return _listaTime2; } }

        public void AddTime2(List<PersonagemModel> arg)
        {
            _listaTime2.AddRange(arg);
        }
        #endregion ListaTime2

        public enum Funcoes
        {
            Controlador,
            Duelista,
            Iniciador,
            Sentinela
        }

        public PersonagemModel(string nome = "", Funcoes funcao = Funcoes.Duelista)
        {
            Nome = nome;
            Funcao = funcao;
        }

        public void CarregaPersonagens()
        {
            ListaPersonagens.Clear();

            AddPersonagem(new PersonagemModel("Brimstone", Funcoes.Controlador));
            AddPersonagem(new PersonagemModel("Phoenix", Funcoes.Duelista));
            AddPersonagem(new PersonagemModel("Sage", Funcoes.Sentinela));
            AddPersonagem(new PersonagemModel("Sova", Funcoes.Iniciador));
            AddPersonagem(new PersonagemModel("Viper", Funcoes.Controlador));
            AddPersonagem(new PersonagemModel("Cypher", Funcoes.Sentinela));
            AddPersonagem(new PersonagemModel("Reyna", Funcoes.Duelista));
            AddPersonagem(new PersonagemModel("Killjoy", Funcoes.Sentinela));
            AddPersonagem(new PersonagemModel("Breach", Funcoes.Iniciador));
            AddPersonagem(new PersonagemModel("Omen", Funcoes.Controlador));
            AddPersonagem(new PersonagemModel("Raze", Funcoes.Duelista));
            AddPersonagem(new PersonagemModel("Skye", Funcoes.Iniciador));
            AddPersonagem(new PersonagemModel("Yoru", Funcoes.Duelista));
            AddPersonagem(new PersonagemModel("Astra", Funcoes.Controlador));
            AddPersonagem(new PersonagemModel("KAY/O", Funcoes.Iniciador));
            AddPersonagem(new PersonagemModel("Chamber", Funcoes.Sentinela));
            AddPersonagem(new PersonagemModel("Neon", Funcoes.Duelista));
            AddPersonagem(new PersonagemModel("Jett", Funcoes.Duelista));
            AddPersonagem(new PersonagemModel("Fade", Funcoes.Iniciador));
        }

        public List<PersonagemModel> RandomizaSemCriterioPersonagens(int quantidadeTime = 5)
        {
            var random = new Random();

            var lista = new List<PersonagemModel>(ListaPersonagens);
            var listaSorteada = new List<PersonagemModel>();

            for (int i = 0; i < quantidadeTime; i++)
            {
                var personagem = lista[random.Next(lista.Count)];

                listaSorteada.Add(personagem);
                lista.Remove(personagem);

                Console.WriteLine();
            }

            return listaSorteada;
        }

        public override string ToString()
        {
            var montaString = "| Time 1 - ";

            int i = 0;
            foreach (var time1 in ListaTime1)
            {
                montaString += $"[#{++i} - {time1.Nome}] ";
            }

            montaString += "| Time 2 - ";

            i = 0;
            foreach (var time2 in ListaTime2)
            {
                montaString += $"[#{++i} - {time2.Nome}] ";
            }

            montaString += "|";

            return montaString;
        }
    }
}
