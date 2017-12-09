using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Collections.ObjectModel;
using System.Data;

namespace Instagram.App
{
    /// <summary>
    /// كلاس للتعامل مع قاعدة البيانات الاصلية 
    /// الاتصال  وخلافه
    /// </summary>
    public class MainDB : IDataBase
    {
        public bool DeleteItem(string name, string[] args)
        {
            throw new NotImplementedException();
        }

        public DataTable Fill(string name)
        {
            throw new NotImplementedException();
        }

        public bool InsertItem(string name, string[] args)
        {
            throw new NotImplementedException();
        }
    }
}

