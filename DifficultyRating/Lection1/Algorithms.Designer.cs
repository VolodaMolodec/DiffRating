using System.Windows.Forms;

namespace DifficultyRating
{
    partial class Algorithms
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
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.graphSelectComboBox1 = new System.Windows.Forms.ComboBox();
            this.graphSelectComboBox2 = new System.Windows.Forms.ComboBox();
            this.operationCheckBox = new System.Windows.Forms.CheckBox();
            this.timeCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
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
            "Вычисление глубины бинарного дерева",
            "Случайное ветвление",
            "Умножение в столбик",
            "Наивное умножение",
            "Поиск медианы"});
            this.graphSelectComboBox1.Location = new System.Drawing.Point(31, 12);
            this.graphSelectComboBox1.Name = "graphSelectComboBox1";
            this.graphSelectComboBox1.Size = new System.Drawing.Size(153, 21);
            this.graphSelectComboBox1.TabIndex = 6;
            this.graphSelectComboBox1.SelectedIndexChanged += new System.EventHandler(this.graphSelectComboBox_SelectedIndexChanged);
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
            "Вычисление глубины бинарного дерева",
            "Случайное ветвление",
            "Умножение в столбик",
            "Наивное умножение",
            "Поиск медианы"});
            this.graphSelectComboBox2.Location = new System.Drawing.Point(31, 39);
            this.graphSelectComboBox2.Name = "graphSelectComboBox2";
            this.graphSelectComboBox2.Size = new System.Drawing.Size(153, 21);
            this.graphSelectComboBox2.TabIndex = 10;
            this.graphSelectComboBox2.SelectedIndexChanged += new System.EventHandler(this.graphSelectComboBox_SelectedIndexChanged);
            // 
            // operationCheckBox
            // 
            this.operationCheckBox.AutoSize = true;
            this.operationCheckBox.Checked = true;
            this.operationCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.operationCheckBox.Location = new System.Drawing.Point(12, 77);
            this.operationCheckBox.Name = "operationCheckBox";
            this.operationCheckBox.Size = new System.Drawing.Size(182, 17);
            this.operationCheckBox.TabIndex = 11;
            this.operationCheckBox.Text = "Отображение кол-ва операций";
            this.operationCheckBox.UseVisualStyleBackColor = true;
            this.operationCheckBox.CheckedChanged += new System.EventHandler(this.operationCheckBox_CheckedChanged);
            // 
            // timeCheckBox
            // 
            this.timeCheckBox.AutoSize = true;
            this.timeCheckBox.Location = new System.Drawing.Point(12, 100);
            this.timeCheckBox.Name = "timeCheckBox";
            this.timeCheckBox.Size = new System.Drawing.Size(207, 17);
            this.timeCheckBox.TabIndex = 12;
            this.timeCheckBox.Text = "Отображение времени выполнения";
            this.timeCheckBox.UseVisualStyleBackColor = true;
            this.timeCheckBox.CheckedChanged += new System.EventHandler(this.timeCheckBox_CheckedChanged);
            // 
            // Algorithms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.timeCheckBox);
            this.Controls.Add(this.operationCheckBox);
            this.Controls.Add(this.graphSelectComboBox2);
            this.Controls.Add(this.graphSelectComboBox1);
            this.Controls.Add(this.zedGraphControl);
            this.Name = "Algorithms";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ZedGraph.ZedGraphControl zedGraphControl;
        private System.Windows.Forms.ComboBox graphSelectComboBox1;
        private ComboBox graphSelectComboBox2;
        private CheckBox operationCheckBox;
        private CheckBox timeCheckBox;
    }
}

