using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.Enum
{
    public enum ReceiptType
    {
        [Description("Phiếu thu")]
        RECEIPT = 1,

        [Description("Phiếu chi")]
        EXPENSE = 2,
    }

    public enum PaymentType
    {
        [Description("Tiền mặt")]
        CASH = 1,

        [Description("Chuyển khoản")]
        TRANSFER = 2,

        [Description("Quẹt thẻ")]
        CARD = 3,
    }

    public enum ImageType
    {
        [Description("Nhỏ")]
        SMALL = 1,

        [Description("Trung bình")]
        MIDDLE = 2,

        [Description("Lớn")]
        LARGE = 3,

        [Description("Khác")]
        ORTHER = 4,
    }

    public enum MenuType
    {
        [Description("Menu trên website")]
        Client = 1,

        [Description("Menu trên website quản trị")]
        Management = 2,
    }
}
