using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using FFImageLoading;
using FFImageLoading.Forms;
using ModernEncryption.Interfaces;
using Xamarin.Forms;
using ZXing;
using ZXing.QrCode;
using ZXing.Rendering;

namespace ModernEncryption.Service
{
    class QrCodeService : IQrCodeService
    {
        public CachedImage Encoder ()
        {
            var qrWriter = new BarcodeWriterPixelData();
            qrWriter.Format = BarcodeFormat.QR_CODE;
            qrWriter.Options = new QrCodeEncodingOptions
            {
                Height = 1000, 
                Width = 1000,
                Margin = 50
            };

            var pixelData = qrWriter.Write("xyd");
            var qrCode = new CachedImage()
            {
                Source = ImageSource.FromStream(() => new MemoryStream(pixelData.Pixels))
            };
            Debug.WriteLine(qrCode.ToString());
            BarcodeWriterSvg barCode = new BarcodeWriterSvg();
            barCode.
            return qrCode;
        }
    }
}
