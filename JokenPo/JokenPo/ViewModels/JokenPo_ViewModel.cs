using CommunityToolkit.Mvvm.ComponentModel;
using JokenPo.Models;
using System.Windows.Input;

namespace JokenPo.ViewModels
{
    public partial class JokenPo_ViewModel : ObservableObject
    {
        [ObservableProperty]
        private string resultado;

        [ObservableProperty]
        private int plScore;

        [ObservableProperty]
        private int opScore;

        [ObservableProperty]
        private string plNome;

        [ObservableProperty]
        private string opNome;

        [ObservableProperty]
        private string plImage;

        [ObservableProperty]
        private string opImage;

        [ObservableProperty]
        private string pl_escolha;

        public ICommand JogarCommand { get; set; }
        public ICommand ReiniciarCommand { get; set; }

        public JokenPo_ViewModel()
        {
            JogarCommand = new Command(Play);
            ReiniciarCommand = new Command(Reset);
            plNome = "Player";
            opNome = "Máquina";
            PlImage = "player.png";
            OpImage = "oponnent.png";
        }

        public void Play()
        {
            Player player = new Player();
            Player oponente = new Player();

            if (Pl_escolha != null)
            {
                player.Choice = ConvertStringToChoice(Pl_escolha.ToString());
                oponente.FazerEscolha();

                UpdatePlayersImages(player.Choice, oponente.Choice);

                CheckGameResult(player, oponente);
            }
            else
            {
                Resultado = "Faça sua jogada";
            }

        }

        private Choice ConvertStringToChoice(string selectedString)
        {
            switch (selectedString)
            {
                case "Pedra":
                    return Choice.Pedra;
                case "Papel":
                    return Choice.Papel;
                case "Tesoura":
                    return Choice.Tesoura;
                default:
                    throw new ArgumentException($"Valor não reconhecido: {selectedString}");
            }
        }

        private void UpdatePlayersImages(Choice playerChoice, Choice oponenteChoice)
        {
            OpImage = GetImageFromChoice(oponenteChoice);
            PlImage = GetImageFromChoice(playerChoice);
        }

        private string GetImageFromChoice(Choice choice)
        {
            switch (choice)
            {
                case Choice.Pedra:
                    return "rock.png";
                case Choice.Papel:
                    return "paper.png";
                case Choice.Tesoura:
                    return "scissor.png";
                default:
                    return "player.png";
            }
        }

        private void CheckGameResult(Player player, Player oponente)
        {
            if (plScore < 10 && opScore < 10)
            {
                if (player.Choice == oponente.Choice)
                {
                    Resultado = "Empate";
                }
                else if ((player.Choice == Choice.Pedra && oponente.Choice == Choice.Tesoura) ||
                         (player.Choice == Choice.Papel && oponente.Choice == Choice.Pedra) ||
                         (player.Choice == Choice.Tesoura && oponente.Choice == Choice.Papel))
                {
                    Resultado = $"{player.Choice} vence {oponente.Choice}, {plNome} venceu";
                    PlScore++;
                }
                else
                {
                    Resultado = $"{oponente.Choice} vence {player.Choice}, {opNome} venceu";
                    OpScore++;
                }
            }
            else
            {
                EndGame();
            }
        }

        private void EndGame()
        {
            if (plScore == 10)
            {
                Resultado = $"Jogo encerrado, {plNome} venceu";
            }
            else
            {
                Resultado = $"Jogo encerrado, {opNome} venceu";
            }

            PlImage = "player.png";
            OpImage = "oponnent.png";
        }

        private void Reset()
        {
            Resultado = "";

            opScore = 0;
            plScore = 0;

            PlImage = "player.png";
            OpImage = "oponnent.png";
        }
    }
}
