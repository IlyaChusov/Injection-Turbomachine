using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SQLite;
using System.IO;

namespace Расчёт_нагнетательной_турбомашины
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            variantBox.SelectedIndex = 0;
            // H = −0.06766x^2 + 0.90276x + 52.44933
            // КПД = −0.00363x^3 + 0.01554x^2 + 3.96383x − 1.98288
        }

        private string dbName = string.Format("Data Source={0}", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Nasosi.db"));
        SQLiteConnection dbConnection = new SQLiteConnection();
        private SQLiteCommand dbCommand = new SQLiteCommand();
        private const double g = 9.81;
        private const double pi = Math.PI;
        private double H_c1;
        private double H_c2;

        private void culcButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            dbConnection = new SQLiteConnection(dbName + ";Version=3;");
            dbCommand.Connection = dbConnection;
            
            int t0_C = getInt("t0C");
            double d_vs = getDouble("d_vs") / 1000;
            double d_n = getDouble("d_n") / 1000;
            int l_vs = getInt("l_vs");
            int l_n = getInt("l_n");
            double h_vs = getDouble("h_vs");
            double h_n = getDouble("h_n");
            int p_2 = getInt("p_2") * 1000;
            double Lyambda = getDouble("Lyambda");
            int Zeta_kr = getInt("Zeta_kr");
            int C = getInt("C");
            double p0 = getDouble("p_a");
            int p = getInt("p");
            int a = getInt("a");
            int Zeta_otkr = getInt("Zeta_otkr");
            int Zeta_C = getInt("Zeta_C");
            double Zeta_pov = getDouble("Zeta_pov");

            int alpha = int.Parse(alphaBox.Text);
            


            H_c1 = h_vs + h_n + (p_2 / (p * g));
            double H_temp_vs = 8 / (pi * pi * Math.Pow(d_vs, 4) * g);
            double H_temp_n = 8 / (pi * pi * Math.Pow(d_n, 4) * g);
            H_c2 = Lyambda * (l_vs / d_vs) * H_temp_vs + Zeta_C * H_temp_vs + Zeta_pov * H_temp_vs + Lyambda * (l_n / d_n) * H_temp_n + Zeta_otkr * H_temp_n + 2 * Zeta_pov * H_temp_n;
            
            H_cLabel.Text = "H c = (" + h_vs.ToString() + " + " + h_n.ToString() + " + (" + p_2.ToString() + " *10^3) / (" + p.ToString()
                + " * " + g.ToString() + ")) + Q^2 * (" + Zeta_C.ToString() + " * \n8 / (pi^2 * " + d_vs.ToString() + "^4 * 9.81) + "
                + Lyambda.ToString() + " * " + l_vs.ToString() + " / " + d_vs.ToString() + " * \n8 / (pi^2 * " + d_vs.ToString() + "^4 * 9.81) + "
                + Zeta_pov.ToString() + " * \n8 / (pi^2 * " + d_vs.ToString() + "^4 * 9.81) + " + Zeta_otkr.ToString()
                + " * 8 / (pi^2 * " + d_n.ToString() + "^4 * 9.81) + 2 * " + Zeta_pov.ToString() + " * \n8 / (pi^2 * " + d_n.ToString() + "^4 * 9.81) + "
                + Lyambda.ToString() + " * " + l_n.ToString() + " / " + d_n.ToString() + " * 8 / (pi^2 * " + d_n.ToString() + "^4 * 9.81))"
                + "\n\nH c = " + Math.Round(H_c1, 3).ToString() + " + Q^2 * " + Math.Round(H_c2, 3).ToString();
                
            Cursor.Current = Cursors.Default;
            graphButton.Enabled = true;

            // Расчёт d
            double H2;
            double Q2;
            try
            {
            H2 = double.Parse(H2_TextBox.Text);
            Q2 = double.Parse(Q2_TextBox.Text);
            if (H2 == 0 || Q2 == 0 || H2 > 50 || Q2 > 50)
                throw new Exception();
            
            // Значения, которые можно рассчитать
            double temp_vs = (H2 - H_c1) / Math.Pow(Q2 * Math.Pow(10, -3), 2) - Lyambda * H_temp_vs * (l_vs / d_vs) - Zeta_C * H_temp_vs -
                Zeta_pov * H_temp_vs;

            Cursor.Current = Cursors.WaitCursor;
            double temp_n = 0;
            double temp_nt;
            double counter = 0.003;
            bool fail = false;
            while (Math.Abs(temp_vs - temp_n) > 0.01)
            {
                if ((temp_vs - temp_n > 100) && (counter > 0.0032))
                {
                    MessageBox.Show("Не найдено!");
                    fail = true;
                    break;
                }
                counter += 0.000000001;
                counter = Math.Round(counter, 9);
                temp_nt = Math.Round(8 / (pi * pi * Math.Pow(counter, 4) * g), 9);
                temp_n = Math.Round((temp_nt * (Lyambda * l_n / counter)) + Zeta_otkr * temp_nt + 2 * Zeta_pov * temp_nt, 9);
            }
            if (!fail)
                d_Label.Text = "d ≈ " + counter.ToString();
            Cursor.Current = Cursors.Default;
            }
            catch (Exception) { MessageBox.Show("Ошибка! Вводите числа!"); }

            graphWork();
            double Q1 = vector[0];
            double H1 = vector[1];

            double Q_н = Q1 * (alpha / 100 + 1);
            Q1Box.Text = Q_н.ToString();

            H31 = new double[2];
            H32 = new double[2];
            H31[0] = Q_н;
            H31[1] = 0;

            H32[0] = Q_н;
            H32[1] = H_c1 + Math.Pow(Q_н * Math.Pow(10, -3), 2) * H_c2;
        }
        

        private int getInt(string column)
        {
            int outInt;
            dbConnection.Open();
            string commandString = "SELECT " + column + " FROM [NasosiTable] WHERE Num = " + variantBox.Text;
            using (SQLiteCommand comExec = new SQLiteCommand(commandString, dbConnection))
            {
                using (SQLiteDataReader reader = comExec.ExecuteReader())
                {
                    reader.Read();
                    outInt = int.Parse(reader[0].ToString());
                }
            }
            dbConnection.Close();
            return outInt;
        }
        private double getDouble(string column)
        {
            double outDouble;
            dbConnection.Open();
            string commandString = "SELECT " + column + " FROM [NasosiTable] WHERE Num = " + variantBox.Text;
            using (SQLiteCommand comExec = new SQLiteCommand(commandString, dbConnection))
            {
                using (SQLiteDataReader reader = comExec.ExecuteReader())
                {
                    reader.Read();
                    outDouble = double.Parse(reader[0].ToString());
                }
            }
            dbConnection.Close();
            return outDouble;
        }

        List<int> ListOfQ;
        List<double> ListOfH, ListOfn, ListOfHc;
        double[] vector, vector2;

        double[] H31, H32;
        private void graphWork()
        {
            ListOfQ = new List<int> { 0, 5, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35 };
            ListOfH = new List<double> { 55, 54.5, 53, 52.6, 52.05, 51.45, 50.7, 50, 49.2, 48.4, 47.4, 46.3, 45, 43.45, 41.65, 39.65, 37.5,
                35, 32.2, 29.15, 25.9, 22.4, 19, 15.35, 11.6, 7.65, 3.95, 0 };
            ListOfn = new List<double> { 0, 20, 35, 37.6, 40.25, 42.75, 45, 47, 48.75, 50.25, 51.65, 52.9, 54.1, 55.15, 55.9, 56.2, 55.6, 54,
                51, 47, 42.25, 36.8, 31, 24.8, 18.85, 12.5, 6.35, 0 };
            ListOfHc = new List<double>();
            foreach (int i in ListOfQ)
                ListOfHc.Add(H_c1 + Math.Pow(i * Math.Pow(10, -3), 2) * H_c2);

            // Расчёт точки пересечения
            int maxIndex = 0, max2Index = 0;
            double max = ListOfH.Max(), max2 = ListOfH.Max();

            for (int i = 0; i < ListOfH.Count; i++)
            {
                double temp = Math.Abs(ListOfH[i] - ListOfHc[i]);
                if (temp < max)
                {
                    max = temp;
                    maxIndex = i;
                }
                else
                {
                    if (temp < max2)
                    {
                        max2 = temp;
                        max2Index = i;
                    }
                }
            }

            double y1_H = ListOfH[maxIndex], y2_H = ListOfH[max2Index];
            double x1_H = ListOfQ[maxIndex], x2_H = ListOfQ[max2Index];
            double x_H = Math.Round(y1_H - y2_H, 10);
            double y_H = x2_H - x1_H;
            double C_H = -(x1_H * y2_H - x2_H * y1_H);

            double y1_Hc = ListOfHc[maxIndex], y2_Hc = ListOfHc[max2Index];
            double x1_Hc = ListOfQ[maxIndex], x2_Hc = ListOfQ[max2Index];
            double x_Hc = Math.Round(y1_Hc - y2_Hc, 10);
            double y_Hc = x2_Hc - x1_Hc;
            double C_Hc = -(x1_Hc * y2_Hc - x2_Hc * y1_Hc);

            double[,] matrix = new double[2, 2];
            matrix[0, 0] = x_H; matrix[0, 1] = y_H;
            matrix[1, 0] = x_Hc; matrix[1, 1] = y_Hc;
            vector = new double[2];
            vector[0] = C_H; vector[1] = C_Hc;

            LinearSystem system = new LinearSystem(matrix, vector);
            vector = system.XVector;

            double y1_p = vector[1], y2_p = Math.Max(ListOfn[maxIndex], ListOfn[max2Index]);
            double x1_p = vector[0], x2_p = x1_p;
            double x_p = Math.Round(y1_p - y2_p, 10);
            double y_p = 0;
            double C_p = -(x1_p * y2_p - x2_p * y1_p);

            double y1_n = ListOfn[maxIndex], y2_n = ListOfn[max2Index];
            double x1_n = ListOfQ[maxIndex], x2_n = ListOfQ[max2Index];
            double x_n = Math.Round(y1_n - y2_n, 10);
            double y_n = x2_n - x1_n;
            double C_n = -(x1_n * y2_n - x2_n * y1_n);

            double[,] matrix2 = new double[2, 2];
            matrix2[0, 0] = x_p; matrix2[0, 1] = y_p;
            matrix2[1, 0] = x_n; matrix2[1, 1] = y_n;
            vector2 = new double[2];
            vector2[0] = C_p; vector2[1] = C_n;

            LinearSystem system2 = new LinearSystem(matrix2, vector2);
            vector2 = system2.XVector;

        }
        private void graphButton_Click(object sender, EventArgs e)
        {
            Form grafik = new Grafik(ListOfQ, ListOfH, ListOfn, ListOfHc, vector, vector2, H31, H32);
            grafik.Text = "Вариант " + variantBox.SelectedItem.ToString();
            grafik.Show();
        }

        private void variantBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            graphButton.Enabled = false;
            d_Label.Text = "d ≈";
            H_cLabel.Text = "H c =";
        }
    }
}