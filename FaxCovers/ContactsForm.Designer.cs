namespace FaxCovers{
	
	partial class ContactsForm{
		
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.listBoxContacts = new System.Windows.Forms.ListBox();
			this.buttonLoad = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBoxContacts
			// 
			this.listBoxContacts.FormattingEnabled = true;
			this.listBoxContacts.HorizontalScrollbar = true;
			this.listBoxContacts.Location = new System.Drawing.Point(12, 12);
			this.listBoxContacts.Name = "listBoxContacts";
			this.listBoxContacts.Size = new System.Drawing.Size(221, 186);
			this.listBoxContacts.TabIndex = 0;
			this.listBoxContacts.DoubleClick += new System.EventHandler(this.ListBoxContactsDoubleClick);
			// 
			// buttonLoad
			// 
			this.buttonLoad.AutoEllipsis = true;
			this.buttonLoad.Location = new System.Drawing.Point(88, 204);
			this.buttonLoad.Name = "buttonLoad";
			this.buttonLoad.Size = new System.Drawing.Size(145, 23);
			this.buttonLoad.TabIndex = 1;
			this.buttonLoad.Text = "Φόρτωση";
			this.buttonLoad.UseVisualStyleBackColor = true;
			this.buttonLoad.Click += new System.EventHandler(this.ButtonLoadClick);
			// 
			// buttonDelete
			// 
			this.buttonDelete.AutoEllipsis = true;
			this.buttonDelete.Location = new System.Drawing.Point(12, 204);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(70, 23);
			this.buttonDelete.TabIndex = 2;
			this.buttonDelete.Text = "Διαγρφή";
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
			// 
			// ContactsForm
			// 
			this.AcceptButton = this.buttonLoad;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(245, 233);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.buttonLoad);
			this.Controls.Add(this.listBoxContacts);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ContactsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Λίστα επαφών";
			this.Load += new System.EventHandler(this.ContactsFormLoad);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ContactsFormFormClosing);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.Button buttonLoad;
		private System.Windows.Forms.ListBox listBoxContacts;
	}
}
