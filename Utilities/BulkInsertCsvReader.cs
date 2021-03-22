using NsBulkInsertTasks;
using System.Collections.Generic;

namespace BulkInsertV2
{
	/// <summary>
	/// Version of March 19th, 13:47S
	/// </summary>
	/// 
	public static class BulkInsertCsvReader
	{
		/// <summary>
		/// Adapted from:
		/// https://stackoverflow.com/questions/1405038/reading-a-csv-file-in-net
		/// </summary>
		/// <param name="csvFilePath"></param>
		/// <returns></returns>
		public static List<CsvReadData> ReadCsvTemplatesFile(string csvFilePath)
		{
			List<CsvReadData> wiList = new();
			var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(csvFilePath)
			{
				TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
			};
			parser.SetDelimiters(new string[] { "," });

			// File must start with field names on line 1;

			int rowNumber = 0;
			while (!parser.EndOfData)
			{
				string[] row = parser.ReadFields();

				if (rowNumber > 0)
				{
					// We only need the workitem's id for AzDo !
					wiList.Add(new CsvReadData()
					{
						Id = row[0],
						Title = row[2]
					});
				}

				rowNumber += 1;
			}
			return wiList;
		}
	}

}
