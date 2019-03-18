using System;
using Eto.Forms;
using Eto.Drawing;
using System.Collections.ObjectModel;
using System.Linq;

namespace DiceBlockGame
{
    public class MainForm : Form
    {
        private Scrollable Scroller = new Scrollable
        {
            ExpandContentHeight = true
        };

        private PixelLayout Layout = new PixelLayout();
        private PlayerBox[] Players;
        private int NumPlayers;
        private int PlayerTurn = 0;

        public MainForm()
        {
            Title = "My Eto Form";
            Bounds = new Rectangle(100, 100, 800, 600);
            Resizable = false;
            Content = Scroller;
            Scroller.Content = Layout;

            MakeStartScreen();

            MakeMenu();
        }

        private void MakeStartScreen()
        {

            Button btnStart = new Button
            {
                Text = "Start Game",
                Size = new Size(100, 50)
            };

            btnStart.Click += ShowDialog;


            PositionInMiddle(btnStart, this);
        }

        private void PositionInMiddle(Control control, Control parent)
        {
            int x = control.Width / 2;
            int y = control.Height / 2;

            Layout.Add(control, parent.Width / 2 - x, parent.Height / 2 - y);
        }

        private void ShowDialog(object Sender, EventArgs e)
        {
            NewGameDialog dialog = new NewGameDialog
            {
                MinimumSize = new Size(300, 200)
            };


            dialog.ShowModal();
            NumPlayers = dialog.Result[0];
            StartNewGame(NumPlayers, dialog.Result[1], dialog.Result[2]);

        }

        private void StartNewGame(int numPlayers, int sizeX, int sizeY)
        {
            Players = new PlayerBox[numPlayers];
            for(int i = 0; i < numPlayers;i++)
            {
                string text = "Player" + (i + 1);
                Players[i] = new PlayerBox(text, i + 1);
                Players[i].EnabledChanged += PlayerEnablechange;
            }
            PlayField field = new PlayField(sizeX, sizeY);
            SuspendLayout();
            Layout.RemoveAll();
            SetNewSize(sizeX, sizeY);
            Layout.Add(Players[0], 5, 5);
            Layout.Add(field, 120, 5);
            field.Blocks[0, 0].Color = Players[0].color;
            field.Blocks[sizeX-1, sizeY-1].Color = Players[1].color;
            Layout.Add(Players[1], Bounds.Width - 120, Bounds.Height - 350);
            ResumeLayout();

        }

        private void SetNewSize(int sizeX, int sizeY)
        {
            Size = new Size(220 + sizeX * (20 + 2) + 30, sizeY * (20 + 2) + 50);
        }

        private void MakeMenu()
        {
            var quitCommand = new Command { MenuText = "Quit", Shortcut = Application.Instance.CommonModifier | Keys.Q };
            quitCommand.Executed += (sender, e) => Application.Instance.Quit();

            var aboutCommand = new Command { MenuText = "About..." };
            aboutCommand.Executed += (sender, e) => new AboutDialog().ShowDialog(this);

            var NGCommand = new Command { MenuText = "New Game" };
            NGCommand.Executed += ShowDialog;

            // create menu
            Menu = new MenuBar
            {
                Items =
                {
                    // File submenu
                    new ButtonMenuItem { Text = "&File", Items = { NGCommand } },
                    // new ButtonMenuItem { Text = "&Edit", Items = { /* commands/items */ } },
                    // new ButtonMenuItem { Text = "&View", Items = { /* commands/items */ } },
                },
                ApplicationItems =
                {
                    // application (OS X) or file menu (others)
                    new ButtonMenuItem { Text = "&Preferences..." },
                },
                QuitItem = quitCommand,
                AboutItem = aboutCommand
            };
        }

        private void PlayerEnablechange (object Sender, EventArgs e)
        {
            PlayerBox ob = (PlayerBox)Sender;
            if (ob.Enabled)
            {
                ob.btnRoll.Enabled = true;
                PlayerTurn = ob.PlayerNumber - 1;
            }
            else
            {
                Players[ob.PlayerNumber % NumPlayers].Enabled = true;
            }

        }
    }
}
