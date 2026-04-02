using IPB2.EventRegistration.Domain.Features.Event;
using IPB2.EventRegistration.Domain.Features.Report;

namespace IPB2.EventRegistrationWindowForm.Features.Report
{
    public partial class ReportForm : Form
    {
        private readonly ReportServices _reportServices;

        public ReportForm(ReportServices reportServices)
        {
            InitializeComponent();
            _reportServices = reportServices;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            // No initial loading needed currently
        }

        private async void btnAvailableEvents_Click(object sender, EventArgs e)
        {
            var result = await _reportServices.GetAvailableEvents(new AvailableEventsRequest());
            DisplayResult(result.IsSuccess, result.Message, result.Data);
        }

        private async void btnSearchEvents_Click(object sender, EventArgs e)
        {
            var request = new SearchEventsRequest { SearchTerm = txtSearch.Text };
            var result = await _reportServices.SearchEvents(request);
            DisplayResult(result.IsSuccess, result.Message, result.Data);
        }

        private void DisplayResult(bool isSuccess, string? message, object? data)
        {
            if (isSuccess)
            {
                dgvReports.DataSource = data;
            }
            else
            {
                MessageBox.Show(message ?? "Unknown error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvReports.DataSource = null;
            }
        }
    }
}
