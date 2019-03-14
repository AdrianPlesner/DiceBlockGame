using System;
using Eto.Forms;
using Eto.Drawing;
namespace DiceBlockGame
{
    public class PlayerBox : GroupBox
    {

        public PlayerBox(string title, int num)
        {
            Text = title;
            PlayerNumber = num;
            if(num > 1)
            {
                this.Enabled = false;
                btnRoll.Enabled = false;
            }

            MinimumSize = new Size(100, 300);
            btnConfirm.Click += BtnConfirm_Click;
            btnRoll.Click += BtnRoll_Click;
            color = new Color((float)Rand.NextDouble(), (float)Rand.NextDouble(), (float)Rand.NextDouble());
            cpPlayerColor.Value = color;
            cpPlayerColor.ValueChanged += CpPlayerColor_ValueChanged;
            layout.Items.Add(lblScore);
            layout.Items.Add(cpPlayerColor);
            layout.Items.Add(btnRoll);
            layout.Items.Add(lblDice);
            layout.Items.Add(btnConfirm);
            Content = layout;
        }

        private Random Rand = new Random();
        public int PlayerNumber;
        private int Dice1 = 0, Dice2 = 0;
        private int Score = 0;
        public Color color = new Color();


        private Label lblScore = new Label { Text = "Score: 0" };

        private ColorPicker cpPlayerColor = new ColorPicker();

        public Button btnRoll = new Button { Text = "Roll dice" };

        private Label lblDice = new Label { Text = "Dice: 0 X 0" };

        public Button btnConfirm = new Button { Text = "Confirm", Enabled = false };
        

        private StackLayout layout = new StackLayout
        {
            Orientation = Orientation.Vertical,
            HorizontalContentAlignment = HorizontalAlignment.Center,
            Spacing = 5,
            Padding = new Padding(5, 5)
        };

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            btnConfirm.Enabled = false;
            this.Enabled = false;
        }


        void BtnRoll_Click(object sender, EventArgs e)
        {
            Dice1 = Rand.Next() % 6 + 1;
            Dice2 = Rand.Next() % 6 + 1;

            lblDice.Text = "Dice: " + Dice1 + " X " + Dice2;
            btnRoll.Enabled = false;
            btnConfirm.Enabled = true;
        }

        void CpPlayerColor_ValueChanged(object Sender, EventArgs e)
        {
            color = cpPlayerColor.Value;
        }

    }
}
