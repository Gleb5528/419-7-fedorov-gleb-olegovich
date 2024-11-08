namespace Practik
{
    partial class Rukovoditel
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnShowProjects = new System.Windows.Forms.Button();
            this.btnShowEfficiency = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridViewProjects = new System.Windows.Forms.DataGridView();
            this.chartEfficiency = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.txtBudget = new System.Windows.Forms.TextBox();
            this.txtDepartmentHead = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddProject = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEfficiency)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowProjects
            // 
            this.btnShowProjects.Location = new System.Drawing.Point(29, 92);
            this.btnShowProjects.Name = "btnShowProjects";
            this.btnShowProjects.Size = new System.Drawing.Size(155, 61);
            this.btnShowProjects.TabIndex = 0;
            this.btnShowProjects.Text = "ShowProjects";
            this.btnShowProjects.UseVisualStyleBackColor = true;
            this.btnShowProjects.Click += new System.EventHandler(this.btnShowProjects_Click);
            // 
            // btnShowEfficiency
            // 
            this.btnShowEfficiency.Location = new System.Drawing.Point(29, 171);
            this.btnShowEfficiency.Name = "btnShowEfficiency";
            this.btnShowEfficiency.Size = new System.Drawing.Size(155, 61);
            this.btnShowEfficiency.TabIndex = 1;
            this.btnShowEfficiency.Text = "ShowEfficiency";
            this.btnShowEfficiency.UseVisualStyleBackColor = true;
            this.btnShowEfficiency.Click += new System.EventHandler(this.btnShowEfficiency_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(29, 260);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 61);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // dataGridViewProjects
            // 
            this.dataGridViewProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProjects.Location = new System.Drawing.Point(637, 53);
            this.dataGridViewProjects.Name = "dataGridViewProjects";
            this.dataGridViewProjects.RowHeadersWidth = 72;
            this.dataGridViewProjects.RowTemplate.Height = 31;
            this.dataGridViewProjects.Size = new System.Drawing.Size(718, 348);
            this.dataGridViewProjects.TabIndex = 3;
            // 
            // chartEfficiency
            // 
            chartArea1.Name = "ChartArea1";
            this.chartEfficiency.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartEfficiency.Legends.Add(legend1);
            this.chartEfficiency.Location = new System.Drawing.Point(807, 307);
            this.chartEfficiency.Name = "chartEfficiency";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartEfficiency.Series.Add(series1);
            this.chartEfficiency.Size = new System.Drawing.Size(528, 365);
            this.chartEfficiency.TabIndex = 4;
            this.chartEfficiency.Text = "chart1";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(203, 388);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(100, 29);
            this.txtProjectName.TabIndex = 5;
            // 
            // txtBudget
            // 
            this.txtBudget.Location = new System.Drawing.Point(203, 566);
            this.txtBudget.Name = "txtBudget";
            this.txtBudget.Size = new System.Drawing.Size(100, 29);
            this.txtBudget.TabIndex = 6;
            this.txtBudget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBudget_KeyPress);
            // 
            // txtDepartmentHead
            // 
            this.txtDepartmentHead.Location = new System.Drawing.Point(210, 628);
            this.txtDepartmentHead.Name = "txtDepartmentHead";
            this.txtDepartmentHead.Size = new System.Drawing.Size(100, 29);
            this.txtDepartmentHead.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 388);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "ProjectName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 566);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Budget";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 628);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "DepartmentHead";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(203, 441);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 29);
            this.dtpStartDate.TabIndex = 11;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(203, 490);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 29);
            this.dtpEndDate.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 441);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "StartDate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 494);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "EndDate";
            // 
            // btnAddProject
            // 
            this.btnAddProject.Location = new System.Drawing.Point(184, 260);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(119, 61);
            this.btnAddProject.TabIndex = 15;
            this.btnAddProject.Text = "AddProject";
            this.btnAddProject.UseVisualStyleBackColor = true;
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click_1);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(249, 107);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(135, 72);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Rukovoditel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Practik.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1406, 729);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAddProject);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDepartmentHead);
            this.Controls.Add(this.txtBudget);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.chartEfficiency);
            this.Controls.Add(this.dataGridViewProjects);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnShowEfficiency);
            this.Controls.Add(this.btnShowProjects);
            this.Name = "Rukovoditel";
            this.Text = "Rukovoditel";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEfficiency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowProjects;
        private System.Windows.Forms.Button btnShowEfficiency;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dataGridViewProjects;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEfficiency;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.TextBox txtBudget;
        private System.Windows.Forms.TextBox txtDepartmentHead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddProject;
        private System.Windows.Forms.Button btnExit;
    }
}