namespace DebugTester
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pbCanvas = new PictureBox();
            mainTimer = new System.Windows.Forms.Timer(components);
            RandomizeColors = new Button();
            RandomScale = new Button();
            SwitchToOtherObject = new Button();
            ((System.ComponentModel.ISupportInitialize)pbCanvas).BeginInit();
            SuspendLayout();
            // 
            // pbCanvas
            // 
            pbCanvas.Location = new Point(248, 17);
            pbCanvas.Margin = new Padding(3, 2, 3, 2);
            pbCanvas.Name = "pbCanvas";
            pbCanvas.Size = new Size(400, 300);
            pbCanvas.TabIndex = 0;
            pbCanvas.TabStop = false;
            // 
            // mainTimer
            // 
            mainTimer.Enabled = true;
            mainTimer.Interval = 40;
            mainTimer.Tick += MainTimer_Tick;
            // 
            // RandomizeColors
            // 
            RandomizeColors.Location = new Point(27, 17);
            RandomizeColors.Margin = new Padding(3, 2, 3, 2);
            RandomizeColors.Name = "RandomizeColors";
            RandomizeColors.Size = new Size(177, 45);
            RandomizeColors.TabIndex = 2;
            RandomizeColors.Text = "Randomize colors";
            RandomizeColors.UseVisualStyleBackColor = true;
            RandomizeColors.Click += RandomizeColors_Click;
            // 
            // RandomScale
            // 
            RandomScale.Location = new Point(27, 82);
            RandomScale.Margin = new Padding(3, 2, 3, 2);
            RandomScale.Name = "RandomScale";
            RandomScale.Size = new Size(177, 45);
            RandomScale.TabIndex = 3;
            RandomScale.Text = "Scale randomly";
            RandomScale.UseVisualStyleBackColor = true;
            RandomScale.Click += RandomScale_Click;
            // 
            // SwitchToOtherObject
            // 
            SwitchToOtherObject.Location = new Point(27, 148);
            SwitchToOtherObject.Margin = new Padding(3, 2, 3, 2);
            SwitchToOtherObject.Name = "SwitchToOtherObject";
            SwitchToOtherObject.Size = new Size(177, 45);
            SwitchToOtherObject.TabIndex = 4;
            SwitchToOtherObject.Text = "Switch to other object";
            SwitchToOtherObject.UseVisualStyleBackColor = true;
            SwitchToOtherObject.Click += SwitchToOtherObject_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(668, 332);
            Controls.Add(SwitchToOtherObject);
            Controls.Add(RandomScale);
            Controls.Add(RandomizeColors);
            Controls.Add(pbCanvas);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbCanvas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbCanvas;
        private System.Windows.Forms.Timer mainTimer;
        private Button RandomizeColors;
        private Button RandomScale;
        private Button SwitchToOtherObject;
    }
}