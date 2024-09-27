namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.OglC = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OglC
            // 
            this.OglC.AccumBits = ((byte)(0));
            this.OglC.AutoCheckErrors = false;
            this.OglC.AutoFinish = false;
            this.OglC.AutoMakeCurrent = true;
            this.OglC.AutoSwapBuffers = true;
            this.OglC.BackColor = System.Drawing.Color.Black;
            this.OglC.ColorBits = ((byte)(32));
            this.OglC.DepthBits = ((byte)(16));
            this.OglC.Location = new System.Drawing.Point(12, 12);
            this.OglC.Name = "OglC";
            this.OglC.Size = new System.Drawing.Size(528, 426);
            this.OglC.StencilBits = ((byte)(0));
            this.OglC.TabIndex = 0;
            this.OglC.Load += new System.EventHandler(this.OglC_Load);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(572, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(207, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Запустить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(572, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(207, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "Выключить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.OglC);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl OglC;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

