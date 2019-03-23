using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;
using System.Windows.Forms;


namespace Langelia
{
    public partial class ChartCities : Form
    {
        City[] _cities;
        public ChartCities()
        {
            InitializeComponent();
        }

        public ChartCities(City[] cities)
        {
            InitializeComponent();
            _cities = cities;
        }

        private void ChartCities_Load(object sender, EventArgs e)
        {
            foreach (var c in _cities)
            {
                chart1.Series["Производство"].Points.AddXY(c.NameCity, c.NumberProduct);
                chart1.Series["Армия"].Points.AddXY(c.NameCity, c.NumberMilitary);
                chart1.Series["Культура"].Points.AddXY(c.NameCity, c.NumberCulture);
                chart1.Series["Жители"].Points.AddXY(c.NameCity, c.NumberCitizen);
                chart1.Series["Пища"].Points.AddXY(c.NameCity, c.NumberFood);
            }
        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Docx (*.docx)|*.docx";
            if(sfd.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string path = sfd.FileName;
            using(var doc = DocX.Create(path, DocumentTypes.Document))
            {
                var headLineFormat = new Formatting
                {
                    FontFamily = new Xceed.Words.NET.Font("Times New Roman"),
                    Size = 16D,
                    Bold = true
                };
                Paragraph title = doc.InsertParagraph("Статистика городов", false, headLineFormat);
                title.Alignment = Alignment.center;
                doc.InsertParagraph(Environment.NewLine);
                var secondTitleFormat = new Formatting
                {
                    FontFamily = new Xceed.Words.NET.Font("Times New Roman"),
                    Size = 14D,
                    Bold = true
                };
                var paraFormat = new Formatting
                {
                    FontFamily = new Xceed.Words.NET.Font("Times New Roman"),
                    Size = 13D,
                    Position = 20
                };
                foreach (var c in _cities)
                {
                    Paragraph secondTitle = doc.InsertParagraph($"Город {c.NameCity}", false, secondTitleFormat);
                    secondTitle.Alignment = Alignment.center;
                    doc.InsertParagraph(Environment.NewLine);
                    string msg = ""
                        + "По Вашему городу " + c.NameCity + " собрана следующая статистика: "
                        + Environment.NewLine + "Количество жителей: " + c.NumberCitizen
                        + Environment.NewLine + "Количество пищи: " + c.NumberFood
                        + Environment.NewLine + "Количество культурных очков: " + c.NumberCulture
                        + Environment.NewLine + "Количество военных очков: " + c.NumberMilitary
                        + Environment.NewLine + "Количество очков производства: " + c.NumberProduct;
                    Paragraph para = doc.InsertParagraph(msg, false, paraFormat);
                    doc.InsertParagraph(Environment.NewLine);
                }
                doc.Save();
            }
        }
    }
}
