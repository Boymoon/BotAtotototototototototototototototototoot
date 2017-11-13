using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.Editors;
using System.Windows.Controls;

namespace Ar_Project.Models
{

    public class RepairVieww
    {

        /*
           ID                                           -> String                         ==> ترميز الطلب  
                NAME                                    ->string                          ==> اسم الطلب
                PRICE                                   ->string                          ==> السعر
                DAT                                     ->string                          ==> تاريخ استلام الطلب
                discounts                               ->string                          ==> الخصم
                datrec                                  ->string                          ==> تاريخ تسليم الطلب
                conprou                                 ->string                          ==> وصف المشكلة
                typeprou                                ->string                          ==> اجمالي الحساب
                isdone                                  ->Byte[]                          ==> تعبير عن حالة الطلب
            
            
            
            */


        public string ID { get; set; } //s1
        public string NAME { get; set; }//s2
        public string PRICE { get; set; }//s3
        public string DAT { get; set; }//s4
        public string discounts { get; set; }//s5
        public string datrec { get; set; }//s6
        public string conprou { get; set; }//s7
        public string typeprou { get; set; }//s8
        public bool isdone { get; set; }//s9
                                        // public bool issdone { get; set; }
    }
    public class RepairView
    {

        /*
           ID                                           -> String                         ==> ترميز الطلب  
                NAME                                    ->string                          ==> اسم الطلب
                PRICE                                   ->string                          ==> السعر
                DAT                                     ->string                          ==> تاريخ استلام الطلب
                discounts                               ->string                          ==> الخصم
                datrec                                  ->string                          ==> تاريخ تسليم الطلب
                conprou                                 ->string                          ==> وصف المشكلة
                typeprou                                ->string                          ==> اجمالي الحساب
                isdone                                  ->Byte[]                          ==> تعبير عن حالة الطلب
            
            
            
            */
        

        public string ID { get; set; } //s1
        public string NAME { get; set; }//s2
        public string PRICE { get; set; }//s3
        public string DAT { get; set; }//s4
        public string discounts { get; set; }//s5
        public string datrec { get; set; }//s6
        public string conprou { get; set; }//s7
        public string typeprou { get; set; }//s8
        public bool isdone { get; set; }//s9
       // public bool issdone { get; set; }
    }
}
