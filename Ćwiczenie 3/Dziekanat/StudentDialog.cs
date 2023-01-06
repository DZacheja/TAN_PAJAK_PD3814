using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dziekanat;
public partial class StudentDialog : Form
{
    public Student student;
    private readonly string TRYB;
    public StudentDialog(ref Student s) : this()
    {
        student = s;
        txtName.Text = student.Name;
        txtSurname.Text = student.Surname;
        txtIndex.Text = student.Index;
        btnSave.Text = "Zapisz";
        TRYB = "edycję";

    }
    public StudentDialog()
    {
        InitializeComponent();
        TRYB = "dodawanie";
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Czy napewno chcesz zakończyć " + TRYB, "Uwaga", MessageBoxButtons.OKCancel) == DialogResult.OK)
            this.Close();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidData()) return;

        if(student == null)
        {
            student = new Student();
        }
        student.Name = txtName.Text;
        student.Surname = txtSurname.Text;
        student.Index = txtIndex.Text;

        MessageBox.Show("Pomyślnie ukończono " + TRYB);
        this.Close();
    }

    private bool ValidData()
    {
        if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtSurname.Text) || string.IsNullOrEmpty(txtIndex.Text))
        {
            MessageBox.Show("Uzupełnij wszystkie dane.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if(txtIndex.Text.Length != 5)
        {
            MessageBox.Show("Nieprawidłowa długość numeru indeksu", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (txtIndex.Text[0] != 'S')
        {
            MessageBox.Show("Indeks powinien zaczynać się od \"S\"", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }
}
