using System;
using System.Collections.Generic;
using System.Drawing;
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

                    addDottedLine(MyPane, H_Hc_linePairList, Color.Black, SymbolType.Circle);
                    break;
                case 3:
                    PointPairList H3podPairList = new PointPairList();
                    PointPairList Hc_0_3_linePairList = new PointPairList();
                    PointPairList H_H3pod_nu_linePairList = new PointPairList();
                    List<double> ListOfH3pod = doubleLists["ListOfH3pod"];
                    double[] H31 = doubleArrays["H31"];
                    double[] H32 = doubleArrays["H32"];
                    double[] H_H3pod_crossPoint = doubleArrays["H_H3pod_crossPoint"];
                    double[] H_H3pod_nu_point = doubleArrays["H_H3pod_nu_point"];
                    for (int i = 0; i < ListOfQ_long.Count; i++)
                        H3podPairList.Add(ListOfQ_long[i], ListOfH3pod[i]);
                    Hc_0_3_linePairList.Add(H31[0], H31[1]);
                    Hc_0_3_linePairList.Add(H32[0], H32[1]);
                    H_H3pod_nu_linePairList.Add(H_H3pod_crossPoint[0], H_H3pod_crossPoint[1]);
                    H_H3pod_nu_linePairList.Add(H_H3pod_nu_point[0], H_H3pod_nu_point[1]);

                    MyPane.AddCurve("H3 под", H3podPairList, Color.RosyBrown, SymbolType.Diamond);
                    addDottedLine(MyPane, Hc_0_3_linePairList, Color.Black, SymbolType.Circle);
                    addDottedLine(MyPane, H_H3pod_nu_linePairList, Color.Black, SymbolType.Circle);
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
                    addDottedLine(MyPane, H_Hc__nu_linePairList, Color.Black, SymbolType.Circle);
                    break;
                case 5:
                    PointPairList H5podPairList = new PointPairList();
                    PointPairList Hc_0_5_linePairList = new PointPairList();
                    PointPairList H_H5pod_nu_linePairList = new PointPairList();
                    List<double> ListOfH5pod = doubleLists["ListOfH5pod"];
                    double[] H51 = doubleArrays["H51"];
                    double[] H52 = doubleArrays["H52"];
                    double[] H_H5pod_crossPoint = doubleArrays["H_H5pod_crossPoint"];
                    double[] H_H5pod_nu_point = doubleArrays["H_H5pod_nu_point"];
                    for (int i = 0; i < ListOfQ_long.Count; i++)
                        H5podPairList.Add(ListOfQ_long[i], ListOfH5pod[i]);
                    Hc_0_5_linePairList.Add(H51[0], H51[1]);
                    Hc_0_5_linePairList.Add(H52[0], H52[1]);
                    Hc_0_5_linePairList.Add(0, H52[1]);
                    H_H5pod_nu_linePairList.Add(H_H5pod_crossPoint[0], H_H5pod_crossPoint[1]);
                    H_H5pod_nu_linePairList.Add(H_H5pod_nu_point[0], H_H5pod_nu_point[1]);

                    MyPane.AddCurve("H5 под", H5podPairList, Color.RosyBrown, SymbolType.Diamond);
                    addDottedLine(MyPane, Hc_0_5_linePairList, Color.Black, SymbolType.Circle);
                    addDottedLine(MyPane, H_H5pod_nu_linePairList, Color.Black, SymbolType.Circle);
                    break;
                case 6:
                    PointPairList KPD_H_1linePairList = new PointPairList();
                    PointPairList KPD_H_2linePairList = new PointPairList();
                    PointPairList HApodlinePairList = new PointPairList();
                    PointPairList HBpodlinePairList = new PointPairList();
                    PointPairList Point6PairList = new PointPairList();
                    PointPairList Point6_PairList = new PointPairList();
                    double[] KPD_1crossPoint = doubleArrays["KPD_1crossPoint"];
                    double[] KPD_H_1crossPoint = doubleArrays["KPD_H_1crossPoint"];
                    double[] KPD_2crossPoint = doubleArrays["KPD_2crossPoint"];
                    double[] KPD_H_2crossPoint = doubleArrays["KPD_H_2crossPoint"];
                    List<double> ListOfHApod = doubleLists["ListOfHApod"];
                    List<double> ListOfHBpod = doubleLists["ListOfHBpod"];
                    double[] point6 = doubleArrays["point6"];
                    double[] point6_ = doubleArrays["point6_"];
                    KPD_H_1linePairList.Add(KPD_1crossPoint[0], KPD_1crossPoint[1]);
                    KPD_H_1linePairList.Add(KPD_H_1crossPoint[0], KPD_H_1crossPoint[1]);
                    KPD_H_2linePairList.Add(KPD_2crossPoint[0], KPD_2crossPoint[1]);
                    KPD_H_2linePairList.Add(KPD_H_2crossPoint[0], KPD_H_2crossPoint[1]);
                    for (int i = 0; i < 15; i++)
                        HApodlinePairList.Add(ListOfQ_long[i], ListOfHApod[i]);
                    for (int i = 0; i < ListOfQ_long.Count; i++)
                        HBpodlinePairList.Add(ListOfQ_long[i], ListOfHBpod[i]);
                    Point6PairList.Add(point6[0], 0);
                    Point6PairList.Add(point6[0], point6[1]);
                    Point6PairList.Add(0, point6[1]);
                    Point6_PairList.Add(point6_[0], 0);
                    Point6_PairList.Add(point6_[0], point6_[1]);
                    Point6_PairList.Add(0, point6_[1]);

                    addDottedLine(MyPane, KPD_H_1linePairList, Color.Black, SymbolType.Circle);
                    addDottedLine(MyPane, KPD_H_2linePairList, Color.Black, SymbolType.Circle);
                    MyPane.AddCurve("HA под", HApodlinePairList, Color.DarkGray, SymbolType.Plus);
                    MyPane.AddCurve("HB под", HBpodlinePairList, Color.DarkOrange, SymbolType.XCross);
                    addDottedLine(MyPane, Point6PairList, Color.Brown, SymbolType.Diamond);
                    addDottedLine(MyPane, Point6_PairList, Color.Brown, SymbolType.Diamond);
                    break;
                case 7:
                    PointPairList H7PointPairList = new PointPairList();
                    PointPairList H_cPairList = new PointPairList();
                    double[] H7Point = doubleArrays["H7Point"];
                    double[] H7_Point = doubleArrays["H7_Point"];
                    List<double> ListOfH_c = doubleLists["ListOfH_c"];
                    H7PointPairList.Add(H7Point[0], H7Point[1]);
                    H7PointPairList.Add(H7_Point[0], H7_Point[1]);
                    for (int i = 0; i < ListOfQ_long.Count; i++)
                        H_cPairList.Add(ListOfQ_long[i], ListOfH_c[i]);

                    addDottedLine(MyPane, H7PointPairList, Color.Black, SymbolType.Circle);
                    MyPane.AddCurve("H'c", H_cPairList, Color.Brown, SymbolType.Diamond);
                    break;
                case 8:
                    PointPairList H8PointPairList = new PointPairList();
                    PointPairList H8podPairList = new PointPairList();
                    PointPairList Hc_H8pod_linePairList = new PointPairList();
                    double[] H8Point = doubleArrays["H8Point"];
                    double[] H8_Point = doubleArrays["H8_Point"];
                    double[] Hc_H8pod_crossPoint = doubleArrays["Hc_H8pod_crossPoint"];
                    List<double> ListOfH8pod = doubleLists["ListOfH8pod"];
                    H8PointPairList.Add(H8Point[0], H8Point[1]);
                    H8PointPairList.Add(H8_Point[0], H8_Point[1]);
                    for (int i = 0; i < 30; i++)
                        H8podPairList.Add(ListOfQ_long[i], ListOfH8pod[i]);
                    Hc_H8pod_linePairList.Add(Hc_H8pod_crossPoint[0], Hc_H8pod_crossPoint[1]);

                    addDottedLine(MyPane, H8PointPairList, Color.Black, SymbolType.Circle);
                    MyPane.AddCurve("H8 под", H8podPairList, Color.Brown, SymbolType.Diamond);
                    addDottedLine(MyPane, Hc_H8pod_linePairList, Color.Black, SymbolType.Circle);
                    break;
            }

            MyGraph.AxisChange();
            MyGraph.Invalidate();
        }

        private void addDottedLine(GraphPane pane, PointPairList pointPairList, Color color, SymbolType symbolType)
        {
            LineItem line = pane.AddCurve("", pointPairList, color, symbolType);
            line.Line.Style = System.Drawing.Drawing2D.DashStyle.Custom;
            // Длина пунктира
            line.Line.DashOn = 7.0f;
            // Длина пропуска между пунктирами
            line.Line.DashOff = 8.0f;
        }

        private void MyGraph_MouseMove(object sender, MouseEventArgs e)
        {
            MyGraph.GraphPane.ReverseTransform(e.Location, out double x, out double y);
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