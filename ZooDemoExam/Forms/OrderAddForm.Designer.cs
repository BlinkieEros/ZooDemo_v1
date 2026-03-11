namespace ZooDemoExam.Forms
{
    partial class OrderAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderAddForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLabel = new System.Windows.Forms.Label();
            this.lblPickup = new System.Windows.Forms.Label();
            this.lblArticle = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.dateTimePickerDelivery = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.cmbPickup = new System.Windows.Forms.ComboBox();
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.lblOrder = new System.Windows.Forms.Label();
            this.dateTimePickerOrder = new System.Windows.Forms.DateTimePicker();
            this.cmbArticle = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(219)))), ((int)(((byte)(226)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblLabel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(727, 59);
            this.panel1.TabIndex = 0;
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLabel.Location = new System.Drawing.Point(7, 11);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(235, 33);
            this.lblLabel.TabIndex = 0;
            this.lblLabel.Text = "Добавление заказа";
            // 
            // lblPickup
            // 
            this.lblPickup.AutoSize = true;
            this.lblPickup.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPickup.Location = new System.Drawing.Point(12, 77);
            this.lblPickup.Name = "lblPickup";
            this.lblPickup.Size = new System.Drawing.Size(127, 23);
            this.lblPickup.TabIndex = 1;
            this.lblPickup.Text = "Пункт выдачи:";
            // 
            // lblArticle
            // 
            this.lblArticle.AutoSize = true;
            this.lblArticle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblArticle.Location = new System.Drawing.Point(399, 77);
            this.lblArticle.Name = "lblArticle";
            this.lblArticle.Size = new System.Drawing.Size(138, 23);
            this.lblArticle.TabIndex = 2;
            this.lblArticle.Text = "Артикул товара:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQuantity.Location = new System.Drawing.Point(430, 100);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(107, 23);
            this.lblQuantity.TabIndex = 3;
            this.lblQuantity.Text = "Количество:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.Location = new System.Drawing.Point(18, 100);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(121, 23);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "ФИО клиента:";
            // 
            // dateTimePickerDelivery
            // 
            this.dateTimePickerDelivery.Location = new System.Drawing.Point(210, 232);
            this.dateTimePickerDelivery.Name = "dateTimePickerDelivery";
            this.dateTimePickerDelivery.Size = new System.Drawing.Size(146, 20);
            this.dateTimePickerDelivery.TabIndex = 5;
            this.dateTimePickerDelivery.Value = new System.DateTime(2026, 3, 11, 16, 24, 58, 0);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDate.Location = new System.Drawing.Point(206, 206);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(129, 23);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Дата доставки:";
            // 
            // cmbPickup
            // 
            this.cmbPickup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPickup.FormattingEnabled = true;
            this.cmbPickup.Items.AddRange(new object[] {
            "394000, г. Воронеж, ул. Ленина, 12",
            "394018, г. Воронеж, пр. Революции, 24",
            "394019, г. Воронеж, ул. Плехановская, 33",
            "394020, г. Воронеж, ул. Кольцовская, 41",
            "394021, г. Воронеж, Московский пр., 88",
            "394026, г. Воронеж, ул. Владимира Невского, 15",
            "394028, г. Воронеж, ул. Хользунова, 56",
            "394029, г. Воронеж, ул. 9 Января, 117",
            "394030, г. Воронеж, ул. Остужева, 22",
            "394033, г. Воронеж, Ленинский пр., 105",
            "394034, г. Воронеж, ул. Димитрова, 79",
            "394036, г. Воронеж, ул. Броневая, 3",
            "394038, г. Воронеж, ул. Перевёрткина, 31",
            "394040, г. Воронеж, ул. Ростовская, 48",
            "394042, г. Воронеж, ул. Антонова-Овсеенко, 27",
            "394043, г. Воронеж, ул. Шишкова, 64",
            "394045, г. Воронеж, ул. Беговая, 5",
            "394047, г. Воронеж, ул. Героев Сибиряков, 73",
            "394049, г. Воронеж, ул. Транспортная, 59",
            "394051, г. Воронеж, ул. Олеко Дундича, 18",
            "394053, г. Воронеж, ул. Минская, 42",
            "394055, г. Воронеж, ул. 20 лет Октября, 96",
            "394056, г. Воронеж, ул. Фридриха Энгельса, 61",
            "394057, г. Воронеж, ул. Карла Маркса, 84",
            "394058, г. Воронеж, ул. Степана Разина, 37",
            "394059, г. Воронеж, ул. Софьи Перовской, 11",
            "394061, г. Воронеж, ул. Пирогова, 50",
            "394062, г. Воронеж, Бульвар Победы, 29",
            "394063, г. Воронеж, ул. Генерала Лизюкова, 43",
            "394064, г. Воронеж, ул. Маршала Жукова, 6",
            "394065, г. Воронеж, ул. Южно-Моравская, 19",
            "394066, г. Воронеж, ул. Перевёрткина, 14",
            "394068, г. Воронеж, ул. Ленинградская, 52",
            "394070, г. Воронеж, ул. Машиностроителей, 38",
            "394071, г. Воронеж, ул. 45 Стрелковой Дивизии, 101",
            "394075, г. Воронеж, ул. Краснознамённая, 22"});
            this.cmbPickup.Location = new System.Drawing.Point(145, 77);
            this.cmbPickup.Name = "cmbPickup";
            this.cmbPickup.Size = new System.Drawing.Size(211, 21);
            this.cmbPickup.TabIndex = 7;
            // 
            // cmbName
            // 
            this.cmbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Items.AddRange(new object[] {
            "Воронцова Екатерина Дмитриевна",
            "Кораблёв Андрей Игоревич",
            "Соболева Ирина Викторовна",
            "Мещеряков Денис Алексеевич",
            "Ткачёва Светлана Петровна",
            "Жилин Сергей Владимирович",
            "Панина Ольга Юрьевна",
            "Родионов Павел Сергеевич",
            "Швецова Наталья Ильинична",
            "Барсукова Татьяна Владимировна",
            "Головин Михаил Олегович",
            "Долгова Елена Викторовна",
            "Еремин Артём Павлович",
            "Журавлева Алина Сергеевна",
            "Завьялов Иван Николаевич",
            "Исаева Кристина Романовна",
            "Зяблов Дмитрий Романович",
            "Лох какой-то"});
            this.cmbName.Location = new System.Drawing.Point(145, 102);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(121, 21);
            this.cmbName.TabIndex = 8;
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblOrder.Location = new System.Drawing.Point(45, 206);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(108, 23);
            this.lblOrder.TabIndex = 10;
            this.lblOrder.Text = "Дата заказа:";
            // 
            // dateTimePickerOrder
            // 
            this.dateTimePickerOrder.Location = new System.Drawing.Point(49, 232);
            this.dateTimePickerOrder.Name = "dateTimePickerOrder";
            this.dateTimePickerOrder.Size = new System.Drawing.Size(146, 20);
            this.dateTimePickerOrder.TabIndex = 9;
            this.dateTimePickerOrder.Value = new System.DateTime(2026, 3, 11, 16, 25, 6, 0);
            // 
            // cmbArticle
            // 
            this.cmbArticle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArticle.FormattingEnabled = true;
            this.cmbArticle.Items.AddRange(new object[] {
            "Z001",
            "Z002",
            "Z003",
            "Z004",
            "Z005",
            "Z006",
            "Z007",
            "Z008",
            "Z009",
            "Z010",
            "Z011",
            "Z012",
            "Z013",
            "Z014",
            "Z015",
            "Z016",
            "Z017",
            "Z018",
            "Z019",
            "Z020",
            "Z021",
            "Z022",
            "Z023",
            "Z024",
            "Z025",
            "Z026",
            "Z027",
            "Z028",
            "Z029",
            "Z030",
            "Z032"});
            this.cmbArticle.Location = new System.Drawing.Point(543, 77);
            this.cmbArticle.Name = "cmbArticle";
            this.cmbArticle.Size = new System.Drawing.Size(119, 21);
            this.cmbArticle.TabIndex = 11;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.Location = new System.Drawing.Point(74, 123);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(65, 23);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "Статус:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Завершен",
            "Новый",
            "Отменен"});
            this.cmbStatus.Location = new System.Drawing.Point(145, 129);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 14;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnSave.Location = new System.Drawing.Point(604, 289);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 40);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Сохранить заказ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnBack.Location = new System.Drawing.Point(12, 289);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(101, 40);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(543, 103);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 20);
            this.numQuantity.TabIndex = 17;
            // 
            // OrderAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(727, 341);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbArticle);
            this.Controls.Add(this.lblOrder);
            this.Controls.Add(this.dateTimePickerOrder);
            this.Controls.Add(this.cmbName);
            this.Controls.Add(this.cmbPickup);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dateTimePickerDelivery);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblArticle);
            this.Controls.Add(this.lblPickup);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrderAddForm";
            this.Text = "Добавить заказ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.Label lblPickup;
        private System.Windows.Forms.Label lblArticle;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DateTimePicker dateTimePickerDelivery;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cmbPickup;
        private System.Windows.Forms.ComboBox cmbName;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.DateTimePicker dateTimePickerOrder;
        private System.Windows.Forms.ComboBox cmbArticle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.NumericUpDown numQuantity;
    }
}