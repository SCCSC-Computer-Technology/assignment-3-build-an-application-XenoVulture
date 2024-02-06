// Andrew Russo
// CPT-206-A80S
// Lab 2

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SearchLibrary2;

namespace StateInfoSearch
{
    public partial class SearchState : Form
    {
        // Public variables go here.
        public string pick = "";

        public const int numOfStates = 50; // Needed to make array for the combobox, if new states are added increase this number to match correct num of states.

        // Create the data context object.
        public StateDBDataContext si = new StateDBDataContext(); // For changes to stick i need to redo this everytime I organiz the grid?

        public string[] stateSelected = new string[numOfStates]; // Makes and array for our states, later we'll populate this and then iterate through it to populate
                                                                 // the combobox. After that we'll use it to look up the selected state and pull its info.
        

        public SearchState()
        {
            InitializeComponent();
        }

        private void SearchState_Load(object sender, EventArgs e)
        {
            StateDBDataContext si = new StateDBDataContext();
            // Prime our check boxes so something starts selected.
            ascRadioButton.Checked = true;
            searchStateRadioButton.Checked = true;
            searchPopulationRadioButton.Checked = true;

            // Get all the state objects from the database.
            var results = si.States;

            // Assign the results of the query to the DataGridView control.
            stateDataGridView.DataSource = results;

            // Populate the stateSelected array
            stateSelected = si.States.Select(s => s.StateName).ToArray(); // Sort state names into an array.

            // Look into this later.
            //pickStateComboBox.Items.AddRange(stateSelected);


            for (int i = 0; i < numOfStates; i++)// Itterate through state names and add them to the drop down list.
            {
                pickStateComboBox.Items.Add(stateSelected[i]);
            }

        } // end form_load


        private void sortStateButton_Click(object sender, EventArgs e)
        {
            StateDBDataContext si = new StateDBDataContext();
            // Sets the default behavior to organizing by State name in ascending order.
            var results = from s in si.States
                          orderby s.StateName ascending
                          select s;

            if (!ascRadioButton.Checked) // If ascending button is NOT selected (there for descending IS selected).
            {
                results = from s in si.States
                          orderby s.StateName descending
                          select s;
            }

            stateDataGridView.DataSource = results;
        } // End sortStateButton_Click

        private void sortPopButton_Click(object sender, EventArgs e)
        {
            StateDBDataContext si = new StateDBDataContext();
            // Sets the default behavior to organizing by population in ascending order.
            var results = from s in si.States
                          orderby s.Population ascending
                          select s;

            if (!ascRadioButton.Checked) // If ascending button is NOT selected (there for descending IS selected).
            {
                results = from s in si.States
                          orderby s.Population descending
                          select s;
            }

            stateDataGridView.DataSource = results;
        } // End sortPopButton_Click

        private void sortFlagButton_Click(object sender, EventArgs e)
        {
            StateDBDataContext si = new StateDBDataContext();
            // Sets the default behavior to organizing by First ltter of the flag description in ascending order.
            var results = from s in si.States
                          orderby s.Flag ascending
                          select s;

            if (!ascRadioButton.Checked) // If ascending button is NOT selected (there for descending IS selected).
            {
                results = from s in si.States
                          orderby s.Flag descending
                          select s;
            }
            stateDataGridView.DataSource = results;
        } // End sortFlagButton_Click.

        private void sortFlowerButton_Click(object sender, EventArgs e)
        {
            StateDBDataContext si = new StateDBDataContext();
            // Sets the default behavior to organizing by flower in ascending order.
            var results = from s in si.States
                          orderby s.Flower ascending
                          select s;

            if (!ascRadioButton.Checked) // If ascending button is NOT selected (there for descending IS selected).
            {
                results = from s in si.States
                          orderby s.Flower descending
                          select s;
            }
            stateDataGridView.DataSource = results;
        } // End sortFlowerButton_Click.

        private void sortBirdButton_Click(object sender, EventArgs e)
        {
            StateDBDataContext si = new StateDBDataContext();
            // Sets the default behavior to organizing by bird in ascending order.
            var results = from s in si.States
                          orderby s.Bird ascending
                          select s;

            if (!ascRadioButton.Checked) // If ascending button is NOT selected (there for descending IS selected).
            {
                results = from s in si.States
                          orderby s.Bird descending
                          select s;
            }
            stateDataGridView.DataSource = results;
        } // End sortBirdButton_Click.

