namespace IPB2.EventRegistrationWindowForm.Features.Event
{
    partial class EventForm
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
            dgvEvents = new DataGridView();
            gbDetails = new GroupBox();
            btnDelete = new Button();
            btnClear = new Button();
            btnSave = new Button();
            dtpDate = new DateTimePicker();
            lblStatus = new Label();
            txtStatus = new TextBox();
            lblDate = new Label();
            txtLocation = new TextBox();
            lblLocation = new Label();
            txtName = new TextBox();
            lblName = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).BeginInit();
            gbDetails.SuspendLayout();
            SuspendLayout();
            // 
            // dgvEvents
            // 
            dgvEvents.AllowUserToAddRows = false;
            dgvEvents.AllowUserToDeleteRows = false;
            dgvEvents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEvents.Location = new Point(12, 12);
            dgvEvents.MultiSelect = false;
            dgvEvents.Name = "dgvEvents";
            dgvEvents.ReadOnly = true;
            dgvEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEvents.Size = new Size(560, 200);
            dgvEvents.TabIndex = 0;
            dgvEvents.CellClick += dgvEvents_CellClick;
            // 
            // gbDetails
            // 
            gbDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbDetails.Controls.Add(btnDelete);
            gbDetails.Controls.Add(btnClear);
            gbDetails.Controls.Add(btnSave);
            gbDetails.Controls.Add(dtpDate);
            gbDetails.Controls.Add(lblStatus);
            gbDetails.Controls.Add(txtStatus);
            gbDetails.Controls.Add(lblDate);
            gbDetails.Controls.Add(txtLocation);
            gbDetails.Controls.Add(lblLocation);
            gbDetails.Controls.Add(txtName);
            gbDetails.Controls.Add(lblName);
            gbDetails.Location = new Point(12, 218);
            gbDetails.Name = "gbDetails";
            gbDetails.Size = new Size(560, 180);
            gbDetails.TabIndex = 1;
            gbDetails.TabStop = false;
            gbDetails.Text = "Event Details";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(460, 130);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 35);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(350, 130);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 35);
            btnClear.TabIndex = 9;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(240, 130);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 35);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(374, 30);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(180, 23);
            dtpDate.TabIndex = 7;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(310, 83);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 15);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Status";
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(374, 80);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(180, 23);
            txtStatus.TabIndex = 5;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(310, 33);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(31, 15);
            lblDate.TabIndex = 4;
            lblDate.Text = "Date";
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(80, 80);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(200, 23);
            txtLocation.TabIndex = 3;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(15, 83);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(53, 15);
            lblLocation.TabIndex = 2;
            lblLocation.Text = "Location";
            // 
            // txtName
            // 
            txtName.Location = new Point(80, 30);
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
            // EventForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 411);
            Controls.Add(gbDetails);
            Controls.Add(dgvEvents);
            Name = "EventForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Event Management";
            Load += EventForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEvents).EndInit();
            gbDetails.ResumeLayout(false);
            gbDetails.PerformLayout();
            ResumeLayout(false);
        }

        private DataGridView dgvEvents;
        private GroupBox gbDetails;
        private Button btnDelete;
        private Button btnClear;
        private Button btnSave;
        private DateTimePicker dtpDate;
        private Label lblStatus;
        private TextBox txtStatus;
        private Label lblDate;
        private TextBox txtLocation;
        private Label lblLocation;
        private TextBox txtName;
        private Label lblName;
    }
}
