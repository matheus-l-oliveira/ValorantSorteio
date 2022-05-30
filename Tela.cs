using ValorantSorteio.Models;
using ValorantSorteio.Utils;

namespace ValorantSorteio
{
    public partial class Tela : Form
    {
        public Tela()
        {
            InitializeComponent();

            CXB_NaoMostrarMensagemCopy.Checked = Regedit.RetornaNaoMostrarMensagemCopy();
        }

        private void BTN_Sortear_Click(object sender, EventArgs e)
        {
            var personagem = new PersonagemModel();

            personagem.CarregaPersonagens();
            personagem.AddTime1(personagem.RandomizaSemCriterioPersonagens());

            personagem.CarregaPersonagens();
            personagem.AddTime2(personagem.RandomizaSemCriterioPersonagens());

            TXB_Time1_1.Text = personagem.ListaTime1[0].Nome;
            TXB_Time1_2.Text = personagem.ListaTime1[1].Nome;
            TXB_Time1_3.Text = personagem.ListaTime1[2].Nome;
            TXB_Time1_4.Text = personagem.ListaTime1[3].Nome;
            TXB_Time1_5.Text = personagem.ListaTime1[4].Nome;

            TXB_Time2_1.Text = personagem.ListaTime2[0].Nome;
            TXB_Time2_2.Text = personagem.ListaTime2[1].Nome;
            TXB_Time2_3.Text = personagem.ListaTime2[2].Nome;
            TXB_Time2_4.Text = personagem.ListaTime2[3].Nome;
            TXB_Time2_5.Text = personagem.ListaTime2[4].Nome;

            Clipboard.SetText(personagem.ToString());

            if (!CXB_NaoMostrarMensagemCopy.Checked)
            {
                MessageBox.Show($"Sorteio de personagens copiado para a área de transferência, pressione CTRL+V para colar." +
                    $"{Environment.NewLine}" +
                    $"{Environment.NewLine}" +
                    $"{personagem}");
            }
        }

        private void Tela_FormClosing(object sender, FormClosingEventArgs e)
        {
            Regedit.SetaNaoMostrarMensagemCopy(CXB_NaoMostrarMensagemCopy.Checked);
        }
    }
}