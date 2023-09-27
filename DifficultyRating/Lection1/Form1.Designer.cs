using System.Windows.Forms;

namespace DifficultyRating
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.StartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ElementsInputTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectionSortOutput = new System.Windows.Forms.TextBox();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.graphSelectComboBox1 = new System.Windows.Forms.ComboBox();
            this.QuickSortOutput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.initButton = new System.Windows.Forms.Button();
            this.graphSelectComboBox2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(12, 394);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(101, 44);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Начать тест";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 394);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выборочная сортировка";
            // 
            // ElementsInputTextBox
            // 
            this.ElementsInputTextBox.Location = new System.Drawing.Point(144, 410);
            this.ElementsInputTextBox.Name = "ElementsInputTextBox";
            this.ElementsInputTextBox.Size = new System.Drawing.Size(69, 20);
            this.ElementsInputTextBox.TabIndex = 2;
            this.ElementsInputTextBox.Text = "5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 394);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Количество элементов";
            // 
            // SelectionSortOutput
            // 
            this.SelectionSortOutput.Location = new System.Drawing.Point(328, 410);
            this.SelectionSortOutput.Name = "SelectionSortOutput";
            this.SelectionSortOutput.ReadOnly = true;
            this.SelectionSortOutput.Size = new System.Drawing.Size(69, 20);
            this.SelectionSortOutput.TabIndex = 4;
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Location = new System.Drawing.Point(222, 12);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0D;
            this.zedGraphControl.ScrollMaxX = 0D;
            this.zedGraphControl.ScrollMaxY = 0D;
            this.zedGraphControl.ScrollMaxY2 = 0D;
            this.zedGraphControl.ScrollMinX = 0D;
            this.zedGraphControl.ScrollMinY = 0D;
            this.zedGraphControl.ScrollMinY2 = 0D;
            this.zedGraphControl.Size = new System.Drawing.Size(566, 366);
            this.zedGraphControl.TabIndex = 5;
            this.zedGraphControl.UseExtendedPrintDialog = true;
            // 
            // graphSelectComboBox1
            // 
            this.graphSelectComboBox1.FormattingEnabled = true;
            this.graphSelectComboBox1.Items.AddRange(new object[] {
            "Выборочная сортировка",
            "Быстрая сортировка",
            "Фибоначчи",
            "Крутой Фибоначчи",
            "Построение бинарного дерева",
            "Поиск элемента бинарного дерева",
            "Вычисление глубины бинарного дерева"});
            this.graphSelectComboBox1.Location = new System.Drawing.Point(31, 62);
            this.graphSelectComboBox1.Name = "graphSelectComboBox1";
            this.graphSelectComboBox1.Size = new System.Drawing.Size(153, 21);
            this.graphSelectComboBox1.TabIndex = 6;
            this.graphSelectComboBox1.SelectedIndexChanged += new System.EventHandler(this.graphSelectComboBox_SelectedIndexChanged);
            // 
            // QuickSortOutput
            // 
            this.QuickSortOutput.Location = new System.Drawing.Point(452, 410);
            this.QuickSortOutput.Name = "QuickSortOutput";
            this.QuickSortOutput.ReadOnly = true;
            this.QuickSortOutput.Size = new System.Drawing.Size(69, 20);
            this.QuickSortOutput.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(435, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Быстрая сортировка";
            // 
            // initButton
            // 
            this.initButton.Location = new System.Drawing.Point(56, 12);
            this.initButton.Name = "initButton";
            this.initButton.Size = new System.Drawing.Size(101, 44);
            this.initButton.TabIndex = 9;
            this.initButton.Text = "Инициализация";
            this.initButton.UseVisualStyleBackColor = true;
            this.initButton.Click += new System.EventHandler(this.initButton_Click);
            // 
            // graphSelectComboBox2
            // 
            this.graphSelectComboBox2.FormattingEnabled = true;
            this.graphSelectComboBox2.Items.AddRange(new object[] {
            "Выборочная сортировка",
            "Быстрая сортировка",
            "Фибоначчи",
            "Крутой Фибоначчи",
            "Построение бинарного дерева",
            "Поиск элемента бинарного дерева",
            "Вычисление глубины бинарного дерева"});
            this.graphSelectComboBox2.Location = new System.Drawing.Point(31, 89);
            this.graphSelectComboBox2.Name = "graphSelectComboBox2";
            this.graphSelectComboBox2.Size = new System.Drawing.Size(153, 21);
            this.graphSelectComboBox2.TabIndex = 10;
            this.graphSelectComboBox2.SelectedIndexChanged += new System.EventHandler(this.graphSelectComboBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.graphSelectComboBox2);
            this.Controls.Add(this.initButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.QuickSortOutput);
            this.Controls.Add(this.graphSelectComboBox1);
            this.Controls.Add(this.zedGraphControl);
            this.Controls.Add(this.SelectionSortOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ElementsInputTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ElementsInputTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SelectionSortOutput;
        private ZedGraph.ZedGraphControl zedGraphControl;
        private System.Windows.Forms.ComboBox graphSelectComboBox1;
        private System.Windows.Forms.TextBox QuickSortOutput;
        private System.Windows.Forms.Label label3;
        private Button initButton;
        private ComboBox graphSelectComboBox2;
    }
}