        private void sortColorButton_Click(object sender, EventArgs e)
        {
            StateDBDataContext si = new StateDBDataContext();
            // Sets the default behavior to organizing by color in ascending order.
            var results = from s in si.States
                          orderby s.Colors ascending
                          select s;

            if (!ascRadioButton.Checked) // If ascending button is NOT selected (there for descending IS selected).
            {
                results = from s in si.States
                          orderby s.Colors descending
                          select s;
            }
            stateDataGridView.DataSource = results;
        } // End sortColorButton_Click.

        private void sortCapitalButton_Click(object sender, EventArgs e)
        {
            StateDBDataContext si = new StateDBDataContext();
            // Sets the default behavior to organizing by capiltal in ascending order.
            var results = from s in si.States
                          orderby s.Capital ascending
                          select s;

            if (!ascRadioButton.Checked) // If ascending button is NOT selected (there for descending IS selected).
            {
                results = from s in si.States
                          orderby s.Capital descending
                          select s;
            }
            stateDataGridView.DataSource = results;
        } // End sortCapitalButton_Click.

        private void sortCity1Button_Click(object sender, EventArgs e)
        {
            StateDBDataContext si = new StateDBDataContext();
            // Sets the default behavior to organizing by city 1 in ascending order.
            var results = from s in si.States
                          orderby s.City1 ascending
                          select s;

            if (!ascRadioButton.Checked) // If ascending button is NOT selected (there for descending IS selected).
            {
                results = from s in si.States
                          orderby s.City1 descending
                          select s;
            }
            stateDataGridView.DataSource = results;
        } // End sortCity1Button_Click.

        private void sortCity2Button_Click(object sender, EventArgs e)
        {
            StateDBDataContext si = new StateDBDataContext();
            // Sets the default behavior to organizing by city 2 in ascending order.
            var results = from s in si.States
                          orderby s.City2 ascending
                          select s;

            if (!ascRadioButton.Checked) // If ascending button is NOT selected (there for descending IS selected).
            {
                results = from s in si.States
                          orderby s.City2 descending
                          select s;
            }
            stateDataGridView.DataSource = results;
        } // End sortCity2Button_Click.

        private void sortCity3Button_Click(object sender, EventArgs e)
        {
            StateDBDataContext si = new StateDBDataContext();
            // Sets the default behavior to organizing by city 3 in ascending order.
            var results = from s in si.States
                          orderby s.City3 ascending
                          select s;

            if (!ascRadioButton.Checked) // If ascending button is NOT selected (there for descending IS selected).
            {
                results = from s in si.States
                          orderby s.City3 descending
                          select s;
            }
            stateDataGridView.DataSource = results;
        } // End sortCity3Button_Click.

        private void sortIncomeButton_Click(object sender, EventArgs e)
        {
            StateDBDataContext si = new StateDBDataContext();
            // Sets the default behavior to organizing by income in ascending order.
            var results = from s in si.States
                          orderby s.Median_Income ascending
                          select s;

            if (!ascRadioButton.Checked) // If ascending button is NOT selected (there for descending IS selected).
            {
                results = from s in si.States
                          orderby s.Median_Income descending
                          select s;
            }
            stateDataGridView.DataSource = results;
        } // End sortIncomeButton_Click.

        private void sortITJobsButton_Click(object sender, EventArgs e)
        {
            StateDBDataContext si = new StateDBDataContext();
            // Sets the default behavior to organizing by computer jobs in ascending order.
            var results = from s in si.States
                          orderby s.Comp_Jobs ascending
                          select s;

            if (!ascRadioButton.Checked) // If ascending button is NOT selected (there for descending IS selected).
            {
                results = from s in si.States
                          orderby s.Comp_Jobs descending
                          select s;
            }
            stateDataGridView.DataSource = results;
        } // End sortITJobsButton_Click.

        private void pickStateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            // Changed this to work with the new EditInfo form.

            // Display a messagebox with the selected state's info.
            pick = stateSelected[pickStateComboBox.SelectedIndex];

            EditInfo edit = new EditInfo();
            edit.selState = pick; // This passes the 'pick' variable to the EditInfo form, where it will be called 'selState'.
            edit.ShowDialog(); // Open the EditInfo form.

            // Hold on to this as a fall back if needed.
            //StateDBDataContext si = new StateDBDataContext();
            //var results = from s in si.States
            //              where s.StateName == pick
            //              select s;

