
namespace LogingInApp
{
    partial class formMain
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
            this.listViewStudents = new System.Windows.Forms.ListView();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.ctlAddress = new AddressControl();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewStudents
            // 
            this.listViewStudents.HideSelection = false;
            this.listViewStudents.Location = new System.Drawing.Point(62, 44);
            this.listViewStudents.Name = "listViewStudents";
            this.listViewStudents.Size = new System.Drawing.Size(349, 149);
            this.listViewStudents.TabIndex = 0;
            this.listViewStudents.UseCompatibleStateImageBehavior = false;
            this.listViewStudents.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewStudents_ItemSelectionChanged);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(653, 44);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(101, 37);
            this.btnLogOut.TabIndex = 1;
            this.btnLogOut.Text = "Log out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // ctlAddress
            // 
            this.ctlAddress.City = null;
            this.ctlAddress.CountryId = 1;
            this.ctlAddress.Location = new System.Drawing.Point(491, 121);
            this.ctlAddress.Name = "ctlAddress";
            this.ctlAddress.PostCode = 0;
            this.ctlAddress.Size = new System.Drawing.Size(263, 215);
            this.ctlAddress.StreetAddress = null;
            this.ctlAddress.TabIndex = 2;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(653, 353);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(101, 23);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.ctlAddress);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.listViewStudents);
            this.Name = "formMain";
            this.Text = "formMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMain_OnClosing);
            this.Load += new System.EventHandler(this.formMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewStudents;
        private System.Windows.Forms.Button btnLogOut;
        private AddressControl ctlAddress;
        private System.Windows.Forms.Button btnSubmit;
    }
}