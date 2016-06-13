using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BusinessLogic.GlobalSettings;
using DataAccess;

namespace BusinessLogic
{
    public class DangKy
    {
        public void Insert(DANGKY dk)
        {
            Database.DANGKies.InsertOnSubmit(dk);
            Database.SubmitChanges();
        }
    }
}
