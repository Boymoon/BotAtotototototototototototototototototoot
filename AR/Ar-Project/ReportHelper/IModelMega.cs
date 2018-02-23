using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;

namespace Ar_Project
{
     interface IModelMega
    {
        void add(string id,string name, string price, string date, string darec, string conprou, string typeprou, string discounts, int isdone);
        void Edit(string id, string name, string price, string date, string darec, string conprou, string typeprou, string discounts, int isdone);
        void Delete(String index);
        void show(DataTable data);
        SQLiteConnection cn();

        
    }
}
