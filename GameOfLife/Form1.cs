using System.Drawing;
using System.Threading;
namespace GameOfLife
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int sleepTimer = 100;
        int itterations = 1000;
        int width = 200;
        int height = 200;
        int zoom = 1;
        Table currentTable;
        Table oldTable;
        private void CreateGameTable()
        {
            Table table = new Table(width, height);
            table.CreateTable(width, height);
            currentTable = table;
            oldTable = table;
        }

        private void RunGame()
        {
            CreateGameTable();
            Graphics g = CreateGraphics();
            g.Clear(Color.AliceBlue);
            int time = 0;
            while (time < itterations)
            {
                currentTable = currentTable.UpdateTable();
                Console.WriteLine(currentTable);
                DrawTable(oldTable, currentTable);
                time++;
                oldTable = currentTable;
                Thread.Sleep(sleepTimer);
            }
        }
        public void DrawTable(Table oldTable, Table newTable)
        {
            Graphics g = CreateGraphics();
            SolidBrush brushLive = new SolidBrush(Color.Black);
            SolidBrush brushDead = new SolidBrush(Color.AliceBlue);
            g.TranslateTransform(12, 12);


            for (int i = 0; i < newTable.rows; i++)
            {
                for (int j = 0; j < newTable.columns; j++)
                {
                    if (oldTable.cells[i, j] != newTable.cells[i, j])
                    {
                        Rectangle rect = new Rectangle(i * zoom, j * zoom, zoom, zoom);
                        if (newTable.cells[i, j] == 0)
                        {
                            g.FillRectangle(brushDead, rect);
                        }
                        else
                        {
                            g.FillRectangle(brushLive, rect);
                        }
                    }
                }
            }
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            RunGame();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            width = Convert.ToInt32(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            height = Convert.ToInt32(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            sleepTimer = Convert.ToInt32(textBox3.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            itterations = Convert.ToInt32(textBox4.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            zoom = Convert.ToInt32(textBox5.Text);
        }
    }
}
