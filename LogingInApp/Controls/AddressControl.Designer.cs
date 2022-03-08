
namespace LogingInApp.Controls
{
    partial class AddressControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtStreetAddress = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtPostCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Country = new System.Windows.Forms.Label();
            this.ddlCountry = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtStreetAddress
            // 
            this.txtStreetAddress.Location = new System.Drawing.Point(114, 38);
            this.txtStreetAddress.Name = "txtStreetAddress";
            this.txtStreetAddress.Size = new System.Drawing.Size(114, 22);
            this.txtStreetAddress.TabIndex = 0;
            this.txtStreetAddress.TextChanged += new System.EventHandler(this.txtStreetAddress_TextChanged);
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(114, 82);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(114, 22);
            this.txtCity.TabIndex = 1;
            this.txtCity.TextChanged += new System.EventHandler(this.txtCity_TextChanged);
            // 
            // txtPostCode
            // 
            this.txtPostCode.Location = new System.Drawing.Point(114, 125);
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.Size = new System.Drawing.Size(114, 22);
            this.txtPostCode.TabIndex = 2;
            this.txtPostCode.TextChanged += new System.EventHandler(this.txtPostCode_TextChanged);
            this.txtPostCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPostCode_KeyPress);
            this.txtPostCode.MouseLeave += new System.EventHandler(this.txtPostCode_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Street";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "City";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Postal Code";
            // 
            // Country
            // 
            this.Country.AutoSize = true;
            this.Country.Location = new System.Drawing.Point(22, 167);
            this.Country.Name = "Country";
            this.Country.Size = new System.Drawing.Size(57, 17);
            this.Country.TabIndex = 7;
            this.Country.Text = "Country";
            // 
            // ddlCountry
            // 
            this.ddlCountry.FormattingEnabled = true;
            this.ddlCountry.Location = new System.Drawing.Point(114, 167);
            this.ddlCountry.Name = "ddlCountry";
            this.ddlCountry.Size = new System.Drawing.Size(114, 24);
            this.ddlCountry.TabIndex = 8;
            this.ddlCountry.SelectedIndexChanged += new System.EventHandler(this.ddlCountry_SelectedIndexChanged);
            // 
            // AddressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ddlCountry);
            this.Controls.Add(this.Country);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPostCode);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtStreetAddress);
            this.Name = "AddressControl";
            this.Size = new System.Drawing.Size(258, 277);
            this.Load += new System.EventHandler(this.AddressControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStreetAddress;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtPostCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Country;
        private System.Windows.Forms.ComboBox ddlCountry;
    }
}
