namespace Lab6
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
            this.buttonWrite = new System.Windows.Forms.Button();
            this.dataGridViewBook = new System.Windows.Forms.DataGridView();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.comboBoxFields = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCondition = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBook)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonWrite
            // 
            this.buttonWrite.Location = new System.Drawing.Point(559, 41);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(105, 23);
            this.buttonWrite.TabIndex = 0;
            this.buttonWrite.Text = "Записать Все";
            this.buttonWrite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonWrite.UseVisualStyleBackColor = true;
            this.buttonWrite.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dataGridViewBook
            // 
            this.dataGridViewBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBook.Location = new System.Drawing.Point(41, 41);
            this.dataGridViewBook.Name = "dataGridViewBook";
            this.dataGridViewBook.Size = new System.Drawing.Size(477, 320);
            this.dataGridViewBook.TabIndex = 1;
            this.dataGridViewBook.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewBook_DataError);
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(556, 415);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(105, 23);
            this.buttonFilter.TabIndex = 4;
            this.buttonFilter.Text = "Фильтровать";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBoxFields
            // 
            this.comboBoxFields.FormattingEnabled = true;
            this.comboBoxFields.Location = new System.Drawing.Point(667, 284);
            this.comboBoxFields.Name = "comboBoxFields";
            this.comboBoxFields.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFields.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(553, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Поле для фильтра";
            // 
            // comboBoxCondition
            // 
            this.comboBoxCondition.Enabled = false;
            this.comboBoxCondition.FormattingEnabled = true;
            this.comboBoxCondition.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.comboBoxCondition.Location = new System.Drawing.Point(667, 311);
            this.comboBoxCondition.Name = "comboBoxCondition";
            this.comboBoxCondition.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCondition.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(553, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Логическое условие";
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.FormattingEnabled = true;
            this.comboBoxFilter.Items.AddRange(new object[] {
            "<",
            ">",
            "="});
            this.comboBoxFilter.Location = new System.Drawing.Point(667, 339);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFilter.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(556, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Фильтр";
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(667, 377);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(121, 20);
            this.textBoxValue.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(553, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Значение фильтра";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(671, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Удалить фильтры";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxFilter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxCondition);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxFields);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.dataGridViewBook);
            this.Controls.Add(this.buttonWrite);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonWrite;
        private System.Windows.Forms.DataGridView dataGridViewBook;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.ComboBox comboBoxFields;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCondition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxFilter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

