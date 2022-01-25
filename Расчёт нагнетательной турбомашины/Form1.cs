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
        private readonly string dbName = string.Format("Data Source={0}", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Nasosi.db"));
        SQLiteConnection dbConnection = new SQLiteConnection();
        private readonly SQLiteCommand dbCommand = new SQLiteCommand();
        private const double g = 9.81;
        private const double pi = Math.PI;

        readonly Dictionary<string, List<int>> intLists = new Dictionary<string, List<int>>();
        readonly Dictionary<string, List<double>> doubleLists = new Dictionary<string, List<double>>();
        readonly Dictionary<string, double[]> doubleArrays = new Dictionary<string, double[]>();

        readonly List<int> ListOfQ = new List<int>
        { 0, 5, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35 };

        readonly List<int> ListOfQ_long = new List<int> 
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 
            29, 30, 31, 32, 33, 34, 35 };

        readonly List<double> ListOfH = new List<double> 
        { 55, 54.5, 53, 52.6, 52.05, 51.45, 50.7, 50, 49.2, 48.4, 47.4, 46.3, 45, 43.45, 41.65, 39.65, 37.5,
                35, 32.2, 29.15, 25.9, 22.4, 19, 15.35, 11.6, 7.65, 3.95, 0 };

        readonly List<double> ListOfnu = new List<double> 
        { 0, 20, 35, 37.6, 40.25, 42.75, 45, 47, 48.75, 50.25, 51.65, 52.9, 54.1, 55.15, 55.9, 56.2, 55.6, 54,
                51, 47, 42.25, 36.8, 31, 24.8, 18.85, 12.5, 6.35, 0 };


        public Form1()
        {
            InitializeComponent();
            variantBox.SelectedIndex = 30;
            intLists["ListOfQ"] = ListOfQ;
            intLists["ListOfQ_long"] = ListOfQ_long;

            doubleLists["ListOfH"] = ListOfH;
            doubleLists["ListOfnu"] = ListOfnu;

            tabControl.SelectedIndex = 12;
        }

        private void culcButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            double H2;
            double Q2;
            double n;
            int alpha;
            double KPD;
            double pNas;
            try
            {
                n = double.Parse(nBox.Text);
                H2 = double.Parse(H2_TextBox.Text);
                Q2 = double.Parse(Q2_TextBox.Text);
                alpha = int.Parse(alphaBox.Text);
                KPD = double.Parse(KPDBox.Text);
                pNas = double.Parse(pNasBox.Text);
                if (H2 == 0 || Q2 == 0 || H2 > 50 || Q2 > 50 || n == 0 || KPD == 0 || pNas == 0)
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


            List<double> ListOfHc = new List<double>();
            foreach (int i in ListOfQ_long)
                ListOfHc.Add(H_c1 + Math.Pow(i * Math.Pow(10, -3), 2) * H_c2);
            doubleLists["ListOfHc"] = ListOfHc;

            List<double[]> H_Hc_crossPoint_list = getCrossingListsPoint(ListOfH, ListOfHc, true);
            double[] H_Hc_crossPoint = H_Hc_crossPoint_list[0];
            double[] H_Hc_nu_point = H_Hc_crossPoint_list[1];
            doubleArrays["H_Hc_crossPoint"] = H_Hc_crossPoint;
            doubleArrays["H_Hc_nu_point"] = H_Hc_nu_point;

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
            //double temp_vs = (H2 - H_c1) / Math.Pow(Q2 * Math.Pow(10, -3), 2) - Lyambda * H_temp_vs * (l_vs / d_vs) - Zeta_C * H_temp_vs -
            //Zeta_pov * H_temp_vs;

            //Cursor.Current = Cursors.WaitCursor;
            //double temp_n = 0;
            //double temp_nt;
            //double counter = 0.003;
            //bool fail = false;
            //while (Math.Abs(temp_vs - temp_n) > 0.01)
            //{
            //    if ((temp_vs - temp_n > 100) && (counter > 0.0032))
            //    {
            //        MessageBox.Show("Не найдено!");
            //        fail = true;
            //        break;
            //    }
            //    counter += 0.000000001;
            //    counter = Math.Round(counter, 9);
            //    temp_nt = Math.Round(8 / (pi * pi * Math.Pow(counter, 4) * g), 9);
            //    temp_n = Math.Round((temp_nt * (Lyambda * l_n / counter)) + Zeta_otkr * temp_nt + 2 * Zeta_pov * temp_nt, 9);
            //}
            //if (!fail)
            //    d_Label.Text = "d ≈ " + counter.ToString();
            //Cursor.Current = Cursors.Default;
            #endregion

            #region Пункт 3
            double Q3 = Q1 * ((double)alpha / 100 + 1);
            Q3Box.Text = Q3.ToString();

            double[] H31 = new double[2];
            double[] H32 = new double[2];
            H31[0] = Q3;
            H31[1] = 0;

            H32[0] = Q3;
            H32[1] = H_c1 + Math.Pow(Q3 * Math.Pow(10, -3), 2) * H_c2;

            doubleArrays["H31"] = H31;
            doubleArrays["H32"] = H32;

            double H3 = H32[1];
            H3Box.Text = H3.ToString();

            double H3pod_ = H3 / Math.Pow(Q3, 2);
            List<double> ListOfH3pod = new List<double>();
            foreach (int i in ListOfQ_long)
                ListOfH3pod.Add(H3pod_ * Math.Pow(i, 2));
            doubleLists["ListOfH3pod"] = ListOfH3pod;

            List<double[]> H_H3pod_crossPoint_list = getCrossingListsPoint(ListOfH, ListOfH3pod, true);
            double[] H_H3pod_crossPoint = H_H3pod_crossPoint_list[0];
            double[] H_H3pod_nu_point = H_H3pod_crossPoint_list[1];
            doubleArrays["H_H3pod_crossPoint"] = H_H3pod_crossPoint;
            doubleArrays["H_H3pod_nu_point"] = H_H3pod_nu_point;

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
            List<double> ListOfHc_ = new List<double>();
            double H_c2_ = Lyambda * (l_vs / d_vs) * H_temp_vs + Zeta_C * H_temp_vs + Zeta_pov * H_temp_vs + Lyambda * (l_n / d_n) * H_temp_n + Zeta_kr * H_temp_n + 2 * Zeta_pov * H_temp_n;
            foreach (int i in ListOfQ_long)
                ListOfHc_.Add(H_c1 + Math.Pow(i * Math.Pow(10, -3), 2) * H_c2_);
            doubleLists["ListOfHc_"] = ListOfHc_;

            List<double[]> H_Hc__crossPoint_list = getCrossingListsPoint(ListOfH, ListOfHc_, true);
            double[] H_Hc__crossPoint = H_Hc__crossPoint_list[0];
            double[] H_Hc__nu_point = H_Hc__crossPoint_list[1];
            doubleArrays["H_Hc__crossPoint"] = H_Hc__crossPoint;
            doubleArrays["H_Hc__nu_point"] = H_Hc__nu_point;

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

            #region Пункт 5
            double Q5 = Q4;
            double[] H51 = new double[2];
            double[] H52 = new double[2];
            H51[0] = Q5;
            H51[1] = 0;

            H52[0] = Q5;
            H52[1] = H_c1 + Math.Pow(Q5 * Math.Pow(10, -3), 2) * H_c2;

            doubleArrays["H51"] = H51;
            doubleArrays["H52"] = H52;

            double H5 = H52[1];

            double H5pod_ = H5 / Math.Pow(Q5, 2);
            List<double> ListOfH5pod = new List<double>();
            foreach (int i in ListOfQ_long)
                ListOfH5pod.Add(H5pod_ * Math.Pow(i, 2));
            doubleLists["ListOfH5pod"] = ListOfH5pod;

            List<double[]> H_H5pod_crossPoint_list = getCrossingListsPoint(ListOfH, ListOfH5pod, true);
            double[] H_H5pod_crossPoint = H_H5pod_crossPoint_list[0];
            double[] H_H5pod_nu_point = H_H5pod_crossPoint_list[1];
            doubleArrays["H_H5pod_crossPoint"] = H_H5pod_crossPoint;
            doubleArrays["H_H5pod_nu_point"] = H_H5pod_nu_point;

            double n5 = Math.Round(n * (Q5 / H_H5pod_crossPoint[0]));
            double nu5 = H_H5pod_nu_point[1];
            double Nn5 = p * g * H5 * Q5 * 0.000001;
            double N5 = Nn5 / nu5 * 100;

            H5Box.Text = H5.ToString();
            Q5Box.Text = Q5.ToString();
            n_5Box.Text = n5.ToString();
            nu5Box.Text = nu5.ToString();
            Nn5Box.Text = Nn5.ToString();
            N5Box.Text = N5.ToString();
            #endregion

            #region Пункт 6
            double n6 = n * (1 - (double)alpha / 100);
            Tuple<double, double> firstPoint = null;
            Tuple<double, double> secondPoint = null;

            for (int i = 0; i < ListOfnu.Count; i++)
            {
                double prevPoint = -1;
                double curPoint = ListOfnu[i];
                if (i != 0)
                    prevPoint = ListOfnu[i - 1];

                if (firstPoint == null)
                {
                    if (curPoint >= KPD)
                    {
                        if (prevPoint == -1)
                        {
                            MessageBox.Show("Значение КПД слишком низкое", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        firstPoint = Tuple.Create(prevPoint, curPoint);
                    }
                }
                else if (curPoint <= KPD)
                {
                    secondPoint = Tuple.Create(curPoint, prevPoint);
                    break;
                }
            }

            List<double[]> KPD_1crossPoint_list = getCrossingListsPoint(
                new List<double>() { firstPoint.Item1, firstPoint.Item2 },
                new List<double>() { KPD, KPD },
                false,
                ListOfnu,
                ListOfH);
            double[] KPD_H_1crossPoint = KPD_1crossPoint_list[1];
            doubleArrays["KPD_1crossPoint"] = KPD_1crossPoint_list[0];
            doubleArrays["KPD_H_1crossPoint"] = KPD_H_1crossPoint;

            List<double[]> KPD_2crossPoint_list = getCrossingListsPoint(
                new List<double>() { secondPoint.Item1, secondPoint.Item2 },
                new List<double>() { KPD, KPD },
                false,
                ListOfnu,
                ListOfH);
            double[] KPD_H_2crossPoint = KPD_2crossPoint_list[1];
            doubleArrays["KPD_2crossPoint"] = KPD_2crossPoint_list[0];
            doubleArrays["KPD_H_2crossPoint"] = KPD_H_2crossPoint;

            double HA = KPD_H_1crossPoint[1];
            double QA = KPD_H_1crossPoint[0];
            double HApod = HA / Math.Pow(QA, 2);
            List<double> ListOfHApod = new List<double>();
            foreach (int i in ListOfQ_long)
                ListOfHApod.Add(Math.Pow(i, 2) * HApod);
            doubleLists["ListOfHApod"] = ListOfHApod;

            double HB = KPD_H_2crossPoint[1];
            double QB = KPD_H_2crossPoint[0];
            double HBpod = HB / Math.Pow(QB, 2);
            List<double> ListOfHBpod = new List<double>();
            foreach (int i in ListOfQ_long)
                ListOfHBpod.Add(Math.Pow(i, 2) * HBpod);
            doubleLists["ListOfHBpod"] = ListOfHBpod;

            double Q6 = QA * n6 / n;
            double Q6_ = QB * n6 / n;
            double H6 = HA * Math.Pow(Q6 / QA, 2);
            double H6_ = HB * Math.Pow(Q6_ / QB, 2);
            doubleArrays["point6"] = new double[] { Q6, H6 };
            doubleArrays["point6_"] = new double[] { Q6_, H6_ };

            Q6Box.Text = Q6.ToString();
            Q6_Box.Text = Q6_.ToString();
            H6Box.Text = H6.ToString();
            H6_Box.Text = H6_.ToString();
            #endregion

            #region Пункт 7
            double H7 = ListOfnu.Max();
            int nuMaxIndex = ListOfnu.IndexOf(H7);
            int Q7 = ListOfQ[nuMaxIndex];
            doubleArrays["H7Point"] = new double[] { Q7, H7 };
            doubleArrays["H7_Point"] = new double[] { Q7, ListOfH[nuMaxIndex] };

            double Hct = ListOfH[nuMaxIndex] - H_c2 * 0.000001 * Math.Pow(Q7, 2);
            double hvs_hn = Hct - p_2 / (p * g);
            List<double> ListOfH_c = new List<double>();
            foreach (int i in ListOfQ_long)
                ListOfH_c.Add(Hct + Math.Pow(i * Math.Pow(10, -3), 2) * H_c2);
            doubleLists["ListOfH_c"] = ListOfH_c;

            hvs_hnBox.Text = hvs_hn.ToString();
            #endregion

            #region Пункт 8
            double H8 = ListOfH[nuMaxIndex];
            int Q8 = Q7;
            double H8pod = H8 / Math.Pow(Q8, 2);
            doubleArrays["H8Point"] = new double[] { Q8, ListOfnu.Max() };
            doubleArrays["H8_Point"] = new double[] { Q8, H8 };

            List<double> ListOfH8pod = new List<double>();
            foreach (int i in ListOfQ_long)
                ListOfH8pod.Add(Math.Pow(i, 2) * H8pod);
            doubleLists["ListOfH8pod"] = ListOfH8pod;

            List<double[]> Hc_H8pod_crossPoint_list = getCrossingListsPoint(ListOfHc, ListOfH8pod, false, ListOfHc, null);
            double[] Hc_H8pod_crossPoint = Hc_H8pod_crossPoint_list[0];
            doubleArrays["Hc_H8pod_crossPoint"] = Hc_H8pod_crossPoint;

            double n8_ = Math.Round(n * Hc_H8pod_crossPoint[0] / Q8);
            n8_Box.Text = n8_.ToString();
            #endregion

            #region Пункт 9
            double ns = Math.Round(3.65 * n * Math.Sqrt(Q2 * 0.001) / Math.Pow(Math.Pow(H2, 3), 1.0 / 4), 1);

            nsBox.Text = ns.ToString();
            #endregion

            #region Пункт 10
            // Расчёт экономических параметров
            const double alphaV = 0.68;
            double nuV = 1 / (1 + alphaV * Math.Pow(ns, -0.66));
            double D1n = 4.25 * Math.Pow(Q2 * 0.001 / n, 1 / 3.0);
            double nuGidr = 1 - (0.42 / Math.Pow(Math.Log(D1n) - 0.172, 2));
            double nuMech = 0.93;
            double nu = nuV * nuGidr * nuMech;
            double N = p * g * Q2 * 0.000001 * H2 / nu;
            double Mkr = N * 30 * 1000 / (pi * n);

            nuVBox.Text = nuV.ToString();
            D1nBox.Text = D1n.ToString();
            nuGidrBox.Text = nuGidr.ToString();
            nuBox.Text = nu.ToString();
            N_Box.Text = N.ToString();
            MkrBox.Text = Mkr.ToString();

            // Расчёт кинематических и геометрических параметров
            double tdop = 150;
            double dv = Math.Pow(Mkr / (0.2 * tdop * g * 10000), 1 / 3.0);
            double dst = 1.3 * dv;
            double D0 = Math.Sqrt(Math.Pow(D1n, 2) + Math.Pow(dst, 2)) * 1000;
            double D1 = (D0 + 20) / 1000;
            double lst = 1.4 * dst;
            double u1 = pi * D1 * n / 60;
            double c0 = 4 * Q2 * 0.001 / (nuV * pi * (Math.Pow(D1, 2) - Math.Pow(dst, 2)));
            double c1 = c0;
            double B1 = Math.Atan(c1 / u1) * 180 / pi;
            double i_ = 4;
            double B1l = B1 + i_;
            double uu1 = 0.9;
            double b1 = Q2 * 0.001 / (nuV * pi * D1 * c1 * uu1);
            double B2 = 17;
            double oo = 3;
            double B2l = B2 + oo;
            double u2 = 0.5 * c1 * (Math.Cos(B2l * pi / 180) / Math.Sin(B2l * pi / 180)) + Math.Sqrt(Math.Pow(c1 * (Math.Cos(B2l * pi / 180) / Math.Sin(B2l * pi / 180)) / 2, 2) + g * H2 / nuGidr);
            double D2 = u2 / (pi * (n / 60));
            double m = D2 / D1;
            double b2 = b1 * D1 / D2;
            double z = Math.Round(6.5 * ((m + 1) / (m - 1)) * Math.Sin((B1l + B2l) / 2 * (pi / 180)));

            dvBox.Text = dv.ToString();
            dstBox.Text = dst.ToString();
            D0mBox.Text = (D0 / 1000).ToString();
            D0mmBox.Text = D0.ToString();
            D1mBox.Text = D1.ToString();
            D1mmBox.Text = (D1 * 1000).ToString();
            lstBox.Text = lst.ToString();
            u1Box.Text = u1.ToString();
            c0Box.Text = c0.ToString();
            B1GradBox.Text = B1.ToString();
            B1lBox.Text = B1l.ToString();
            b1Box.Text = b1.ToString();
            B2lBox.Text = B2l.ToString();
            u2Box.Text = u2.ToString();
            D2Box.Text = D2.ToString();
            mBox.Text = m.ToString();
            b2Box.Text = b2.ToString();
            zBox.Text = z.ToString();
            #endregion

            #region Пункт 11
            double Hkav = (p_a * 1000 - pNas) / (p * g);
            double Hkr_vs = Hkav - 10 * Math.Pow(n * Math.Sqrt(Q2 * 0.001) / C, 4 / 3.0);
            double Hdop_vs = Hkr_vs - 0.25 * (Hkav - Hkr_vs);

            HdopvsBox.Text = Hdop_vs.ToString();
            #endregion

            #region Пункт 12
            double Q12 = Q1 / 2;
            Tuple<double, double> tuple = Tuple.Create(
                ListOfnu[ListOfQ.IndexOf((int)Math.Round(Q12))],
                ListOfnu[ListOfQ.IndexOf((int)Math.Round(Q12) + 1)]);
            double Q12_calculating = (tuple.Item1 + tuple.Item2) / 2;
            List<double[]> P12Point_list = getCrossingListsPoint(
                new List<double>() { tuple.Item1, tuple.Item2 },
                new List<double>() { Q12_calculating, Q12_calculating },
                false,
                ListOfnu,
                ListOfH);
            if (Q12 > P12Point_list[0][0])
            {
                while (Q12 > P12Point_list[0][0])
                {
                    Q12_calculating += 0.0001;

                    P12Point_list = getCrossingListsPoint(
                new List<double>() { tuple.Item1, tuple.Item2 },
                new List<double>() { Q12_calculating, Q12_calculating },
                false,
                ListOfnu,
                ListOfH);
                }
            }
            else
            {
                while (Q12 < P12Point_list[0][0])
                {
                    Q12_calculating -= 0.0001;

                    P12Point_list = getCrossingListsPoint(
                new List<double>() { tuple.Item1, tuple.Item2 },
                new List<double>() { Q12_calculating, Q12_calculating },
                false,
                ListOfnu,
                ListOfH);
                }
            }

            double[] P12_HPoint = P12Point_list[1];
            doubleArrays["P12Point"] = P12Point_list[0];
            doubleArrays["P12_HPoint"] = P12_HPoint;

            double H12 = P12_HPoint[1];
            List<double> ListOfP12 = new List<double>();
            double H_c1_P12 = ListOfHc[0];
            double H_c2_P12 = (H12 - H_c1_P12) / Math.Pow(P12_HPoint[0], 2);
            foreach (int i in ListOfQ_long)
                ListOfP12.Add(H_c1_P12 + Math.Pow(i, 2) * H_c2_P12);
            doubleLists["ListOfP12"] = ListOfP12;

            double nu12 = P12Point_list[0][1];
            double Nn12 = p * g * Q12 * H12 * 0.000001;
            double N12 = Nn12 / (nu12 * 0.01);
            N12Box.Text = N12.ToString();

            tuple = Tuple.Create(
                ListOfHc[ListOfQ_long.IndexOf((int)Math.Round(Q12))],
                ListOfHc[ListOfQ_long.IndexOf((int)Math.Round(Q12) + 1)]);
            Q12_calculating = (tuple.Item1 + tuple.Item2) / 2;
            List<double[]> P12_Point_list = getCrossingListsPoint(
                new List<double>() { tuple.Item1, tuple.Item2 },
                new List<double>() { Q12_calculating, Q12_calculating },
                false,
                ListOfHc,
                null,
                ListOfQ_long);

            if (Q12 > P12_Point_list[0][0])
            {
                while (Q12 > P12_Point_list[0][0])
                {
                    Q12_calculating += 0.0001;

                    P12_Point_list = getCrossingListsPoint(
                new List<double>() { tuple.Item1, tuple.Item2 },
                new List<double>() { Q12_calculating, Q12_calculating },
                false,
                ListOfHc,
                null,
                ListOfQ_long);
                }
            }
            else
            {
                while (Q12 < P12_Point_list[0][0])
                {
                    Q12_calculating -= 0.0001;

                    P12_Point_list = getCrossingListsPoint(
                new List<double>() { tuple.Item1, tuple.Item2 },
                new List<double>() { Q12_calculating, Q12_calculating },
                false,
                ListOfHc,
                null,
                ListOfQ_long);
                }
            }

            double[] P12_ = P12_Point_list[0];
            double H12_ = P12_[1];
            doubleArrays["P12_Point"] = P12_;

            double H_12_pod = H12_ / Math.Pow(Q12, 2);
            List<double> ListOfP12_ = new List<double>();
            foreach (int i in ListOfQ_long)
                ListOfP12_.Add(Math.Pow(i, 2) * H_12_pod);
            doubleLists["ListOfP12_"] = ListOfP12_;

            List<double[]> P12__HcrossPoint_list = getCrossingListsPoint(
                ListOfH,
                ListOfP12_,
                true);
            double[] DPoint = P12__HcrossPoint_list[0];
            doubleArrays["DPoint"] = DPoint;
            double[] D_Point = P12__HcrossPoint_list[1];
            doubleArrays["D_Point"] = D_Point;
            double nu12_ = D_Point[1];
            double Nn12_ = p * g * Q12 * H12_ * 0.000001;
            double N12_ = Nn12_ / (nu12_ * 0.01);
            N12_Box.Text = N12_.ToString();
            #endregion

            #region Пункт 13
            List<int> ListOfQ_longer = new List<int>(ListOfQ_long);
            for (int i = ListOfQ_long.Count; i < ListOfQ_long.Count + 30; i++)
                ListOfQ_longer.Add(i);
            intLists["ListOfQ_longer"] = ListOfQ_longer;
            List<double> ListOfHc_long = new List<double>();
            foreach (int i in ListOfQ_longer)
                ListOfHc_long.Add(H_c1 + Math.Pow(i * Math.Pow(10, -3), 2) * H_c2);
            doubleLists["ListOfHc_long"] = ListOfHc_long;

            double Q13 = Q1 * 1.2;
            tuple = Tuple.Create(
                ListOfHc_long[ListOfQ_longer.IndexOf((int)Math.Round(Q13))],
                ListOfHc_long[ListOfQ_longer.IndexOf((int)Math.Round(Q13) + 1)]);
            double Q13_calculating = (tuple.Item1 + tuple.Item2) / 2;
            List<double[]> P13Point_list = getCrossingListsPoint(
                new List<double>() { tuple.Item1, tuple.Item2 },
                new List<double>() { Q13_calculating, Q13_calculating },
                false,
                ListOfHc_long,
                null,
                ListOfQ_longer);
            if (Q13 > P13Point_list[0][0])
            {
                while (Q13 > P13Point_list[0][0])
                {
                    Q13 += 0.0001;

                    P13Point_list = getCrossingListsPoint(
                new List<double>() { tuple.Item1, tuple.Item2 },
                new List<double>() { Q13_calculating, Q13_calculating },
                false,
                ListOfHc_long,
                null,
                ListOfQ_longer);
                }
            }
            else
            {
                while (Q13 < P13Point_list[0][0])
                {
                    Q13_calculating -= 0.0001;

                    P13Point_list = getCrossingListsPoint(
                new List<double>() { tuple.Item1, tuple.Item2 },
                new List<double>() { Q13_calculating, Q13_calculating },
                false,
                ListOfHc_long,
                null,
                ListOfQ_longer);
                }
            }

            double[] P13Point = P13Point_list[0];
            doubleArrays["P13Point"] = P13Point;
            double H13 = P13Point[1];
            double H13pod = H13 / Math.Pow(Q13, 2);
            List<double> ListOfH13pod = new List<double>();
            foreach (int i in ListOfQ_longer)
                ListOfH13pod.Add(Math.Pow(i, 2) * H13pod);
            doubleLists["ListOfH13pod"] = ListOfH13pod;

            List<double[]> P13_HcrossPoint_list = getCrossingListsPoint(
                ListOfH,
                ListOfH13pod,
                true);
            double Q13_ = P13_HcrossPoint_list[0][0];
            double H13_ = P13_HcrossPoint_list[0][1];
            doubleArrays["P13_HPoint"] = new double[] { Q13_, H13_ };
            double n13 = n * Q13 / Q13_;
            double n_n13 = n13 / n;

            n_n13Box.Text = n_n13.ToString();
            #endregion

        }

        private List<double[]> getCrossingListsPoint(List<double> smallList, List<double> list, bool longList)
        {
            return getCrossingListsPoint(smallList, list, longList, null, ListOfnu, null);
        }

        private List<double[]> getCrossingListsPoint(List<double> smallList, List<double> list, bool longList, List<double> crossLinesList, List<double> insteadOfNuList)
        {
            return getCrossingListsPoint(smallList, list, longList, crossLinesList, insteadOfNuList, null);
        }

        private List<double[]> getCrossingListsPoint(List<double> smallList, List<double> list, bool longList, List<double> crossLinesList, List<double> insteadOfNuList, List<int> insteadOfQlist)
        {
            // Расчёт точки пересечения
            int maxIndex = 0, max2Index = 0;
            double max = smallList.Max(), max2 = smallList.Max();
            int longInt = 0;
            if (longList)
                longInt = 8;
            int j = 0;
            if (longList)
                j = 2;

            for (int i = j; i < smallList.Count; i++)
            {
                double temp = Math.Abs(smallList[i] - list[i + longInt]);
                if (temp < max)
                {
                    max = temp;
                    maxIndex = i;
                }
                else
                {
                    if ((temp < max2) && (Math.Abs(maxIndex - i) == 1))
                    {
                        max2 = temp;
                        max2Index = i;
                    }
                }
            }

            int q1Index = maxIndex;
            int q2Index = max2Index;
            if (crossLinesList != null)
            {
                q1Index = crossLinesList.IndexOf(smallList[maxIndex]);
                q2Index = crossLinesList.IndexOf(smallList[max2Index]);
                if ((smallList.Count == list.Count) && smallList.Count > ListOfQ.Count)
                {
                    q1Index -= 8;
                    q2Index -= 8;
                }
            }

            if (insteadOfQlist == null)
                insteadOfQlist = ListOfQ;

            double y1_H = smallList[maxIndex], y2_H = smallList[max2Index];
            double x1_H = insteadOfQlist[q1Index], x2_H = insteadOfQlist[q2Index];
            double x_H = y1_H - y2_H;
            double y_H = x2_H - x1_H;
            double C_H = -(x1_H * y2_H - x2_H * y1_H);

            double y1_Hc = list[maxIndex + longInt], y2_Hc = list[max2Index + longInt];
            double x1_Hc = insteadOfQlist[q1Index], x2_Hc = insteadOfQlist[q2Index];
            double x_Hc = y1_Hc - y2_Hc;
            double y_Hc = x2_Hc - x1_Hc;
            double C_Hc = -(x1_Hc * y2_Hc - x2_Hc * y1_Hc);

            double[,] matrix = new double[2, 2];
            matrix[0, 0] = x_H; matrix[0, 1] = y_H;
            matrix[1, 0] = x_Hc; matrix[1, 1] = y_Hc;
            double[] vector = new double[2];
            vector[0] = C_H; vector[1] = C_Hc;

            LinearSystem system = new LinearSystem(matrix, vector);
            vector = system.XVector;

            if (insteadOfNuList != null)
            {
                int nu1Index = q1Index;
                int nu2Index = q2Index;
                if (insteadOfNuList.Count > ListOfnu.Count)
                {
                    nu1Index += 8;
                    nu2Index += 8;
                }
                    
                double y1_p = vector[1], y2_p = Math.Max(insteadOfNuList[nu1Index], insteadOfNuList[nu2Index]);
                double x1_p = vector[0], x2_p = x1_p;
                double x_p = y1_p - y2_p;
                double y_p = 0;
                double C_p = -(x1_p * y2_p - x2_p * y1_p);

                double y1_n = insteadOfNuList[nu1Index], y2_n = insteadOfNuList[nu2Index];
                double x1_n = insteadOfQlist[q1Index], x2_n = insteadOfQlist[q2Index];
                double x_n = y1_n - y2_n;
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
            return new List<double[]> { vector };
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
                intLists,
                doubleLists,
                doubleArrays);
            grafik.Text = "Вариант " + variantBox.SelectedItem + ", пункт " + (tabControl.SelectedIndex + 1);
            grafik.Show();
        }

        private void variantBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            graphButton.Enabled = false;
            d_Label.Text = "d ≈";
            H_cLabel.Text = "H c =";
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //if (tabControl.SelectedIndex == 9)
            //{
            //    Width = 690;
            //    Height = 677;

            //    tabControl.Width = 655;
            //    tabControl.Height = 259;

            //    culcButton.Width = 321;
            //    culcButton.Height = 131;
            //    culcButton.Location = new Point(9, 498);

            //    graphButton.Width = 321;
            //    graphButton.Height = 131;
            //    graphButton.Location = new Point(341, 498);
            //}
            //else
            //{
            //    Width = 564;
            //    Height = 550;

            //    tabControl.Width = 530;
            //    tabControl.Height = 181;

            //    culcButton.Width = 259;
            //    culcButton.Height = 82;
            //    culcButton.Location = new Point(9, 420);

            //    graphButton.Width = 259;
            //    graphButton.Height = 82;
            //    graphButton.Location = new Point(278, 420);
            //}
        }
    }
}