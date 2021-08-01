using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Core.Models
{
    public class Yetki
    {
        public int Id { get; set; }
        public Guid user_id { get; set; }
        public string controller_name { get; set; }
        public bool can_get { get; set; }
        public bool can_post { get; set; }
        public bool can_put { get; set; }
        public bool can_delete { get; set; }
    }
}
