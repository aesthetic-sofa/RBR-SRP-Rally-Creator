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
        // We initialise the needed objects in order to use all of their methods. 
        CSV csv = new CSV();
        List<CSV.StageNumberAndName> availableStagesList = new List<CSV.StageNumberAndName>();
        List<ValidCombo> trackList = new List<ValidCombo>();
        SRP srp = new SRP();
        List<stage> chosenStages = new List<stage>();
        // End of objects initialisation.

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

                // Read the data and translate.
                chosenStages = srp.ReadSRP(chosenStages, this.openFileDialog1.FileName);
                chosenStages = srp.RallyPartialToFull(chosenStages, srp.CountStages(this.openFileDialog1.FileName));
                chosenStages = srp.RallyNumberToFull(chosenStages, srp.CountStages(this.openFileDialog1.FileName));

                chosenStagesGrid.DataSource = chosenStages;

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

            //We read the TrackListing.csv file.
            trackList = csv.ReadCSV(); //This will be needed to validate the combos.
            availableStagesList = csv.GenerateAvailableStagesGrid(trackList); //This is needed for display in the DataGridView.

            //csv.writeCSV(availableStagesList, "testGUI.csv"); // Useful for debugging.

            // We populate the DataGridView
            availableStagesGrid.DataSource = availableStagesList;
            availableStagesGrid.Columns[0].HeaderText = "ID";
            availableStagesGrid.Columns[1].HeaderText = "Name";
            availableStagesGrid.AutoResizeColumns();

        }

        private void sortByName_Click(object sender, EventArgs e)
        {
            availableStagesList = csv.SortStagesByName(availableStagesList);
            availableStagesGrid.DataSource = availableStagesList;
        }

        private void sortByNumber_Click(object sender, EventArgs e)
        {
            availableStagesList = csv.SortStagesByNumber(availableStagesList);
            availableStagesGrid.DataSource = availableStagesList;
        }
    }
}
