namespace CurrencyAppConverter
{
    partial class CurrencyConverter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrencyConverter));
            this.sourceCurrency = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sourceCurrencyComboBox = new System.Windows.Forms.ComboBox();
            this.destinationCurrencyComboBox = new System.Windows.Forms.ComboBox();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sourceCurrency
            // 
            this.sourceCurrency.AutoSize = true;
            this.sourceCurrency.BackColor = System.Drawing.Color.Transparent;
            this.sourceCurrency.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceCurrency.ForeColor = System.Drawing.Color.Black;
            this.sourceCurrency.Location = new System.Drawing.Point(125, 110);
            this.sourceCurrency.Name = "sourceCurrency";
            this.sourceCurrency.Size = new System.Drawing.Size(51, 23);
            this.sourceCurrency.TabIndex = 0;
            this.sourceCurrency.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(125, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(125, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Amount";
            // 
            // sourceCurrencyComboBox
            // 
            this.sourceCurrencyComboBox.FormattingEnabled = true;
            this.sourceCurrencyComboBox.Location = new System.Drawing.Point(221, 110);
            this.sourceCurrencyComboBox.Name = "sourceCurrencyComboBox";
            this.sourceCurrencyComboBox.Size = new System.Drawing.Size(121, 21);
            this.sourceCurrencyComboBox.TabIndex = 3;
            // 
            // destinationCurrencyComboBox
            // 
            this.destinationCurrencyComboBox.FormattingEnabled = true;
            this.destinationCurrencyComboBox.Location = new System.Drawing.Point(221, 150);
            this.destinationCurrencyComboBox.Name = "destinationCurrencyComboBox";
            this.destinationCurrencyComboBox.Size = new System.Drawing.Size(121, 21);
            this.destinationCurrencyComboBox.TabIndex = 4;
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(221, 190);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(121, 20);
            this.amountTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(125, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Total :";
            // 
            // btnConvert
            // 
            this.btnConvert.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.ForeColor = System.Drawing.Color.Black;
            this.btnConvert.Location = new System.Drawing.Point(370, 150);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(88, 45);
            this.btnConvert.TabIndex = 7;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            // 
            // CurrencyConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(529, 371);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.destinationCurrencyComboBox);
            this.Controls.Add(this.sourceCurrencyComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sourceCurrency);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CurrencyConverter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppInterface";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sourceCurrency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox sourceCurrencyComboBox;
        private System.Windows.Forms.ComboBox destinationCurrencyComboBox;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConvert;
    }
}

