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
        private readonly int mode;
        private readonly List<int> ListOfQ = new List<int>();
        private readonly List<int> ListOfQ_long = new List<int>();
        private readonly List<double> ListOfH = new List<double>();
        private readonly List<double> ListOfnu = new List<double>();
        private readonly List<double> ListOfHc = new List<double>();
        private readonly List<double> ListOfH3pod = new List<double>();
        private readonly double[] H_Hc_crossPoint;
        private readonly double[] H_Hc_nu_point;
        private readonly double[] H_H3pod_crossPoint;
        private readonly double[] H_H3pod_nu_point;
        private readonly double[] H31;
        private readonly double[] H32;

        public Grafik(
            int _mode, 
            List<int> _ListOfQ, 
            List<int> _ListOfQ_long, 
            List<double> _ListOfH, 
            List<double> _ListOfnu, 
            List<double> _ListOfHc, 
            List<double> _ListOfH3pod, 
            double[] _H_Hc_crossPoint, 
            double[] _H_Hc_nu_point,
            double[] _H_H3pod_crossPoint,
            double[] _H_H3pod_nu_point,
            double[] _H31, 
            double[] _H32)
        {
            InitializeComponent();
            mode = _mode;
            ListOfQ = _ListOfQ;
            ListOfQ_long = _ListOfQ_long;
            ListOfH = _ListOfH;
            ListOfnu = _ListOfnu;
            ListOfHc = _ListOfHc;
            ListOfH3pod = _ListOfH3pod;
            H_Hc_crossPoint = _H_Hc_crossPoint;
            H_Hc_nu_point = _H_Hc_nu_point;
            H_H3pod_crossPoint = _H_H3pod_crossPoint;
            H_H3pod_nu_point = _H_H3pod_nu_point;
            H31 = _H31;
            H32 = _H32;
            Draw();
        }

        private void Draw()
        {
            GraphPane MyPane = MyGraph.GraphPane;
            MyGraph.IsShowPointValues = true;
            MyPane.YAxis.Cross = 0.0;
            MyPane.XAxis.Title.IsVisible = false;
            MyPane.YAxis.Title.IsVisible = false;
            MyPane.Title.IsVisible = false;
            PointPairList HPairList = new PointPairList();
            PointPairList nPairList = new PointPairList();
            PointPairList HcPairList = new PointPairList();
            PointPairList H3podPairList = new PointPairList();
            PointPairList H_Hc_crossPointPairList = new PointPairList();
            PointPairList H_Hc_nu_pointPairList = new PointPairList();
            PointPairList H_H3pod_crossPointPairList = new PointPairList();
            PointPairList H_H3pod_nu_pointPairList = new PointPairList();
            PointPairList H_Hc_linePairList = new PointPairList();
            PointPairList H31PairList = new PointPairList();
            PointPairList H32PairList = new PointPairList();
            PointPairList H_linePairList = new PointPairList();
            PointPairList H3_linePairList = new PointPairList();

            for (int i = 0; i < ListOfQ.Count; i++)
            {
                HPairList.Add(ListOfQ[i], ListOfH[i]);
                nPairList.Add(ListOfQ[i], ListOfnu[i]);
            }
            for (int i = 0; i < ListOfQ_long.Count; i++)
            {
                HcPairList.Add(ListOfQ_long[i], ListOfHc[i]);
                H3podPairList.Add(ListOfQ_long[i], ListOfH3pod[i]);
            }
            H_Hc_crossPointPairList.Add(H_Hc_crossPoint[0], H_Hc_crossPoint[1]);
            H_Hc_nu_pointPairList.Add(H_Hc_nu_point[0], H_Hc_nu_point[1]);
            H_Hc_linePairList.Add(H_Hc_crossPoint[0], H_Hc_crossPoint[1]);
            H_Hc_linePairList.Add(H_Hc_nu_point[0], H_Hc_nu_point[1]);
            H_H3pod_crossPointPairList.Add(H_H3pod_crossPoint[0], H_H3pod_crossPoint[1]);
            H_H3pod_nu_pointPairList.Add(H_H3pod_nu_point[0], H_H3pod_nu_point[1]);
            H3_linePairList.Add(H_H3pod_crossPoint[0], H_H3pod_crossPoint[1]);
            H3_linePairList.Add(H_H3pod_nu_point[0], H_H3pod_nu_point[1]);
            H31PairList.Add(H31[0], H31[1]);
            H32PairList.Add(H32[0], H32[1]);
            H_linePairList.Add(H31[0], H31[1]);
            H_linePairList.Add(H32[0], H32[1]);

            MyPane.AddCurve("H", HPairList, Color.Blue, SymbolType.Plus);
            MyPane.AddCurve("nu", nPairList, Color.Red, SymbolType.Triangle);
            MyPane.AddCurve("Hc", HcPairList, Color.Green, SymbolType.Square);

            switch (mode)
            {
                case 1:
                    MyPane.AddCurve("", H_Hc_crossPointPairList, Color.Black, SymbolType.Circle);
                    MyPane.AddCurve("", H_Hc_nu_pointPairList, Color.Black, SymbolType.Circle);
                    MyPane.AddCurve("", H_Hc_linePairList, Color.RosyBrown, SymbolType.None);
                    break;
                case 3:
                    MyPane.AddCurve("H3 под", H3podPairList, Color.RosyBrown, SymbolType.Diamond);
                    MyPane.AddCurve("", H31PairList, Color.Black, SymbolType.Circle);
                    MyPane.AddCurve("", H32PairList, Color.Black, SymbolType.Circle);
                    MyPane.AddCurve("", H_linePairList, Color.Black, SymbolType.None);
                    MyPane.AddCurve("", H_H3pod_crossPointPairList, Color.Black, SymbolType.Circle);
                    MyPane.AddCurve("", H_H3pod_nu_pointPairList, Color.Black, SymbolType.Circle);
                    MyPane.AddCurve("", H3_linePairList, Color.Black, SymbolType.None);
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