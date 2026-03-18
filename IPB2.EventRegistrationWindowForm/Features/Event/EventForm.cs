using IPB2.EventRegistrationWebApi.Features.Event;

namespace IPB2.EventRegistrationWindowForm.Features.Event
{
    public partial class EventForm : Form
    {
        private readonly EventServices _eventServices;
        private int? _selectedEventId = null;

        public EventForm(EventServices eventServices)
        {
            InitializeComponent();
            _eventServices = eventServices;
        }

        private async void EventForm_Load(object sender, EventArgs e)
        {
            await LoadEvents();
        }

        private async Task LoadEvents()
        {
            var result = await _eventServices.GetEvents(new EventListRequest());
            if (result.IsSuccess)
            {
                dgvEvents.DataSource = result.Data;
                if (dgvEvents.Columns["EventId"] != null) dgvEvents.Columns["EventId"].Visible = false;
            }
            else
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtLocation.Clear();
            dtpDate.Value = DateTime.Now;
            txtStatus.Text = "Active";
            _selectedEventId = null;
            dgvEvents.ClearSelection();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter event name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedEventId == null)
            {
                // Create
                var request = new EventCreateRequest
                {
                    EventName = txtName.Text,
                    Location = txtLocation.Text,
                    EventDate = DateOnly.FromDateTime(dtpDate.Value),
                    Status = txtStatus.Text
                };
                var result = await _eventServices.CreateEvent(request);
                MessageBox.Show(result.Message);
            }
            else
            {
                // Update
                var request = new EventUpdateRequest
                {
                    EventId = _selectedEventId.Value,
                    EventName = txtName.Text,
                    Location = txtLocation.Text,
                    EventDate = DateOnly.FromDateTime(dtpDate.Value),
                    Status = txtStatus.Text
                };
                var result = await _eventServices.UpdateEvent(request);
                MessageBox.Show(result.Message);
            }

            ClearInputs();
            await LoadEvents();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedEventId == null)
            {
                MessageBox.Show("Please select an event to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this event?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            var result = await _eventServices.DeleteEvent(new EventDeleteRequest { EventId = _selectedEventId.Value });
            MessageBox.Show(result.Message);

            ClearInputs();
            await LoadEvents();
        }

        private void dgvEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvEvents.Rows[e.RowIndex];
                _selectedEventId = (int)row.Cells["EventId"].Value;
                txtName.Text = row.Cells["EventName"].Value?.ToString();
                txtLocation.Text = row.Cells["Location"].Value?.ToString();
                if (row.Cells["EventDate"].Value is DateOnly date)
                    dtpDate.Value = date.ToDateTime(TimeOnly.MinValue);
                txtStatus.Text = row.Cells["Status"].Value?.ToString();
            }
        }
    }
}
