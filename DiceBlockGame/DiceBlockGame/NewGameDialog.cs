using System;
using Eto.Forms;
using Eto.Drawing;

namespace DiceBlockGame
{
    public class NewGameDialog : Dialog<int[]>
    {
        private StackLayout dLayout = new StackLayout
        {
            Orientation = Orientation.Vertical,
            HorizontalContentAlignment = HorizontalAlignment.Center,
            Spacing = 10,
            Padding = new Padding(10,10)
        };

        private Button btnOK = new Button
        {
            Text = "OK!"
        };

        private NumericStepper stpX = new NumericStepper
        {
            MinValue = 0,
            MaxValue = 50,
            Value = 20
        };

        private NumericStepper stpY = new NumericStepper
        {
            MinValue = 0,
            MaxValue = 50,
            Value = 30
        };

        private DropDown ddPlayers = new DropDown { Items = { "1 Player", "2 Players" } }; 

        public NewGameDialog()
        {

            dLayout.Items.Add(ddPlayers);

            btnOK.Click += CloseDialog;

            StackLayout laySteppers = new StackLayout
            {
                Orientation = Orientation.Horizontal,
                Spacing = 5,
                Padding = new Padding(2, 2),
                VerticalContentAlignment = VerticalAlignment.Center,
                Items = { new Label { Text = "Size: " }, new Label { Text = "X: " }, stpX, new Label { Text = "Y: " }, stpY }
            };

            dLayout.Items.Add(laySteppers);
            dLayout.Items.Add(btnOK);


            Content = dLayout;

        }

        private void CloseDialog(object sender, EventArgs e)
        {
            Result = new int[3];
            Result[0] = ddPlayers.SelectedIndex + 1;
            Result[1] = (int)stpX.Value;
            Result[2] = (int)stpY.Value;

            this.Close();
        }



    }
}
