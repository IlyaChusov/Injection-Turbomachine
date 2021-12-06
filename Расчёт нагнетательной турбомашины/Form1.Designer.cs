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
            this.nBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.tab2 = new System.Windows.Forms.TabPage();
            this.tab3 = new System.Windows.Forms.TabPage();
            this.tab4 = new System.Windows.Forms.TabPage();
            this.tab5 = new System.Windows.Forms.TabPage();
            this.tab6 = new System.Windows.Forms.TabPage();
            this.H1Box = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.nu1Box = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Nn1Box = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.N1Box = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.N3Box = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.Nn3Box = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.nu3Box = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.H3Box = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.Q3Box = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.n_3Box = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tab1.SuspendLayout();
            this.tab2.SuspendLayout();
            this.tab3.SuspendLayout();
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
            "30",
            "31"});
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
            this.d_Label.Location = new System.Drawing.Point(5, 3);
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
            this.H2_TextBox.Location = new System.Drawing.Point(160, 6);
            this.H2_TextBox.Margin = new System.Windows.Forms.Padding(2);
            this.H2_TextBox.Name = "H2_TextBox";
            this.H2_TextBox.Size = new System.Drawing.Size(50, 20);
            this.H2_TextBox.TabIndex = 7;
            this.H2_TextBox.Text = "39,84";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(214, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Q2 =";
            // 
            // Q2_TextBox
            // 
            this.Q2_TextBox.Location = new System.Drawing.Point(257, 7);
            this.Q2_TextBox.Margin = new System.Windows.Forms.Padding(2);
            this.Q2_TextBox.Name = "Q2_TextBox";
            this.Q2_TextBox.Size = new System.Drawing.Size(50, 20);
            this.Q2_TextBox.TabIndex = 9;
            this.Q2_TextBox.Text = "22,93";
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
            this.alphaBox.Text = "4";
            // 
            // Q1Box
            // 
            this.Q1Box.Location = new System.Drawing.Point(51, 5);
            this.Q1Box.Margin = new System.Windows.Forms.Padding(2);
            this.Q1Box.Name = "Q1Box";
            this.Q1Box.ReadOnly = true;
            this.Q1Box.Size = new System.Drawing.Size(114, 20);
            this.Q1Box.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 8);
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
            this.label7.Location = new System.Drawing.Point(173, 8);
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
            // nBox
            // 
            this.nBox.Location = new System.Drawing.Point(161, 209);
            this.nBox.Margin = new System.Windows.Forms.Padding(2);
            this.nBox.Name = "nBox";
            this.nBox.Size = new System.Drawing.Size(50, 20);
            this.nBox.TabIndex = 17;
            this.nBox.Text = "3000";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(135, 214);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "n =";
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
            this.tab1.Controls.Add(this.N1Box);
            this.tab1.Controls.Add(this.label16);
            this.tab1.Controls.Add(this.label17);
            this.tab1.Controls.Add(this.Nn1Box);
            this.tab1.Controls.Add(this.label14);
            this.tab1.Controls.Add(this.label15);
            this.tab1.Controls.Add(this.nu1Box);
            this.tab1.Controls.Add(this.label11);
            this.tab1.Controls.Add(this.label12);
            this.tab1.Controls.Add(this.H1Box);
            this.tab1.Controls.Add(this.label9);
            this.tab1.Controls.Add(this.label10);
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
            this.tab2.Controls.Add(this.d_Label);
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
            this.tab3.Controls.Add(this.n_3Box);
            this.tab3.Controls.Add(this.label28);
            this.tab3.Controls.Add(this.label29);
            this.tab3.Controls.Add(this.N3Box);
            this.tab3.Controls.Add(this.label18);
            this.tab3.Controls.Add(this.label19);
            this.tab3.Controls.Add(this.Nn3Box);
            this.tab3.Controls.Add(this.label20);
            this.tab3.Controls.Add(this.label21);
            this.tab3.Controls.Add(this.nu3Box);
            this.tab3.Controls.Add(this.label22);
            this.tab3.Controls.Add(this.label23);
            this.tab3.Controls.Add(this.H3Box);
            this.tab3.Controls.Add(this.label24);
            this.tab3.Controls.Add(this.label25);
            this.tab3.Controls.Add(this.Q3Box);
            this.tab3.Controls.Add(this.label26);
            this.tab3.Controls.Add(this.label27);
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
            // H1Box
            // 
            this.H1Box.Location = new System.Drawing.Point(51, 29);
            this.H1Box.Margin = new System.Windows.Forms.Padding(2);
            this.H1Box.Name = "H1Box";
            this.H1Box.ReadOnly = true;
            this.H1Box.Size = new System.Drawing.Size(114, 20);
            this.H1Box.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 32);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "H 1 =";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(173, 32);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "м";
            // 
            // nu1Box
            // 
            this.nu1Box.Location = new System.Drawing.Point(51, 53);
            this.nu1Box.Margin = new System.Windows.Forms.Padding(2);
            this.nu1Box.Name = "nu1Box";
            this.nu1Box.ReadOnly = true;
            this.nu1Box.Size = new System.Drawing.Size(114, 20);
            this.nu1Box.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 56);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "nu 1 =";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(173, 56);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "%";
            // 
            // Nn1Box
            // 
            this.Nn1Box.Location = new System.Drawing.Point(51, 77);
            this.Nn1Box.Margin = new System.Windows.Forms.Padding(2);
            this.Nn1Box.Name = "Nn1Box";
            this.Nn1Box.ReadOnly = true;
            this.Nn1Box.Size = new System.Drawing.Size(114, 20);
            this.Nn1Box.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 80);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "N n1 =";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(173, 80);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(25, 13);
            this.label15.TabIndex = 24;
            this.label15.Text = "кВт";
            // 
            // N1Box
            // 
            this.N1Box.Location = new System.Drawing.Point(51, 101);
            this.N1Box.Margin = new System.Windows.Forms.Padding(2);
            this.N1Box.Name = "N1Box";
            this.N1Box.ReadOnly = true;
            this.N1Box.Size = new System.Drawing.Size(114, 20);
            this.N1Box.TabIndex = 26;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 104);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 13);
            this.label16.TabIndex = 25;
            this.label16.Text = "N1 =";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(173, 104);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 13);
            this.label17.TabIndex = 27;
            this.label17.Text = "кВт";
            // 
            // N3Box
            // 
            this.N3Box.Location = new System.Drawing.Point(51, 125);
            this.N3Box.Margin = new System.Windows.Forms.Padding(2);
            this.N3Box.Name = "N3Box";
            this.N3Box.ReadOnly = true;
            this.N3Box.Size = new System.Drawing.Size(114, 20);
            this.N3Box.TabIndex = 41;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 128);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 13);
            this.label18.TabIndex = 40;
            this.label18.Text = "N3 =";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(173, 128);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(25, 13);
            this.label19.TabIndex = 42;
            this.label19.Text = "кВт";
            // 
            // Nn3Box
            // 
            this.Nn3Box.Location = new System.Drawing.Point(51, 101);
            this.Nn3Box.Margin = new System.Windows.Forms.Padding(2);
            this.Nn3Box.Name = "Nn3Box";
            this.Nn3Box.ReadOnly = true;
            this.Nn3Box.Size = new System.Drawing.Size(114, 20);
            this.Nn3Box.TabIndex = 38;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 104);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(39, 13);
            this.label20.TabIndex = 37;
            this.label20.Text = "N n3 =";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(173, 104);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(25, 13);
            this.label21.TabIndex = 39;
            this.label21.Text = "кВт";
            // 
            // nu3Box
            // 
            this.nu3Box.Location = new System.Drawing.Point(51, 77);
            this.nu3Box.Margin = new System.Windows.Forms.Padding(2);
            this.nu3Box.Name = "nu3Box";
            this.nu3Box.ReadOnly = true;
            this.nu3Box.Size = new System.Drawing.Size(114, 20);
            this.nu3Box.TabIndex = 35;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 80);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(37, 13);
            this.label22.TabIndex = 34;
            this.label22.Text = "nu 3 =";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label23.Location = new System.Drawing.Point(173, 80);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(15, 13);
            this.label23.TabIndex = 36;
            this.label23.Text = "%";
            // 
            // H3Box
            // 
            this.H3Box.Location = new System.Drawing.Point(51, 29);
            this.H3Box.Margin = new System.Windows.Forms.Padding(2);
            this.H3Box.Name = "H3Box";
            this.H3Box.ReadOnly = true;
            this.H3Box.Size = new System.Drawing.Size(114, 20);
            this.H3Box.TabIndex = 32;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(14, 32);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(33, 13);
            this.label24.TabIndex = 31;
            this.label24.Text = "H 3 =";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label25.Location = new System.Drawing.Point(173, 32);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(15, 13);
            this.label25.TabIndex = 33;
            this.label25.Text = "м";
            // 
            // Q3Box
            // 
            this.Q3Box.Location = new System.Drawing.Point(51, 5);
            this.Q3Box.Margin = new System.Windows.Forms.Padding(2);
            this.Q3Box.Name = "Q3Box";
            this.Q3Box.ReadOnly = true;
            this.Q3Box.Size = new System.Drawing.Size(114, 20);
            this.Q3Box.TabIndex = 29;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(14, 8);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(33, 13);
            this.label26.TabIndex = 28;
            this.label26.Text = "Q 3 =";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label27.Location = new System.Drawing.Point(173, 8);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(24, 13);
            this.label27.TabIndex = 30;
            this.label27.Text = "л/с";
            // 
            // n_3Box
            // 
            this.n_3Box.Location = new System.Drawing.Point(51, 53);
            this.n_3Box.Margin = new System.Windows.Forms.Padding(2);
            this.n_3Box.Name = "n_3Box";
            this.n_3Box.ReadOnly = true;
            this.n_3Box.Size = new System.Drawing.Size(114, 20);
            this.n_3Box.TabIndex = 44;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(16, 56);
            this.label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(31, 13);
            this.label28.TabIndex = 43;
            this.label28.Text = "n 3 =";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label29.Location = new System.Drawing.Point(173, 56);
            this.label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(44, 13);
            this.label29.TabIndex = 45;
            this.label29.Text = "об/мин";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 587);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.alphaBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Q2_TextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.H2_TextBox);
            this.Controls.Add(this.label2);
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
            this.tab2.ResumeLayout(false);
            this.tab2.PerformLayout();
            this.tab3.ResumeLayout(false);
            this.tab3.PerformLayout();
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
        private System.Windows.Forms.TextBox nBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tab1;
        private System.Windows.Forms.TabPage tab2;
        private System.Windows.Forms.TabPage tab3;
        private System.Windows.Forms.TabPage tab4;
        private System.Windows.Forms.TabPage tab5;
        private System.Windows.Forms.TabPage tab6;
        private System.Windows.Forms.TextBox H1Box;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox nu1Box;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox N1Box;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox Nn1Box;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox n_3Box;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox N3Box;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox Nn3Box;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox nu3Box;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox H3Box;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox Q3Box;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
    }
}

