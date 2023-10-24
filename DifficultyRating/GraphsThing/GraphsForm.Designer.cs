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
            this.InitializationButton = new System.Windows.Forms.Button();
            this.GraphSelectComboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            // InitializationButton
            // 
            this.InitializationButton.Location = new System.Drawing.Point(156, 10);
            this.InitializationButton.Name = "InitializationButton";
            this.InitializationButton.Size = new System.Drawing.Size(134, 21);
            this.InitializationButton.TabIndex = 1;
            this.InitializationButton.Text = "Инициализация";
            this.InitializationButton.UseVisualStyleBackColor = true;
            this.InitializationButton.Click += new System.EventHandler(this.InitializationButton_Click);
            // 
            // GraphSelectComboBox
            // 
            this.GraphSelectComboBox.FormattingEnabled = true;
            this.GraphSelectComboBox.Location = new System.Drawing.Point(12, 10);
            this.GraphSelectComboBox.Name = "GraphSelectComboBox";
            this.GraphSelectComboBox.Size = new System.Drawing.Size(138, 21);
            this.GraphSelectComboBox.TabIndex = 2;
            this.GraphSelectComboBox.SelectedIndexChanged += new System.EventHandler(this.GraphSelectComboBox_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(473, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(476, 362);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            // 
            // GraphsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 415);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.GraphSelectComboBox);
            this.Controls.Add(this.InitializationButton);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "GraphsForm";
            this.Text = "GraphsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Button InitializationButton;
        private System.Windows.Forms.ComboBox GraphSelectComboBox;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}