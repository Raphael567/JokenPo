using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokenPo.Models
{
    public partial class Player : ObservableObject
    {
        public Choice Choice { get; set; }

        public void FazerEscolha()
        {
            Random random = new Random();

            Choice = (Choice)random.Next(3);
        }
    }
}
