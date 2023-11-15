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
            this.graphGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.testComboBox = new System.Windows.Forms.ComboBox();
            this.testOutput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.testOperationCountLabel = new System.Windows.Forms.Label();
            this.testTimeLabel = new System.Windows.Forms.Label();
            this.testStartButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.graphGridView)).BeginInit();
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
            // graphGridView
            // 
            this.graphGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.graphGridView.Location = new System.Drawing.Point(465, 50);
            this.graphGridView.Name = "graphGridView";
            this.graphGridView.Size = new System.Drawing.Size(350, 350);
            this.graphGridView.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(465, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Тест";
            // 
            // testComboBox
            // 
            this.testComboBox.FormattingEnabled = true;
            this.testComboBox.Items.AddRange(new object[] {
            "Поиск в глубину",
            "Поиск в ширину",
            "Рекурсия ориентированный граф"});
            this.testComboBox.Location = new System.Drawing.Point(468, 23);
            this.testComboBox.Name = "testComboBox";
            this.testComboBox.Size = new System.Drawing.Size(127, 21);
            this.testComboBox.TabIndex = 12;
            this.testComboBox.SelectedIndexChanged += new System.EventHandler(this.testComboBox_SelectedIndexChanged);
            // 
            // testOutput
            // 
            this.testOutput.Location = new System.Drawing.Point(601, 24);
            this.testOutput.Name = "testOutput";
            this.testOutput.ReadOnly = true;
            this.testOutput.Size = new System.Drawing.Size(128, 20);
            this.testOutput.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(598, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Вывод";
            // 
            // testOperationCountLabel
            // 
            this.testOperationCountLabel.AutoSize = true;
            this.testOperationCountLabel.Location = new System.Drawing.Point(744, 7);
            this.testOperationCountLabel.Name = "testOperationCountLabel";
            this.testOperationCountLabel.Size = new System.Drawing.Size(60, 13);
            this.testOperationCountLabel.TabIndex = 15;
            this.testOperationCountLabel.Text = "Операций:";
            // 
            // testTimeLabel
            // 
            this.testTimeLabel.AutoSize = true;
            this.testTimeLabel.Location = new System.Drawing.Point(744, 27);
            this.testTimeLabel.Name = "testTimeLabel";
            this.testTimeLabel.Size = new System.Drawing.Size(43, 13);
            this.testTimeLabel.TabIndex = 16;
            this.testTimeLabel.Text = "Время:";
            // 
            // testStartButton
            // 
            this.testStartButton.Location = new System.Drawing.Point(821, 50);
            this.testStartButton.Name = "testStartButton";
            this.testStartButton.Size = new System.Drawing.Size(44, 36);
            this.testStartButton.TabIndex = 17;
            this.testStartButton.Text = "Start";
            this.testStartButton.UseVisualStyleBackColor = true;
            this.testStartButton.Click += new System.EventHandler(this.testStartButton_Click);
            // 
            // GraphsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 415);
            this.Controls.Add(this.testStartButton);
            this.Controls.Add(this.testTimeLabel);
            this.Controls.Add(this.testOperationCountLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.testOutput);
            this.Controls.Add(this.testComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.graphGridView);
            this.Controls.Add(this.graphShowModeComboBox);
            this.Controls.Add(this.GraphSelectComboBox);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "GraphsForm";
            this.Text = "GraphsForm";
            ((System.ComponentModel.ISupportInitialize)(this.graphGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ComboBox GraphSelectComboBox;
        private System.Windows.Forms.ComboBox graphShowModeComboBox;
        private System.Windows.Forms.DataGridView graphGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox testComboBox;
        private System.Windows.Forms.TextBox testOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label testOperationCountLabel;
        private System.Windows.Forms.Label testTimeLabel;
        private System.Windows.Forms.Button testStartButton;
    }
}