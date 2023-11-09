namespace DifficultyRating.GraphsThing
{
    partial class GraphsForm
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
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.GraphSelectComboBox = new System.Windows.Forms.ComboBox();
            this.graphShowModeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 37);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(447, 363);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // GraphSelectComboBox
            // 
            this.GraphSelectComboBox.FormattingEnabled = true;
            this.GraphSelectComboBox.Items.AddRange(new object[] {
            "Поиск в глубину",
            "Поиск в ширину",
            "Рекурсия ориентированный граф"});
            this.GraphSelectComboBox.Location = new System.Drawing.Point(12, 10);
            this.GraphSelectComboBox.Name = "GraphSelectComboBox";
            this.GraphSelectComboBox.Size = new System.Drawing.Size(138, 21);
            this.GraphSelectComboBox.TabIndex = 2;
            this.GraphSelectComboBox.SelectedIndexChanged += new System.EventHandler(this.GraphSelectComboBox_SelectedIndexChanged);
            // 
            // graphShowModeComboBox
            // 
            this.graphShowModeComboBox.FormattingEnabled = true;
            this.graphShowModeComboBox.Items.AddRange(new object[] {
            "Кол-во операций",
            "Время выполнения"});
            this.graphShowModeComboBox.Location = new System.Drawing.Point(353, 10);
            this.graphShowModeComboBox.Name = "graphShowModeComboBox";
            this.graphShowModeComboBox.Size = new System.Drawing.Size(106, 21);
            this.graphShowModeComboBox.TabIndex = 9;
            this.graphShowModeComboBox.SelectedIndexChanged += new System.EventHandler(this.GraphSelectComboBox_SelectedIndexChanged);
            // 
            // GraphsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 415);
            this.Controls.Add(this.graphShowModeComboBox);
            this.Controls.Add(this.GraphSelectComboBox);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "GraphsForm";
            this.Text = "GraphsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ComboBox GraphSelectComboBox;
        private System.Windows.Forms.ComboBox graphShowModeComboBox;
    }
}