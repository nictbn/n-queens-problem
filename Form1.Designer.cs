namespace NQueens
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RecombinationProbabilityLabel = new System.Windows.Forms.Label();
            this.MutationProbabilityLabel = new System.Windows.Forms.Label();
            this.PopulationSizeLabel = new System.Windows.Forms.Label();
            this.MaxGenerationsLabel = new System.Windows.Forms.Label();
            this.RecombinationProbabilityUpDown = new System.Windows.Forms.NumericUpDown();
            this.MutationProbabilityUpDown = new System.Windows.Forms.NumericUpDown();
            this.PopulationSizeTextBox = new System.Windows.Forms.TextBox();
            this.MaxGenerationsTextbox = new System.Windows.Forms.TextBox();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.StartButton = new System.Windows.Forms.Button();
            this.GeneticAlgorithmBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.NumberOfQueensUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.RecombinationProbabilityUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MutationProbabilityUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfQueensUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // RecombinationProbabilityLabel
            // 
            this.RecombinationProbabilityLabel.AutoSize = true;
            this.RecombinationProbabilityLabel.Location = new System.Drawing.Point(0, 37);
            this.RecombinationProbabilityLabel.Name = "RecombinationProbabilityLabel";
            this.RecombinationProbabilityLabel.Size = new System.Drawing.Size(174, 13);
            this.RecombinationProbabilityLabel.TabIndex = 0;
            this.RecombinationProbabilityLabel.Text = "Recombination Probability (0 - 100):";
            // 
            // MutationProbabilityLabel
            // 
            this.MutationProbabilityLabel.AutoSize = true;
            this.MutationProbabilityLabel.Location = new System.Drawing.Point(30, 68);
            this.MutationProbabilityLabel.Name = "MutationProbabilityLabel";
            this.MutationProbabilityLabel.Size = new System.Drawing.Size(144, 13);
            this.MutationProbabilityLabel.TabIndex = 1;
            this.MutationProbabilityLabel.Text = "Mutation Probability (0 - 100):";
            // 
            // PopulationSizeLabel
            // 
            this.PopulationSizeLabel.AutoSize = true;
            this.PopulationSizeLabel.Location = new System.Drawing.Point(91, 99);
            this.PopulationSizeLabel.Name = "PopulationSizeLabel";
            this.PopulationSizeLabel.Size = new System.Drawing.Size(83, 13);
            this.PopulationSizeLabel.TabIndex = 2;
            this.PopulationSizeLabel.Text = "Population Size:";
            // 
            // MaxGenerationsLabel
            // 
            this.MaxGenerationsLabel.AutoSize = true;
            this.MaxGenerationsLabel.Location = new System.Drawing.Point(8, 129);
            this.MaxGenerationsLabel.Name = "MaxGenerationsLabel";
            this.MaxGenerationsLabel.Size = new System.Drawing.Size(166, 13);
            this.MaxGenerationsLabel.TabIndex = 3;
            this.MaxGenerationsLabel.Text = "Maximum Number of Generations:";
            // 
            // RecombinationProbabilityUpDown
            // 
            this.RecombinationProbabilityUpDown.Location = new System.Drawing.Point(189, 35);
            this.RecombinationProbabilityUpDown.Name = "RecombinationProbabilityUpDown";
            this.RecombinationProbabilityUpDown.Size = new System.Drawing.Size(120, 20);
            this.RecombinationProbabilityUpDown.TabIndex = 4;
            this.RecombinationProbabilityUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RecombinationProbabilityUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // MutationProbabilityUpDown
            // 
            this.MutationProbabilityUpDown.Location = new System.Drawing.Point(189, 66);
            this.MutationProbabilityUpDown.Name = "MutationProbabilityUpDown";
            this.MutationProbabilityUpDown.Size = new System.Drawing.Size(120, 20);
            this.MutationProbabilityUpDown.TabIndex = 5;
            this.MutationProbabilityUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MutationProbabilityUpDown.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // PopulationSizeTextBox
            // 
            this.PopulationSizeTextBox.Location = new System.Drawing.Point(189, 96);
            this.PopulationSizeTextBox.Name = "PopulationSizeTextBox";
            this.PopulationSizeTextBox.Size = new System.Drawing.Size(108, 20);
            this.PopulationSizeTextBox.TabIndex = 6;
            this.PopulationSizeTextBox.Text = "100";
            this.PopulationSizeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MaxGenerationsTextbox
            // 
            this.MaxGenerationsTextbox.Location = new System.Drawing.Point(189, 129);
            this.MaxGenerationsTextbox.Name = "MaxGenerationsTextbox";
            this.MaxGenerationsTextbox.Size = new System.Drawing.Size(108, 20);
            this.MaxGenerationsTextbox.TabIndex = 7;
            this.MaxGenerationsTextbox.Text = "10000";
            this.MaxGenerationsTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Location = new System.Drawing.Point(123, 167);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(51, 13);
            this.ProgressLabel.TabIndex = 8;
            this.ProgressLabel.Text = "Progress:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(180, 157);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(406, 32);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 9;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(180, 205);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 10;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // GeneticAlgorithmBackgroundWorker
            // 
            this.GeneticAlgorithmBackgroundWorker.WorkerReportsProgress = true;
            this.GeneticAlgorithmBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GeneticAlgorithmBackgroundWorker_DoWork);
            this.GeneticAlgorithmBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.GeneticAlgorithmBackgroundWorker_ProgressChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Number of Queens (8 - 12):";
            // 
            // NumberOfQueensUpDown
            // 
            this.NumberOfQueensUpDown.Location = new System.Drawing.Point(189, 7);
            this.NumberOfQueensUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.NumberOfQueensUpDown.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.NumberOfQueensUpDown.Name = "NumberOfQueensUpDown";
            this.NumberOfQueensUpDown.Size = new System.Drawing.Size(120, 20);
            this.NumberOfQueensUpDown.TabIndex = 12;
            this.NumberOfQueensUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumberOfQueensUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 253);
            this.Controls.Add(this.NumberOfQueensUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.MaxGenerationsTextbox);
            this.Controls.Add(this.PopulationSizeTextBox);
            this.Controls.Add(this.MutationProbabilityUpDown);
            this.Controls.Add(this.RecombinationProbabilityUpDown);
            this.Controls.Add(this.MaxGenerationsLabel);
            this.Controls.Add(this.PopulationSizeLabel);
            this.Controls.Add(this.MutationProbabilityLabel);
            this.Controls.Add(this.RecombinationProbabilityLabel);
            this.Name = "Form1";
            this.Text = "The N Queens Problem";
            ((System.ComponentModel.ISupportInitialize)(this.RecombinationProbabilityUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MutationProbabilityUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfQueensUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RecombinationProbabilityLabel;
        private System.Windows.Forms.Label MutationProbabilityLabel;
        private System.Windows.Forms.Label PopulationSizeLabel;
        private System.Windows.Forms.Label MaxGenerationsLabel;
        private System.Windows.Forms.NumericUpDown RecombinationProbabilityUpDown;
        private System.Windows.Forms.NumericUpDown MutationProbabilityUpDown;
        private System.Windows.Forms.TextBox PopulationSizeTextBox;
        private System.Windows.Forms.TextBox MaxGenerationsTextbox;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button StartButton;
        private System.ComponentModel.BackgroundWorker GeneticAlgorithmBackgroundWorker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumberOfQueensUpDown;
    }
}