            //var messageString = string.Join("", results.Select(s => string.Format("State: {0}\n\nPopulation: {1}\n\nCapital: {2}\n\nCity with the highest population: {3}" +
            //                                                                    "\n\nCity with the second highest population:{4}\n\nCity with the third highest population {5}" +
            //                                                                    "\n\nState flag description: {6}\n\nOfficial state colors: {7}\n\nOfficial state bird: {8}" +
            //                                                                    "\n\nOfficial state flower: {9}\n\nMedian income for {0}: {10}" +
            //                                                                    "\n\nPercentage of IT related jobs in{0}: {11}%",
            //                                                                    s.StateName, s.Population, s.Capital, s.City1, s.City2, s.City3,
            //                                                                    s.Flag, s.Colors, s.Bird, s.Flower, s.Median_Income, s.Comp_Jobs)));

            //MessageBox.Show(messageString);

            StateDBDataContext si = new StateDBDataContext(); // Rebuild the DB object after possible updates.

            var results = from s in si.States
                      select s;
            stateDataGridView.DataSource = results;
            
            // Refresh the drop down in case a state name was changed.
            stateSelected = si.States.Select(s => s.StateName).ToArray(); // Sort state names into an array.
            for (int i = 0; i < numOfStates; i++) // Itterate through state names and add them to the drop down list.
            {
                pickStateComboBox.Items.Add(stateSelected[i]);
            }


        } // End pickStateComboBox_SelectedIndexChanged.

        private void searchForButton_Click(object sender, EventArgs e)
        {
            StateDBDataContext si = new StateDBDataContext();
            var results = from s in si.States
                          select s;

            if (string.IsNullOrEmpty(SearchForTextBox.Text))
            {
                MessageBox.Show("Please enter something to search for in the text box and select which column you would like to search, before pressing the search button.");
            }
            else // String contains more then just null or white space.
            {
                // Use the library method to check for valid data.
                int validCode = SearchForTextBox.Text.ContainsValidData();

                /* Codes for ContainsValidData()
                 * -2 means started with digit but contains characters that are not digits. 
                 * -1 means Started with letter but contains characters that are not a letter or space.
                 * 0 means input was null, white space  or started with neither a letter or digit.
                 * 1 means input contains only letters or spaces.
                 * 2 means input contains only digits.
                 * We use code 2 as a positive retun indicator for searching pop/income/jobs later.
                */

                if (searchStateRadioButton.Checked)
                {
                    if (validCode == 1)
                    {
                        results = from s in si.States
                                  where s.StateName.Contains(SearchForTextBox.Text)
                                  orderby s.StateName
                                  select s;
                    }
                    else
                    {
                        MessageBox.Show("When searching for a state by name please make sure to only enter letters and spaces (as needed)");
                    }
                    
                }
                else if (searchFlagRadioButton.Checked)
                {
                    if (validCode == 1)
                    {
                        results = from s in si.States
                                  where s.Flag.Contains(SearchForTextBox.Text)
                                  orderby s.Flag
                                  select s;
                    }
                    else
                    {
                        MessageBox.Show("When searching for a flag description please make sure to only enter letters and spaces (as needed)");
                    }
                }
                else if (searchFlowerRadioButton.Checked)
                {
                    if (validCode == 1)
                    {
                        results = from s in si.States
                                  where s.Flower.Contains(SearchForTextBox.Text)
                                  orderby s.Flower
                                  select s;
                    }
                    else
                    {
                        MessageBox.Show("When searching for a flower please make sure to only enter letters and spaces (as needed)");
                    }
                }
                else if (searchBirdRadioButton.Checked)
                {
                    if (validCode == 1)
                    {
                        results = from s in si.States
                                  where s.Bird.Contains(SearchForTextBox.Text)
                                  orderby s.Bird
                                  select s;
                    }
                    else
                    {
                        MessageBox.Show("When searching for a bird please make sure to only enter letters and spaces (as needed)");
                    }
                }
                else if (searchColorRadioButton.Checked)
                {
                    if (validCode == 1)
                    {
                        results = from s in si.States
                                  where s.Colors.Contains(SearchForTextBox.Text)
                                  orderby s.Colors
                                  select s;
                    }
                    else
                    {
                        MessageBox.Show("When searching for a color please make sure to only enter letters and spaces (as needed)");
                    }
                }
                else if (searchCapitalRadioButton.Checked)
                {
                    if (validCode == 1)
                    {
                        results = from s in si.States
                                  where s.Capital.Contains(SearchForTextBox.Text)
                                  orderby s.Capital
                                  select s;
                    }
                    else
                    {
                        MessageBox.Show("When searching for a capital please make sure to only enter letters and spaces (as needed)");
                    }
                }
                else if (searchCity1RadioButton.Checked)
                {
                    if (validCode == 1)
                    {
                        results = from s in si.States
                                  where s.City1.Contains(SearchForTextBox.Text)
                                  orderby s.City1
                                  select s;
                    }
                    else
                    {
                        MessageBox.Show("When searching the highest population cities in each state please make sure to only enter letters and spaces (as needed)");
                    }
                }
                else if (searchCity2RadioButton.Checked)
                {
                    if (validCode == 1)
                    {
                        results = from s in si.States
                                  where s.City2.Contains(SearchForTextBox.Text)
                                  orderby s.City2
                                  select s;
                    }
                    else
                    {
                        MessageBox.Show("When searching the second highest population cities in each state please make sure to only enter letters and spaces (as needed)");
                    }
                }
                else // if (searchCity3RadioButton.Checked) Dont need since there is no other option left at this point.
                {
                    if (validCode == 1)
                    {
                        results = from s in si.States
                                  where s.City3.Contains(SearchForTextBox.Text)
                                  orderby s.City3
                                  select s;
                    }
                    else
                    {
                        MessageBox.Show("When searching the third highest population cities in each state please make sure to only enter letters and spaces (as needed)");
                    }
                }

                stateDataGridView.DataSource = results;

            } // End of else, when string contains more then just null or white space.

        } // End searchForButton_Click.

