using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebservice
{
    public class notification
    {
        public string title { get; set; }
        public string body_content { get; set; }
        public int notification_id { get; set; }
        public string notification_generated_date { get; set; }
    }

    public class CustomNotificationReq
    {
        public string title { get; set; }
        public string body { get; set; }


    }

    public partial class USP_Notification_Result
    {
        public string title { get; set; }
        public string body_content { get; set; }
        public int notification_id { get; set; }
        public string notification_generated_date { get; set; }
    }
}