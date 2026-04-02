using IPB2.EventRegistration.Domain.Features.Participant;

namespace IPB2.EventRegistrationWindowForm.Features.Participant
{
    public partial class ParticipantForm : Form
    {
        private readonly ParticipantServices _participantServices;
        private int? _selectedParticipantId = null;

        public ParticipantForm(ParticipantServices participantServices)
        {
            InitializeComponent();
            _participantServices = participantServices;
        }

        private async void ParticipantForm_Load(object sender, EventArgs e)
        {
            await LoadParticipants();
        }

        private async Task LoadParticipants()
        {
            var result = await _participantServices.GetParticipants(new ParticipantListRequest());
            if (result.IsSuccess)
            {
                dgvParticipants.DataSource = result.Data;
                if (dgvParticipants.Columns["ParticipantId"] != null) dgvParticipants.Columns["ParticipantId"].Visible = false;
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
            txtEmail.Clear();
            txtPhone.Clear();
            _selectedParticipantId = null;
            dgvParticipants.ClearSelection();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter participant name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedParticipantId == null)
            {
                // Create
                var request = new ParticipantCreateRequest
                {
                    ParticipantName = txtName.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text
                };
                var result = await _participantServices.CreateParticipant(request);
                MessageBox.Show(result.Message);
            }
            else
            {
                // Update
                var request = new ParticipantUpdateRequest
                {
                    ParticipantId = _selectedParticipantId.Value,
                    ParticipantName = txtName.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text
                };
                var result = await _participantServices.UpdateParticipant(request);
                MessageBox.Show(result.Message);
            }

            ClearInputs();
            await LoadParticipants();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedParticipantId == null)
            {
                MessageBox.Show("Please select a participant to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this participant?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            var result = await _participantServices.DeleteParticipant(new ParticipantDeleteRequest { ParticipantId = _selectedParticipantId.Value });
            MessageBox.Show(result.Message);

            ClearInputs();
            await LoadParticipants();
        }

        private void dgvParticipants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvParticipants.Rows[e.RowIndex];
                _selectedParticipantId = (int)row.Cells["ParticipantId"].Value;
                txtName.Text = row.Cells["ParticipantName"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtPhone.Text = row.Cells["Phone"].Value?.ToString();
            }
        }
    }
}
