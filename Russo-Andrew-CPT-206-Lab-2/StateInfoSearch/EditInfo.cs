using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SearchLibrary2;

namespace StateInfoSearch
{
    public partial class EditInfo : Form
    {
        // Public variables go here
        public StateDBDataContext si = new StateDBDataContext();
        //public State s = new State();
        public string selState { get; set; }

        public EditInfo()
        {
            InitializeComponent();
        }

        private void EditInfo_Load(object sender, EventArgs e)
        {
            DisplayCurrentInfo(); // Load with current data filled in.
        }

        public void DisplayCurrentInfo()
        {
            //var nam = from s in si.States
            //              where s.StateName == selState
            //              select s;

            var nam = si.States.Where(s => s.StateName == selState);

            curStateNameTextBox.Text = string.Join("", nam.Select(s => string.Format("{0}", s.StateName)));
            curPopTextBox.Text = string.Join("", nam.Select(s => string.Format("{0}", s.Population)));
            curCapTextBox.Text = string.Join("", nam.Select(s => string.Format("{0}", s.Capital)));
            curCity1TextBox.Text = string.Join("", nam.Select(s => string.Format("{0}", s.City1)));
            curCity2TextBox.Text = string.Join("", nam.Select(s => string.Format("{0}", s.City2)));
            curCity3TextBox.Text = string.Join("", nam.Select(s => string.Format("{0}", s.City3)));
            curFlagDescTextBox.Text = string.Join("", nam.Select(s => string.Format("{0}", s.Flag)));
            curColorsTextBox.Text = string.Join("", nam.Select(s => string.Format("{0}", s.Colors)));
            curBirdTextBox.Text = string.Join("", nam.Select(s => string.Format("{0}", s.Bird)));
            curFlowerTextBox.Text = string.Join("", nam.Select(s => string.Format("{0}", s.Flower)));
            curIncomeTextBox.Text = string.Join("", nam.Select(s => string.Format("{0}", s.Median_Income)));
            curITJobsTextBox.Text = string.Join("", nam.Select(s => string.Format("{0}", s.Comp_Jobs)));


        } // End DisplayCurrentInfo()

