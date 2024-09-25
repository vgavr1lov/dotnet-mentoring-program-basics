using System;
using System.Windows.Forms;
using HelloConcatenationLibrary;

namespace WindowsFormsApp
{
   public partial class MainForm : Form
   {
      public MainForm()
      {
         InitializeComponent();
      }

      private void confirmUsernameButton_Click(object sender, EventArgs e)
      {
         string message = HelloConcatenation.ConcatenateTimeAndUsername(usernameText.Text);
         MessageBox.Show(message);
      }
   }
}
