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
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic ;
using System.IO ;
using Multipetros ;

namespace FaxCovers{
	
	/// <summary>
	/// Description of ContactsForm.
	/// </summary>
	public partial class ContactsForm : Form{
		public ContactsForm(){
			InitializeComponent();
			LoadUIStrings() ;
		}
		
		bool contactsDeleted = false ;
		ToolTip tip = new ToolTip() ;
			
		void LoadContactAndClose(){
			string selectedContact = (string) listBoxContacts.SelectedItem ;
			if(selectedContact != null){
				Props ini = new Props(MainForm.INI_NAME, true) ;
				ini.SetProperty("LAST_CONTACT", selectedContact) ;
			}
			this.DialogResult = DialogResult.OK ;
			Close() ;			
		}
		
		void ButtonLoadClick(object sender, EventArgs e){
			LoadContactAndClose() ;
		}
		
		void ContactsFormLoad(object sender, EventArgs e){
			string[] contactsFileData = File.ReadAllLines(MainForm.CONTACTS_FILENAME) ;
			listBoxContacts.Items.AddRange(contactsFileData) ;
		}
		
		void ButtonDeleteClick(object sender, EventArgs e){
			if(listBoxContacts.SelectedIndex > -1){
				listBoxContacts.Items.RemoveAt(listBoxContacts.SelectedIndex) ;
				contactsDeleted = true ;
			}
		}
		
		void ContactsFormFormClosing(object sender, FormClosingEventArgs e)	{
			if(contactsDeleted){
				SaveContactsFile() ;
			}
		}
		
		void SaveContactsFile(){
			int contactsCount = listBoxContacts.Items.Count ;
			string[] contacts = new string[contactsCount] ;
			for(int i=0; i<contactsCount; i++){
				contacts[i] = (string)listBoxContacts.Items[i] ;
			}
			File.WriteAllLines(MainForm.CONTACTS_FILENAME, contacts) ;			
		}
		
		void ListBoxContactsDoubleClick(object sender, EventArgs e){
			LoadContactAndClose() ;
		}
		
		private void LoadUIStrings(){
			Props ini = new Props(MainForm.INI_NAME, false) ;
			string langFile = ini.GetProperty(MainForm.INI_PARAM_LANG_FILE) ;
			if(langFile == null)
				return ;
			
			Props lang = new Props(langFile, false) ;
			buttonDelete.Text = lang.GetProperty("CONTACTS_DELETE", true) ;
			buttonLoad.Text = lang.GetProperty("CONTACTS_LOAD", true) ;
			this.Text = lang.GetProperty("CONTACTS_TITLE", true) ;
			
			tip.SetToolTip(listBoxContacts, lang.GetProperty("CONTACTS_TIP", true)) ;
			tip.SetToolTip(buttonLoad, lang.GetProperty("CONTACTS_LOAD_TIP", true)) ;
			tip.SetToolTip(buttonDelete, lang.GetProperty("CONTACTS_DELETE_TIP", true)) ;
		}
	}
}
