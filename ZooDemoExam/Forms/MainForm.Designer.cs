namespace ZooDemoExam
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.radioAsc = new System.Windows.Forms.RadioButton();
            this.radioDesc = new System.Windows.Forms.RadioButton();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(219)))), ((int)(((byte)(226)))));
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 73);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(809, 391);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ZooDemoExam.Properties.Resources.Logotip;
            this.pictureBox1.Location = new System.Drawing.Point(12, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.Location = new System.Drawing.Point(632, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 23);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "ФИО";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(831, 115);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(105, 20);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSearch.Location = new System.Drawing.Point(827, 89);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(64, 23);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = "Поиск:";
            // 
            // cmbFilter
            // 
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Items.AddRange(new object[] {
            "Все поставщики",
            "ЗооПром",
            "КормЦентр",
            "ИП Иванов",
            "ЗооТрейд",
            "ЗооЛюкc",
            "ВетСнаб"});
            this.cmbFilter.Location = new System.Drawing.Point(831, 173);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(105, 21);
            this.cmbFilter.TabIndex = 5;
            this.cmbFilter.SelectedValueChanged += new System.EventHandler(this.cmbFilter_SelectedValueChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFilter.Location = new System.Drawing.Point(827, 147);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(73, 23);
            this.lblFilter.TabIndex = 6;
            this.lblFilter.Text = "Фильтр:";
            // 
            // radioAsc
            // 
            this.radioAsc.AutoSize = true;
            this.radioAsc.Location = new System.Drawing.Point(831, 200);
            this.radioAsc.Name = "radioAsc";
            this.radioAsc.Size = new System.Drawing.Size(109, 17);
            this.radioAsc.TabIndex = 7;
            this.radioAsc.TabStop = true;
            this.radioAsc.Text = "По возрастанию";
            this.radioAsc.UseVisualStyleBackColor = true;
            this.radioAsc.CheckedChanged += new System.EventHandler(this.radioAsc_CheckedChanged);
            // 
            // radioDesc
            // 
            this.radioDesc.AutoSize = true;
            this.radioDesc.Location = new System.Drawing.Point(831, 223);
            this.radioDesc.Name = "radioDesc";
            this.radioDesc.Size = new System.Drawing.Size(93, 17);
            this.radioDesc.TabIndex = 8;
            this.radioDesc.TabStop = true;
            this.radioDesc.Text = "По убыванию";
            this.radioDesc.UseVisualStyleBackColor = true;
            this.radioDesc.CheckedChanged += new System.EventHandler(this.radioDesc_CheckedChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnAdd.Location = new System.Drawing.Point(831, 246);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(109, 42);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Добавить товар";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnOrder.Location = new System.Drawing.Point(831, 294);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(109, 42);
            this.btnOrder.TabIndex = 10;
            this.btnOrder.Text = "Заказы";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnBack.Location = new System.Drawing.Point(831, 422);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(109, 42);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(942, 476);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.radioDesc);
            this.Controls.Add(this.radioAsc);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "ООО \"ЗооМагазин\"";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.RadioButton radioAsc;
        private System.Windows.Forms.RadioButton radioDesc;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnBack;
    }
}