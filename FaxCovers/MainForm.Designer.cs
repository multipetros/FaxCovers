namespace FaxCovers{
	
	partial class MainForm{
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.textBoxPages = new System.Windows.Forms.TextBox();
			this.textBoxToFax = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxTo = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxToAdr = new System.Windows.Forms.TextBox();
			this.textBoxFromFax = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxFromAdr = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.textBoxFromTel = new System.Windows.Forms.TextBox();
			this.textBoxFromContact = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBoxFrom = new System.Windows.Forms.TextBox();
			this.textBoxMessage = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.menuStripMain = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemSparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonPrint = new System.Windows.Forms.Button();
			this.pictureBoxRight = new System.Windows.Forms.PictureBox();
			this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
			this.textBoxStdMessage = new System.Windows.Forms.TextBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.webBrowser = new System.Windows.Forms.WebBrowser();
			this.label13 = new System.Windows.Forms.Label();
			this.pictureBoxLoadContact = new System.Windows.Forms.PictureBox();
			this.pictureBoxSaveContact = new System.Windows.Forms.PictureBox();
			this.pictureBoxClear = new System.Windows.Forms.PictureBox();
			this.menuStripMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoadContact)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSaveContact)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxClear)).BeginInit();
			this.SuspendLayout();
			// 
			// dateTimePicker
			// 
			this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker.Location = new System.Drawing.Point(101, 31);
			this.dateTimePicker.Name = "dateTimePicker";
			this.dateTimePicker.Size = new System.Drawing.Size(128, 20);
			this.dateTimePicker.TabIndex = 30;
			// 
			// textBoxPages
			// 
			this.textBoxPages.Location = new System.Drawing.Point(101, 57);
			this.textBoxPages.Name = "textBoxPages";
			this.textBoxPages.Size = new System.Drawing.Size(128, 20);
			this.textBoxPages.TabIndex = 0;
			// 
			// textBoxToFax
			// 
			this.textBoxToFax.Location = new System.Drawing.Point(101, 109);
			this.textBoxToFax.Name = "textBoxToFax";
			this.textBoxToFax.Size = new System.Drawing.Size(128, 20);
			this.textBoxToFax.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Ημερομηνία";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Αρ. σελίδων";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Αρ. Φαξ";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 86);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Προς";
			// 
			// textBoxTo
			// 
			this.textBoxTo.Location = new System.Drawing.Point(101, 83);
			this.textBoxTo.Name = "textBoxTo";
			this.textBoxTo.Size = new System.Drawing.Size(128, 20);
			this.textBoxTo.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(12, 138);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(83, 23);
			this.label5.TabIndex = 8;
			this.label5.Text = "Διεύθυνση";
			// 
			// textBoxToAdr
			// 
			this.textBoxToAdr.Location = new System.Drawing.Point(101, 135);
			this.textBoxToAdr.Name = "textBoxToAdr";
			this.textBoxToAdr.Size = new System.Drawing.Size(128, 20);
			this.textBoxToAdr.TabIndex = 3;
			// 
			// textBoxFromFax
			// 
			this.textBoxFromFax.Location = new System.Drawing.Point(335, 135);
			this.textBoxFromFax.Name = "textBoxFromFax";
			this.textBoxFromFax.Size = new System.Drawing.Size(128, 20);
			this.textBoxFromFax.TabIndex = 10;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(257, 138);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 23);
			this.label6.TabIndex = 16;
			this.label6.Text = "Φαξ";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(257, 86);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 23);
			this.label7.TabIndex = 15;
			this.label7.Text = "Διεύθυνση";
			// 
			// textBoxFromAdr
			// 
			this.textBoxFromAdr.Location = new System.Drawing.Point(335, 83);
			this.textBoxFromAdr.Name = "textBoxFromAdr";
			this.textBoxFromAdr.Size = new System.Drawing.Size(128, 20);
			this.textBoxFromAdr.TabIndex = 8;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(257, 112);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(72, 23);
			this.label8.TabIndex = 13;
			this.label8.Text = "Τηλέφνο";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(257, 60);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 23);
			this.label9.TabIndex = 12;
			this.label9.Text = "Υπεύθυνος";
			// 
			// textBoxFromTel
			// 
			this.textBoxFromTel.Location = new System.Drawing.Point(335, 109);
			this.textBoxFromTel.Name = "textBoxFromTel";
			this.textBoxFromTel.Size = new System.Drawing.Size(128, 20);
			this.textBoxFromTel.TabIndex = 9;
			// 
			// textBoxFromContact
			// 
			this.textBoxFromContact.Location = new System.Drawing.Point(335, 57);
			this.textBoxFromContact.Name = "textBoxFromContact";
			this.textBoxFromContact.Size = new System.Drawing.Size(128, 20);
			this.textBoxFromContact.TabIndex = 7;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(257, 34);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 23);
			this.label10.TabIndex = 19;
			this.label10.Text = "Από";
			// 
			// textBoxFrom
			// 
			this.textBoxFrom.Location = new System.Drawing.Point(335, 31);
			this.textBoxFrom.Name = "textBoxFrom";
			this.textBoxFrom.Size = new System.Drawing.Size(128, 20);
			this.textBoxFrom.TabIndex = 6;
			// 
			// textBoxMessage
			// 
			this.textBoxMessage.Location = new System.Drawing.Point(12, 192);
			this.textBoxMessage.Multiline = true;
			this.textBoxMessage.Name = "textBoxMessage";
			this.textBoxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxMessage.Size = new System.Drawing.Size(217, 99);
			this.textBoxMessage.TabIndex = 4;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(12, 171);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(184, 18);
			this.label11.TabIndex = 21;
			this.label11.Text = "Συνοδευτικό κείμενο";
			// 
			// label12
			// 
			this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label12.Location = new System.Drawing.Point(242, 34);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(2, 280);
			this.label12.TabIndex = 22;
			// 
			// menuStripMain
			// 
			this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem,
									this.helpToolStripMenuItem});
			this.menuStripMain.Location = new System.Drawing.Point(0, 0);
			this.menuStripMain.Name = "menuStripMain";
			this.menuStripMain.Size = new System.Drawing.Size(483, 24);
			this.menuStripMain.TabIndex = 23;
			this.menuStripMain.Text = "menuStrip";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.loadContactToolStripMenuItem,
									this.saveContactToolStripMenuItem,
									this.printToolStripMenuItem,
									this.toolStripMenuItemSparator1,
									this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
			this.fileToolStripMenuItem.Text = "&Αρχείο";
			// 
			// loadContactToolStripMenuItem
			// 
			this.loadContactToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadContactToolStripMenuItem.Image")));
			this.loadContactToolStripMenuItem.Name = "loadContactToolStripMenuItem";
			this.loadContactToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.loadContactToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
			this.loadContactToolStripMenuItem.Text = "&Φόρτωση επαφής";
			this.loadContactToolStripMenuItem.Click += new System.EventHandler(this.LoadContactToolStripMenuItemClick);
			// 
			// saveContactToolStripMenuItem
			// 
			this.saveContactToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveContactToolStripMenuItem.Image")));
			this.saveContactToolStripMenuItem.Name = "saveContactToolStripMenuItem";
			this.saveContactToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveContactToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
			this.saveContactToolStripMenuItem.Text = "Απο&θήκευση επαφής";
			this.saveContactToolStripMenuItem.Click += new System.EventHandler(this.SaveContactToolStripMenuItemClick);
			// 
			// printToolStripMenuItem
			// 
			this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
			this.printToolStripMenuItem.Name = "printToolStripMenuItem";
			this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.printToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
			this.printToolStripMenuItem.Text = "&Εκτύπωση";
			this.printToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItemClick);
			// 
			// toolStripMenuItemSparator1
			// 
			this.toolStripMenuItemSparator1.Name = "toolStripMenuItemSparator1";
			this.toolStripMenuItemSparator1.Size = new System.Drawing.Size(225, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
			this.exitToolStripMenuItem.Text = "Έ&ξοδος";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
			this.helpToolStripMenuItem.Text = "&Βοήθεια";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.aboutToolStripMenuItem.Text = "&Πληροφορίες";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
			// 
			// buttonPrint
			// 
			this.buttonPrint.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrint.Image")));
			this.buttonPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonPrint.Location = new System.Drawing.Point(51, 300);
			this.buttonPrint.Name = "buttonPrint";
			this.buttonPrint.Size = new System.Drawing.Size(134, 34);
			this.buttonPrint.TabIndex = 5;
			this.buttonPrint.Text = "Εκτύπωση";
			this.buttonPrint.UseVisualStyleBackColor = true;
			this.buttonPrint.Click += new System.EventHandler(this.ButtonPrintClick);
			// 
			// pictureBoxRight
			// 
			this.pictureBoxRight.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxRight.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxRight.Image")));
			this.pictureBoxRight.Location = new System.Drawing.Point(236, 315);
			this.pictureBoxRight.Name = "pictureBoxRight";
			this.pictureBoxRight.Size = new System.Drawing.Size(15, 18);
			this.pictureBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBoxRight.TabIndex = 26;
			this.pictureBoxRight.TabStop = false;
			this.pictureBoxRight.Click += new System.EventHandler(this.PictureBoxRightClick);
			// 
			// pictureBoxLeft
			// 
			this.pictureBoxLeft.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxLeft.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLeft.Image")));
			this.pictureBoxLeft.Location = new System.Drawing.Point(236, 315);
			this.pictureBoxLeft.Name = "pictureBoxLeft";
			this.pictureBoxLeft.Size = new System.Drawing.Size(15, 18);
			this.pictureBoxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBoxLeft.TabIndex = 27;
			this.pictureBoxLeft.TabStop = false;
			this.pictureBoxLeft.Visible = false;
			this.pictureBoxLeft.Click += new System.EventHandler(this.PictureBoxLeftClick);
			// 
			// textBoxStdMessage
			// 
			this.textBoxStdMessage.Location = new System.Drawing.Point(257, 196);
			this.textBoxStdMessage.Multiline = true;
			this.textBoxStdMessage.Name = "textBoxStdMessage";
			this.textBoxStdMessage.Size = new System.Drawing.Size(206, 66);
			this.textBoxStdMessage.TabIndex = 11;
			// 
			// buttonSave
			// 
			this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
			this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSave.Location = new System.Drawing.Point(355, 268);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(108, 23);
			this.buttonSave.TabIndex = 12;
			this.buttonSave.Text = "Αποθήκευση";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// webBrowser
			// 
			this.webBrowser.Location = new System.Drawing.Point(0, 327);
			this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.Size = new System.Drawing.Size(20, 20);
			this.webBrowser.TabIndex = 30;
			this.webBrowser.Visible = false;
			this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowserDocumentCompleted);
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(257, 171);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(206, 23);
			this.label13.TabIndex = 31;
			this.label13.Text = "Standard μήνυμα επικονωνίας";
			// 
			// pictureBoxLoadContact
			// 
			this.pictureBoxLoadContact.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxLoadContact.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLoadContact.Image")));
			this.pictureBoxLoadContact.Location = new System.Drawing.Point(79, 86);
			this.pictureBoxLoadContact.Name = "pictureBoxLoadContact";
			this.pictureBoxLoadContact.Size = new System.Drawing.Size(16, 16);
			this.pictureBoxLoadContact.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBoxLoadContact.TabIndex = 32;
			this.pictureBoxLoadContact.TabStop = false;
			this.pictureBoxLoadContact.Click += new System.EventHandler(this.PictureBoxLoadContactClick);
			// 
			// pictureBoxSaveContact
			// 
			this.pictureBoxSaveContact.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxSaveContact.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSaveContact.Image")));
			this.pictureBoxSaveContact.Location = new System.Drawing.Point(60, 86);
			this.pictureBoxSaveContact.Name = "pictureBoxSaveContact";
			this.pictureBoxSaveContact.Size = new System.Drawing.Size(16, 16);
			this.pictureBoxSaveContact.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBoxSaveContact.TabIndex = 33;
			this.pictureBoxSaveContact.TabStop = false;
			this.pictureBoxSaveContact.Click += new System.EventHandler(this.PictureBoxSaveContactClick);
			// 
			// pictureBoxClear
			// 
			this.pictureBoxClear.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxClear.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClear.Image")));
			this.pictureBoxClear.Location = new System.Drawing.Point(215, 161);
			this.pictureBoxClear.Name = "pictureBoxClear";
			this.pictureBoxClear.Size = new System.Drawing.Size(16, 16);
			this.pictureBoxClear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBoxClear.TabIndex = 34;
			this.pictureBoxClear.TabStop = false;
			this.pictureBoxClear.Click += new System.EventHandler(this.PictureBoxClearClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(483, 346);
			this.Controls.Add(this.pictureBoxClear);
			this.Controls.Add(this.pictureBoxSaveContact);
			this.Controls.Add(this.pictureBoxLoadContact);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.webBrowser);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.textBoxStdMessage);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.pictureBoxLeft);
			this.Controls.Add(this.pictureBoxRight);
			this.Controls.Add(this.buttonPrint);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.textBoxMessage);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.textBoxFrom);
			this.Controls.Add(this.textBoxFromFax);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textBoxFromAdr);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.textBoxFromTel);
			this.Controls.Add(this.textBoxFromContact);
			this.Controls.Add(this.textBoxToAdr);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBoxTo);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxToFax);
			this.Controls.Add(this.textBoxPages);
			this.Controls.Add(this.dateTimePicker);
			this.Controls.Add(this.menuStripMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStripMain;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "FaxCovers";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.menuStripMain.ResumeLayout(false);
			this.menuStripMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoadContact)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSaveContact)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxClear)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.PictureBox pictureBoxClear;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItemSparator1;
		private System.Windows.Forms.ToolStripMenuItem saveContactToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadContactToolStripMenuItem;
		private System.Windows.Forms.PictureBox pictureBoxLoadContact;
		private System.Windows.Forms.PictureBox pictureBoxSaveContact;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.WebBrowser webBrowser;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.TextBox textBoxStdMessage;
		private System.Windows.Forms.PictureBox pictureBoxLeft;
		private System.Windows.Forms.PictureBox pictureBoxRight;
		private System.Windows.Forms.Button buttonPrint;
		private System.Windows.Forms.MenuStrip menuStripMain;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBoxMessage;
		private System.Windows.Forms.TextBox textBoxFrom;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBoxFromContact;
		private System.Windows.Forms.TextBox textBoxFromTel;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBoxFromAdr;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBoxFromFax;
		private System.Windows.Forms.TextBox textBoxToAdr;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxTo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxToFax;
		private System.Windows.Forms.TextBox textBoxPages;
		private System.Windows.Forms.DateTimePicker dateTimePicker;
	}
}
