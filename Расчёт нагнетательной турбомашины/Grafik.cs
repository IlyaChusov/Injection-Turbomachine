using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Расчёт_нагнетательной_турбомашины
{
    public partial class Grafik : Form
    {
        public Grafik(
            int mode,
            Dictionary<string, List<int>> intLists,
            Dictionary<string, List<double>> doubleLists,
            Dictionary<string, double[]> doubleArrays)
        {
            InitializeComponent();
            Draw(mode, intLists, doubleLists, doubleArrays);
        }

        private void Draw(int mode,
            Dictionary<string, List<int>> intLists,
            Dictionary<string, List<double>> doubleLists,
            Dictionary<string, double[]> doubleArrays)
        {
            GraphPane MyPane = MyGraph.GraphPane;
            MyGraph.IsShowPointValues = true;
            MyPane.YAxis.Cross = 0.0;
            MyPane.XAxis.Title.IsVisible = false;
            MyPane.YAxis.Title.IsVisible = false;
            MyPane.Title.IsVisible = false;

            List<int> ListOfQ = intLists["ListOfQ"];
            List<int> ListOfQ_long = intLists["ListOfQ_long"];
            List<double> ListOfH = doubleLists["ListOfH"];
            List<double> ListOfnu = doubleLists["ListOfnu"];
            List<double> ListOfHc = doubleLists["ListOfHc"];

            PointPairList HPairList = new PointPairList();
            PointPairList nPairList = new PointPairList();
            PointPairList HcPairList = new PointPairList();
            
            for (int i = 0; i < ListOfQ.Count; i++)
            {
                HPairList.Add(ListOfQ[i], ListOfH[i]);
                nPairList.Add(ListOfQ[i], ListOfnu[i]);
            }
            for (int i = 0; i < ListOfQ_long.Count; i++)
                HcPairList.Add(ListOfQ_long[i], ListOfHc[i]);

            MyPane.AddCurve("H", HPairList, Color.Blue, SymbolType.Plus);
            MyPane.AddCurve("nu", nPairList, Color.Red, SymbolType.Triangle);
            MyPane.AddCurve("Hc", HcPairList, Color.Green, SymbolType.Square);

            switch (mode)
            {
                case 1:
                    PointPairList H_Hc_linePairList = new PointPairList();
                    double[] H_Hc_crossPoint = doubleArrays["H_Hc_crossPoint"];
                    double[] H_Hc_nu_point = doubleArrays["H_Hc_nu_point"];

                    H_Hc_linePairList.Add(H_Hc_crossPoint[0], H_Hc_crossPoint[1]);
                    H_Hc_linePairList.Add(H_Hc_nu_point[0], H_Hc_nu_point[1]);

                    MyPane.AddCurve("", H_Hc_linePairList, Color.Black, SymbolType.Circle);
                    break;
                case 3:
                    PointPairList H3podPairList = new PointPairList();
                    PointPairList Hc_0_linePairList = new PointPairList();
                    PointPairList H_H3pod_nu_linePairList = new PointPairList();
                    List<double> ListOfH3pod = doubleLists["ListOfH3pod"];
                    double[] H31 = doubleArrays["H31"];
                    double[] H32 = doubleArrays["H32"];
                    double[] H_H3pod_crossPoint = doubleArrays["H_H3pod_crossPoint"];
                    double[] H_H3pod_nu_point = doubleArrays["H_H3pod_nu_point"];
                    for (int i = 0; i < ListOfQ_long.Count; i++)
                        H3podPairList.Add(ListOfQ_long[i], ListOfH3pod[i]);
                    Hc_0_linePairList.Add(H31[0], H31[1]);
                    Hc_0_linePairList.Add(H32[0], H32[1]);
                    H_H3pod_nu_linePairList.Add(H_H3pod_crossPoint[0], H_H3pod_crossPoint[1]);
                    H_H3pod_nu_linePairList.Add(H_H3pod_nu_point[0], H_H3pod_nu_point[1]);

                    MyPane.AddCurve("H3 под", H3podPairList, Color.RosyBrown, SymbolType.Diamond);
                    MyPane.AddCurve("", Hc_0_linePairList, Color.Black, SymbolType.Circle);
                    MyPane.AddCurve("", H_H3pod_nu_linePairList, Color.Black, SymbolType.Circle);
                    break;
                case 4:
                    PointPairList Hc__PairList = new PointPairList();
                    PointPairList H_Hc__nu_linePairList = new PointPairList();
                    List<double> ListOfHc_ = doubleLists["ListOfHc_"];
                    double[] H_Hc__crossPoint = doubleArrays["H_Hc__crossPoint"];
                    double[] H_Hc__nu_point = doubleArrays["H_Hc__nu_point"];
                    for (int i = 0; i < ListOfQ_long.Count; i++)
                        Hc__PairList.Add(ListOfQ_long[i], ListOfHc_[i]);
                    H_Hc__nu_linePairList.Add(H_Hc__crossPoint[0], H_Hc__crossPoint[1]);
                    H_Hc__nu_linePairList.Add(H_Hc__nu_point[0], H_Hc__nu_point[1]);

                    MyPane.AddCurve("H'c", Hc__PairList, Color.RosyBrown, SymbolType.Diamond);
                    MyPane.AddCurve("", H_Hc__nu_linePairList, Color.Black, SymbolType.Circle);
                    break;
            }

            MyGraph.AxisChange();
            MyGraph.Invalidate();
        }

        private void MyGraph_MouseMove(object sender, MouseEventArgs e)
        {
            double x, y;
            MyGraph.GraphPane.ReverseTransform(e.Location, out x, out y);
            string text = string.Format("Q (л/с): {0};     H (м): {1}", Math.Round(x, 5), Math.Round(y, 5));
            labelXY.Text = text;
        }

        private void MyGraph_ContextMenuBuilder(ZedGraphControl sender, ContextMenuStrip menuStrip, Point mousePt, ZedGraphControl.ContextMenuObjectState objState)
        {
            menuStrip.Items[0].Text = "Копировать";
            menuStrip.Items[1].Text = "Сохранить как картинку";
            menuStrip.Items[2].Text = "Параметры страницы";
            menuStrip.Items[3].Text = "Печать";
            menuStrip.Items[4].Text = "Показывать значения в точках";
            menuStrip.Items[6].Text = "Отменить приближение";
            menuStrip.Items.RemoveAt(7);
            menuStrip.Items.RemoveAt(5);
        }
    }
}