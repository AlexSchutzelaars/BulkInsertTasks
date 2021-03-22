
namespace BulkInsertV2
{
	partial class frmDemoBulkInsert
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
			this.txtIterationPath = new System.Windows.Forms.TextBox();
			this.lblIterationPath = new System.Windows.Forms.Label();
			this.lblWorkItems = new System.Windows.Forms.Label();
			this.btnCreateTasks = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.chkListWorkItems = new System.Windows.Forms.CheckedListBox();
			this.lstDebugInfoOnWorkItem = new System.Windows.Forms.ListBox();
			this.lblTemplateFile = new System.Windows.Forms.Label();
			this.txtTemplatesFileForTeam = new System.Windows.Forms.TextBox();
			this.lblWorkItemsExportFile = new System.Windows.Forms.Label();
			this.txtWorkItemsExportFile = new System.Windows.Forms.TextBox();
			this.btnOpenTemplateFile = new System.Windows.Forms.Button();
			this.btnGetWorkItems = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtIterationPath
			// 
			this.txtIterationPath.Location = new System.Drawing.Point(213, 3);
			this.txtIterationPath.Name = "txtIterationPath";
			this.txtIterationPath.Size = new System.Drawing.Size(541, 27);
			this.txtIterationPath.TabIndex = 0;
			// 
			// lblIterationPath
			// 
			this.lblIterationPath.AutoSize = true;
			this.lblIterationPath.Location = new System.Drawing.Point(46, 6);
			this.lblIterationPath.Name = "lblIterationPath";
			this.lblIterationPath.Size = new System.Drawing.Size(97, 20);
			this.lblIterationPath.TabIndex = 1;
			this.lblIterationPath.Text = "Iteration Path";
			// 
			// lblWorkItems
			// 
			this.lblWorkItems.AutoSize = true;
			this.lblWorkItems.Location = new System.Drawing.Point(46, 213);
			this.lblWorkItems.Name = "lblWorkItems";
			this.lblWorkItems.Size = new System.Drawing.Size(167, 20);
			this.lblWorkItems.TabIndex = 3;
			this.lblWorkItems.Text = "Workitems in export file";
			// 
			// btnCreateTasks
			// 
			this.btnCreateTasks.Location = new System.Drawing.Point(46, 410);
			this.btnCreateTasks.Name = "btnCreateTasks";
			this.btnCreateTasks.Size = new System.Drawing.Size(160, 29);
			this.btnCreateTasks.TabIndex = 5;
			this.btnCreateTasks.Text = "Create tasks";
			this.btnCreateTasks.UseVisualStyleBackColor = true;
			this.btnCreateTasks.Click += new System.EventHandler(this.btnCreateTasks_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.label1.Location = new System.Drawing.Point(224, 410);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(126, 20);
			this.label1.TabIndex = 6;
			this.label1.Text = "Info on work item";
			// 
			// chkListWorkItems
			// 
			this.chkListWorkItems.FormattingEnabled = true;
			this.chkListWorkItems.Location = new System.Drawing.Point(46, 251);
			this.chkListWorkItems.Name = "chkListWorkItems";
			this.chkListWorkItems.Size = new System.Drawing.Size(733, 70);
			this.chkListWorkItems.TabIndex = 9;
			this.chkListWorkItems.SelectedIndexChanged += new System.EventHandler(this.chkListWorkItems_SelectedIndexChanged);
			// 
			// lstDebugInfoOnWorkItem
			// 
			this.lstDebugInfoOnWorkItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.lstDebugInfoOnWorkItem.FormattingEnabled = true;
			this.lstDebugInfoOnWorkItem.ItemHeight = 20;
			this.lstDebugInfoOnWorkItem.Location = new System.Drawing.Point(224, 437);
			this.lstDebugInfoOnWorkItem.Name = "lstDebugInfoOnWorkItem";
			this.lstDebugInfoOnWorkItem.Size = new System.Drawing.Size(643, 104);
			this.lstDebugInfoOnWorkItem.TabIndex = 4;
			// 
			// lblTemplateFile
			// 
			this.lblTemplateFile.AutoSize = true;
			this.lblTemplateFile.Location = new System.Drawing.Point(46, 56);
			this.lblTemplateFile.Name = "lblTemplateFile";
			this.lblTemplateFile.Size = new System.Drawing.Size(102, 20);
			this.lblTemplateFile.TabIndex = 11;
			this.lblTemplateFile.Text = "Templates file";
			// 
			// txtTemplatesFileForTeam
			// 
			this.txtTemplatesFileForTeam.Location = new System.Drawing.Point(213, 56);
			this.txtTemplatesFileForTeam.Name = "txtTemplatesFileForTeam";
			this.txtTemplatesFileForTeam.Size = new System.Drawing.Size(541, 27);
			this.txtTemplatesFileForTeam.TabIndex = 10;
			// 
			// lblWorkItemsExportFile
			// 
			this.lblWorkItemsExportFile.AutoSize = true;
			this.lblWorkItemsExportFile.Location = new System.Drawing.Point(46, 106);
			this.lblWorkItemsExportFile.Name = "lblWorkItemsExportFile";
			this.lblWorkItemsExportFile.Size = new System.Drawing.Size(139, 20);
			this.lblWorkItemsExportFile.TabIndex = 13;
			this.lblWorkItemsExportFile.Text = "WI Export file (CSV)";
			// 
			// txtWorkItemsExportFile
			// 
			this.txtWorkItemsExportFile.Location = new System.Drawing.Point(213, 106);
			this.txtWorkItemsExportFile.Name = "txtWorkItemsExportFile";
			this.txtWorkItemsExportFile.Size = new System.Drawing.Size(541, 27);
			this.txtWorkItemsExportFile.TabIndex = 12;
			// 
			// btnOpenTemplateFile
			// 
			this.btnOpenTemplateFile.Location = new System.Drawing.Point(773, 54);
			this.btnOpenTemplateFile.Name = "btnOpenTemplateFile";
			this.btnOpenTemplateFile.Size = new System.Drawing.Size(94, 29);
			this.btnOpenTemplateFile.TabIndex = 14;
			this.btnOpenTemplateFile.Text = "...";
			this.btnOpenTemplateFile.UseVisualStyleBackColor = true;
			this.btnOpenTemplateFile.Click += new System.EventHandler(this.btnOpenTemplateFile_Click);
			// 
			// btnGetWorkItems
			// 
			this.btnGetWorkItems.Location = new System.Drawing.Point(46, 164);
			this.btnGetWorkItems.Name = "btnGetWorkItems";
			this.btnGetWorkItems.Size = new System.Drawing.Size(196, 29);
			this.btnGetWorkItems.TabIndex = 15;
			this.btnGetWorkItems.Text = "Get workitems";
			this.btnGetWorkItems.UseVisualStyleBackColor = true;
			this.btnGetWorkItems.Click += new System.EventHandler(this.btnGetWorkItems_Click);
			// 
			// frmDemoBulkInsert
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(879, 610);
			this.Controls.Add(this.btnGetWorkItems);
			this.Controls.Add(this.btnOpenTemplateFile);
			this.Controls.Add(this.lblWorkItemsExportFile);
			this.Controls.Add(this.txtWorkItemsExportFile);
			this.Controls.Add(this.lblTemplateFile);
			this.Controls.Add(this.txtTemplatesFileForTeam);
			this.Controls.Add(this.chkListWorkItems);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCreateTasks);
			this.Controls.Add(this.lstDebugInfoOnWorkItem);
			this.Controls.Add(this.lblWorkItems);
			this.Controls.Add(this.lblIterationPath);
			this.Controls.Add(this.txtIterationPath);
			this.Name = "frmDemoBulkInsert";
			this.Text = "Bulk Insert tasks for workitems";
			this.Load += new System.EventHandler(this.frmDemoBulkInsert_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtIterationPath;
		private System.Windows.Forms.Label lblIterationPath;
		private System.Windows.Forms.Label lblWorkItems;
		private System.Windows.Forms.Button btnCreateTasks;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckedListBox chkListWorkItems;
		private System.Windows.Forms.ListBox lstDebugInfoOnWorkItem;
		private System.Windows.Forms.Label lblTemplateFile;
		private System.Windows.Forms.TextBox txtTemplatesFileForTeam;
		private System.Windows.Forms.Label lblWorkItemsExportFile;
		private System.Windows.Forms.TextBox txtWorkItemsExportFile;
		private System.Windows.Forms.Button btnOpenTemplateFile;
		private System.Windows.Forms.Button btnGetWorkItems;
	}
}

