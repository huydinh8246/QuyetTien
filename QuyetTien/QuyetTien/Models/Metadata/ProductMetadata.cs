﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QuyetTien.Models
{
    [MetadataType(typeof(ProductMetadata))]
    public partial class Product
    {
        internal sealed class ProductMetadata
        {
            [DisplayName("Mã SP")]
            public string ProductCode { get; set; }
            [DisplayName("Tên SP")]
            public string ProductName { get; set; }
            [DisplayName("Loại SP")]
            public int ProductTypeID { get; set; }
            [DisplayName("Giá bán")]
            public int SalePrice { get; set; }
            [DisplayName("Giá gốc")]
            public int OriginPrice { get; set; }
            [DisplayName("Giá góp")]
            public int InstallmentPrice { get; set; }
            [DisplayName("Số lượng")]
            public int Quantity { get; set; }
            [DisplayName("Hình ảnh")]
            public string Avatar { get; set; }
            [DisplayName("Tình trạng")]
            public Nullable<bool> Status { get; set; }

        }

    }
}