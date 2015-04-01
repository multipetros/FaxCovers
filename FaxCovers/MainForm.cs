/*
 * FaxCovers - Copyright (C) 2012 Petros Kyladitis
 * A Fax cover page printing program
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
 
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
		private const string INI_PARAM_FONT_NAME = "FONT_NAME" ;
		private const string INI_PARAM_FONT_SIZE = "FONT_SIZE" ;
		public const string INI_PARAM_LANG_FILE = "LANG_FILE" ;
		private bool settingsHided ;
		ToolTip tip = new ToolTip() ;
		
		public MainForm(){
			InitializeComponent() ;
			LoadUIStrings() ;
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
			LoadFontButtonText() ;
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
			Props ini = new Props(INI_NAME, false) ;
			string fontName = ini.GetProperty(INI_PARAM_FONT_NAME) ;
			if(fontName == null)
				fontName = "Sans" ;
			
			string fontSize = ini.GetProperty(INI_PARAM_FONT_SIZE) ;
			if(fontSize == null)
				fontSize = "12" ;
			
			string html = File.ReadAllText(TEMPLATE_FILENAME) ;
			html = html.Replace("#DATE_DATA#", dateTimePicker.Value.ToString("dd/MM/yy")) ;
			html = html.Replace("#PAGES_DATA#", textBoxPages.Text) ;
			html = html.Replace("#TO_DATA#", textBoxTo.Text) ;
			html = html.Replace("#TO_ADDRESS_DATA#", textBoxToAdr.Text) ;
			html = html.Replace("#TO_FAX_DATA#", textBoxToFax.Text) ;
			html = html.Replace("#FROM_DATA#", textBoxFrom.Text) ;
			html = html.Replace("#FROM_CONTACT_DATA#", textBoxFromContact.Text) ;
			html = html.Replace("#FROM_ADDRESS_DATA#", textBoxFromAdr.Text) ;
			html = html.Replace("#FROM_TEL_DATA#", textBoxFromTel.Text) ;
			html = html.Replace("#FROM_FAX_DATA#", textBoxFromFax.Text) ;
			html = html.Replace("#STD_MESSAGE_DATA#", HtmlEncode(textBoxStdMessage.Text)) ;
			html = html.Replace("#MESSAGE_DATA#", HtmlEncode(textBoxMessage.Text)) ;
			html = html.Replace("#FONT_NAME_DATA#", fontName) ;
			html = html.Replace("#FONT_SIZE_DATA#", fontSize) ;
			
			string langFile = ini.GetProperty(INI_PARAM_LANG_FILE) ;
			if(langFile != null){
				Props lang = new Props(langFile, false) ;
				string[] labels = {"HTML_MESSAGE", "HTML_DATE", "HTML_PAGES", "HTML_TO", "HTML_TO_ADDRESS", "HTML_TO_FAX", "HTML_FROM", "HTML_FROM_CONTACT", "HTML_FROM_ADDRESS", "HTML_FROM_TEL", "HTML_FROM_FAX"} ;
				foreach(string label in labels){
					html = html.Replace("#" + label + "#", lang.GetProperty(label, true)) ;
				}
			}
					
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
				ini.SetProperty("REG_CHANGED", true.ToString()) ;
				ini.Save() ;
				Registry.CurrentUser.OpenSubKey(key, true).SetValue("footer", "");
				Registry.CurrentUser.OpenSubKey(key, true).SetValue("header", "");
			} catch(Exception) { }
		}
		
		private void RestorePageSetupRegistry(){
			try{
				string key = @"Software\Microsoft\Internet Explorer\PageSetup";
				Props ini = new Props(INI_NAME, true) ;
				string regFooter = ini.GetProperty("REG_FOOTER") ;
				string regHeader = ini.GetProperty("REG_HEADER") ;
				Registry.CurrentUser.OpenSubKey(key, true).SetValue("footer", regFooter);
				Registry.CurrentUser.OpenSubKey(key, true).SetValue("header", regHeader);
				ini.SetProperty("REG_CHANGED", false.ToString()) ;
			} catch(Exception) { }
		}
		
		private void PrintHtml(){
			Props ini = new Props(INI_NAME, false) ;
			if(ini.GetProperty("REG_CHANGED", true).Equals("False", StringComparison.CurrentCultureIgnoreCase))
				SaveClearPageSetupRegistry() ;

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
			Props ini = new Props(INI_NAME, true) ;
			if(ini.GetProperty("REG_CHANGED", true).Equals("True", StringComparison.CurrentCultureIgnoreCase))
				RestorePageSetupRegistry() ;
			
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
			MessageBox.Show("FaxCovers - v 2.0\nA Fax cover page printing program.\nCopyright (c) 2012 Petros Kyladitis\n\nDistributed under the terms of GNU General Public License.\nThis program comes with ABSOLUTELY NO WARRANTY, is free software, and you are welcome to redistribute it under certain conditions; for licensing details read \"license.txt\".\nFor updates and more info see at <http://multipetros.gr/>", "About", MessageBoxButtons.OK, MessageBoxIcon.Information) ;
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
		
		void ButtonSelectFontClick(object sender, EventArgs e){
			Props ini = new Props(INI_NAME, false) ;			
			fontDialog.ShowDialog() ;
			ini.SetProperty(INI_PARAM_FONT_NAME, fontDialog.Font.FontFamily.Name) ;
			int size = (int)fontDialog.Font.Size ;
			ini.SetProperty(INI_PARAM_FONT_SIZE, size.ToString()) ;
			ini.Save() ;
			LoadFontButtonText() ;
		}
		
		private void LoadFontButtonText(){
			Props ini = new Props(INI_NAME, false) ;
			
			string size = ini.GetProperty(INI_PARAM_FONT_SIZE) ;
			if(size == null)
				size = "Not" ;
			
			string name = ini.GetProperty(INI_PARAM_FONT_NAME) ;
			if(name == null)
				name = "selected" ;
			
			buttonSelectFont.Text = size + " - " + name ;
		}
		
		private void LoadUIStrings(){
			Props ini = new Props(INI_NAME, false) ;
			string langFile = ini.GetProperty("LANG_FILE") ;
			if(langFile == null)
				return ;
			
			Props lang = new Props(langFile, false) ;
			labelDate.Text = lang.GetProperty("DATE", true) ;
			labelPages.Text = lang.GetProperty("PAGES", true) ;
			labelTo.Text = lang.GetProperty("TO", true) ;
			labelToFax.Text = lang.GetProperty("TO_FAX", true) ;
			labelToAddr.Text = lang.GetProperty("TO_ADDR", true) ;
			labelMessage.Text = lang.GetProperty("MESSAGE", true) ;
			labelFrom.Text = lang.GetProperty("FROM", true) ;
			labelFromContact.Text = lang.GetProperty("FROM_CONTACT", true) ;
			labelFromAddr.Text = lang.GetProperty("FROM_ADDR", true) ;
			labelFromTel.Text = lang.GetProperty("FROM_TEL", true) ;
			labelFromFax.Text = lang.GetProperty("FROM_FAX", true) ;
			labelStdCommunication.Text = lang.GetProperty("STD_COM_MESSAGE", true) ;
			buttonSave.Text = lang.GetProperty("SAVE", true) ;
			buttonPrint.Text = lang.GetProperty("PRINT", true) ;
			groupBoxFont.Text = lang.GetProperty("FONT", true) ;
			
			fileToolStripMenuItem.Text = lang.GetProperty("MENU_FILE", true) ;
			loadContactToolStripMenuItem.Text = lang.GetProperty("MENU_LOAD_CONTACT", true) ;
			saveContactToolStripMenuItem.Text = lang.GetProperty("MENU_SAVE_CONTACT", true) ;
			printToolStripMenuItem.Text = lang.GetProperty("MENU_PRINT", true) ;
			exitToolStripMenuItem.Text = lang.GetProperty("MENU_EXIT", true) ;
			helpToolStripMenuItem.Text = lang.GetProperty("MENU_HELP", true) ;
			languageToolStripMenuItem.Text = lang.GetProperty("MENU_LANGUAGE", true) ;
			aboutToolStripMenuItem.Text = lang.GetProperty("MENU_ABOUT", true) ;
			
			tip.SetToolTip(this.buttonPrint, lang.GetProperty("PRINT_TIP", true)) ;
			tip.SetToolTip(this.pictureBoxLoadContact, lang.GetProperty("LOAD_CONTACT_TIP", true)) ;
			tip.SetToolTip(this.pictureBoxSaveContact, lang.GetProperty("SAVE_CONTACT_TIP", true)) ;
			tip.SetToolTip(this.pictureBoxClear, lang.GetProperty("CLEAR_TIP", true)) ;
			tip.SetToolTip(this.pictureBoxRight, lang.GetProperty("SHOW_MORE_TIP", true)) ;
			tip.SetToolTip(this.pictureBoxLeft, lang.GetProperty("SHOW_LESS_TIP", true)) ;
			tip.SetToolTip(this.buttonSave, lang.GetProperty("SAVE_SENDER_TIP", true)) ;
		}
		
		void EnglishToolStripMenuItemClick(object sender, EventArgs e){
			Props ini = new Props(INI_NAME, true) ;
			string currentLanguage = ini.GetProperty(INI_PARAM_LANG_FILE, true) ;
			string selectedLanguage = "en.lang" ;
			if(currentLanguage != selectedLanguage){
				ini.SetProperty(INI_PARAM_LANG_FILE, selectedLanguage) ;
				LoadUIStrings() ;
			}
		}
		
		void GreekToolStripMenuItemClick(object sender, EventArgs e){
			Props ini = new Props(INI_NAME, true) ;			
			string currentLanguage = ini.GetProperty(INI_PARAM_LANG_FILE, true) ;
			string selectedLanguage = "gr.lang" ;
			if(currentLanguage != selectedLanguage){
				ini.SetProperty(INI_PARAM_LANG_FILE, selectedLanguage) ;
				LoadUIStrings() ;
			}
		}
	}
}
