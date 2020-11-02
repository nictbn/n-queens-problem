using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NQueens
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!isProbabilityValid(Convert.ToInt32(Math.Round(RecombinationProbabilityUpDown.Value, 0))))
            {
                MessageBox.Show("Invalid Recombination Probability!");
                return;
            }

            if (!isProbabilityValid(Convert.ToInt32(Math.Round(MutationProbabilityUpDown.Value, 0))))
            {
                MessageBox.Show("Invalid Mutation Probability!");
                return;
            }

            int populationSize;
            bool isValidPopulationSize = int.TryParse(PopulationSizeTextBox.Text, out populationSize);
            if (!isValidPopulationSize || populationSize < 5)
            {
                MessageBox.Show("Invalid Population Size! Population should have at least 5 individuals");
                return;
            }

            int maximumNumberOfGenerations;
            bool isValidNumberOfGenerations = int.TryParse(MaxGenerationsTextbox.Text, out maximumNumberOfGenerations);
            if(!isValidNumberOfGenerations || maximumNumberOfGenerations < 1)
            {
                MessageBox.Show("Invalid Maximum Number of Generations");
                return;
            }
        }

        private bool isProbabilityValid(int probability)
        {
            return 0 <= probability && probability <= 100;
        }
    }
}
