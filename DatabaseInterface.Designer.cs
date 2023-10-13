namespace GUI_C_
{
    partial class WindowManipulate
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowManipulate));
            this.lbID = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbID = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.lbDate = new System.Windows.Forms.Label();
            this.tbHospital = new System.Windows.Forms.TextBox();
            this.lbHospital = new System.Windows.Forms.Label();
            this.tbArrive = new System.Windows.Forms.TextBox();
            this.lbArrivel = new System.Windows.Forms.Label();
            this.tbMedicine = new System.Windows.Forms.TextBox();
            this.lbMedicine = new System.Windows.Forms.Label();
            this.tbPreQui = new System.Windows.Forms.TextBox();
            this.lbPreQui = new System.Windows.Forms.Label();
            this.tbDuringQui = new System.Windows.Forms.TextBox();
            this.lbDuringQui = new System.Windows.Forms.Label();
            this.lbAfterQui = new System.Windows.Forms.Label();
            this.tbAfterQui = new System.Windows.Forms.TextBox();
            this.tbObs = new System.Windows.Forms.TextBox();
            this.lbObs = new System.Windows.Forms.Label();
            this.visãoTabela = new System.Windows.Forms.DataGridView();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.visãoTabela)).BeginInit();
            this.SuspendLayout();
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.ForeColor = System.Drawing.Color.White;
            this.lbID.Location = new System.Drawing.Point(36, 26);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(24, 13);
            this.lbID.TabIndex = 0;
            this.lbID.Text = "ID: ";
            this.lbID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.ForeColor = System.Drawing.Color.White;
            this.lbName.Location = new System.Drawing.Point(36, 51);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(41, 13);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Nome: ";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(88)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(118, 302);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Deletar";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(88)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(198, 302);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.Add_Click);
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(118, 22);
            this.tbID.MaxLength = 4;
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(30, 20);
            this.tbID.TabIndex = 5;
            this.tbID.TextChanged += new System.EventHandler(this.tbID_TextChanged_1);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(118, 46);
            this.tbName.MaxLength = 50;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(237, 20);
            this.tbName.TabIndex = 6;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(88)))));
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(159, 331);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Limpar";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(88)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(38, 302);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Atualizar";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(88)))));
            this.btnSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSelect.FlatAppearance.BorderSize = 0;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.White;
            this.btnSelect.Location = new System.Drawing.Point(279, 302);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 10;
            this.btnSelect.Text = "Selecionar";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.Selecionar_Click);
            // 
            // tbDate
            // 
            this.tbDate.Location = new System.Drawing.Point(118, 70);
            this.tbDate.MaxLength = 10;
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(93, 20);
            this.tbDate.TabIndex = 12;
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.ForeColor = System.Drawing.Color.White;
            this.lbDate.Location = new System.Drawing.Point(36, 75);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(33, 13);
            this.lbDate.TabIndex = 11;
            this.lbDate.Text = "Data:";
            this.lbDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbHospital
            // 
            this.tbHospital.Location = new System.Drawing.Point(118, 95);
            this.tbHospital.MaxLength = 50;
            this.tbHospital.Name = "tbHospital";
            this.tbHospital.Size = new System.Drawing.Size(237, 20);
            this.tbHospital.TabIndex = 14;
            // 
            // lbHospital
            // 
            this.lbHospital.AutoSize = true;
            this.lbHospital.ForeColor = System.Drawing.Color.White;
            this.lbHospital.Location = new System.Drawing.Point(36, 100);
            this.lbHospital.Name = "lbHospital";
            this.lbHospital.Size = new System.Drawing.Size(48, 13);
            this.lbHospital.TabIndex = 13;
            this.lbHospital.Text = "Hospital:";
            this.lbHospital.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbArrive
            // 
            this.tbArrive.Location = new System.Drawing.Point(118, 119);
            this.tbArrive.MaxLength = 5;
            this.tbArrive.Name = "tbArrive";
            this.tbArrive.Size = new System.Drawing.Size(93, 20);
            this.tbArrive.TabIndex = 16;
            // 
            // lbArrivel
            // 
            this.lbArrivel.AutoSize = true;
            this.lbArrivel.ForeColor = System.Drawing.Color.White;
            this.lbArrivel.Location = new System.Drawing.Point(36, 124);
            this.lbArrivel.Name = "lbArrivel";
            this.lbArrivel.Size = new System.Drawing.Size(53, 13);
            this.lbArrivel.TabIndex = 15;
            this.lbArrivel.Text = "Chegada:";
            this.lbArrivel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbMedicine
            // 
            this.tbMedicine.Location = new System.Drawing.Point(118, 143);
            this.tbMedicine.MaxLength = 50;
            this.tbMedicine.Name = "tbMedicine";
            this.tbMedicine.Size = new System.Drawing.Size(237, 20);
            this.tbMedicine.TabIndex = 18;
            // 
            // lbMedicine
            // 
            this.lbMedicine.AutoSize = true;
            this.lbMedicine.ForeColor = System.Drawing.Color.White;
            this.lbMedicine.Location = new System.Drawing.Point(36, 148);
            this.lbMedicine.Name = "lbMedicine";
            this.lbMedicine.Size = new System.Drawing.Size(74, 13);
            this.lbMedicine.TabIndex = 17;
            this.lbMedicine.Text = "Medicamento:";
            this.lbMedicine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPreQui
            // 
            this.tbPreQui.Location = new System.Drawing.Point(118, 168);
            this.tbPreQui.MaxLength = 100;
            this.tbPreQui.Name = "tbPreQui";
            this.tbPreQui.Size = new System.Drawing.Size(237, 20);
            this.tbPreQui.TabIndex = 20;
            // 
            // lbPreQui
            // 
            this.lbPreQui.AutoSize = true;
            this.lbPreQui.ForeColor = System.Drawing.Color.White;
            this.lbPreQui.Location = new System.Drawing.Point(36, 173);
            this.lbPreQui.Name = "lbPreQui";
            this.lbPreQui.Size = new System.Drawing.Size(61, 13);
            this.lbPreQui.TabIndex = 19;
            this.lbPreQui.Text = "Pré Quimio:";
            this.lbPreQui.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbDuringQui
            // 
            this.tbDuringQui.Location = new System.Drawing.Point(118, 192);
            this.tbDuringQui.MaxLength = 100;
            this.tbDuringQui.Name = "tbDuringQui";
            this.tbDuringQui.Size = new System.Drawing.Size(237, 20);
            this.tbDuringQui.TabIndex = 22;
            // 
            // lbDuringQui
            // 
            this.lbDuringQui.AutoSize = true;
            this.lbDuringQui.ForeColor = System.Drawing.Color.White;
            this.lbDuringQui.Location = new System.Drawing.Point(36, 197);
            this.lbDuringQui.Name = "lbDuringQui";
            this.lbDuringQui.Size = new System.Drawing.Size(48, 13);
            this.lbDuringQui.TabIndex = 21;
            this.lbDuringQui.Text = "Durante:";
            this.lbDuringQui.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbAfterQui
            // 
            this.lbAfterQui.AutoSize = true;
            this.lbAfterQui.ForeColor = System.Drawing.Color.White;
            this.lbAfterQui.Location = new System.Drawing.Point(36, 221);
            this.lbAfterQui.Name = "lbAfterQui";
            this.lbAfterQui.Size = new System.Drawing.Size(28, 13);
            this.lbAfterQui.TabIndex = 23;
            this.lbAfterQui.Text = "Pós:";
            this.lbAfterQui.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbAfterQui
            // 
            this.tbAfterQui.Location = new System.Drawing.Point(118, 217);
            this.tbAfterQui.MaxLength = 100;
            this.tbAfterQui.Name = "tbAfterQui";
            this.tbAfterQui.Size = new System.Drawing.Size(237, 20);
            this.tbAfterQui.TabIndex = 24;
            // 
            // tbObs
            // 
            this.tbObs.Location = new System.Drawing.Point(118, 241);
            this.tbObs.MaxLength = 100;
            this.tbObs.Name = "tbObs";
            this.tbObs.Size = new System.Drawing.Size(237, 20);
            this.tbObs.TabIndex = 26;
            // 
            // lbObs
            // 
            this.lbObs.AutoSize = true;
            this.lbObs.ForeColor = System.Drawing.Color.White;
            this.lbObs.Location = new System.Drawing.Point(36, 243);
            this.lbObs.Name = "lbObs";
            this.lbObs.Size = new System.Drawing.Size(73, 13);
            this.lbObs.TabIndex = 25;
            this.lbObs.Text = "Observações:";
            this.lbObs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // visãoTabela
            // 
            this.visãoTabela.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(88)))));
            this.visãoTabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.visãoTabela.Location = new System.Drawing.Point(382, 24);
            this.visãoTabela.Margin = new System.Windows.Forms.Padding(2);
            this.visãoTabela.Name = "visãoTabela";
            this.visãoTabela.RowHeadersWidth = 51;
            this.visãoTabela.RowTemplate.Height = 24;
            this.visãoTabela.Size = new System.Drawing.Size(648, 330);
            this.visãoTabela.TabIndex = 27;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(88)))));
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.ForeColor = System.Drawing.Color.White;
            this.btnHelp.Location = new System.Drawing.Point(955, 359);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 28;
            this.btnHelp.Text = "Ajuda";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // WindowManipulate
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(34)))), ((int)(((byte)(50)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1054, 417);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.visãoTabela);
            this.Controls.Add(this.tbObs);
            this.Controls.Add(this.lbObs);
            this.Controls.Add(this.tbAfterQui);
            this.Controls.Add(this.lbAfterQui);
            this.Controls.Add(this.tbDuringQui);
            this.Controls.Add(this.lbDuringQui);
            this.Controls.Add(this.tbPreQui);
            this.Controls.Add(this.lbPreQui);
            this.Controls.Add(this.tbMedicine);
            this.Controls.Add(this.lbMedicine);
            this.Controls.Add(this.tbArrive);
            this.Controls.Add(this.lbArrivel);
            this.Controls.Add(this.tbHospital);
            this.Controls.Add(this.lbHospital);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WindowManipulate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pacientes Database Interface";
            this.TransparencyKey = System.Drawing.Color.White;
            ((System.ComponentModel.ISupportInitialize)(this.visãoTabela)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox tbDate;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.TextBox tbHospital;
        private System.Windows.Forms.Label lbHospital;
        private System.Windows.Forms.TextBox tbArrive;
        private System.Windows.Forms.Label lbArrivel;
        private System.Windows.Forms.TextBox tbMedicine;
        private System.Windows.Forms.Label lbMedicine;
        private System.Windows.Forms.TextBox tbPreQui;
        private System.Windows.Forms.Label lbPreQui;
        private System.Windows.Forms.TextBox tbDuringQui;
        private System.Windows.Forms.Label lbDuringQui;
        private System.Windows.Forms.Label lbAfterQui;
        private System.Windows.Forms.TextBox tbAfterQui;
        private System.Windows.Forms.TextBox tbObs;
        private System.Windows.Forms.Label lbObs;
        private System.Windows.Forms.DataGridView visãoTabela;
        private System.Windows.Forms.Button btnHelp;
    }
}

