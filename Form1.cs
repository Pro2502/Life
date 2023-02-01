using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIFE
{
    
    public partial class Form1 : Form
    {
        //private int _currentGeneration = 0;
        //_c нижнего
        //Публичные - с большой буквы - NumberOne
        //Переменная - существительное. Класс - существительное. Метод - глагол
        private Graphics graphics;
        private int resolution;
        //private bool[,] field;
        //private int rows;
        //private int cols;
        private CalculationAutomata calculationAutomata;
        public Form1()
        {
            InitializeComponent();
        }

        private void StartGame()
        {
            if (timeDisplay.Enabled)
                return;
            //_currentGeneration = 0;
            
            nudResolution.Enabled = false;
            nudDensity.Enabled = false;
            resolution = (int)nudResolution.Value;

            calculationAutomata = new CalculationAutomata(/*rows*/ fieldForDrawing.Height / resolution, /*cols*/fieldForDrawing.Width / resolution, (int) nudDensity.Value);

            //rows = fieldForDrawing.Height / resolution;
            //cols = fieldForDrawing.Width / resolution;

            Text = $"Generation: {calculationAutomata.CurrentGeneration}";

            //field = new bool[cols, rows];

            //Random random = new Random();
            //for (int x = 0; x < cols; x++)
            //{
            //    for (int y = 0; y < rows; y++)
            //    {
            //        field[x, y] = random.Next((int)nudDensity.Value) == 0;
            //    }
            //}

            fieldForDrawing.Image = new Bitmap(fieldForDrawing.Width, fieldForDrawing.Height);
            graphics = Graphics.FromImage(fieldForDrawing.Image);

            timeDisplay.Start();
        }
        private void DrawNewGeneration()
        {
            graphics.Clear(Color.Black);
            var field = calculationAutomata.CountingCurrentGeneration();

            for (int x = 0; x < field.GetLength(0); x++)
            {
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    if (field[x,y])
                    {
                        graphics.FillEllipse(Brushes.Aquamarine, x * resolution, y * resolution, resolution, resolution);
                    }
                }
            }

            fieldForDrawing.Refresh();
            Text = $"Generation: {calculationAutomata.CurrentGeneration}";
            calculationAutomata.CalculationGeneration();
            //    var newField = new bool[cols, rows];

            //    for (int x = 0; x < cols; x++)
            //    {
            //        for (int y = 0; y < rows; y++)
            //        {
            //            var neighboursCount = CountNeighbours(x, y);
            //            var hasLife = field[x, y];
            //            if (!hasLife && neighboursCount == 3)
            //            {
            //                newField[x, y] = true;
            //            }
            //            else if (hasLife && (neighboursCount < 2 || neighboursCount > 3))
            //            {
            //                newField[x, y] = false;
            //            }
            //            else
            //            {
            //                newField[x, y] = field[x, y];
            //            }
            //            if (hasLife)
            //            {
            //                graphics.FillEllipse(Brushes.Aquamarine, x * resolution, y * resolution, resolution, resolution);
            //            }
            //        }
            //    }
            //    field = newField;

        }
    //private int CountNeighbours(int x, int y)
    //{
    //    int count = 0;
    //    for (int i = -1; i < 2; i++)
    //    {
    //        for (int j = -1; j < 2; j++)
    //        {
    //            var col = (x + i + cols) % cols;//если заходим за левый край - он является правым
    //            var row = (y + j + rows) % rows;
    //            var isSelfChecking = col == x && row == y;// самопроверка
    //            var hasLife = field[col, row];
    //            if (hasLife && !isSelfChecking)
    //                count++;
    //        }
    //    }
    //    return count;
    //}
    private void StopGame()
        {
            if (!timeDisplay.Enabled)
            {
                return;
            }
            timeDisplay.Stop();
            nudResolution.Enabled = true;
            nudDensity.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawNewGeneration();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            StopGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void nudDensity_ValueChanged(object sender, EventArgs e)
        {

        }

        private void picture_Click(object sender, EventArgs e)
        {

        }
    }
    

}
