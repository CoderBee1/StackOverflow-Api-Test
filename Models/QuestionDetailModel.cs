using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationTask.Models
{
    public class QuestionDetailModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Link { get; set; }
        public string Tags { get; set; }
    }

}