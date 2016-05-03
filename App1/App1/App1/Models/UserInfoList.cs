using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    public class UserInfoList : List<UserInfoModel>
    {
        public UserInfoList()
        { 
            this.Add(new UserInfoModel() { Name = "王子麵", EngName = "Noddle" });
            this.Add(new UserInfoModel() { Name = "陳皮梅", EngName = "Plum" });
            this.Add(new UserInfoModel() { Name = "湯包", EngName = "Bun" });
        }
    }
}