        private void searchBetweenButton_Click(object sender, EventArgs e)
        {
            StateDBDataContext si = new StateDBDataContext();
            var results = from s in si.States
                          select s;

            if (string.IsNullOrEmpty(minSearchValueTextBox.Text) || string.IsNullOrEmpty(maxSearchValueTextBox.Text))
            {
                MessageBox.Show("Please enter a minimum and maximum valus before pressing search (do not include spaces, commas, dollar or percent signs).");
            }
            else // String contains more then just null or white space.
            {
                // Use the library method to check for valid data.
                int isMinValid = minSearchValueTextBox.Text.ContainsValidData();
                int isMaxValid = maxSearchValueTextBox.Text.ContainsValidData();

                if (isMinValid != 2 && isMaxValid != 2) // Since 2 is is the only valis code here we can reject everything else and give more specific reasons
                                                        // This will allow 1 error message for 2 errors, reducing user frustration.
                {
                    MessageBox.Show("Please enter a valid minimum and maximum numbers (do not include spaces, commas, dollar or percent signs).");
                }
                else if (isMinValid != 2) // If only min is invalid.
                {
                    MessageBox.Show("Please enter a valid minimum number (do not include spaces, commas, dollar or percent signs).");
                }
                else if (isMaxValid != 2) // If only max is invalid.
                {
                    MessageBox.Show("Please enter a valid maximum number (do not include spaces, commas, dollar or percent signs).");
                }
                else // Min and Max confrimed to be valid.
                {
                    decimal.TryParse(minSearchValueTextBox.Text, out decimal tempMinValue);
                    decimal.TryParse(maxSearchValueTextBox.Text, out decimal tempMaxValue);

                    if (tempMinValue > tempMaxValue)
                    {
                        MessageBox.Show("You have entered in a minimum value that is greater than the maximum you entered.");
                    }

                    else if (searchPopulationRadioButton.Checked)
                    {
                        double.TryParse(minSearchValueTextBox.Text, out double minValue);
                        double.TryParse(maxSearchValueTextBox.Text, out double maxValue);

                        /*
                        results = from s in si.States
                                  where s.Population >= minValue && s.Population <= maxValue
                                  orderby s.Population
                                  select s;
                        */
                        results = si.States.Where(s => s.Population >= minValue && s.Population <= maxValue).OrderBy(s => s.Population);   
                    }
                    else if (searchIncomeRadioButton.Checked)
                    {
                        decimal.TryParse(minSearchValueTextBox.Text, out decimal minValue);
                        decimal.TryParse(maxSearchValueTextBox.Text, out decimal maxValue);

                        results = from s in si.States
                                  where s.Median_Income >= minValue && s.Median_Income <= maxValue
                                  orderby s.Median_Income
                                  select s;
                    }
                    else // if (searchITJobsRadioButton.Checked) IT Jobs would be the only option left.
                    {
                        double.TryParse(minSearchValueTextBox.Text, out double minValue);
                        double.TryParse(maxSearchValueTextBox.Text, out double maxValue);

                        results = from s in si.States
                                  where s.Comp_Jobs >= minValue && s.Comp_Jobs <= maxValue
                                  orderby s.Comp_Jobs
                                  select s;
                    }
                    stateDataGridView.DataSource = results;
                } // End else where min and max are confirmed valid.

            } // End else where string contains more then just null or white space.
        } // End searchBetweenButton_Click
    } // End public partial class SearchState : Form.

} // End namespace
