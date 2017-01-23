using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MacPurge3
{
	public class FEN_Purge : Form
	{
		private IContainer components;

		private GroupBox LIBAC_Erreur;

		private ListBox LIST_Erreur;

		private Button BTN_AnnuleTermine;

		private ProgressBar JAUGE_MoyFicSuppr;

		private Label LIB_NbDossscan;

		private Label LIB_NbDossierScan;

		private Label LIB_NbFichierScan;

		private Label LIB_NbFicScan;

		private Label LIB_NbFichierSupprime;

		private Label LIB_FicSuppr;

		private Label LIB_RelationSupprScan;

		private Label LIB_RelSupScan;

		private long NbFilesScan;

		private long NbFilesDel;

		private long NbFolderDel;

		private long NbFolderScan;

		private string[] PathFolderDeb;

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FEN_Purge));
			this.LIBAC_Erreur = new GroupBox();
			this.LIST_Erreur = new ListBox();
			this.BTN_AnnuleTermine = new Button();
			this.JAUGE_MoyFicSuppr = new ProgressBar();
			this.LIB_NbDossscan = new Label();
			this.LIB_NbDossierScan = new Label();
			this.LIB_NbFichierScan = new Label();
			this.LIB_NbFicScan = new Label();
			this.LIB_NbFichierSupprime = new Label();
			this.LIB_FicSuppr = new Label();
			this.LIB_RelationSupprScan = new Label();
			this.LIB_RelSupScan = new Label();
			this.LIBAC_Erreur.SuspendLayout();
			base.SuspendLayout();
			this.LIBAC_Erreur.Controls.Add(this.LIST_Erreur);
			this.LIBAC_Erreur.Location = new Point(6, 12);
			this.LIBAC_Erreur.Name = "LIBAC_Erreur";
			this.LIBAC_Erreur.Size = new Size(496, 107);
			this.LIBAC_Erreur.TabIndex = 1;
			this.LIBAC_Erreur.TabStop = false;
			this.LIBAC_Erreur.Text = "Erreurs ...";
			this.LIST_Erreur.BackColor = Color.Firebrick;
			this.LIST_Erreur.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.LIST_Erreur.ForeColor = SystemColors.Info;
			this.LIST_Erreur.FormattingEnabled = true;
			this.LIST_Erreur.Location = new Point(9, 19);
			this.LIST_Erreur.Name = "LIST_Erreur";
			this.LIST_Erreur.Size = new Size(481, 82);
			this.LIST_Erreur.TabIndex = 0;
			this.BTN_AnnuleTermine.Location = new Point(396, 185);
			this.BTN_AnnuleTermine.Name = "BTN_AnnuleTermine";
			this.BTN_AnnuleTermine.Size = new Size(108, 23);
			this.BTN_AnnuleTermine.TabIndex = 2;
			this.BTN_AnnuleTermine.Text = "Terminé";
			this.BTN_AnnuleTermine.UseVisualStyleBackColor = true;
			this.BTN_AnnuleTermine.Click += new EventHandler(this.BTN_AnnuleTermine_Click);
			this.JAUGE_MoyFicSuppr.Location = new Point(14, 194);
			this.JAUGE_MoyFicSuppr.Name = "JAUGE_MoyFicSuppr";
			this.JAUGE_MoyFicSuppr.Size = new Size(363, 14);
			this.JAUGE_MoyFicSuppr.TabIndex = 4;
			this.LIB_NbDossscan.Location = new Point(12, 122);
			this.LIB_NbDossscan.Name = "LIB_NbDossscan";
			this.LIB_NbDossscan.Size = new Size(158, 13);
			this.LIB_NbDossscan.TabIndex = 5;
			this.LIB_NbDossscan.Text = "Nombre de Dossiers Scannés :";
			this.LIB_NbDossierScan.Location = new Point(176, 122);
			this.LIB_NbDossierScan.Name = "LIB_NbDossierScan";
			this.LIB_NbDossierScan.Size = new Size(199, 13);
			this.LIB_NbDossierScan.TabIndex = 6;
			this.LIB_NbDossierScan.Text = "10000000 Dossiers";
			this.LIB_NbDossierScan.TextAlign = ContentAlignment.MiddleRight;
			this.LIB_NbFichierScan.Location = new Point(176, 139);
			this.LIB_NbFichierScan.Name = "LIB_NbFichierScan";
			this.LIB_NbFichierScan.Size = new Size(199, 13);
			this.LIB_NbFichierScan.TabIndex = 8;
			this.LIB_NbFichierScan.Text = "10000000 Fichiers";
			this.LIB_NbFichierScan.TextAlign = ContentAlignment.MiddleRight;
			this.LIB_NbFicScan.Location = new Point(12, 139);
			this.LIB_NbFicScan.Name = "LIB_NbFicScan";
			this.LIB_NbFicScan.Size = new Size(158, 13);
			this.LIB_NbFicScan.TabIndex = 7;
			this.LIB_NbFicScan.Text = "Nombre de Fichiers Scannés :";
			this.LIB_NbFichierSupprime.Location = new Point(176, 156);
			this.LIB_NbFichierSupprime.Name = "LIB_NbFichierSupprime";
			this.LIB_NbFichierSupprime.Size = new Size(199, 13);
			this.LIB_NbFichierSupprime.TabIndex = 10;
			this.LIB_NbFichierSupprime.Text = "10000000 Fichiers / 10000000 Dossiers";
			this.LIB_NbFichierSupprime.TextAlign = ContentAlignment.MiddleRight;
			this.LIB_FicSuppr.Location = new Point(12, 156);
			this.LIB_FicSuppr.Name = "LIB_FicSuppr";
			this.LIB_FicSuppr.Size = new Size(158, 13);
			this.LIB_FicSuppr.TabIndex = 9;
			this.LIB_FicSuppr.Text = "Nombre de Fichiers Supprimés :";
			this.LIB_RelationSupprScan.Location = new Point(317, 178);
			this.LIB_RelationSupprScan.Name = "LIB_RelationSupprScan";
			this.LIB_RelationSupprScan.Size = new Size(57, 13);
			this.LIB_RelationSupprScan.TabIndex = 12;
			this.LIB_RelationSupprScan.Text = "99,99 %";
			this.LIB_RelationSupprScan.TextAlign = ContentAlignment.MiddleRight;
			this.LIB_RelSupScan.Location = new Point(11, 178);
			this.LIB_RelSupScan.Name = "LIB_RelSupScan";
			this.LIB_RelSupScan.Size = new Size(190, 13);
			this.LIB_RelSupScan.TabIndex = 11;
			this.LIB_RelSupScan.Text = "Relation Fichier Scanné / Supprimé :";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(520, 218);
			base.Controls.Add(this.LIB_RelationSupprScan);
			base.Controls.Add(this.LIB_RelSupScan);
			base.Controls.Add(this.LIB_NbFichierSupprime);
			base.Controls.Add(this.LIB_FicSuppr);
			base.Controls.Add(this.LIB_NbFichierScan);
			base.Controls.Add(this.LIB_NbFicScan);
			base.Controls.Add(this.LIB_NbDossierScan);
			base.Controls.Add(this.LIB_NbDossscan);
			base.Controls.Add(this.JAUGE_MoyFicSuppr);
			base.Controls.Add(this.BTN_AnnuleTermine);
			base.Controls.Add(this.LIBAC_Erreur);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "FEN_Purge";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Mac Purge - Vidange Terminée ...";
			this.LIBAC_Erreur.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public FEN_Purge(string[] PathDeb)
		{
			this.InitializeComponent();
			this.PathFolderDeb = PathDeb;
			this.JAUGE_MoyFicSuppr.Maximum = 100;
			this.LIB_NbDossierScan.Text = "0 Dossier";
			this.LIB_NbFichierScan.Text = "0 Fichier";
			this.LIB_NbFichierSupprime.Text = "0 Fichier / 0 Dossier";
			this.Run();
			this.Affiche();
		}

		public void Run()
		{
			string[] pathFolderDeb = this.PathFolderDeb;
			for (int i = 0; i < pathFolderDeb.Length; i++)
			{
				string path = pathFolderDeb[i];
				if (Directory.Exists(path))
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(path);
					this.DelMacFiles(directoryInfo);
					this.DelMacFiles(directoryInfo.GetDirectories());
				}
				else
				{
					this.LIST_Erreur.Items.Add("Impossible de traiter : " + Path.GetFileName(path));
				}
			}
		}

		public void Affiche()
		{
			this.LIB_NbDossierScan.Text = this.NbFolderScan.ToString() + " Dossiers";
			this.LIB_NbFichierScan.Text = this.NbFilesScan.ToString() + " Fichiers";
			this.LIB_NbFichierSupprime.Text = this.NbFilesDel.ToString() + " Fichiers / " + this.NbFolderDel.ToString() + " Dossiers";
			decimal value = 0m;
			if (this.NbFilesScan != 0L)
			{
				double num = (double)this.NbFilesDel / (double)this.NbFilesScan * 100.0;
				value = Math.Round((decimal)num, 2);
			}
			this.LIB_RelationSupprScan.Text = value.ToString() + " %";
			this.JAUGE_MoyFicSuppr.Value = (int)value;
		}

		public void DelMacFiles(DirectoryInfo[] dirinf)
		{
			this.NbFolderScan += (long)dirinf.Length;
			for (int i = 0; i < dirinf.Length; i++)
			{
				DirectoryInfo directoryInfo = dirinf[i];
				try
				{
					if (directoryInfo.Name == ".Spotlight-V100" || directoryInfo.Name == ".AppleDouble")
					{
						directoryInfo.Delete(true);
						this.NbFolderDel += 1L;
					}
					else if (directoryInfo.Name == ".Trashes")
					{
						directoryInfo.Delete(true);
						this.NbFolderDel += 1L;
					}
					else
					{
						this.DelMacFiles(directoryInfo);
						this.DelMacFiles(directoryInfo.GetDirectories());
					}
				}
				catch (Exception)
				{
					this.LIST_Erreur.Items.Add("Acces Impossible sur : " + directoryInfo.FullName);
				}
			}
		}

		public void DelMacFiles(DirectoryInfo dir)
		{
			try
			{
				FileInfo[] files = dir.GetFiles();
				this.NbFilesScan += (long)files.Length;
				int num = files.Length;
				for (int i = 0; i < num; i++)
				{
					if (files[i].Name.Substring(0, 2) == "._")
					{
						if (ProcStat.IsMacFile(files[i]))
						{
							this.NbFilesDel += 1L;
							files[i].Delete();
						}
					}
					else if (files[i].Name == ".DS_Store")
					{
						this.NbFilesDel += 1L;
						files[i].Delete();
					}
				}
			}
			catch (Exception)
			{
				this.LIST_Erreur.Items.Add("Acces Impossible sur : " + dir.FullName);
			}
		}

		private void BTN_AnnuleTermine_Click(object sender, EventArgs e)
		{
			base.Close();
		}
	}
}
