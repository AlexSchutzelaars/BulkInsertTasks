using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BulkInsertTasks
{
	public static class WorkitemInfoHandler
	{
		private static string GetAzdoBaseUrl()
		{
			string organizationName = "ExactGroup";
			string projectName = "EOL-Development";
			string urlOrgPlusProject = $"https://dev.azure.com/{organizationName}/{projectName}"; // Organization URL, for example: https://dev.azure.com/ExactGroup/EOL-DSevelopment               
			return urlOrgPlusProject;
		}

		private static string GetCredentials(string personalAccessToken)
		{
			// encode your personal access token   

			string credentials = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "", personalAccessToken)));
			return credentials;
		}

		private static string GetValueSafely(JObject obj, string property)
		{
			string value = string.Empty;
			if (obj.GetValue(property) != null)
			{
				value = obj.GetValue(property).ToString();
			}
			return value;
		}

		/// <summary>
		/// TODO: also for non-existing work items [add Valid field]
		/// </summary>
		/// <param name="id"></param>
		/// <param name="obj"></param>
		/// <returns></returns>

		private static WorkItemInfo GetWorkItemInfo(int id, JObject obj)
		{
			WorkItemInfo workitemInfo = new()
			{
				Id = id.ToString(),

				// If id = valid then ....

				IterationPath = GetValueSafely(obj, "System.IterationPath"),
				AreaPath = GetValueSafely(obj, "System.AreaPath"),
				Description = GetValueSafely(obj, "System.Description"),
				Title = GetValueSafely(obj, "System.Title"),
				WorkItemType = GetValueSafely(obj, "System.WorkItemType"),
				State = GetValueSafely(obj, "System.State")
			};
			return workitemInfo;
		}

		public static WorkItemInfo GetDataForWorkItem(int workItemId)
		{
			string urlOrgPlusProject = GetAzdoBaseUrl();
			string personalAccessToken = "gp2micjr4uedambvmgjup4ezdx5ncf52ud3h4yz5oyw3gtnp52mq";

			Uri orgAndProjectUrl = new(urlOrgPlusProject);
			string credentials = GetCredentials(personalAccessToken);
			WorkItemInfo wiInfo = null;

			// use the httpclient
			using (var client = new HttpClient())
			{
				client.BaseAddress = orgAndProjectUrl;
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

				// connect to the REST endpoint            
				HttpResponseMessage response;

				// response = client.GetAsync("_apis/projects?stateFilter=All&api-version=5.1").Result;
				response = client.GetAsync($"_apis/wit/workitems/{workItemId}?api-version=5.1").Result;

				// If we have a successful response ...

				if (response.IsSuccessStatusCode)
				{
					string value = response.Content.ReadAsStringAsync().Result;
					dynamic deserialized = JObject.Parse(value);
					dynamic fields = deserialized.fields;
					JObject obj = JObject.Parse(fields.ToString());

					wiInfo = GetWorkItemInfo(workItemId, obj);
					wiInfo.IsValid = true;

					// https://stackoverflow.com/questions/58974020/c-sharp-equivalent-for-powershell-invoke-restmethod-token
				}

				else
				{
					// TODO:

					/* wiInfo = new WorkItemInfo { Id = sWorkItemId, IsValid = false }; */
				}
			}
			return wiInfo;
		}
	}

}
