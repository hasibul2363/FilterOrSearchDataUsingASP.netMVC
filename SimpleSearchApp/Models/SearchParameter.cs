using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleSearchApp.Models
{
    public class SearchParameter
    {
        [Key]
        public int Id { get; set; }
        public string ParameterName { get; set; }
    }
}