        private void okayButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void submitChangesButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(editStateNameTextBox.Text) &&
                string.IsNullOrWhiteSpace(editPopTextBox.Text) &&
                string.IsNullOrWhiteSpace(editCapTextBox.Text) &&
                string.IsNullOrWhiteSpace(editCity1TextBox.Text) &&
                string.IsNullOrWhiteSpace(editCity2TextBox.Text) &&
                string.IsNullOrWhiteSpace(editCity3TextBox.Text) &&
                string.IsNullOrWhiteSpace(editFlagDescTextBox.Text) &&
                string.IsNullOrWhiteSpace(editColorsTextBox.Text) &&
                string.IsNullOrWhiteSpace(editBirdTextBox.Text) &&
                string.IsNullOrWhiteSpace(editFlowerTextBox.Text) &&
                string.IsNullOrWhiteSpace(editIncomeTextBox.Text) &&
                string.IsNullOrWhiteSpace(editITJobsTextBox.Text)) // If all boxes are empty prompt user to input changes to make.
            {
                MessageBox.Show("Please enter data into fields you wish to change.");
            }
            else // If there is any data in any box.
            {
                // MessageBox to confirm. Should be updated to show the changes that are being made, then allow the user to confirm or cancel

                var message = "Would you like to replace the data with the data you have entered?" +
                    "\nNOTE: This will only replace data in fields that you have entered replacement information for." +
                    "\nAny fields left blank will not be affected.";
                var title = "Alter Data?";
                var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                switch (result)
                {
                    case DialogResult.Yes:
                        UpdateStateInfo();
                        this.Close(); // Close the form only after changes made and are accepted.
                        break;

                    case DialogResult.No:
                        MessageBox.Show("No changes were made to the table.");
                        break;

                    default:
                        MessageBox.Show("Nothing was pressed?!?!");
                        break;
                }
            } // End else where data exists
            
        } // End submitChangesButton_Click

        public void UpdateStateInfo() // This isn't working for some reason.
        {
            // Valid codes from ContainsValidData are:
            // 1 for letters and spaces.
            // 2 for digits.
            // All other return values are invalid.

            State s = si.States.Single(p => p.StateName == selState);

            // Only using 'if' statements since i only want it to step out and attempt an update once for each iteration.

            if (!string.IsNullOrWhiteSpace(editStateNameTextBox.Text) &&
                editStateNameTextBox.Text.ContainsValidData() == 1)
            {
                try
                {
                    s.StateName = editStateNameTextBox.Text;
                    si.SubmitChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error: {e}\nUnable to update state name.");
                }

            }
            if (!string.IsNullOrWhiteSpace(editPopTextBox.Text) &&
                editPopTextBox.Text.ContainsValidData() == 2 && // Since we are using TryParse next this might be a bit redundant
                double.TryParse(editPopTextBox.Text, out double pop))
            {
                try
                {
                    s.Population = pop;
                    si.SubmitChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error: {e}\nUnable to update state population.");
                }

            }
            if (!string.IsNullOrWhiteSpace(editCapTextBox.Text) &&
                editCapTextBox.Text.ContainsValidData() == 1)
            {
                try
                {
                    s.Capital = editCapTextBox.Text;
                    si.SubmitChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error: {e}\nUnable to update state capital.");
                }

            }
            if (!string.IsNullOrWhiteSpace(editCity1TextBox.Text) &&
                editCity1TextBox.Text.ContainsValidData() == 1)
            {
                try
                {
                    s.City1 = editCity1TextBox.Text;
                    si.SubmitChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error: {e}\nUnable to update the city with the highest population.");
                }

            }
            if (!string.IsNullOrWhiteSpace(editCity2TextBox.Text) &&
                editCity2TextBox.Text.ContainsValidData() == 1)
            {
                try
                {
                    s.City2 = editCity2TextBox.Text;
                    si.SubmitChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error: {e}\nUnable to update the city with the second highest population.");
                }

            }
            if (!string.IsNullOrWhiteSpace(editCity3TextBox.Text) &&
                editCity3TextBox.Text.ContainsValidData() == 1 )
            {
                try
                {
                    s.City3 = editCity3TextBox.Text;
                    si.SubmitChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error: {e}\nUnable to update the city with the third highest population.");
                }

            }
            if (!string.IsNullOrWhiteSpace(editFlagDescTextBox.Text) &&
                editFlagDescTextBox.Text.ContainsValidData() == 1)
            {
                try
                {
                    s.Flag = editFlagDescTextBox.Text;
                    si.SubmitChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error: {e}\nUnable to update flag description.");
                }

            }
            if (!string.IsNullOrWhiteSpace(editColorsTextBox.Text) &&
                editColorsTextBox.Text.ContainsValidData() == 1)
            {
                try
                {
                    s.Colors = editColorsTextBox.Text;
                    si.SubmitChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error: {e}\nUnable to update state color(s).");
                }

            }
            if (!string.IsNullOrWhiteSpace(editBirdTextBox.Text) &&
                editBirdTextBox.Text.ContainsValidData() == 1)
            {
                try
                {
                    s.Bird = editBirdTextBox.Text;
                    si.SubmitChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error: {e}\nUnable to update state bird.");
                }

            }
            if (!string.IsNullOrWhiteSpace(editFlowerTextBox.Text) &&
                editFlowerTextBox.Text.ContainsValidData() == 1)
            {
                try
                {
                    s.Flower = editFlowerTextBox.Text;
                    si.SubmitChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error: {e}\nUnable to update staet flower.");
                }

            }
            if (!string.IsNullOrWhiteSpace(editIncomeTextBox.Text) &&
                editIncomeTextBox.Text.ContainsValidData() == 2 &&
                decimal.TryParse(editIncomeTextBox.Text, out decimal income))
            {
                try
                {
                    s.Median_Income = income;
                    si.SubmitChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error: {e}\nUnable to update state median income.");
                }

            }
            if (!string.IsNullOrWhiteSpace(editITJobsTextBox.Text) &&
                editITJobsTextBox.Text.ContainsValidData() == 2 &&
                double.TryParse(editITJobsTextBox.Text, out double itJobs))
            {
                try
                {
                    s.Comp_Jobs = itJobs;
                    si.SubmitChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error: {e}\nUnable to update number of IT jobs in the state.");
                }

            }
            
        } // End UpdateStateInfo()
    }
}
