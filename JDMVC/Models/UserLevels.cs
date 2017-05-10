using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JDMVC.Models
{
    public class UserLevels
    {
        public IDictionary<int, string> levels = new Dictionary<int, string>() { { 1, "注册用户" }, {2, "铜牌会员" }, {3, "银牌会员" }, {4, "金牌会员" }, {5, "钻石会员" } };
    }
}