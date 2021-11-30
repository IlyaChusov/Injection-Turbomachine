namespace Расчёт_нагнетательной_турбомашины
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.variantBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.culcButton = new System.Windows.Forms.Button();
            this.H_cLabel = new System.Windows.Forms.Label();
            this.graphButton = new System.Windows.Forms.Button();
            this.d_Label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.H2_TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Q2_TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.alphaBox = new System.Windows.Forms.TextBox();
            this.Q1Box = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.nBox = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.tab2 = new System.Windows.Forms.TabPage();
            this.tab3 = new System.Windows.Forms.TabPage();
            this.tab4 = new System.Windows.Forms.TabPage();
            this.tab5 = new System.Windows.Forms.TabPage();
            this.tab6 = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tab1.SuspendLayout();
            this.SuspendLayout();
            // 
            // variantBox
            // 
            this.variantBox.DisplayMember = "1";
            this.variantBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variantBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.variantBox.Location = new System.Drawing.Point(78, 7);
            this.variantBox.Margin = new System.Windows.Forms.Padding(2);
            this.variantBox.Name = "variantBox";
            this.variantBox.Size = new System.Drawing.Size(37, 21);
            this.variantBox.TabIndex = 0;
            this.variantBox.SelectedIndexChanged += new System.EventHandler(this.variantBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Вариант:";
            // 
            // culcButton
            // 
            this.culcButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.culcButton.Location = new System.Drawing.Point(9, 446);
            this.culcButton.Margin = new System.Windows.Forms.Padding(2);
            this.culcButton.Name = "culcButton";
            this.culcButton.Size = new System.Drawing.Size(241, 131);
            this.culcButton.TabIndex = 2;
            this.culcButton.Text = "РАССЧИТАТЬ";
            this.culcButton.UseVisualStyleBackColor = true;
            this.culcButton.Click += new System.EventHandler(this.culcButton_Click);
            // 
            // H_cLabel
            // 
            this.H_cLabel.AutoSize = true;
            this.H_cLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.H_cLabel.Location = new System.Drawing.Point(9, 34);
            this.H_cLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.H_cLabel.Name = "H_cLabel";
            this.H_cLabel.Size = new System.Drawing.Size(41, 17);
            this.H_cLabel.TabIndex = 3;
            this.H_cLabel.Text = "H c =";
            // 
            // graphButton
            // 
            this.graphButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.graphButton.Location = new System.Drawing.Point(257, 446);
            this.graphButton.Margin = new System.Windows.Forms.Padding(2);
            this.graphButton.Name = "graphButton";
            this.graphButton.Size = new System.Drawing.Size(244, 131);
            this.graphButton.TabIndex = 4;
            this.graphButton.Text = "ПОСТРОИТЬ ГРАФИК";
            this.graphButton.UseVisualStyleBackColor = true;
            this.graphButton.Click += new System.EventHandler(this.graphButton_Click);
            // 
            // d_Label
            // 
            this.d_Label.AutoSize = true;
            this.d_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.d_Label.Location = new System.Drawing.Point(9, 187);
            this.d_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.d_Label.Name = "d_Label";
            this.d_Label.Size = new System.Drawing.Size(28, 17);
            this.d_Label.TabIndex = 5;
            this.d_Label.Text = "d ≈";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(118, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "H2 =";
            // 
            // H2_TextBox
            // 
            this.H2_TextBox.Location = new System.Drawing.Point(151, 7);
            this.H2_TextBox.Margin = new System.Windows.Forms.Padding(2);
            this.H2_TextBox.Name = "H2_TextBox";
            this.H2_TextBox.Size = new System.Drawing.Size(50, 20);
            this.H2_TextBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(204, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Q2 =";
            // 
            // Q2_TextBox
            // 
            this.Q2_TextBox.Location = new System.Drawing.Point(236, 7);
            this.Q2_TextBox.Margin = new System.Windows.Forms.Padding(2);
            this.Q2_TextBox.Name = "Q2_TextBox";
            this.Q2_TextBox.Size = new System.Drawing.Size(50, 20);
            this.Q2_TextBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 211);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "alpha =";
            // 
            // alphaBox
            // 
            this.alphaBox.Location = new System.Drawing.Point(55, 209);
            this.alphaBox.Margin = new System.Windows.Forms.Padding(2);
            this.alphaBox.Name = "alphaBox";
            this.alphaBox.Size = new System.Drawing.Size(50, 20);
            this.alphaBox.TabIndex = 11;
            // 
            // Q1Box
            // 
            this.Q1Box.Location = new System.Drawing.Point(42, 5);
            this.Q1Box.Margin = new System.Windows.Forms.Padding(2);
            this.Q1Box.Name = "Q1Box";
            this.Q1Box.ReadOnly = true;
            this.Q1Box.Size = new System.Drawing.Size(50, 20);
            this.Q1Box.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Q 1 =";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(108, 211);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(95, 7);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "л/с";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(215, 211);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "об/мин";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(161, 209);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(50, 20);
            this.textBox1.TabIndex = 17;
            // 
            // nBox
            // 
            this.nBox.AutoSize = true;
            this.nBox.Location = new System.Drawing.Point(135, 214);
            this.nBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nBox.Name = "nBox";
            this.nBox.Size = new System.Drawing.Size(22, 13);
            this.nBox.TabIndex = 16;
            this.nBox.Text = "n =";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tab1);
            this.tabControl.Controls.Add(this.tab2);
            this.tabControl.Controls.Add(this.tab3);
            this.tabControl.Controls.Add(this.tab4);
            this.tabControl.Controls.Add(this.tab5);
            this.tabControl.Controls.Add(this.tab6);
            this.tabControl.Location = new System.Drawing.Point(9, 234);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(492, 207);
            this.tabControl.TabIndex = 19;
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.Q1Box);
            this.tab1.Controls.Add(this.label5);
            this.tab1.Controls.Add(this.label7);
            this.tab1.Location = new System.Drawing.Point(4, 22);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(3);
            this.tab1.Size = new System.Drawing.Size(484, 181);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "Пункт 1";
            this.tab1.UseVisualStyleBackColor = true;
            // 
            // tab2
            // 
            this.tab2.Location = new System.Drawing.Point(4, 22);
            this.tab2.Name = "tab2";
            this.tab2.Padding = new System.Windows.Forms.Padding(3);
            this.tab2.Size = new System.Drawing.Size(484, 181);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "Пункт 2";
            this.tab2.UseVisualStyleBackColor = true;
            // 
            // tab3
            // 
            this.tab3.Location = new System.Drawing.Point(4, 22);
            this.tab3.Name = "tab3";
            this.tab3.Padding = new System.Windows.Forms.Padding(3);
            this.tab3.Size = new System.Drawing.Size(484, 181);
            this.tab3.TabIndex = 2;
            this.tab3.Text = "Пункт 3";
            this.tab3.UseVisualStyleBackColor = true;
            // 
            // tab4
            // 
            this.tab4.Location = new System.Drawing.Point(4, 22);
            this.tab4.Name = "tab4";
            this.tab4.Padding = new System.Windows.Forms.Padding(3);
            this.tab4.Size = new System.Drawing.Size(484, 181);
            this.tab4.TabIndex = 3;
            this.tab4.Text = "Пункт 4";
            this.tab4.UseVisualStyleBackColor = true;
            // 
            // tab5
            // 
            this.tab5.Location = new System.Drawing.Point(4, 22);
            this.tab5.Name = "tab5";
            this.tab5.Padding = new System.Windows.Forms.Padding(3);
            this.tab5.Size = new System.Drawing.Size(484, 181);
            this.tab5.TabIndex = 4;
            this.tab5.Text = "Пункт 5";
            this.tab5.UseVisualStyleBackColor = true;
            // 
            // tab6
            // 
            this.tab6.Location = new System.Drawing.Point(4, 22);
            this.tab6.Name = "tab6";
            this.tab6.Padding = new System.Windows.Forms.Padding(3);
            this.tab6.Size = new System.Drawing.Size(484, 181);
            this.tab6.TabIndex = 5;
            this.tab6.Text = "Пункт 6";
            this.tab6.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 587);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.nBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.alphaBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Q2_TextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.H2_TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.d_Label);
            this.Controls.Add(this.graphButton);
            this.Controls.Add(this.H_cLabel);
            this.Controls.Add(this.culcButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.variantBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Расчёт нагнетательной турбомашины";
            this.tabControl.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox variantBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button culcButton;
        private System.Windows.Forms.Label H_cLabel;
        private System.Windows.Forms.Button graphButton;
        private System.Windows.Forms.Label d_Label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox H2_TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Q2_TextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox alphaBox;
        private System.Windows.Forms.TextBox Q1Box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label nBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tab1;
        private System.Windows.Forms.TabPage tab2;
        private System.Windows.Forms.TabPage tab3;
        private System.Windows.Forms.TabPage tab4;
        private System.Windows.Forms.TabPage tab5;
        private System.Windows.Forms.TabPage tab6;
    }
}

