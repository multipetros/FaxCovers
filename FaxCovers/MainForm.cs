using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Multipetros ;
using System.IO ;
using Microsoft.Win32 ;

namespace FaxCovers{
	
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form{
		
		public const string INI_NAME = "FaxCovers.ini" ;
		public const string CONTACTS_FILENAME = "Contacts.db" ;
		private const string PRINT_FILENAME = "toprint.html" ;
		private const string TEMPLATE_FILENAME = "template.html" ;
		private const string INI_PARAM_FROM_ORG = "FROM_ORG" ;
		private const string INI_PARAM_FROM_PER = "FROM_PER" ;
		private const string INI_PARAM_FROM_ADR = "FROM_ADR" ;
		private const string INI_PARAM_FROM_FAX = "FROM_FAX" ;
		private const string INI_PARAM_FROM_TEL = "FROM_TEL" ;
		private const string INI_PARAM_STD_MSG = "STD_MSG" ;
		private const string INI_PARAM_LAST_CONTACT = "LAST_CONTACT" ;
		private const string INI_PARAM_HIDE_SETTINGS = "HIDE_SETTINGS" ;
		private bool settingsHided ;
		
		public MainForm(){
			InitializeComponent();
			ToolTip toolTip = new ToolTip() ;
			toolTip.SetToolTip(this.buttonPrint, "Δημιουργία συνοδευτικής σελίδας και εκτύπωσή της") ;
			toolTip.SetToolTip(this.pictureBoxLoadContact, "Φόρτωση στοιχείων επαφή από τη λίστα") ;
			toolTip.SetToolTip(this.pictureBoxSaveContact, "Αποθήκευση στοιχείων επαφής στη λίστα για μετέπειτα χρήση") ;			
			toolTip.SetToolTip(this.pictureBoxClear, "Καθαρισμός όλων των πεδίων") ;
			toolTip.SetToolTip(this.pictureBoxRight, "Εμφάνιση ρυθμίσεων στοιχείων αποστολέα") ;
			toolTip.SetToolTip(this.pictureBoxLeft, "Απόκρυψη ρυθμίσεων στοιχείων αποστολέα") ;
			toolTip.SetToolTip(this.buttonSave, "Αποθήκευση στοιχείων αποστολέα") ;
		}
		
		void ButtonSaveClick(object sender, EventArgs e){
			SaveSettings() ;
		}
		
		private void SaveSettings(){
			Props ini = new Props(INI_NAME, false) ;
			ini.SetProperty(INI_PARAM_FROM_ORG, textBoxFrom.Text) ;
			ini.SetProperty(INI_PARAM_FROM_PER, textBoxFromContact.Text) ;
			ini.SetProperty(INI_PARAM_FROM_ADR, textBoxFromAdr.Text) ;
			ini.SetProperty(INI_PARAM_FROM_FAX, textBoxFromFax.Text) ;
			ini.SetProperty(INI_PARAM_FROM_TEL, textBoxFromTel.Text) ;
			ini.SetProperty(INI_PARAM_STD_MSG, textBoxStdMessage.Text) ;
			ini.Save() ;			
		}
		
		private void LoadSettings(){
			Props ini = new Props(INI_NAME, false) ;
			textBoxStdMessage.Text = ini.GetProperty(INI_PARAM_STD_MSG, true) ;
			textBoxFromTel.Text = ini.GetProperty(INI_PARAM_FROM_TEL, true) ;
			textBoxFromFax.Text = ini.GetProperty(INI_PARAM_FROM_FAX, true) ;
			textBoxFromAdr.Text = ini.GetProperty(INI_PARAM_FROM_ADR, true) ;
			textBoxFromContact.Text = ini.GetProperty(INI_PARAM_FROM_PER, true) ;
			textBoxFrom.Text = ini.GetProperty(INI_PARAM_FROM_ORG, true) ;
			
			if(ini.GetProperty(INI_PARAM_HIDE_SETTINGS, true).Equals("True", StringComparison.CurrentCultureIgnoreCase))
				HideSettings() ;
			else
				RevealSettings() ;
			
			dateTimePicker.Value = DateTime.Now ;
		}
		
		void MainFormLoad(object sender, EventArgs e){			
			LoadSettings() ;
			LoadContact() ;
			SaveClearPageSetupRegistry() ;
		}
		
		void PictureBoxRightClick(object sender, EventArgs e){
			RevealSettings() ;
		}
		
		void PictureBoxLeftClick(object sender, EventArgs e){
			HideSettings() ;
		}
		
		private void RevealSettings(){
			pictureBoxRight.Visible = false ;
			pictureBoxLeft.Visible = true ;
			this.Width = 485 ;
			settingsHided = false ;
		}
		
		private void HideSettings(){
			pictureBoxRight.Visible = true ;
			pictureBoxLeft.Visible = false ;
			this.Width = 260 ;
			settingsHided = true ;
		}
		
		private void SaveHtml(){
			string html = File.ReadAllText(TEMPLATE_FILENAME) ;
			html = html.Replace("#date#", dateTimePicker.Value.ToString("dd/MM/yy")) ;
			html = html.Replace("#pages#", textBoxPages.Text) ;
			html = html.Replace("#to#", textBoxTo.Text) ;
			html = html.Replace("#toadr#", textBoxToAdr.Text) ;
			html = html.Replace("#tofax#", textBoxToFax.Text) ;
			html = html.Replace("#from#", textBoxFrom.Text) ;
			html = html.Replace("#fromcont#", textBoxFromContact.Text) ;
			html = html.Replace("#fromadr#", textBoxFromAdr.Text) ;
			html = html.Replace("#fromtel#", textBoxFromTel.Text) ;
			html = html.Replace("#fromfax#", textBoxFromFax.Text) ;
			html = html.Replace("#stdmsg#", HtmlEncode(textBoxStdMessage.Text)) ;
			html = html.Replace("#msg#", HtmlEncode(textBoxMessage.Text)) ;
			File.WriteAllText(PRINT_FILENAME, html) ;
		}
		
		private void SaveClearPageSetupRegistry(){
			try{
				string key = @"Software\Microsoft\Internet Explorer\PageSetup";
				string regFooter = Registry.CurrentUser.OpenSubKey(key).GetValue("footer").ToString();
				string regHeader = Registry.CurrentUser.OpenSubKey(key).GetValue("header").ToString();
				Props ini = new Props(INI_NAME, false) ;
				ini.SetProperty("REG_FOOTER", regFooter) ;
				ini.SetProperty("REG_HEADER", regHeader) ;
				ini.Save() ;
				Registry.CurrentUser.OpenSubKey(key, true).SetValue("footer", "");
				Registry.CurrentUser.OpenSubKey(key, true).SetValue("header", "");	
			} catch(Exception) { }
		}
		
		private void RestorePageSetupRegistry(){
			try{
				string key = @"Software\Microsoft\Internet Explorer\PageSetup";
				Props ini = new Props(INI_NAME, false) ;
				string regFooter = ini.GetProperty("REG_FOOTER") ;
				string regHeader = ini.GetProperty("REG_HEADER") ;			
				Registry.CurrentUser.OpenSubKey(key, true).SetValue("footer", regFooter);
				Registry.CurrentUser.OpenSubKey(key, true).SetValue("header", regHeader);			
			} catch(Exception) { }
		}
		
		private void PrintHtml(){
			WebBrowser ie = new WebBrowser() ;
			string printPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + PRINT_FILENAME ;			
			webBrowser.Navigate(printPath) ;			
		}
		
		void ButtonPrintClick(object sender, EventArgs e){
			SaveHtml() ;
			//PrintHtml() ;
		}
		
		void WebBrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e){
			webBrowser.ShowPrintDialog() ;
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e){
			RestorePageSetupRegistry() ;
			Props ini = new Props(INI_NAME, true) ;
			string currentContact = textBoxTo.Text + "\t" + textBoxToFax.Text + "\t" + textBoxToAdr.Text ;
			ini.SetProperty(INI_PARAM_LAST_CONTACT, currentContact) ;			
			ini.SetProperty(INI_PARAM_HIDE_SETTINGS, settingsHided.ToString()) ;
		}
		
