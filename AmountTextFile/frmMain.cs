using OperationLibrary;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmountTextFile
{
    public partial class frmMain : Form
    {
        private ValidateInputData validateInputData = new ValidateInputData();
        private SplitInputData splitInputData = new SplitInputData();
        private DataTable dataInput = new DataTable();
        private DataTable dataFormat = new DataTable();
        private BindingSource openBinding = new BindingSource();
        private BindingSource formatBinding = new BindingSource();
        private string folderSavingPath = string.Empty;
        
        public frmMain()
        {
            InitializeComponent();
            storeComboBox.SelectedIndex = 0;
            dataInput.Columns.Add("CODIGO", typeof(string));
            dataInput.Columns.Add("CANTIDAD", typeof(string));
            dataFormat.Columns.Add("CODIGO", typeof(string));
            dataFormat.Columns.Add("CANTIDAD", typeof(string));
        }

        private async void openTextButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = $"text|*.txt";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (validateInputData.ValidateFolderSavingPath(this.folderSavingPath) == false)
                {
                    ;
                }
                else if (true == await validateInputData.ValidateFileInfo(openFileDialog.FileName, storeComboBox.SelectedItem.ToString(), dataInput))
                {
                    BindingOpenDGV();
                    StyleOpenDGV();

                    if (true == await splitInputData.SplitValuesPerLine(dataInput, dataFormat, storeComboBox.SelectedItem.ToString(), this.folderSavingPath))
                    {
                        BindingFormatDGV();
                        StyleFormatDGV();
                        MessageBox.Show("Archivos guardados en la carpeta "  + this.folderSavingPath, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void BindingOpenDGV()
        {
            openBinding.DataSource = dataInput;
            openDGV.AutoGenerateColumns = true;
            openDGV.DataSource = openBinding;
            openDGV.Refresh();

        }

        private void StyleOpenDGV()
        {
            openDGV.Columns[0].Width = 200;
            openDGV.Columns[1].Width = 200;
        }

        private void BindingFormatDGV()
        {
            formatBinding.DataSource = dataFormat;
            formatedDGV.AutoGenerateColumns = true;
            formatedDGV.DataSource = formatBinding;
            formatedDGV.Refresh();
        }

        private void StyleFormatDGV()
        {
            formatedDGV.Columns[0].Width = 200;
            formatedDGV.Columns[1].Width = 200;
        }

        private void selectFolderButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    this.folderSavingPath = fbd.SelectedPath;
                    folderSavingTextBox.Text = fbd.SelectedPath;
                }
            }
        }
    }
}
