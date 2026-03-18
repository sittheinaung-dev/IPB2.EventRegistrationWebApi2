namespace IPB2.EventRegistrationWindowForm.Features.Registration
{
    partial class RegistrationForm
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
            dgvRegistrations = new DataGridView();
            gbDetails = new GroupBox();
            btnUpdateStatus = new Button();
            txtStatus = new TextBox();
            lblStatus = new Label();
            btnCancel = new Button();
            btnClear = new Button();
            btnRegister = new Button();
            cmbParticipant = new ComboBox();
            lblParticipant = new Label();
            cmbEvent = new ComboBox();
            lblEvent = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRegistrations).BeginInit();
            gbDetails.SuspendLayout();
            SuspendLayout();
            // 
            // dgvRegistrations
            // 
            dgvRegistrations.AllowUserToAddRows = false;
            dgvRegistrations.AllowUserToDeleteRows = false;
            dgvRegistrations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRegistrations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRegistrations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegistrations.Location = new Point(12, 12);
            dgvRegistrations.MultiSelect = false;
            dgvRegistrations.Name = "dgvRegistrations";
            dgvRegistrations.ReadOnly = true;
            dgvRegistrations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegistrations.Size = new Size(660, 200);
            dgvRegistrations.TabIndex = 0;
            dgvRegistrations.CellClick += dgvRegistrations_CellClick;
            // 
            // gbDetails
            // 
            gbDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbDetails.Controls.Add(btnUpdateStatus);
            gbDetails.Controls.Add(txtStatus);
            gbDetails.Controls.Add(lblStatus);
            gbDetails.Controls.Add(btnCancel);
            gbDetails.Controls.Add(btnClear);
            gbDetails.Controls.Add(btnRegister);
            gbDetails.Controls.Add(cmbParticipant);
            gbDetails.Controls.Add(lblParticipant);
            gbDetails.Controls.Add(cmbEvent);
            gbDetails.Controls.Add(lblEvent);
            gbDetails.Location = new Point(12, 218);
            gbDetails.Name = "gbDetails";
            gbDetails.Size = new Size(660, 180);
            gbDetails.TabIndex = 1;
            gbDetails.TabStop = false;
            gbDetails.Text = "Registration Details";
            // 
            // btnUpdateStatus
            // 
            btnUpdateStatus.Location = new Point(300, 132);
            btnUpdateStatus.Name = "btnUpdateStatus";
            btnUpdateStatus.Size = new Size(120, 30);
            btnUpdateStatus.TabIndex = 13;
            btnUpdateStatus.Text = "Update Status";
            btnUpdateStatus.UseVisualStyleBackColor = true;
            btnUpdateStatus.Click += btnUpdateStatus_Click;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(83, 80);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(197, 23);
            txtStatus.TabIndex = 11;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(15, 83);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 15);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Status";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(550, 130);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 35);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel Reg";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(440, 130);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 35);
            btnClear.TabIndex = 9;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(160, 130);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(120, 35);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "Register New";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // cmbParticipant
            // 
            cmbParticipant.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbParticipant.FormattingEnabled = true;
            cmbParticipant.Location = new Point(374, 30);
            cmbParticipant.Name = "cmbParticipant";
            cmbParticipant.Size = new Size(270, 23);
            cmbParticipant.TabIndex = 7;
            // 
            // lblParticipant
            // 
            lblParticipant.AutoSize = true;
            lblParticipant.Location = new Point(300, 33);
            lblParticipant.Name = "lblParticipant";
            lblParticipant.Size = new Size(64, 15);
            lblParticipant.TabIndex = 6;
            lblParticipant.Text = "Participant";
            // 
            // cmbEvent
            // 
            cmbEvent.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEvent.FormattingEnabled = true;
            cmbEvent.Location = new Point(80, 30);
            cmbEvent.Name = "cmbEvent";
            cmbEvent.Size = new Size(200, 23);
            cmbEvent.TabIndex = 1;
            // 
            // lblEvent
            // 
            lblEvent.AutoSize = true;
            lblEvent.Location = new Point(15, 33);
            lblEvent.Name = "lblEvent";
            lblEvent.Size = new Size(36, 15);
            lblEvent.TabIndex = 0;
            lblEvent.Text = "Event";
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 411);
            Controls.Add(gbDetails);
            Controls.Add(dgvRegistrations);
            Name = "RegistrationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registration Management";
            Load += RegistrationForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRegistrations).EndInit();
            gbDetails.ResumeLayout(false);
            gbDetails.PerformLayout();
            ResumeLayout(false);
        }

        private DataGridView dgvRegistrations;
        private GroupBox gbDetails;
        private Button btnCancel;
        private Button btnClear;
        private Button btnRegister;
        private ComboBox cmbParticipant;
        private Label lblParticipant;
        private ComboBox cmbEvent;
        private Label lblEvent;
        private TextBox txtStatus;
        private Label lblStatus;
        private Button btnUpdateStatus;
    }
}
