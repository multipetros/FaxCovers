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
		
		private const string INI_NAME = "FaxCovers.ini" ;
		private const string PRINT_FILENAME = "toprint.html" ;
		private const string TEMPLATE_FILENAME = "template.html" ;
		
		public MainForm(){
			InitializeComponent();			
		}
		
		void ButtonSaveClick(object sender, EventArgs e){
			SaveSettings() ;
		}
		
		private void SaveSettings(){
			Props ini = new Props(INI_NAME, false) ;
			ini.SetProperty("FROM_ORG", textBoxFrom.Text) ;
			ini.SetProperty("FROM_PER", textBoxFromContact.Text) ;
			ini.SetProperty("FROM_ADR", textBoxFromAdr.Text) ;
			ini.SetProperty("FROM_FAX", textBoxFromFax.Text) ;
			ini.SetProperty("FROM_TEL", textBoxFromTel.Text) ;
			ini.SetProperty("STD_MSG", textBoxStdMessage.Text) ;
			ini.Save() ;			
		}
		
		private void LoadSettings(){
			Props ini = new Props(INI_NAME, false) ;
			textBoxStdMessage.Text = ini.GetProperty("STD_MSG") ;
			textBoxFromTel.Text = ini.GetProperty("FROM_TEL") ;
			textBoxFromFax.Text = ini.GetProperty("FROM_FAX") ;
			textBoxFromAdr.Text = ini.GetProperty("FROM_ADR") ;
			textBoxFromContact.Text = ini.GetProperty("FROM_PER") ;
			textBoxFrom.Text = ini.GetProperty("FROM_ORG") ;
			dateTimePicker.Value = DateTime.Now ;
		}
		
		void MainFormLoad(object sender, EventArgs e){
			LoadSettings() ;
			SaveClearPageSetupRegistry() ;
		}
		
		void PictureBoxRightClick(object sender, EventArgs e){			
			pictureBoxRight.Visible = false ;
			pictureBoxLeft.Visible = true ;
			//reveal form smoothly
			while(this.Width <= 485){
				this.Width++ ;
				Application.DoEvents() ;
			}
			//this.Width = 485 ;
		}
		
		void PictureBoxLeftClick(object sender, EventArgs e){			
			pictureBoxRight.Visible = true ;
			pictureBoxLeft.Visible = false ;
			//hide a pice of form smoothly
			while(this.Width > 260){
				this.Width-- ;
				Application.DoEvents() ;
			}
			//this.Width = 255 ;
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
			html = html.Replace("#stdmsg#", textBoxStdMessage.Text) ;
			html = html.Replace("#msg#", textBoxMessage.Text) ;
			File.WriteAllText(PRINT_FILENAME, html) ;
		}
		
		private void SaveClearPageSetupRegistry(){
			string key = @"Software\Microsoft\Internet Explorer\PageSetup";
			string regFooter = Registry.CurrentUser.OpenSubKey(key).GetValue("footer").ToString();
			string regHeader = Registry.CurrentUser.OpenSubKey(key).GetValue("header").ToString();
			Props ini = new Props(INI_NAME, false) ;
			ini.SetProperty("REG_FOOTER", regFooter) ;
			ini.SetProperty("REG_HEADER", regHeader) ;
			ini.Save() ;
			Registry.CurrentUser.OpenSubKey(key, true).SetValue("footer", "");
			Registry.CurrentUser.OpenSubKey(key, true).SetValue("header", "");				
		}
		
		private void RestorePageSetupRegistry(){
			string key = @"Software\Microsoft\Internet Explorer\PageSetup";
			Props ini = new Props(INI_NAME, false) ;
			string regFooter = ini.GetProperty("REG_FOOTER") ;
			string regHeader = ini.GetProperty("REG_HEADER") ;			
			Registry.CurrentUser.OpenSubKey(key, true).SetValue("footer", regFooter);
			Registry.CurrentUser.OpenSubKey(key, true).SetValue("header", regHeader);			
		}
		
		private void PrintHtml(){
			WebBrowser ie = new WebBrowser() ;
			string printPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + PRINT_FILENAME ;			
			webBrowser.Navigate(printPath) ;			
		}
		
		void ButtonPrintClick(object sender, EventArgs e){
			SaveHtml() ;
			PrintHtml() ;
		}
		
		void WebBrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e){
			webBrowser.ShowPrintDialog() ;
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e){
			RestorePageSetupRegistry() ;
		}
		
		void PrintToolStripMenuItemClick(object sender, EventArgs e){
			SaveHtml() ;
			PrintHtml() ;			
		}
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e){
			Application.Exit() ;
		}
		
		void AboutToolStripMenuItemClick(object sender, EventArgs e){
			MessageBox.Show("FaxCovers - v 1.0\nΜια εφαρμογή εκτύπωσης συνοδευτικών σελίδων ΦΑΞ\nCopyright (c) 2012 Πέτρος Κυλαδίτης", "Πληροφορίες για την εφαρμογή", MessageBoxButtons.OK, MessageBoxIcon.Information) ;
		}
	}
}