		void PrintToolStripMenuItemClick(object sender, EventArgs e){
			SaveHtml() ;
			PrintHtml() ;			
		}
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e){
			Application.Exit() ;
		}
		
		void AboutToolStripMenuItemClick(object sender, EventArgs e){
			MessageBox.Show("FaxCovers - v 1.6\nΜια εφαρμογή εκτύπωσης συνοδευτικών σελίδων ΦΑΞ\nCopyright (c) 2012 Πέτρος Κυλαδίτης", "Πληροφορίες για την εφαρμογή", MessageBoxButtons.OK, MessageBoxIcon.Information) ;
		}
		
		void PictureBoxLoadContactClick(object sender, EventArgs e)	{
			ContactsForm contacts = new ContactsForm() ;
			DialogResult result = contacts.ShowDialog() ;
			if(result == DialogResult.OK)
				LoadContact() ;
		}
		
		void LoadContact(){
			Props ini = new Props(INI_NAME, false) ;
			string lastContact = ini.GetProperty(INI_PARAM_LAST_CONTACT) ;
			if(lastContact !=  null){
				string[] contactFields = lastContact.Split("\t".ToCharArray()) ;
				if(contactFields.Length == 3){
					textBoxTo.Text = contactFields[0] ;
					textBoxToFax.Text = contactFields[1] ;
					textBoxToAdr.Text = contactFields[2] ;
				}
			}
		}
		
		void PictureBoxSaveContactClick(object sender, EventArgs e)	{
			SaveContact() ;
		}
		
		void SaveContact(){
			Props ini = new Props(INI_NAME, false) ;
			string lastContact = ini.GetProperty(INI_PARAM_LAST_CONTACT, true) ;	
			string currentContact = textBoxTo.Text + "\t" + textBoxToFax.Text + "\t" + textBoxToAdr.Text ;
			if(lastContact != currentContact){
				currentContact += "\r\n" ;
				File.AppendAllText(CONTACTS_FILENAME, currentContact) ;
			}
		}
		
		void PictureBoxClearClick(object sender, EventArgs e){
			dateTimePicker.Value = System.DateTime.Now ;
			textBoxPages.Text = "" ;
			textBoxTo.Text = "" ;
			textBoxToAdr.Text = "" ;
			textBoxToFax.Text = "" ;
		}
		
		private string HtmlEncode(string text){
			string encodedText = text ;			
			encodedText = encodedText.Replace("&","&amp;") ;
			encodedText = encodedText.Replace(" ", "&nbsp;") ;
			encodedText = encodedText.Replace("<", "&lt;") ;
			encodedText = encodedText.Replace(">","&gt;") ;
			encodedText = encodedText.Replace("\"","&quot;") ;
			encodedText = encodedText.Replace("'","&apos;") ;			
			encodedText = encodedText.Replace("\n", "<br>") ;
			return encodedText ;
		}
		
		void LoadContactToolStripMenuItemClick(object sender, EventArgs e){
			PictureBoxLoadContactClick(sender, e) ;
		}
		
		void SaveContactToolStripMenuItemClick(object sender, EventArgs e){
			PictureBoxSaveContactClick(sender, e) ;
		}
	}
}
