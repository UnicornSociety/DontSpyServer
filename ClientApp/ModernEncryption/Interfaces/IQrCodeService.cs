using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using FFImageLoading.Forms;
using Image = Xamarin.Forms.Image;

namespace ModernEncryption.Interfaces
{
    interface IQrCodeService
    {
        CachedImage Encoder();
    }
}
