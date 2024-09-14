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
            button1 = new Button();
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
            mainTimer.Tick += mainTimer_Tick;
            // 
            // button1
            // 
            button1.Location = new Point(27, 17);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(177, 110);
            button1.TabIndex = 2;
            button1.Text = "tu możecie dodać jakieś funkcjonalności";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(668, 332);
            Controls.Add(button1);
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
        private Button button1;
    }
}