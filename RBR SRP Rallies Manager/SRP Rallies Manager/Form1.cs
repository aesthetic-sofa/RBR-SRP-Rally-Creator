using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRP_Rallies_Manager
{
    public partial class Form1 : Form
    {
        CSV csv = new CSV();
        List<ValidCombo> availableStagesList = new List<ValidCombo>();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void availableStages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            // We set the starting directory correctly to plugins/TrainingDay, to help the user find the SRP files.
            string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string folderpath = dir + @"\plugins\TrainingDay\";
            openFileDialog1.InitialDirectory = folderpath;
            // Show the dialog that allows user to select a file, the 
            // call will result a value from the DialogResult enum
            // when the dialog is dismissed.
            DialogResult result = this.openFileDialog1.ShowDialog();
            // if a file is selected
            if (result == DialogResult.OK)
            {
                // Set the selected file URL to the textbox
                this.fileURLTextBox.Text = System.IO.Path.GetFileNameWithoutExtension(this.openFileDialog1.FileName);
            }
        }

        private void saveRallyButton_Click(object sender, EventArgs e)
        {
            string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string folderpath = dir + @"\plugins\TrainingDay\";
            saveFileDialog1.InitialDirectory = folderpath;

            DialogResult saveresult = saveFileDialog1.ShowDialog();
            if (saveresult == DialogResult.OK)
            {

            }
        }

        private void updateTrackList_Click(object sender, EventArgs e)
        {
            availableStagesList = csv.ReadCSV();
            //csv.writeCSV(availableStagesList, "testGUI.csv"); // Useful for debugging.
            availableStages.DataSource = csv.GenerateAvailableStagesList(availableStagesList);
            availableStagesGrid.DataSource = csv.GenerateAvailableStagesGrid(availableStagesList);
        }
    }
}
