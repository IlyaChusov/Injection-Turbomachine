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
        private readonly List<int> ListOfQ = new List<int>();
        private readonly List<double> ListOfH = new List<double>();
        private readonly List<double> ListOfn = new List<double>();
        private readonly List<double> ListOfHc = new List<double>();
        private readonly double[] crossPoint;
        private readonly double[] crossPoint2;
        private readonly double[] H31;
        private readonly double[] H32;

        public Grafik(List<int> _ListOfQ, List<double> _ListOfH, List<double> _ListOfn, List<double> _ListOfHc, double[] _crossPoint, double[] _crossPoint2, double[] _H31, double[] _H32)
        {
            InitializeComponent();
            ListOfQ = _ListOfQ;
            ListOfH = _ListOfH;
            ListOfn = _ListOfn;
            ListOfHc = _ListOfHc;
            crossPoint = _crossPoint;
            crossPoint2 = _crossPoint2;
            H31 = _H31;
            H32 = _H32;
            Draw();
        }

        private void Draw()
        {
            GraphPane MyPane = MyGraph.GraphPane;
            MyPane.YAxis.Cross = 0.0;
            MyPane.XAxis.Title.IsVisible = false;
            MyPane.YAxis.Title.IsVisible = false;
            MyPane.Title.IsVisible = false;
            PointPairList HPairList = new PointPairList();
            PointPairList nPairList = new PointPairList();
            PointPairList HcPairList = new PointPairList();
            PointPairList pointPairList = new PointPairList();
            PointPairList point2PairList = new PointPairList();
            PointPairList linePairList = new PointPairList();
            PointPairList H31PairList = new PointPairList();
            PointPairList H32PairList = new PointPairList();
            PointPairList lineHPairList = new PointPairList();

            for (int i = 0; i < ListOfQ.Count; i++)
            {
                HPairList.Add(ListOfQ[i], ListOfH[i]);
                nPairList.Add(ListOfQ[i], ListOfn[i]);
                HcPairList.Add(ListOfQ[i], ListOfHc[i]);
            }
            pointPairList.Add(crossPoint[0], crossPoint[1]);
            point2PairList.Add(crossPoint2[0], crossPoint2[1]);
            linePairList.Add(crossPoint[0], crossPoint[1]);
            linePairList.Add(crossPoint2[0], crossPoint2[1]);
            H31PairList.Add(H31[0], H31[1]);
            H32PairList.Add(H32[0], H32[1]);
            lineHPairList.Add(H31[0], H31[1]);
            lineHPairList.Add(H32[0], H32[1]);

            MyPane.AddCurve("H", HPairList, Color.Blue, SymbolType.Plus);
            MyPane.AddCurve("n", nPairList, Color.Red, SymbolType.Triangle);
            MyPane.AddCurve("Hc", HcPairList, Color.Green, SymbolType.Square);
            MyPane.AddCurve("", pointPairList, Color.Black, SymbolType.Circle);
            MyPane.AddCurve("", point2PairList, Color.Black, SymbolType.Circle);
            MyPane.AddCurve("", linePairList, Color.RosyBrown, SymbolType.None);
            MyPane.AddCurve("", H31PairList, Color.Black, SymbolType.Circle);
            MyPane.AddCurve("", H32PairList, Color.Black, SymbolType.Circle);
            MyPane.AddCurve("", lineHPairList, Color.Aqua, SymbolType.None);

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