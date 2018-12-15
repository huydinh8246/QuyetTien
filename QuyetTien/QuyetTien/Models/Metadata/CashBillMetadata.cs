using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QuyetTien.Models
{
    [MetadataType(typeof(CashBillMetadata))]
    public partial class CashBill
    {
        internal sealed class CashBillMetadata
        {
            [DisplayName("Mã hóa đơn")]
            public string BillCode { get; set; }
            [DisplayName("Tên khách hàng")]
            public string CustomerName { get; set; }
            [DisplayName("Số điện thoại")]
            public string PhoneNumber { get; set; }
            [DisplayName("Địa chỉ")]
            public string Address { get; set; }
            [DisplayName("Ngày")]
            public System.DateTime Date { get; set; }
            [DisplayName("Người giao hàng")]
            public string Shipper { get; set; }
            [DisplayName("Ghi chú")]
            public string Note { get; set; }
            [DisplayName("Tổng tiền")]
            public int GrandTotal { get; set; }
        }
    }
}