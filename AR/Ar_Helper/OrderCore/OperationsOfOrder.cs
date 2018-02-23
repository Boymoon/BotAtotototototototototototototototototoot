using Ar_Helper.CatagoriesCore;
using Ar_Helper.Modules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar_Helper.OrderCore
{
    public class OperationsOfOrder
    {
        protected string connectionstring = $"Data Source=" + System.Windows.Forms.Application.StartupPath + "\\dbPascal.db;Version=3;";
        private StorageCategories StorageCategories;//temporary
        private Order ModelOrder_;
        /// <summary>
        /// Model of order to add or remove or edit
        /// </summary>
        public Order ModelOrder
        {
            get { return ModelOrder_; }
            set { ModelOrder_ = value; }
        }

        private Order selectedItem_;
        public Order SelectedItem
        {
            get { return selectedItem_; }
            set
            {
                if (value != null)
                {
                    selectedItem_ = value;
                    StorageCategories.SetModelOperationOfCategories(Orders_[Orders_.IndexOf(Orders_.Where(item => item == value).FirstOrDefault())].Operations);
                    Orders_[Orders_.IndexOf(Orders_.Where(item => item == value).FirstOrDefault())].Operations.setSelectedItem(value.OIDC);

                }
            }
        }
        private ObservableCollection<Order> Orders_;
        public ObservableCollection<Order> Orders
        {
            get {
                if (Orders_==null)
                {
                    Orders_ = GetOrders();
                }
                return Orders_;
            }
            set
            {
                if (value != null)
                {
                    Orders_ = value;

                }
                else
                    Orders_ = new ObservableCollection<Order>();
            }
        }
        public PresenterOfCategoryType categoryType_;
        public OperationsOfOrder(PresenterOfCategoryType categoryType):this()
        {
            categoryType_ = categoryType;
        }
        public OperationsOfOrder()
        {
            AddNewOrder(new Order()
            {
                DateOfDelivery = DateTime.Now.AddDays(560),
                DateOfTheOrder = DateTime.Now,
                address = "24.ST.Norhern-Jeddah",
                Numberphone1 = "+1 2056 6577",
                Numberphone2 = "+1 2056 6577",
                OId = "1aved",
                OIDC = new CatagoriesHelper() { IDC = new OperationsOfCatagories().CreateNewIDC() },
                Oname = "Chicken",
                OnameOfClient = "John wael",
                Operations = new OperationsOfCatagories()
            });
        }
        public void AddNewOrder(Order order)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = connectionstring;
            cn.Open();
            SQLiteCommand cm = new SQLiteCommand(cn);
            cm.CommandText = $"Insert Into Orders (OId ,counter ,Numberphone1 ,Numberphone2 ,OnameOfClient ,address ,IDC,Oname,DateOfTheOrder,DateOfDelivery) Values('{order.OId}',{order.index},'{order.Numberphone1}','{order.Numberphone2}','{order.OnameOfClient}','{order.address}','{order.OIDC.IDC}','{order.Oname}','{order.DateOfTheOrder}','{order.DateOfDelivery}');";
            cm.ExecuteNonQuery();
            cn.Close();
            Orders.Add(order);
        }
        public void RemoveOrder(Order order)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = connectionstring;
            cn.Open();
            SQLiteCommand cm = new SQLiteCommand(cn);
            cm.CommandText = $"delete From Orders Where OId='{order.OId}' And counter={order.index} And Numberphone1='{order.Numberphone1}' And Numberphone2='{order.Numberphone2}' And OnameOfClient='{order.OnameOfClient}' And IDC='{order.OIDC.IDC}' And address='{order.address}' And Oname='{order.Oname}' And DateOfDelivery='{order.DateOfDelivery}' And DateOfTheOrder='{order.DateOfTheOrder}' ;";
            cm.ExecuteNonQuery();
            cm.CommandText = $"delete from Catagories where IDC='{order.OIDC.IDC}';";
            cm.ExecuteNonQuery();
            Orders_.Remove(order);
            cn.Close();
        }
        public void InsertIntoSepcficOrder(string IDC, string OId, Order order)
        {
            if (string.IsNullOrEmpty(IDC) || string.IsNullOrEmpty(OId) || order == null)
            {
                return;
            }
            var CurrentOrder = Orders_.Where(ord => ord.OId == OId).FirstOrDefault();
            CurrentOrder.Numberphone1 = (order.Numberphone1 == null) ? 0.ToString() : order.Numberphone1;
            CurrentOrder.Numberphone2 = (order.Numberphone2 == null) ? 0.ToString() : order.Numberphone2;
            CurrentOrder.Oname = (order.Oname == null) ? 0.ToString() : order.Oname;
            CurrentOrder.OnameOfClient = (order.OnameOfClient == null) ? "".ToString() : order.OnameOfClient;
            CurrentOrder.address = (order.address == null) ? 0.ToString() : order.address;
            CurrentOrder.OIDC = (order.OIDC == null) ? null : order.OIDC;
        }
        public void setStorage(StorageCategories storage)
        {
            if (storage==null)
            {
                return;
            }
            this.StorageCategories = storage;
        }

        public ObservableCollection<Order> GetOrders()
        {
            var dtable = new DataTable();
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = connectionstring;
            cn.Open();
            SQLiteCommand cm = new SQLiteCommand(cn);
            cm.CommandText = "Select * from Orders;";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cm);
            adapter.Fill(dtable);
            var ContainerOfOrders = new ObservableCollection<Order>();
            dtable.Rows.Cast<DataRow>().ToList().ForEach(Datarow =>{

                ContainerOfOrders.Add(new Order()
                {
                    address = Datarow.Field<string>("address"),
                    DateOfDelivery = DateTime.Parse(Datarow.Field<string>("DateOfDelivery")),
                    DateOfTheOrder = DateTime.Parse(Datarow.Field<string>("DateOfTheOrder")),
                    OIDC = new CatagoriesHelper() { IDC = Datarow.Field<string>("IDC") },
                    Numberphone1 = Datarow.Field<string>("Numberphone1"),
                    Numberphone2 = Datarow.Field<string>("Numberphone2"),
                    OId = Datarow.Field<string>("OId"),
                    Oname = Datarow.Field<string>("Oname"),
                    OnameOfClient = Datarow.Field<string>("OnameOfClient"),
                    Operations = new OperationsOfCatagories()
                });
            });
            cn.Close();
            return ContainerOfOrders;
        }
    }
}
