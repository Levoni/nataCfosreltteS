//--------------------------------------------------------------------
// login.cs is a c# form that the user sees upon starting the game
// this form will be exited upon the game start conditions being met
// upon form load the user will be prompted by the system asking if 
// the user will be the host, and will require the user to input their
// IP address, and PlayerID
//--------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace nataC_fo_sreltteS
{
   public partial class Login : Form
   {
      Client mainForm;
      bool shutdownProgram = true;
      public Login(Client cli)
      {
         InitializeComponent();
         mainForm = cli; //So we dont create more clients, we only want one mainform
         Bitmap temp = new Bitmap(nataC_fo_sreltteS.Properties.Resources.SplashImage);
         Bitmap backGround = new Bitmap(temp, this.Width - 16, this.Height - 39); //Setting up the Background image fit the size of the form
         this.BackgroundImage = backGround;
      }

      public Login()
      {
         InitializeComponent();
         Bitmap temp = new Bitmap(nataC_fo_sreltteS.Properties.Resources.SplashImage);
         Bitmap backGround = new Bitmap(temp, this.Width - 16, this.Height - 39); //Setting up the Background image fit the size of the form
         this.BackgroundImage = backGround;
      }

      //-----------------------------------------------------------------------
      // this method will check to see that a valid name is entered, and that
      // the IP address is valid. if the IP address is valid, it will 
      // initiate the client's gameboard and pull the randomly generated map
      // from the server and send it to all players.                       				TODO: we need to somehow check number of players
      //-----------------------------------------------------------------------
      private void btnEnterGame_Click(object sender, EventArgs e)
      {
         errName.Clear();
         string Name = txtName.Text.Trim();
         string IP = txtIP.Text.Trim();

         btnEnterGame.Text = "Please Wait...";
         btnEnterGame.Refresh();
         if (txtName.Text.Trim() == "")
         {
            //MessageBox.Show("Please Enter a name");
            errName.SetError(txtName, "Please enter a name");
            btnEnterGame.Text = "Enter Game";
            return;
         } 
         else
            mainForm.playerName = Name;
         if (!mainForm.testIP(IP))
            MessageBox.Show("Invalid IP/Could not connect to server");
         else
         {
            shutdownProgram = false;
            mainForm.Show();
            this.Close();
         }
         btnEnterGame.Text = "Enter Game";


         
      }

      /// <summary>
      /// Method to press the EnterGame button from outside classes
      /// Used for testing
      /// </summary>
      public void PressEnterGame()
      {
         btnEnterGame_Click(null, EventArgs.Empty);
      }

      public string GetErrorMsg()
      {
         return errName.GetError(txtName);   
      }

      //-----------------------------------------------------------------------
      // if the exit button is pressed it will exit the application           	TODO: check for what happens when the host server clicks exit at any point
      //-----------------------------------------------------------------------
      private void btnExit_Click(object sender, EventArgs e)
      {
         mainForm.Close();
         this.Close();
      }

      //-----------------------------------------------------------------------
      // this is a guard that does not allow the user to enter a colon in the
      // name field. All other characters will be accepted.
      //-----------------------------------------------------------------------
      private void txtName_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (e.KeyChar == ':')
         {
            MessageBox.Show("Invalid Name. Your name cannot contain a \":\". ", "Invalid Character",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Handled = true;
         }

      }

      //-----------------------------------------------------------------------
      // This is a guard that only allows the user to input a period, or 
      // digit. the control keys are also enabled though, so the arrows and
      // backspace can be used.
      //-----------------------------------------------------------------------
      private void txtIP_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (!(e.KeyChar == '.' || e.KeyChar >= '0' && e.KeyChar <= '9' || char.IsControl(e.KeyChar)))
         {
            e.Handled = true;
         }
      }

      //ToDo add the form load event  and get the legit path to the .exe
      // still need to have it auto-enter the host IP, instead of what it displays, and not allow 

      //-----------------------------------------------------------------------
      // this is the method that will display the host's local IP address
      // this is solely for the user's benefit as the host's IP will be sent 
      // as 127.0.0.1, and not their IP displayed. this method also opens the
      // server .exe file
      //-----------------------------------------------------------------------

      private void Login_Load(object sender, EventArgs e)
      {
         DialogResult dr = MessageBox.Show("Will you host the server?" + Environment.NewLine +
            "NOTE: there can only be one host per game.", "Start New Game", MessageBoxButtons.YesNo,
      MessageBoxIcon.Question);
         if (dr == DialogResult.Yes)
         {
            txtIP.Text = GetLocalIPAddress();
            txtIP.ReadOnly = true;
            try
            {
               //byte[] myResBytes = nataC_fo_sreltteS.Properties.Resources.nataCServer;
               //Assembly asm = Assembly.Load(myResBytes);
               // search for the Entry Point
               //MethodInfo method = asm.EntryPoint;
               //if (method == null) throw new NotSupportedException();
               // create an instance of the Startup form Main method
               //object obj = asm.CreateInstance(method.Name);
               // invoke the application starting point
               //method.Invoke(obj, null);
               //Process.Start(nataC_fo_sreltteS.Properties.Resources.nataCServer);
               System.Diagnostics.Process.Start(@"../../../nataC Server\\bin\\Debug\\nataC Server.exe");

            }
            catch (FileNotFoundException ex)
            {
               MessageBox.Show("Could not find file!");
            }
            catch(Exception ex)
            {
            }
         }
      }

      //-----------------------------------------------------------------------
      // this is the method that will retrieve the host's local IP address
      //-----------------------------------------------------------------------
      public static string GetLocalIPAddress()
      {
         var host = Dns.GetHostEntry(Dns.GetHostName());
         foreach (var ip in host.AddressList)
         {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
               return ip.ToString();
            }
         }
         throw new Exception("Local IP Address Not Found!");
      }

      private void Login_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (shutdownProgram)
            mainForm.Close();
      }
   }
}

//8 methods