namespace IPB2.EventRegistrationWindowForm.Features.Main
{
    partial class MainForm
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
            btnEvents = new Button();
            btnParticipants = new Button();
            btnRegistrations = new Button();
            btnReports = new Button();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // btnEvents
            // 
            btnEvents.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEvents.Location = new Point(50, 100);
            btnEvents.Name = "btnEvents";
            btnEvents.Size = new Size(200, 60);
            btnEvents.TabIndex = 0;
            btnEvents.Text = "Manage Events";
            btnEvents.UseVisualStyleBackColor = true;
            btnEvents.Click += btnEvents_Click;
            // 
            // btnParticipants
            // 
            btnParticipants.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnParticipants.Location = new Point(300, 100);
            btnParticipants.Name = "btnParticipants";
            btnParticipants.Size = new Size(200, 60);
            btnParticipants.TabIndex = 1;
            btnParticipants.Text = "Manage Participants";
            btnParticipants.UseVisualStyleBackColor = true;
            btnParticipants.Click += btnParticipants_Click;
            // 
            // btnRegistrations
            // 
            btnRegistrations.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRegistrations.Location = new Point(50, 200);
            btnRegistrations.Name = "btnRegistrations";
            btnRegistrations.Size = new Size(200, 60);
            btnRegistrations.TabIndex = 2;
            btnRegistrations.Text = "Manage Registrations";
            btnRegistrations.UseVisualStyleBackColor = true;
            btnRegistrations.Click += btnRegistrations_Click;
            // 
            // btnReports
            // 
            btnReports.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnReports.Location = new Point(300, 200);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(200, 60);
            btnReports.TabIndex = 3;
            btnReports.Text = "View Reports";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(130, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 32);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "Event Registration System";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 320);
            Controls.Add(lblTitle);
            Controls.Add(btnReports);
            Controls.Add(btnRegistrations);
            Controls.Add(btnParticipants);
            Controls.Add(btnEvents);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnEvents;
        private Button btnParticipants;
        private Button btnRegistrations;
        private Button btnReports;
        private Label lblTitle;
    }
}
