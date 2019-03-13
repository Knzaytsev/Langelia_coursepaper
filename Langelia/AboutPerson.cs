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
        private Person _person;
        private GameProcess gameProcess;
        public AboutPerson()
        {
            InitializeComponent();
        }

        public void About(Person person, GameProcess gp)
        {
            namePerson.Text = person.Name;
            movePerson.Text = person.NumberMove.ToString();
            healthPerson.Text = person.Health.ToString();
            defensePerson.Text = person.Defense.ToString();
            attackLabel.Text = person.Attack.ToString();
            switch (person.Feature)
            {
                case 1:
                    typePerson.Text = "Воин";
                    action.Text = "Атаковать";
                    break;
                case 2:
                    typePerson.Text = "Поселенец";
                    action.Text = "Построить город";
                    break;
                case 3:
                    typePerson.Text = "Дипломат";
                    action.Text = "Установить связи";
                    break;
            }
            _person = person;
            gameProcess = gp;
        }

        public void ChangingMove(int move)
        {
            movePerson.Text = move.ToString();
            _person.NumberMove = move;
        }

        private void action_Click(object sender, EventArgs e)
        {
            switch (_person.Feature)
            {
                case 1:
                    break;
                case 2:
                    gameProcess.CreateCity();
                    Close();
                    break;
                case 3:
                    break;
            }
        }
    }
}
