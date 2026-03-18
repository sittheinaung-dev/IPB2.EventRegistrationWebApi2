using IPB2.EventRegistrationWindowForm.Features.Event;
using IPB2.EventRegistrationWindowForm.Features.Participant;
using IPB2.EventRegistrationWindowForm.Features.Registration;
using IPB2.EventRegistrationWindowForm.Features.Report;
using Microsoft.Extensions.DependencyInjection;

namespace IPB2.EventRegistrationWindowForm.Features.Main
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public MainForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void btnEvents_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<EventForm>();
            form.ShowDialog();
        }

        private void btnParticipants_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<ParticipantForm>();
            form.ShowDialog();
        }

        private void btnRegistrations_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<RegistrationForm>();
            form.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<ReportForm>();
            form.ShowDialog();
        }
    }
}
