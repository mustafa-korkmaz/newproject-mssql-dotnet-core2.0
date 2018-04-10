using System;
using System.Collections.Generic;
using System.Linq;

namespace Dto
{
    public class ApplicationUser
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string NameSurname { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string ImageName { get; set; }

        public bool ContactPermission { get; set; }

        //public string ImageUrl
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(ImageName))
        //        {
        //            return Statics.GetApiUrl() + ImagePath.User + ImageName;
        //        }
        //        return null;
        //    }
        //}

        public DateTime CreatedAt { get; set; }

        //public Status Status { get; set; }   // author status

        public int PredictionsTotal { get; set; } // total tip amount that author wrote for any event

        public int WonTotal { get; set; } // total won count

        public int CommentsTotal { get; set; } // total comment amount that author wrote for any event

        public decimal Yield { get; set; } // yield

        public IList<string> Roles { get; set; }

        public Dictionary<string, string> Claims { get; set; }

        //public bool IsAdmin
        //{
        //    get
        //    {
        //        if (Roles == null)
        //        {
        //            return false;
        //        }
        //        return Roles.Any(r => r == ApplicationRole.Admin);
        //    }
        //}

     
    }
}
