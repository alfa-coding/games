using Halma.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Halma.WFormsGUI
{
    public partial class Form1 : Form
    {

        public LogicGUIManager LogicGUIHandler { get; set; }
        public Dictionary<GameColorBoxInfo,Brush> BrushBuilder { get; set; }

        public Form1(GameLogic game)
        {
            this.LogicGUIHandler = new LogicGUIManager(game);
            this.BrushBuilder = FillBrushBuilder();
            InitializeComponent();
            this.label1.Text = LogicGUIHandler.GetPlayerName(0);
            this.label2.Text = LogicGUIHandler.GetPlayerName(1);


        }

        private Dictionary<GameColorBoxInfo, Brush> FillBrushBuilder()
        {
            Dictionary<GameColorBoxInfo, Brush> builder = new Dictionary<GameColorBoxInfo, Brush>()
            {
                { GameColorBoxInfo.Black,Brushes.Black },
                {GameColorBoxInfo.Red,Brushes.Red},
                {GameColorBoxInfo.Blue,Brushes.Blue}
            };
            return builder;
        }

        private void pbxBoard_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
            DrawBoard(e.Graphics);
        }

        private void DrawBoard(Graphics graphics)
        {
            int numOfCel = LogicGUIHandler.GetBoardSize();
            int celSize = pbxBoard.Width / numOfCel;
            int stride = 10;
            Pen p = new Pen(Color.Black);
            Font font = new Font("Arial", 12,FontStyle.Bold);

            for (int i = 0; i < numOfCel; i++)
            {
                for (int j = 0; j < numOfCel; j++)
                {
                   
                    ValueBoxInfo valueBox = LogicGUIHandler.ContentBox(i, j);

                    Brush brush = BrushBuilder[valueBox.BrushInfo];


                    graphics.DrawString(valueBox.Content, font, brush, new Point(j * celSize + stride, i * celSize + stride));
                }
            }
        }

        private void DrawGrid(Graphics graphics)
        {
            int numOfCel = LogicGUIHandler.GetBoardSize();
            int celSize = pbxBoard.Width/numOfCel;
            Pen p = new Pen(Color.Black);
            for (int y = 0; y < numOfCel; y++)
            {
                graphics.DrawLine(p, 0, y * celSize, numOfCel * celSize, y * celSize);
            }

            for (int x = 0; x < numOfCel; x++)
            {
                graphics.DrawLine(p, x * celSize,0, x * celSize, numOfCel * celSize);
            }
        }

        private void pbxBoard_Click(object sender, EventArgs e)
        {
            
        }

        private void pbxBoard_MouseClick(object sender, MouseEventArgs e)
        {
            int numOfCel = LogicGUIHandler.GetBoardSize();
            int celSize = pbxBoard.Width / numOfCel;
            int col = e.X / celSize;
            int row = e.Y / celSize;

            DecisionBasedOnSelection decision = LogicGUIHandler.ProcessClick(col,row);

            if (decision.HasError)
            {
                MessageBox.Show(decision.ErrorMessage);
            }
            else
            {
                lblStartingPointValue.Text = LogicGUIHandler.StartingPosition.Row.ToString() + "," + LogicGUIHandler.StartingPosition.Col.ToString();
                lblSelectionValue.Text = row.ToString() + "," + col.ToString();
                pbxBoard.Refresh();
            }

        }
    }
}
