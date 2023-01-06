namespace Dziekanat;

public partial class MainWindow : Form
{
    private List<Student> students = new List<Student>();
    public MainWindow()
    {
        InitializeComponent();

        students.Add(new Student()
        {
            Name = "Damian",
            Surname = "Zacheja",
            Index = "S3814"
        });

        students.Add(new Student()
        {
            Name = "Jêdrzej",
            Surname = "Czajkowski",
            Index = "S3215"
        });

        dgvStudents.DataSource = students;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        StudentDialog dlg = new StudentDialog();
        dlg.StartPosition = FormStartPosition.CenterParent;
        dlg.ShowDialog(this);
        if (dlg.student != null)
        {
            students.Add(dlg.student);
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = students;
        }
    }

    private void dgvStudents_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvStudents.SelectedRows.Count == 0) return;

        var student = dgvStudents.SelectedRows[0].DataBoundItem as Student;
        txtName.Text = student.Name;
        txtSurname.Text = student.Surname;
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (dgvStudents.SelectedRows.Count == 0) return;

        var student = dgvStudents.SelectedRows[0].DataBoundItem as Student;
        StudentDialog dlg = new StudentDialog(ref student);
        dlg.StartPosition = FormStartPosition.CenterParent;
        dlg.ShowDialog(this);

        if (dlg.student != null)
        {
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = students;
        }
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
        if (dgvStudents.SelectedRows.Count == 0) return;
        if (MessageBox.Show(
            "Czy na pewno chcesz usun¹æ rekord?",
            "Uwaga",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Warning) == DialogResult.OK)
        {
            var student = dgvStudents.SelectedRows[0].DataBoundItem as Student;
            students.Remove(student);
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = students;
        }

    }
}
