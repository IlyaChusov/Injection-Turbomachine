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
            variantBox.SelectedIndex = 30;
            // H = −0.06766x^2 + 0.90276x + 52.44933
            // КПД = −0.00363x^3 + 0.01554x^2 + 3.96383x − 1.98288
        }

        private readonly string dbName = string.Format("Data Source={0}", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Nasosi.db"));
        SQLiteConnection dbConnection = new SQLiteConnection();
        private readonly SQLiteCommand dbCommand = new SQLiteCommand();
        private const double g = 9.81;
        private const double pi = Math.PI;

        List<int> ListOfQ = new List<int> 
        { 0, 5, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35 };
        
        List<int> ListOfQ_long = new List<int> 
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 
            29, 30, 31, 32, 33, 34, 35 };
        
        List<double> ListOfH = new List<double> 
        { 55, 54.5, 53, 52.6, 52.05, 51.45, 50.7, 50, 49.2, 48.4, 47.4, 46.3, 45, 43.45, 41.65, 39.65, 37.5,
                35, 32.2, 29.15, 25.9, 22.4, 19, 15.35, 11.6, 7.65, 3.95, 0 };
        
        List<double> ListOfnu = new List<double> 
        { 0, 20, 35, 37.6, 40.25, 42.75, 45, 47, 48.75, 50.25, 51.65, 52.9, 54.1, 55.15, 55.9, 56.2, 55.6, 54,
                51, 47, 42.25, 36.8, 31, 24.8, 18.85, 12.5, 6.35, 0 };
        
        List<double> ListOfHc, ListOfH3pod, ListOfHc_;
        double[] H_Hc_crossPoint, H_Hc_nu_point, H_H3pod_crossPoint, H_H3pod_nu_point, H_Hc__crossPoint, H_Hc__nu_point;
        double[] H31, H32;

        private void culcButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            double H2 = -1;
            double Q2 = -1;
            double n = -1;
            int alpha = -1;
            try
            {
                n = double.Parse(nBox.Text);
                H2 = double.Parse(H2_TextBox.Text);
                Q2 = double.Parse(Q2_TextBox.Text);
                alpha = int.Parse(alphaBox.Text);
                if (H2 == 0 || Q2 == 0 || H2 > 50 || Q2 > 50 || n == 0)
                    throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка! Вводите числа!");
                return;
            }

            dbConnection = new SQLiteConnection(dbName + ";Version=3;");
            dbCommand.Connection = dbConnection;
            
            double d_vs = getDouble("d_vs") / 1000;
            double d_n = getDouble("d_n") / 1000;
            int l_vs = getInt("l_vs");
            int l_n = getInt("l_n");
            double h_vs = getDouble("h_vs");
            double h_n = getDouble("h_n");
            double Lyambda = getDouble("Lyambda");
            int Zeta_C = getInt("Zeta_C");
            double Zeta_pov = getDouble("Zeta_pov");
            int Zeta_otkr = getInt("Zeta_otkr");
            int Zeta_kr = getInt("Zeta_kr");
            int C = getInt("C");
            double p_a = getDouble("p_a");
            int p_2 = getInt("p_2") * 1000;
            int p = getInt("p");
            int t0_C = getInt("t0C");
            int a = getInt("a");


            double H_c1 = h_vs + h_n + (p_2 / (p * g));
            double H_temp_vs = 8 / (pi * pi * Math.Pow(d_vs, 4) * g);
            double H_temp_n = 8 / (pi * pi * Math.Pow(d_n, 4) * g);
            double H_c2 = Lyambda * (l_vs / d_vs) * H_temp_vs + Zeta_C * H_temp_vs + Zeta_pov * H_temp_vs + Lyambda * (l_n / d_n) * H_temp_n + Zeta_otkr * H_temp_n + 2 * Zeta_pov * H_temp_n;
            
            H_cLabel.Text = "H c = (" + h_vs.ToString() + " + " + h_n.ToString() + " + (" + p_2.ToString() + " *10^3) / (" + p.ToString()
                + " * " + g.ToString() + ")) + Q^2 * (" + Zeta_C.ToString() + " * \n8 / (pi^2 * " + d_vs.ToString() + "^4 * 9.81) + "
                + Lyambda.ToString() + " * " + l_vs.ToString() + " / " + d_vs.ToString() + " * \n8 / (pi^2 * " + d_vs.ToString() + "^4 * 9.81) + "
                + Zeta_pov.ToString() + " * \n8 / (pi^2 * " + d_vs.ToString() + "^4 * 9.81) + " + Zeta_otkr.ToString()
                + " * 8 / (pi^2 * " + d_n.ToString() + "^4 * 9.81) + 2 * " + Zeta_pov.ToString() + " * \n8 / (pi^2 * " + d_n.ToString() + "^4 * 9.81) + "
                + Lyambda.ToString() + " * " + l_n.ToString() + " / " + d_n.ToString() + " * 8 / (pi^2 * " + d_n.ToString() + "^4 * 9.81))"
                + "\n\nH c = " + Math.Round(H_c1, 3).ToString() + " + Q^2 * " + Math.Round(H_c2, 3).ToString();
                
            Cursor.Current = Cursors.Default;
            graphButton.Enabled = true;
            

            ListOfHc = new List<double>();
            ListOfH3pod = new List<double>();

            foreach (int i in ListOfQ_long)
                ListOfHc.Add(H_c1 + Math.Pow(i * Math.Pow(10, -3), 2) * H_c2);

            List<double[]> H_Hc_crossPoint_list = getCrossingLinesPoint(ListOfH, ListOfHc);
            H_Hc_crossPoint = H_Hc_crossPoint_list[0];
            H_Hc_nu_point = H_Hc_crossPoint_list[1];

            #region Пункт 1
            double Q1 = H_Hc_crossPoint[0];
            double H1 = H_Hc_crossPoint[1];
            double nu1 = H_Hc_nu_point[1];
            double Nn1 = p * g * Q1 * 0.000001 * H1;
            double N1 = Nn1 / nu1 * 100;

            Q1Box.Text = Q1.ToString();
            H1Box.Text = H1.ToString();
            nu1Box.Text = nu1.ToString();
            Nn1Box.Text = Nn1.ToString();
            N1Box.Text = N1.ToString();
            #endregion

            #region Пункт 2
            // Расчёт d
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
            #endregion

            #region Пункт 3
            double Q3 = Q1 * ((double) alpha / 100 + 1);
            Q3Box.Text = Q3.ToString();

            H31 = new double[2];
            H32 = new double[2];
            H31[0] = Q3;
            H31[1] = 0;

            H32[0] = Q3;
            H32[1] = H_c1 + Math.Pow(Q3 * Math.Pow(10, -3), 2) * H_c2;

            double H3 = H32[1];
            H3Box.Text = H3.ToString();

            double H3pod_ = H3 / Math.Pow(Q3, 2);
            foreach (int i in ListOfQ_long)
                ListOfH3pod.Add(H3pod_ * Math.Pow(i, 2));

            List<double[]> H_H3pod_crossPoint_list = getCrossingLinesPoint(ListOfH, ListOfH3pod);
            H_H3pod_crossPoint = H_H3pod_crossPoint_list[0];
            H_H3pod_nu_point = H_H3pod_crossPoint_list[1];

            double n3 = Math.Round(n * (Q3 / H_H3pod_crossPoint[0]));
            double nu3 = H_H3pod_nu_point[1];
            double Nn3 = p * g * H3 * Q3 * 0.000001;
            double N3 = Nn3 / nu3 * 100;
            
            n_3Box.Text = n3.ToString();
            nu3Box.Text = nu3.ToString();
            Nn3Box.Text = Nn3.ToString();
            N3Box.Text = N3.ToString();
            #endregion

            #region Пункт 4
            ListOfHc_ = new List<double>();
            double H_c2_ = Lyambda * (l_vs / d_vs) * H_temp_vs + Zeta_C * H_temp_vs + Zeta_pov * H_temp_vs + Lyambda * (l_n / d_n) * H_temp_n + Zeta_kr * H_temp_n + 2 * Zeta_pov * H_temp_n;
            foreach (int i in ListOfQ_long)
                ListOfHc_.Add(H_c1 + Math.Pow(i * Math.Pow(10, -3), 2) * H_c2_);

            List<double[]> H_Hc__crossPoint_list = getCrossingLinesPoint(ListOfH, ListOfHc_);
            H_Hc__crossPoint = H_Hc__crossPoint_list[0];
            H_Hc__nu_point = H_Hc__crossPoint_list[1];

            double Q4 = H_Hc__crossPoint[0];
            double H4 = H_Hc__crossPoint[1];
            double nu4 = H_Hc__nu_point[1];
            double Nn4 = p * g * H4 * Q4 * 0.000001;
            double N4 = Nn4 / nu4 * 100;

            Q4Box.Text = Q4.ToString();
            H4Box.Text = H4.ToString();
            nu4Box.Text = nu4.ToString();
            Nn4Box.Text = Nn4.ToString();
            N4Box.Text = N4.ToString();
            #endregion
        }

        private List<double[]> getCrossingLinesPoint(List<double> smallList, List<double> list)
        {
            // Расчёт точки пересечения
            int maxIndex = 0, max2Index = 0;
            double max = smallList.Max(), max2 = smallList.Max();

            for (int i = 2; i < smallList.Count; i++)
            {
                double temp = Math.Abs(smallList[i] - list[i + 8]);
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

            double y1_H = smallList[maxIndex], y2_H = smallList[max2Index];
            double x1_H = ListOfQ[maxIndex], x2_H = ListOfQ[max2Index];
            double x_H = Math.Round(y1_H - y2_H, 10);
            double y_H = x2_H - x1_H;
            double C_H = -(x1_H * y2_H - x2_H * y1_H);

            double y1_Hc = list[maxIndex + 8], y2_Hc = list[max2Index + 8];
            double x1_Hc = ListOfQ[maxIndex], x2_Hc = ListOfQ[max2Index];
            double x_Hc = Math.Round(y1_Hc - y2_Hc, 10);
            double y_Hc = x2_Hc - x1_Hc;
            double C_Hc = -(x1_Hc * y2_Hc - x2_Hc * y1_Hc);

            double[,] matrix = new double[2, 2];
            matrix[0, 0] = x_H; matrix[0, 1] = y_H;
            matrix[1, 0] = x_Hc; matrix[1, 1] = y_Hc;
            double[] vector = new double[2];
            vector[0] = C_H; vector[1] = C_Hc;

            LinearSystem system = new LinearSystem(matrix, vector);
            vector = system.XVector;

            double y1_p = vector[1], y2_p = Math.Max(ListOfnu[maxIndex], ListOfnu[max2Index]);
            double x1_p = vector[0], x2_p = x1_p;
            double x_p = Math.Round(y1_p - y2_p, 10);
            double y_p = 0;
            double C_p = -(x1_p * y2_p - x2_p * y1_p);

            double y1_n = ListOfnu[maxIndex], y2_n = ListOfnu[max2Index];
            double x1_n = ListOfQ[maxIndex], x2_n = ListOfQ[max2Index];
            double x_n = Math.Round(y1_n - y2_n, 10);
            double y_n = x2_n - x1_n;
            double C_n = -(x1_n * y2_n - x2_n * y1_n);

            double[,] matrix2 = new double[2, 2];
            matrix2[0, 0] = x_p; matrix2[0, 1] = y_p;
            matrix2[1, 0] = x_n; matrix2[1, 1] = y_n;
            double[] vector2 = new double[2];
            vector2[0] = C_p; vector2[1] = C_n;

            LinearSystem system2 = new LinearSystem(matrix2, vector2);
            vector2 = system2.XVector;

            return new List<double[]>
            {
                vector,
                vector2
            };
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

        private void graphButton_Click(object sender, EventArgs e)
        {
            Form grafik = new Grafik(
                tabControl.SelectedIndex + 1, 
                ListOfQ, ListOfQ_long, ListOfH, ListOfnu, 
                ListOfHc, ListOfH3pod, ListOfHc_,
                H_Hc_crossPoint, H_Hc_nu_point,
                H31, H32,
                H_H3pod_crossPoint, H_H3pod_nu_point,
                H_Hc__crossPoint, H_Hc__nu_point);
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