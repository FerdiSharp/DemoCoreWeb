using DemoCoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;using System.Threading.Tasks;

namespace DemoCoreWeb.Controllers {
	public class HomeController : Controller {
		private readonly ILogger<HomeController> _logger;
		private readonly IConfiguration _configuration;
		private readonly TebFaktoringContext _dbcontext;

		public HomeController(ILogger<HomeController> logger,IConfiguration configuration,TebFaktoringContext dbcontext) {
			_logger = logger;
			_configuration = configuration;
			_dbcontext = dbcontext;
		}

		public IActionResult Index() {
			try {
				List<Site> sites = _dbcontext.Sites.ToList();
				return View(sites);
			}
			catch (Exception ex) {
				ViewData["ErrorMsg"] = ex.Message;
				return View(viewName: "Error");
			}
		}

		public IActionResult Privacy() {
			return View();
		}

		[HttpGet]
		public string CheckDb(string tableName) {
			SqlConnection connection = null;
			try {
				string connectionString = _configuration.GetConnectionString("faktoringDb");
				string sql = "select count(*) from " + tableName;
				connection = new SqlConnection(connectionString);
				if (connection.State != ConnectionState.Open) {
					connection.Open();
				}

				SqlCommand sqlCommand = new SqlCommand(sql, connection);
				int val = int.Parse(sqlCommand.ExecuteScalar().ToString());
				return val.ToString();
			} catch (Exception ex) {
				return ex.Message;
			} finally {
				if (connection != null && connection.State == ConnectionState.Open) {
					connection.Close();
				}
			}

			return "ok";
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
