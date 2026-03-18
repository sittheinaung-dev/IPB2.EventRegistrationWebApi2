namespace IPB2.EventRegistrationWindowForm.Features.Participant
{
    partial class ParticipantForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvParticipants = new DataGridView();
            gbDetails = new GroupBox();
            btnDelete = new Button();
            btnClear = new Button();
            btnSave = new Button();
            lblPhone = new Label();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtName = new TextBox();
            lblName = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvParticipants).BeginInit();
            gbDetails.SuspendLayout();
            SuspendLayout();
            // 
            // dgvParticipants
            // 
            dgvParticipants.AllowUserToAddRows = false;
            dgvParticipants.AllowUserToDeleteRows = false;
            dgvParticipants.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvParticipants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvParticipants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvParticipants.Location = new Point(12, 12);
            dgvParticipants.MultiSelect = false;
            dgvParticipants.Name = "dgvParticipants";
            dgvParticipants.ReadOnly = true;
            dgvParticipants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParticipants.Size = new Size(560, 200);
            dgvParticipants.TabIndex = 0;
            dgvParticipants.CellClick += dgvParticipants_CellClick;
            // 
            // gbDetails
            // 
            gbDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbDetails.Controls.Add(btnDelete);
            gbDetails.Controls.Add(btnClear);
            gbDetails.Controls.Add(btnSave);
            gbDetails.Controls.Add(lblPhone);
            gbDetails.Controls.Add(txtPhone);
            gbDetails.Controls.Add(txtEmail);
            gbDetails.Controls.Add(lblEmail);
            gbDetails.Controls.Add(txtName);
            gbDetails.Controls.Add(lblName);
            gbDetails.Location = new Point(12, 218);
            gbDetails.Name = "gbDetails";
            gbDetails.Size = new Size(560, 150);
            gbDetails.TabIndex = 1;
            gbDetails.TabStop = false;
            gbDetails.Text = "Participant Details";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(460, 80);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 35);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(360, 80);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 35);
            btnClear.TabIndex = 9;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(260, 80);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 35);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(310, 33);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(41, 15);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "Phone";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(374, 30);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(180, 23);
            txtPhone.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(57, 80);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(15, 83);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            // 
            // txtName
            // 
            txtName.Location = new Point(57, 30);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(15, 33);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // ParticipantForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 381);
            Controls.Add(gbDetails);
            Controls.Add(dgvParticipants);
            Name = "ParticipantForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Participant Management";
            Load += ParticipantForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvParticipants).EndInit();
            gbDetails.ResumeLayout(false);
            gbDetails.PerformLayout();
            ResumeLayout(false);
        }

        private DataGridView dgvParticipants;
        private GroupBox gbDetails;
        private Button btnDelete;
        private Button btnClear;
        private Button btnSave;
        private Label lblPhone;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtName;
        private Label lblName;
    }
}
