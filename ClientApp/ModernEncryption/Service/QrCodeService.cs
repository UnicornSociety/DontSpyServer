using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using FFImageLoading;
using Xamarin.Forms;
using ZXing;
using ZXing.QrCode;
using ZXing.Rendering;

namespace ModernEncryption.Service
{
    class QrCodeService
    {
        public void Encoder ()
        {
            var qrWriter = new BarcodeWriterPixelData();
            qrWriter.Format = BarcodeFormat.QR_CODE;
            qrWriter.Options = new QrCodeEncodingOptions
            {
                Height = 250, 
                Width = 250,
                Margin = 0
            };

            var pixelData = qrWriter.Write("xyd");
            var image = new Image
            {
                Source = ImageSource.FromStream(() => new MemoryStream(pixelData.Pixels))
            };
            
            
        }
    }
}
