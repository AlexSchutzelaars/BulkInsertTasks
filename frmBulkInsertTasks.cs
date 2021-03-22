using BulkInsertTasks;
using NsBulkInsertTasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BulkInsertV2
{

	public partial class frmDemoBulkInsert : Form
	{
		public frmDemoBulkInsert()
		{
			InitializeComponent();
		}

		// Version of March 19th, 23:51

		private void frmDemoBulkInsert_Load(object sender, EventArgs e)
		{
			txtIterationPath.Text = @"EOL-Development\Payroll\Payroll CLA NL\2021\Sprint 0911";

			string templatesFolder = @"C:\AzDo Scripts Bulkimport";

			// TODO: Get name of xml file from settings
			//       CSV file will be phased out.

			string teamName = "CLA";

			txtTemplatesFileForTeam.Text = Path.Combine(templatesFolder, $"{teamName}TeamTaskTemplates.xml");
			string wiExportFile = Path.Combine(templatesFolder, $"WorkItemsForBulkInsert_{teamName}Team.csv");
			txtWorkItemsExportFile.Text = wiExportFile;
		}

		private static int ExtractWorkItemFromDescription(string description)
		{
			if (description.Length > 5)
			{
				string[] words = description.Split(' ');
				bool OK = int.TryParse(words[0], out int workItem);
				if (!OK)
				{
					workItem = 99999;
				}
				return workItem;
			}
			else
			{
				return 99999;
			}
		}

		private void btnCreateTasks_Click(object sender, EventArgs e)
		{
			foreach (var item in chkListWorkItems.Items)
			{
				int wi = ExtractWorkItemFromDescription(item.ToString());
				WorkItemInfo wiAzDo = WorkitemInfoHandler.GetDataForWorkItem(wi);

				// TODO: process in validation routine

				if (wiAzDo != null && wiAzDo.IsValid)
				{
					if (wiAzDo.WorkItemType == "Task")
					{
						MessageBox.Show(wiAzDo.Id + " is not valid (no tasks within tasks allowed)");
					}
				}
			}
		}

		private void chkListWorkItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			int wi = ExtractWorkItemFromDescription(((CheckedListBox)sender).SelectedItem.ToString());
			WorkItemInfo wiAzDo = WorkitemInfoHandler.GetDataForWorkItem(wi);
			lstDebugInfoOnWorkItem.Items.Clear();

			if (wiAzDo != null)
			{
				lstDebugInfoOnWorkItem.Items.Add(wiAzDo.Id);
				lstDebugInfoOnWorkItem.Items.Add(wiAzDo.Title);
				lstDebugInfoOnWorkItem.Items.Add(wiAzDo.Description);
				lstDebugInfoOnWorkItem.Items.Add(wiAzDo.State);
			}
		}

		private void btnOpenTemplateFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog fdlg = new OpenFileDialog();
			fdlg.Title = "Select Team Templates file";
			fdlg.InitialDirectory = @"C:\AzDo Scripts Bulkimport";

			fdlg.Filter = "xml files (*.xml)|*.xml";
			fdlg.FilterIndex = 2;
			fdlg.RestoreDirectory = true;
			if (fdlg.ShowDialog() == DialogResult.OK)
			{
				txtTemplatesFileForTeam.Text = fdlg.FileName;
			}

		}


		public class TeamTemplate
		{
			public string Title;
			public string Activity;
			public string AreaPath;
			public string Description;
			public string IterationPath;
			public string RemainingWork;
			public string Comments;

		}
		public IEnumerable<TeamTemplate> ReadTemplatesXML()
		{
			//// First write something so that there is something to read ...  
			//var b = new Book { title = "Serialization Overview" };
			//var writer = new System.Xml.Serialization.XmlSerializer(typeof(Book));
			//var wfile = new System.IO.StreamWriter(@"c:\temp\SerializationOverview.xml");
			//writer.Serialize(wfile, b);
			//wfile.Close();

			string inputFile = txtTemplatesFileForTeam.Text;

			var xml = XDocument.Load(inputFile);

			IEnumerable<TeamTemplate> qryTemplates = from c in xml.Root.Descendants("template")
						 select new TeamTemplate
						 { 
							 Title = c.Element("Title").Value,
							 Activity = c.Element("Activity").Value,
							 AreaPath = c.Element("AreaPath").Value,
							 Description = c.Element("Description").Value,
							 IterationPath = c.Element("IterationPath").Value,
							 RemainingWork = c.Element("RemainingWork").Value,
							 Comments = c.Element("Comments").Value,
						 };

			return qryTemplates;

			// Werkte niet ...

			// Now we can read the serialized book ...  
			//System.Xml.Serialization.XmlSerializer reader =
			//	new System.Xml.Serialization.XmlSerializer(typeof(List<TeamTemplate>));

			//StreamReader file = new System.IO.StreamReader(
			//	inputFile);
			//List<TeamTemplate> overview = (List<TeamTemplate>)reader.Deserialize(file);
			//file.Close();

			//Console.WriteLine(overview.Title);

		}

		private void btnGetWorkItems_Click(object sender, EventArgs e)
		{

			var templates = ReadTemplatesXML();

			// TODO: Get workitems directly from AzDo
			// Use the templates as a filter (AreaPath)

			List<CsvReadData> workItemsCsvData = BulkInsertCsvReader.ReadCsvTemplatesFile(txtWorkItemsExportFile.Text);

			// TODO: Get workitems directly from AzDo

			// List<int> workItems = new() { 65954, 69976, 99999 };

			//foreach (var wi in workItems)
			//{
			//	var wiData = WorkitemInfoHandler.GetDataForWorkItem(wi);
			//	if (wiData != null)
			//	{
			//		chkListWorkItems.Items.Add(wiData.Title, wiAzdo.IsValid);
			//	}
			//}

			foreach (CsvReadData wiData in workItemsCsvData)
			{
				int wi = int.Parse(wiData.Id);
				var wiAzdo = WorkitemInfoHandler.GetDataForWorkItem(wi);
				if (wiAzdo != null)
				{
					chkListWorkItems.Items.Add(wiAzdo.Title, wiAzdo.IsValid);
				}
				else
				{
					// Not found in AzDo: still show to user !!!!

					chkListWorkItems.Items.Add(wiData.Title, false);
				}
			}
		}
	}

}
