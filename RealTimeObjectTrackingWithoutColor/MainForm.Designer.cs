namespace RealTimeObjectTrackingWithoutColor
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.m_panelCamera = new System.Windows.Forms.Panel();
            this.m_numericUpDownSensitivity = new System.Windows.Forms.NumericUpDown();
            this.m_timer = new System.Windows.Forms.Timer(this.components);
            this.m_backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.m_checkBoxTrackObject = new System.Windows.Forms.CheckBox();
            this.m_labelSensitivity = new System.Windows.Forms.Label();
            this.m_buttonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDownSensitivity)).BeginInit();
            this.SuspendLayout();
            // 
            // m_panelCamera
            // 
            this.m_panelCamera.Location = new System.Drawing.Point(12, 12);
            this.m_panelCamera.Name = "m_panelCamera";
            this.m_panelCamera.Size = new System.Drawing.Size(340, 280);
            this.m_panelCamera.TabIndex = 2;
            // 
            // m_numericUpDownSensitivity
            // 
            this.m_numericUpDownSensitivity.Location = new System.Drawing.Point(232, 298);
            this.m_numericUpDownSensitivity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.m_numericUpDownSensitivity.Name = "m_numericUpDownSensitivity";
            this.m_numericUpDownSensitivity.Size = new System.Drawing.Size(120, 20);
            this.m_numericUpDownSensitivity.TabIndex = 3;
            this.m_numericUpDownSensitivity.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // m_timer
            // 
            this.m_timer.Tick += new System.EventHandler(this.m_timer_Tick);
            // 
            // m_backgroundWorker
            // 
            this.m_backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_backgroundWorker_DoWork);
            // 
            // m_checkBoxTrackObject
            // 
            this.m_checkBoxTrackObject.AutoSize = true;
            this.m_checkBoxTrackObject.Checked = true;
            this.m_checkBoxTrackObject.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_checkBoxTrackObject.Location = new System.Drawing.Point(12, 301);
            this.m_checkBoxTrackObject.Name = "m_checkBoxTrackObject";
            this.m_checkBoxTrackObject.Size = new System.Drawing.Size(54, 17);
            this.m_checkBoxTrackObject.TabIndex = 4;
            this.m_checkBoxTrackObject.Text = "Track";
            this.m_checkBoxTrackObject.UseVisualStyleBackColor = true;
            // 
            // m_labelSensitivity
            // 
            this.m_labelSensitivity.AutoSize = true;
            this.m_labelSensitivity.Location = new System.Drawing.Point(139, 300);
            this.m_labelSensitivity.Name = "m_labelSensitivity";
            this.m_labelSensitivity.Size = new System.Drawing.Size(63, 13);
            this.m_labelSensitivity.TabIndex = 5;
            this.m_labelSensitivity.Text = "Sensitivity : ";
            // 
            // m_buttonStart
            // 
            this.m_buttonStart.Location = new System.Drawing.Point(277, 342);
            this.m_buttonStart.Name = "m_buttonStart";
            this.m_buttonStart.Size = new System.Drawing.Size(75, 23);
            this.m_buttonStart.TabIndex = 6;
            this.m_buttonStart.Text = "Başla";
            this.m_buttonStart.UseVisualStyleBackColor = true;
            this.m_buttonStart.Click += new System.EventHandler(this.m_buttonStart_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 375);
            this.Controls.Add(this.m_buttonStart);
            this.Controls.Add(this.m_labelSensitivity);
            this.Controls.Add(this.m_checkBoxTrackObject);
            this.Controls.Add(this.m_numericUpDownSensitivity);
            this.Controls.Add(this.m_panelCamera);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tracking";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDownSensitivity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel m_panelCamera;
        private System.Windows.Forms.NumericUpDown m_numericUpDownSensitivity;
        private System.Windows.Forms.Timer m_timer;
        private System.ComponentModel.BackgroundWorker m_backgroundWorker;
        private System.Windows.Forms.CheckBox m_checkBoxTrackObject;
        private System.Windows.Forms.Label m_labelSensitivity;
        private System.Windows.Forms.Button m_buttonStart;
    }
}

