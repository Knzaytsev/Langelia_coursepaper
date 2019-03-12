using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Langelia
{
    public partial class AboutPerson : Form
    {
        public AboutPerson()
        {
            InitializeComponent();
        }

        public void About(string name, string type, int movement, int health, int defense, int attack)
        {
            namePerson.Text = name;
            movePerson.Text = movement.ToString();
            healthPerson.Text = health.ToString();
            defensePerson.Text = defense.ToString();
            attackLabel.Text = attack.ToString();
            switch (type)
            {
                case "warrior":
                    typePerson.Text = "Воин";
                    action.Text = "Атаковать";
                    break;
                case "settler":
                    typePerson.Text = "Поселенец";
                    action.Text = "Построить город";
                    break;
                case "diplomat":
                    typePerson.Text = "Дипломат";
                    action.Text = "Установить связи";
                    break;
            }
        }

        public void ChangingMove(int move)
        {

        }
    }
}
