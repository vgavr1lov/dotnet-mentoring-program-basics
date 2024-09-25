namespace WindowsFormsApp
{
   partial class MainForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.confirmUsernameButton = new System.Windows.Forms.Button();
         this.usernameLabel = new System.Windows.Forms.Label();
         this.usernameText = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // confirmUsernameButton
         // 
         this.confirmUsernameButton.Location = new System.Drawing.Point(950, 123);
         this.confirmUsernameButton.Name = "confirmUsernameButton";
         this.confirmUsernameButton.Size = new System.Drawing.Size(152, 55);
         this.confirmUsernameButton.TabIndex = 5;
         this.confirmUsernameButton.Text = "Confirm";
         this.confirmUsernameButton.UseVisualStyleBackColor = true;
         this.confirmUsernameButton.Click += new System.EventHandler(this.confirmUsernameButton_Click);
         // 
         // usernameLabel
         // 
         this.usernameLabel.AutoSize = true;
         this.usernameLabel.Location = new System.Drawing.Point(38, 136);
         this.usernameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
         this.usernameLabel.Name = "usernameLabel";
         this.usernameLabel.Size = new System.Drawing.Size(235, 29);
         this.usernameLabel.TabIndex = 4;
         this.usernameLabel.Text = "Enter your username";
         // 
         // usernameText
         // 
         this.usernameText.Location = new System.Drawing.Point(283, 133);
         this.usernameText.Margin = new System.Windows.Forms.Padding(5);
         this.usernameText.Name = "usernameText";
         this.usernameText.Size = new System.Drawing.Size(569, 35);
         this.usernameText.TabIndex = 3;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1139, 315);
         this.Controls.Add(this.confirmUsernameButton);
         this.Controls.Add(this.usernameLabel);
         this.Controls.Add(this.usernameText);
         this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
         this.Name = "MainForm";
         this.Text = "MainForm";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button confirmUsernameButton;
      private System.Windows.Forms.Label usernameLabel;
      private System.Windows.Forms.TextBox usernameText;
   }
}

