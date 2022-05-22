using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCoreWeb.Models {
	public class Site {

		[Key]
		public int Id { get; set; }
		public DateTime? CreateDate { get; set; }
		public DateTime? UpdateDate { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }

		public string LocalUrl { get; set; }
		public bool ForceHttps { get; set; }
		public bool IsActive { get; set; }
		public int InsertedUserId { get; set; }

	}
}
