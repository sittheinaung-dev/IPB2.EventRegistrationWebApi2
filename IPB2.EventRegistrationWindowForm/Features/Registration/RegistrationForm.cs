using IPB2.EventRegistration.Domain.Features.Event;
using IPB2.EventRegistration.Domain.Features.Participant;
using IPB2.EventRegistration.Domain.Features.Registration;

namespace IPB2.EventRegistrationWindowForm.Features.Registration
{
    public partial class RegistrationForm : Form
    {
        private readonly RegistrationServices _registrationServices;
        private readonly EventServices _eventServices;
        private readonly ParticipantServices _participantServices;
        private int? _selectedRegistrationId = null;

        public RegistrationForm(
            RegistrationServices registrationServices,
            EventServices eventServices,
            ParticipantServices participantServices)
        {
            InitializeComponent();
            _registrationServices = registrationServices;
            _eventServices = eventServices;
            _participantServices = participantServices;
        }

        private async void RegistrationForm_Load(object sender, EventArgs e)
        {
            await LoadCombos();
            await LoadRegistrations();
        }

        private async Task LoadCombos()
        {
            var events = await _eventServices.GetEvents(new EventListRequest());
            if (events.IsSuccess)
            {
                cmbEvent.DataSource = events.Data;
                cmbEvent.DisplayMember = "EventName";
                cmbEvent.ValueMember = "EventId";
            }

            var participants = await _participantServices.GetParticipants(new ParticipantListRequest());
            if (participants.IsSuccess)
            {
                cmbParticipant.DataSource = participants.Data;
                cmbParticipant.DisplayMember = "ParticipantName";
                cmbParticipant.ValueMember = "ParticipantId";
            }
        }

        private async Task LoadRegistrations()
        {
            var result = await _registrationServices.GetRegistrations(new RegistrationListRequest());
            if (result.IsSuccess)
            {
                dgvRegistrations.DataSource = result.Data;
                if (dgvRegistrations.Columns["RegistrationId"] != null) dgvRegistrations.Columns["RegistrationId"].Visible = false;
                if (dgvRegistrations.Columns["EventId"] != null) dgvRegistrations.Columns["EventId"].Visible = false;
                if (dgvRegistrations.Columns["ParticipantId"] != null) dgvRegistrations.Columns["ParticipantId"].Visible = false;
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
            cmbEvent.SelectedIndex = -1;
            cmbParticipant.SelectedIndex = -1;
            txtStatus.Clear();
            _selectedRegistrationId = null;
            dgvRegistrations.ClearSelection();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (cmbEvent.SelectedValue == null || cmbParticipant.SelectedValue == null)
            {
                MessageBox.Show("Please select both Event and Participant.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var request = new RegistrationCreateRequest
            {
                EventId = (int)cmbEvent.SelectedValue,
                ParticipantId = (int)cmbParticipant.SelectedValue
            };

            var result = await _registrationServices.RegisterParticipant(request);
            MessageBox.Show(result.Message);

            ClearInputs();
            await LoadRegistrations();
        }

        private async void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (_selectedRegistrationId == null)
            {
                MessageBox.Show("Please select a registration to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var request = new RegistrationUpdateRequest
            {
                RegistrationId = _selectedRegistrationId.Value,
                Status = txtStatus.Text
            };

            var result = await _registrationServices.UpdateRegistration(request);
            MessageBox.Show(result.Message);

            ClearInputs();
            await LoadRegistrations();
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            if (_selectedRegistrationId == null)
            {
                MessageBox.Show("Please select a registration to cancel.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to cancel this registration?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            var result = await _registrationServices.CancelRegistration(new RegistrationCancelRequest { RegistrationId = _selectedRegistrationId.Value });
            MessageBox.Show(result.Message);

            ClearInputs();
            await LoadRegistrations();
        }

        private void dgvRegistrations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvRegistrations.Rows[e.RowIndex];
                _selectedRegistrationId = (int)row.Cells["RegistrationId"].Value;
                cmbEvent.SelectedValue = row.Cells["EventId"].Value;
                cmbParticipant.SelectedValue = row.Cells["ParticipantId"].Value;
                txtStatus.Text = row.Cells["Status"].Value?.ToString();
            }
        }
    }
}
