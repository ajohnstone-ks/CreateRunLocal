using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationHost.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DataPortalController : Csla.Server.Hosts.HttpPortalController
	{
		public override Task PostAsync(string operation) {
			try {
				return base.PostAsync(operation);
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
				throw;
			}
		}
	}
}
