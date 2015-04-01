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
			ToolTip toolTip = new ToolTip() ;
			toolTip.SetToolTip(listBoxContacts, "Επιλέξετε την επαφή που θέλετε και κάντε διπλό κλικ σε αυτήν\nγια κλείσει αυτό το παράθυρο και να φορτωθεί στην εφαρμογή") ;
			toolTip.SetToolTip(buttonLoad, "Φόρτωση των στοιχείων της επιλεγμένης επαφής\nστην εφαρμογή και κλείσιμο αυτού του παραθύρου") ;
			toolTip.SetToolTip(buttonDelete, "Διαγραφή της επιλεγμένης επαφής από τη λίστα\nΠροσοχή! Η ενέργεια αυτή δεν μπορεί να αναιρεθεί") ;		
		}
		
		bool contactsDeleted = false ;
		
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
	}
}
