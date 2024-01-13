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
            this.totalTime_CB = new System.Windows.Forms.CheckBox();
            this.operationsCount_CB = new System.Windows.Forms.CheckBox();
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
            "Дерево минимальных расстояний",
            "Дийкстра",
            "Рекурсия ориентированный граф"});
            this.GraphSelectComboBox.Location = new System.Drawing.Point(12, 10);
            this.GraphSelectComboBox.Name = "GraphSelectComboBox";
            this.GraphSelectComboBox.Size = new System.Drawing.Size(138, 21);
            this.GraphSelectComboBox.TabIndex = 2;
            this.GraphSelectComboBox.SelectedIndexChanged += new System.EventHandler(this.GraphSelectComboBox_SelectedIndexChanged);
            // 
            // totalTime_CB
            // 
            this.totalTime_CB.AutoSize = true;
            this.totalTime_CB.Location = new System.Drawing.Point(352, 12);
            this.totalTime_CB.Name = "totalTime_CB";
            this.totalTime_CB.Size = new System.Drawing.Size(107, 17);
            this.totalTime_CB.TabIndex = 3;
            this.totalTime_CB.Text = "Кол-во времени";
            this.totalTime_CB.UseVisualStyleBackColor = true;
            this.totalTime_CB.CheckedChanged += new System.EventHandler(this.totalTime_CB_CheckedChanged);
            // 
            // operationsCount_CB
            // 
            this.operationsCount_CB.AutoSize = true;
            this.operationsCount_CB.Checked = true;
            this.operationsCount_CB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.operationsCount_CB.Location = new System.Drawing.Point(235, 12);
            this.operationsCount_CB.Name = "operationsCount_CB";
            this.operationsCount_CB.Size = new System.Drawing.Size(111, 17);
            this.operationsCount_CB.TabIndex = 4;
            this.operationsCount_CB.Text = "Кол-во операций";
            this.operationsCount_CB.UseVisualStyleBackColor = true;
            this.operationsCount_CB.CheckedChanged += new System.EventHandler(this.operationsCount_CH_CheckedChanged);
            // 
            // GraphsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 408);
            this.Controls.Add(this.operationsCount_CB);
            this.Controls.Add(this.totalTime_CB);
            this.Controls.Add(this.GraphSelectComboBox);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "GraphsForm";
            this.Text = "GraphsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ComboBox GraphSelectComboBox;
        private System.Windows.Forms.CheckBox totalTime_CB;
        private System.Windows.Forms.CheckBox operationsCount_CB;
    }
}