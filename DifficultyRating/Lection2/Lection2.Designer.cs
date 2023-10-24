namespace DifficultyRating.Lection2
{
    partial class Lection2
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
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.graphSelectComboBox1 = new System.Windows.Forms.ComboBox();
            this.graphSelectComboBox2 = new System.Windows.Forms.ComboBox();
            this.coefficientTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Location = new System.Drawing.Point(10, 32);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0D;
            this.zedGraphControl.ScrollMaxX = 0D;
            this.zedGraphControl.ScrollMaxY = 0D;
            this.zedGraphControl.ScrollMaxY2 = 0D;
            this.zedGraphControl.ScrollMinX = 0D;
            this.zedGraphControl.ScrollMinY = 0D;
            this.zedGraphControl.ScrollMinY2 = 0D;
            this.zedGraphControl.Size = new System.Drawing.Size(609, 400);
            this.zedGraphControl.TabIndex = 0;
            this.zedGraphControl.UseExtendedPrintDialog = true;
            // 
            // graphSelectComboBox1
            // 
            this.graphSelectComboBox1.FormattingEnabled = true;
            this.graphSelectComboBox1.Items.AddRange(new object[] {
            "- Нет -",
            "Умножение в столбик",
            "Разделяй и влавствуй",
            "Медиана Случайная",
            "Дерево со случайным ветвлением"});
            this.graphSelectComboBox1.Location = new System.Drawing.Point(29, 5);
            this.graphSelectComboBox1.Name = "graphSelectComboBox1";
            this.graphSelectComboBox1.Size = new System.Drawing.Size(139, 21);
            this.graphSelectComboBox1.TabIndex = 1;
            this.graphSelectComboBox1.SelectedIndexChanged += new System.EventHandler(this.graphSelectComboBox1_SelectedIndexChanged);
            // 
            // graphSelectComboBox2
            // 
            this.graphSelectComboBox2.FormattingEnabled = true;
            this.graphSelectComboBox2.Items.AddRange(new object[] {
            "- Нет -",
            "Умножение в столбик",
            "Разделяй и влавствуй",
            "Дерево со случайным ветвлением"});
            this.graphSelectComboBox2.Location = new System.Drawing.Point(194, 5);
            this.graphSelectComboBox2.Name = "graphSelectComboBox2";
            this.graphSelectComboBox2.Size = new System.Drawing.Size(139, 21);
            this.graphSelectComboBox2.TabIndex = 2;
            this.graphSelectComboBox2.SelectedIndexChanged += new System.EventHandler(this.graphSelectComboBox1_SelectedIndexChanged);
            // 
            // coefficientTextBox
            // 
            this.coefficientTextBox.Location = new System.Drawing.Point(194, 6);
            this.coefficientTextBox.Name = "coefficientTextBox";
            this.coefficientTextBox.Size = new System.Drawing.Size(112, 20);
            this.coefficientTextBox.TabIndex = 3;
            this.coefficientTextBox.Text = "2";
            this.coefficientTextBox.Visible = false;
            this.coefficientTextBox.Validated += new System.EventHandler(this.graphSelectComboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(349, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 20);
            this.button1.TabIndex = 4;
            this.button1.Text = "Инициализация";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Lection2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 444);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.coefficientTextBox);
            this.Controls.Add(this.graphSelectComboBox2);
            this.Controls.Add(this.graphSelectComboBox1);
            this.Controls.Add(this.zedGraphControl);
            this.Name = "Lection2";
            this.Text = "Lection2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl;
        private System.Windows.Forms.ComboBox graphSelectComboBox1;
        private System.Windows.Forms.ComboBox graphSelectComboBox2;
        private System.Windows.Forms.TextBox coefficientTextBox;
        private System.Windows.Forms.Button button1;
    }
}