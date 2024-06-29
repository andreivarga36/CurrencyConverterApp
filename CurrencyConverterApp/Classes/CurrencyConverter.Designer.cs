using System;

namespace CurrencyConverterApp
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
            this.labFrom = new System.Windows.Forms.Label();
            this.labTo = new System.Windows.Forms.Label();
            this.labAmount = new System.Windows.Forms.Label();
            this.sourceCurrencyComboBox = new System.Windows.Forms.ComboBox();
            this.destinationCurrencyComboBox = new System.Windows.Forms.ComboBox();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.labTotal = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labFrom
            // 
            this.labFrom.AutoSize = true;
            this.labFrom.BackColor = System.Drawing.Color.Transparent;
            this.labFrom.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFrom.ForeColor = System.Drawing.Color.Black;
            this.labFrom.Location = new System.Drawing.Point(125, 110);
            this.labFrom.Name = "labFrom";
            this.labFrom.Size = new System.Drawing.Size(51, 23);
            this.labFrom.TabIndex = 0;
            this.labFrom.Text = "From";
            // 
            // labTo
            // 
            this.labTo.AutoSize = true;
            this.labTo.BackColor = System.Drawing.Color.Transparent;
            this.labTo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTo.ForeColor = System.Drawing.Color.Black;
            this.labTo.Location = new System.Drawing.Point(125, 150);
            this.labTo.Name = "labTo";
            this.labTo.Size = new System.Drawing.Size(27, 23);
            this.labTo.TabIndex = 1;
            this.labTo.Text = "To";
            // 
            // labAmount
            // 
            this.labAmount.AutoSize = true;
            this.labAmount.BackColor = System.Drawing.Color.Transparent;
            this.labAmount.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labAmount.ForeColor = System.Drawing.Color.Black;
            this.labAmount.Location = new System.Drawing.Point(125, 190);
            this.labAmount.Name = "labAmount";
            this.labAmount.Size = new System.Drawing.Size(72, 23);
            this.labAmount.TabIndex = 2;
            this.labAmount.Text = "Amount";
            // 
            // sourceCurrencyComboBox
            // 
            this.sourceCurrencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceCurrencyComboBox.FormattingEnabled = true;
            this.sourceCurrencyComboBox.Location = new System.Drawing.Point(221, 110);
            this.sourceCurrencyComboBox.Name = "sourceCurrencyComboBox";
            this.sourceCurrencyComboBox.Size = new System.Drawing.Size(121, 21);
            this.sourceCurrencyComboBox.TabIndex = 1;
            this.sourceCurrencyComboBox.DropDown += HandleCurrencyComboBoxesPopulation;
            this.sourceCurrencyComboBox.SelectedIndexChanged += ComboBoxSelectedIndexChanged;
            // 
            // destinationCurrencyComboBox
            // 
            this.destinationCurrencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destinationCurrencyComboBox.FormattingEnabled = true;
            this.destinationCurrencyComboBox.Location = new System.Drawing.Point(221, 150);
            this.destinationCurrencyComboBox.Name = "destinationCurrencyComboBox";
            this.destinationCurrencyComboBox.Size = new System.Drawing.Size(121, 21);
            this.destinationCurrencyComboBox.TabIndex = 2;
            this.destinationCurrencyComboBox.DropDown += HandleCurrencyComboBoxesPopulation;
            this.destinationCurrencyComboBox.SelectedIndexChanged += ComboBoxSelectedIndexChanged;
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(221, 190);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(121, 20);
            this.amountTextBox.TabIndex = 3;
            this.amountTextBox.KeyPress += AmountTextBoxKeyPress;
            this.amountTextBox.Leave += AmountTextBoxLeave;
            this.amountTextBox.KeyDown += AmountTextBoxKeyDown;
            // 
            // labTotal
            // 
            this.labTotal.AutoSize = true;
            this.labTotal.BackColor = System.Drawing.Color.Transparent;
            this.labTotal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTotal.ForeColor = System.Drawing.Color.Black;
            this.labTotal.Location = new System.Drawing.Point(125, 240);
            this.labTotal.Name = "labTotal";
            this.labTotal.Size = new System.Drawing.Size(55, 23);
            this.labTotal.TabIndex = 6;
            this.labTotal.Text = "Total :";
            // 
            // btnConvert
            // 
            this.btnConvert.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.ForeColor = System.Drawing.Color.Black;
            this.btnConvert.Location = new System.Drawing.Point(370, 150);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(88, 45);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.HandleConvertButtonClick);
            // 
            // CurrencyConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(529, 371);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.labTotal);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.destinationCurrencyComboBox);
            this.Controls.Add(this.sourceCurrencyComboBox);
            this.Controls.Add(this.labAmount);
            this.Controls.Add(this.labTo);
            this.Controls.Add(this.labFrom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CurrencyConverter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppInterface";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labFrom;
        private System.Windows.Forms.Label labTo;
        private System.Windows.Forms.Label labAmount;
        private System.Windows.Forms.ComboBox sourceCurrencyComboBox;
        private System.Windows.Forms.ComboBox destinationCurrencyComboBox;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Label labTotal;
        private System.Windows.Forms.Button btnConvert;
    }
}

