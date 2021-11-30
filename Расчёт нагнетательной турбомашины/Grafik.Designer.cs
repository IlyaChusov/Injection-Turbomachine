namespace Расчёт_нагнетательной_турбомашины
{
    partial class Grafik
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
            this.components = new System.ComponentModel.Container();
            this.MyGraph = new ZedGraph.ZedGraphControl();
            this.labelXY = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MyGraph
            // 
            this.MyGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyGraph.Location = new System.Drawing.Point(0, 0);
            this.MyGraph.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MyGraph.Name = "MyGraph";
            this.MyGraph.ScrollGrace = 0D;
            this.MyGraph.ScrollMaxX = 0D;
            this.MyGraph.ScrollMaxY = 0D;
            this.MyGraph.ScrollMaxY2 = 0D;
            this.MyGraph.ScrollMinX = 0D;
            this.MyGraph.ScrollMinY = 0D;
            this.MyGraph.ScrollMinY2 = 0D;
            this.MyGraph.Size = new System.Drawing.Size(800, 477);
            this.MyGraph.TabIndex = 1;
            this.MyGraph.ContextMenuBuilder += new ZedGraph.ZedGraphControl.ContextMenuBuilderEventHandler(this.MyGraph_ContextMenuBuilder);
            this.MyGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyGraph_MouseMove);
            // 
            // labelXY
            // 
            this.labelXY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelXY.AutoSize = true;
            this.labelXY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelXY.Location = new System.Drawing.Point(12, 489);
            this.labelXY.Name = "labelXY";
            this.labelXY.Size = new System.Drawing.Size(0, 20);
            this.labelXY.TabIndex = 2;
            // 
            // Grafik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 522);
            this.Controls.Add(this.labelXY);
            this.Controls.Add(this.MyGraph);
            this.MinimumSize = new System.Drawing.Size(818, 569);
            this.Name = "Grafik";
            this.Text = "Grafik";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl MyGraph;
        private System.Windows.Forms.Label labelXY;
    }
}