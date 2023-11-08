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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FullGraphGenerateButton = new System.Windows.Forms.Button();
            this.graphSizeTexBox = new System.Windows.Forms.TextBox();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PartGraphGenerateButton = new System.Windows.Forms.Button();
            this.graphShowModeComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            "Поиск в глубину"});
            this.GraphSelectComboBox.Location = new System.Drawing.Point(12, 10);
            this.GraphSelectComboBox.Name = "GraphSelectComboBox";
            this.GraphSelectComboBox.Size = new System.Drawing.Size(138, 21);
            this.GraphSelectComboBox.TabIndex = 2;
            this.GraphSelectComboBox.SelectedIndexChanged += new System.EventHandler(this.GraphSelectComboBox_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(473, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(476, 338);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            // 
            // FullGraphGenerateButton
            // 
            this.FullGraphGenerateButton.Location = new System.Drawing.Point(473, 5);
            this.FullGraphGenerateButton.Name = "FullGraphGenerateButton";
            this.FullGraphGenerateButton.Size = new System.Drawing.Size(134, 21);
            this.FullGraphGenerateButton.TabIndex = 4;
            this.FullGraphGenerateButton.Text = "Сген. полный граф";
            this.FullGraphGenerateButton.UseVisualStyleBackColor = true;
            this.FullGraphGenerateButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // graphSizeTexBox
            // 
            this.graphSizeTexBox.Location = new System.Drawing.Point(620, 13);
            this.graphSizeTexBox.Name = "graphSizeTexBox";
            this.graphSizeTexBox.Size = new System.Drawing.Size(78, 20);
            this.graphSizeTexBox.TabIndex = 5;
            this.graphSizeTexBox.Text = "5";
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(819, 10);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(121, 20);
            this.pathTextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(717, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Пройденный путь";
            // 
            // PartGraphGenerateButton
            // 
            this.PartGraphGenerateButton.Location = new System.Drawing.Point(473, 32);
            this.PartGraphGenerateButton.Name = "PartGraphGenerateButton";
            this.PartGraphGenerateButton.Size = new System.Drawing.Size(134, 21);
            this.PartGraphGenerateButton.TabIndex = 8;
            this.PartGraphGenerateButton.Text = "Сген. разр. граф";
            this.PartGraphGenerateButton.UseVisualStyleBackColor = true;
            this.PartGraphGenerateButton.Click += new System.EventHandler(this.PartGraphGenerateButton_Click);
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
            this.ClientSize = new System.Drawing.Size(972, 415);
            this.Controls.Add(this.graphShowModeComboBox);
            this.Controls.Add(this.PartGraphGenerateButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.graphSizeTexBox);
            this.Controls.Add(this.FullGraphGenerateButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.GraphSelectComboBox);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "GraphsForm";
            this.Text = "GraphsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ComboBox GraphSelectComboBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button FullGraphGenerateButton;
        private System.Windows.Forms.TextBox graphSizeTexBox;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PartGraphGenerateButton;
        private System.Windows.Forms.ComboBox graphShowModeComboBox;
    }
}