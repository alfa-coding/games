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
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int size = (int)nudSize.Value;
            string p1 = tbxPlayer1.Text;
            string p2 = tbxPlayer2.Text;

            GameLogic game = new GameLogic(size,new string[] { p1,p2 });
            var formGame = new Form1(game);
            formGame.ShowDialog();
        }
    }
}
