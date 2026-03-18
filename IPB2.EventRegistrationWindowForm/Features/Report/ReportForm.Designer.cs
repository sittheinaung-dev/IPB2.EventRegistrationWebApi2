namespace IPB2.EventRegistrationWindowForm.Features.Report
{
    partial class ReportForm
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
            dgvReports = new DataGridView();
            gbReports = new GroupBox();
            btnSearchEvents = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            btnAvailableEvents = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
            gbReports.SuspendLayout();
            SuspendLayout();
            // 
            // dgvReports
            // 
            dgvReports.AllowUserToAddRows = false;
            dgvReports.AllowUserToDeleteRows = false;
            dgvReports.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReports.Location = new Point(12, 120);
            dgvReports.Name = "dgvReports";
            dgvReports.ReadOnly = true;
            dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReports.Size = new Size(760, 329);
            dgvReports.TabIndex = 0;
            // 
            // gbReports
            // 
            gbReports.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbReports.Controls.Add(btnSearchEvents);
            gbReports.Controls.Add(txtSearch);
            gbReports.Controls.Add(lblSearch);
            gbReports.Controls.Add(btnAvailableEvents);
            gbReports.Location = new Point(12, 12);
            gbReports.Name = "gbReports";
            gbReports.Size = new Size(760, 100);
            gbReports.TabIndex = 1;
            gbReports.TabStop = false;
            gbReports.Text = "Report Options";
            // 
            // btnSearchEvents
            // 
            btnSearchEvents.Location = new Point(550, 40);
            btnSearchEvents.Name = "btnSearchEvents";
            btnSearchEvents.Size = new Size(130, 30);
            btnSearchEvents.TabIndex = 3;
            btnSearchEvents.Text = "Search Events";
            btnSearchEvents.UseVisualStyleBackColor = true;
            btnSearchEvents.Click += btnSearchEvents_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(330, 40);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 23);
            txtSearch.TabIndex = 2;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(270, 43);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(42, 15);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search";
            // 
            // btnAvailableEvents
            // 
            btnAvailableEvents.Location = new Point(15, 30);
            btnAvailableEvents.Name = "btnAvailableEvents";
            btnAvailableEvents.Size = new Size(150, 55);
            btnAvailableEvents.TabIndex = 0;
            btnAvailableEvents.Text = "Get Available Events";
            btnAvailableEvents.UseVisualStyleBackColor = true;
            btnAvailableEvents.Click += btnAvailableEvents_Click;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(gbReports);
            Controls.Add(dgvReports);
            Name = "ReportForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "System Reports";
            Load += ReportForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
            gbReports.ResumeLayout(false);
            gbReports.PerformLayout();
            ResumeLayout(false);
        }

        private DataGridView dgvReports;
        private GroupBox gbReports;
        private Button btnSearchEvents;
        private TextBox txtSearch;
        private Label lblSearch;
        private Button btnAvailableEvents;
    }
}
