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
            this.StartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ElementsInputTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectionSortOutput = new System.Windows.Forms.TextBox();
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

