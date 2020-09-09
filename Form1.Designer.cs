namespace Cheese_Updater
{
    partial class Cheese_Updater
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cheese_Updater));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.L_Title = new System.Windows.Forms.Label();
            this.L_Progress = new System.Windows.Forms.Label();
            this.B_Next = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.L_Error = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.Yellow;
            this.progressBar.Location = new System.Drawing.Point(12, 83);
            this.progressBar.Maximum = 7;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(437, 35);
            this.progressBar.TabIndex = 0;
            // 
            // L_Title
            // 
            this.L_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.L_Title.Location = new System.Drawing.Point(12, -1);
            this.L_Title.Name = "L_Title";
            this.L_Title.Size = new System.Drawing.Size(437, 36);
            this.L_Title.TabIndex = 1;
            this.L_Title.Text = "Poczekaj... Aktualizujemy dla Ciebie PROGRAM_NAME";
            this.L_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // L_Progress
            // 
            this.L_Progress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.L_Progress.Location = new System.Drawing.Point(12, 57);
            this.L_Progress.Name = "L_Progress";
            this.L_Progress.Size = new System.Drawing.Size(437, 23);
            this.L_Progress.TabIndex = 2;
            this.L_Progress.Text = "Aktualizujemy...";
            this.L_Progress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // B_Next
            // 
            this.B_Next.BackColor = System.Drawing.SystemColors.ControlLight;
            this.B_Next.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.B_Next.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.B_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Next.Location = new System.Drawing.Point(357, 126);
            this.B_Next.Name = "B_Next";
            this.B_Next.Size = new System.Drawing.Size(92, 23);
            this.B_Next.TabIndex = 3;
            this.B_Next.Text = "Zakończ";
            this.B_Next.UseVisualStyleBackColor = false;
            this.B_Next.Visible = false;
            this.B_Next.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.B_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.B_Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.B_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Cancel.Location = new System.Drawing.Point(12, 126);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(92, 23);
            this.B_Cancel.TabIndex = 4;
            this.B_Cancel.Text = "Anuluj";
            this.B_Cancel.UseVisualStyleBackColor = false;
            this.B_Cancel.Visible = false;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // L_Error
            // 
            this.L_Error.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.L_Error.ForeColor = System.Drawing.Color.Red;
            this.L_Error.Location = new System.Drawing.Point(12, 35);
            this.L_Error.Name = "L_Error";
            this.L_Error.Size = new System.Drawing.Size(437, 25);
            this.L_Error.TabIndex = 5;
            this.L_Error.Text = "ERROR";
            this.L_Error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.L_Error.Visible = false;
            // 
            // Cheese_Updater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 161);
            this.Controls.Add(this.L_Error);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Next);
            this.Controls.Add(this.L_Progress);
            this.Controls.Add(this.L_Title);
            this.Controls.Add(this.progressBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Cheese_Updater";
            this.Text = "Cheese Updater";
            this.Load += new System.EventHandler(this.Cheese_Updater_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label L_Title;
        private System.Windows.Forms.Label L_Progress;
        private System.Windows.Forms.Button B_Next;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Label L_Error;
    }
}

