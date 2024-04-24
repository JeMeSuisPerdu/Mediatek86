namespace Mediatek86.Vue
{
    partial class AjouterAbsence
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
            this.ajouterAbsTitre = new System.Windows.Forms.Label();
            this.dateDebutAbsLbl = new System.Windows.Forms.Label();
            this.dateFinAbsLbl = new System.Windows.Forms.Label();
            this.motifAbsLbl = new System.Windows.Forms.Label();
            this.dateDebutAbs = new System.Windows.Forms.DateTimePicker();
            this.dateFinAbs = new System.Windows.Forms.DateTimePicker();
            this.motifAbsLst = new System.Windows.Forms.ListBox();
            this.AjouterAbsBtn = new System.Windows.Forms.Button();
            this.AnnulerAbsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ajouterAbsTitre
            // 
            this.ajouterAbsTitre.AutoSize = true;
            this.ajouterAbsTitre.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.ajouterAbsTitre.ForeColor = System.Drawing.Color.White;
            this.ajouterAbsTitre.Location = new System.Drawing.Point(12, 9);
            this.ajouterAbsTitre.Name = "ajouterAbsTitre";
            this.ajouterAbsTitre.Size = new System.Drawing.Size(187, 25);
            this.ajouterAbsTitre.TabIndex = 0;
            this.ajouterAbsTitre.Text = "Ajouter une absence";
            // 
            // dateDebutAbsLbl
            // 
            this.dateDebutAbsLbl.AutoSize = true;
            this.dateDebutAbsLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.dateDebutAbsLbl.ForeColor = System.Drawing.Color.White;
            this.dateDebutAbsLbl.Location = new System.Drawing.Point(103, 151);
            this.dateDebutAbsLbl.Name = "dateDebutAbsLbl";
            this.dateDebutAbsLbl.Size = new System.Drawing.Size(115, 21);
            this.dateDebutAbsLbl.TabIndex = 1;
            this.dateDebutAbsLbl.Text = "Date de début";
            // 
            // dateFinAbsLbl
            // 
            this.dateFinAbsLbl.AutoSize = true;
            this.dateFinAbsLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.dateFinAbsLbl.ForeColor = System.Drawing.Color.White;
            this.dateFinAbsLbl.Location = new System.Drawing.Point(103, 275);
            this.dateFinAbsLbl.Name = "dateFinAbsLbl";
            this.dateFinAbsLbl.Size = new System.Drawing.Size(90, 21);
            this.dateFinAbsLbl.TabIndex = 2;
            this.dateFinAbsLbl.Text = "Date de fin";
            // 
            // motifAbsLbl
            // 
            this.motifAbsLbl.AutoSize = true;
            this.motifAbsLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.motifAbsLbl.ForeColor = System.Drawing.Color.White;
            this.motifAbsLbl.Location = new System.Drawing.Point(627, 74);
            this.motifAbsLbl.Name = "motifAbsLbl";
            this.motifAbsLbl.Size = new System.Drawing.Size(136, 21);
            this.motifAbsLbl.TabIndex = 3;
            this.motifAbsLbl.Text = "Motifs d\'absence";
            // 
            // dateDebutAbs
            // 
            this.dateDebutAbs.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDebutAbs.Location = new System.Drawing.Point(268, 151);
            this.dateDebutAbs.Name = "dateDebutAbs";
            this.dateDebutAbs.Size = new System.Drawing.Size(200, 20);
            this.dateDebutAbs.TabIndex = 4;
            // 
            // dateFinAbs
            // 
            this.dateFinAbs.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFinAbs.Location = new System.Drawing.Point(268, 275);
            this.dateFinAbs.Name = "dateFinAbs";
            this.dateFinAbs.Size = new System.Drawing.Size(200, 20);
            this.dateFinAbs.TabIndex = 5;
            // 
            // motifAbsLst
            // 
            this.motifAbsLst.FormattingEnabled = true;
            this.motifAbsLst.Location = new System.Drawing.Point(564, 117);
            this.motifAbsLst.Name = "motifAbsLst";
            this.motifAbsLst.Size = new System.Drawing.Size(246, 212);
            this.motifAbsLst.TabIndex = 6;
            // 
            // AjouterAbsBtn
            // 
            this.AjouterAbsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.AjouterAbsBtn.FlatAppearance.BorderSize = 0;
            this.AjouterAbsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AjouterAbsBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.AjouterAbsBtn.ForeColor = System.Drawing.Color.White;
            this.AjouterAbsBtn.Location = new System.Drawing.Point(169, 381);
            this.AjouterAbsBtn.Name = "AjouterAbsBtn";
            this.AjouterAbsBtn.Size = new System.Drawing.Size(111, 33);
            this.AjouterAbsBtn.TabIndex = 7;
            this.AjouterAbsBtn.Text = "Ajouter";
            this.AjouterAbsBtn.UseVisualStyleBackColor = false;
            // 
            // AnnulerAbsBtn
            // 
            this.AnnulerAbsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AnnulerAbsBtn.FlatAppearance.BorderSize = 0;
            this.AnnulerAbsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AnnulerAbsBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.AnnulerAbsBtn.ForeColor = System.Drawing.Color.White;
            this.AnnulerAbsBtn.Location = new System.Drawing.Point(333, 381);
            this.AnnulerAbsBtn.Name = "AnnulerAbsBtn";
            this.AnnulerAbsBtn.Size = new System.Drawing.Size(111, 33);
            this.AnnulerAbsBtn.TabIndex = 8;
            this.AnnulerAbsBtn.Text = "Annuler";
            this.AnnulerAbsBtn.UseVisualStyleBackColor = false;
            // 
            // AjouterAbsence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(34)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(871, 470);
            this.Controls.Add(this.AnnulerAbsBtn);
            this.Controls.Add(this.AjouterAbsBtn);
            this.Controls.Add(this.motifAbsLst);
            this.Controls.Add(this.dateFinAbs);
            this.Controls.Add(this.dateDebutAbs);
            this.Controls.Add(this.motifAbsLbl);
            this.Controls.Add(this.dateFinAbsLbl);
            this.Controls.Add(this.dateDebutAbsLbl);
            this.Controls.Add(this.ajouterAbsTitre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AjouterAbsence";
            this.Text = "AjouterPersonnel";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AjouterAbsence_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AjouterAbsence_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AjouterAbsence_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ajouterAbsTitre;
        private System.Windows.Forms.Label dateDebutAbsLbl;
        private System.Windows.Forms.Label dateFinAbsLbl;
        private System.Windows.Forms.Label motifAbsLbl;
        private System.Windows.Forms.DateTimePicker dateDebutAbs;
        private System.Windows.Forms.DateTimePicker dateFinAbs;
        private System.Windows.Forms.ListBox motifAbsLst;
        private System.Windows.Forms.Button AjouterAbsBtn;
        private System.Windows.Forms.Button AnnulerAbsBtn;
    }
}