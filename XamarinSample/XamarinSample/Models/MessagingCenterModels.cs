using System;
using System.Collections.Generic;
using System.Text;
using XamarinSample.Consts;

namespace XamarinSample.Models
{
    class AlertParameter
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Accept { get; set; }
        public string Cancel { get; set; }
        public Action<bool> Action { get; set; }
    }

    public class UserType
    {
        public CommonEnums.UserCategoryType userCategory { get; set; }
        public CommonEnums.UserStatusType userStatus { get; set; }

    }
}
