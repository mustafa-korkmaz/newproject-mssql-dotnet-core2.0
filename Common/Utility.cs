using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Common
{
    /// <summary>
    /// provides common purpose usage methods
    /// </summary>
    public static class Utility
    {
        public static string GetStatusText(Status status)
        {
            switch (status)
            {
                case Status.Active:
                    return "Aktif";
                case Status.Passive:
                    return "Pasif";
                case Status.Suspended:
                    return "Donduruldu";
                case Status.Deleted:
                    return "Silindi";
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        }

        public static string GetNotificationStatusText(NotificationStatus notificationStatus)
        {
            switch (notificationStatus)
            {
                case NotificationStatus.HasError:
                    return NotificationMessage.HasError;
                case NotificationStatus.WaitingForSendingNotification:
                    return NotificationMessage.WaitingForSendingNotification;
                case NotificationStatus.NotificationSent:
                    return NotificationMessage.NotificationSent;
                case NotificationStatus.NotificationRead:
                    return NotificationMessage.NotificationRead;
                default:
                    throw new ArgumentOutOfRangeException(nameof(notificationStatus), notificationStatus, null);
            }
        }

        public static string GetSettingText(int settingId)
        {
            switch (settingId)
            {
                case DatabaseKey.Setting.NotifyOnExactQuantity:
                    return "İstediğim miktara düşünce haber ver";
                case DatabaseKey.Setting.NotifyOnExactPrice:
                    return "İstediğim fiyata düşünce haber ver";
                case DatabaseKey.Setting.NotifyOnPriceChanges:
                    return "Fiyat değiştiğinde haber ver";
                case DatabaseKey.Setting.NotifyOnPriceDecreased:
                    return "Fiyatı düşünce haber ver";
                case DatabaseKey.Setting.NotifyOnPriceIncreased:
                    return "Fiyatı yükselince haber ver";
                case DatabaseKey.Setting.NotifyOnQuantityChanges:
                    return "Stok değiştiğinde haber ver";
                case DatabaseKey.Setting.NotifyOnQuantityDecreased:
                    return "Stoklar azalınca haber ver";
                case DatabaseKey.Setting.NotifyOnQuantityIncreased:
                    return "Stoklar artınca haber ver";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string GetApprovalText(bool isApproved)
        {
            return isApproved ? "Onaylı" : "Onay Bekliyor";
        }

        public static DateTime GetTurkeyCurrentDateTime()
        {
            DateTime utcTime = DateTime.UtcNow;
            //TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("GTB Standard Time");
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Arab Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi); // convert from utc to local
        }

        //public static BusinessResponse<string> SaveImage(string imageData, string filePath)
        //{
        //    var businessResp = new BusinessResponse<string>
        //    {
        //        ResponseCode = ResponseCode.Fail,
        //    };

        //    Regex regex = new Regex(@"base64,(.*)");
        //    Match match = regex.Match(imageData);

        //    if (!match.Success)
        //    {
        //        return businessResp;
        //    }

        //    string imageDataBase64String = match.Value.Substring(7); // trim 'base64,'

        //    regex = new Regex(@"data[:-]image(.*);"); //data-image/png;

        //    match = regex.Match(imageData);

        //    if (!match.Success)
        //    {
        //        return businessResp;
        //    }

        //    string fileExtension = "." + match.Value.Substring(11).Replace(";", ""); // trim 'data-image/' returns: .png

        //    var guid = Guid.NewGuid().ToString();

        //    string fullPath = filePath + guid + fileExtension;

        //    var sourceBytes = Convert.FromBase64String(imageDataBase64String);

        //    var targetBytes = CropImage(sourceBytes, 144, 144);

        //    using (var imageFile = new FileStream(fullPath, FileMode.Create))
        //    {
        //        imageFile.Write(targetBytes, 0, targetBytes.Length);
        //        imageFile.Flush();
        //    }

        //    businessResp.ResponseData = guid + fileExtension; // return file name.
        //    businessResp.ResponseCode = ResponseCode.Success;
        //    return businessResp;
        //}

        //public static byte[] CropImage(byte[] imageStream, int width, int height, bool needToFill = false)
        //{
        //    Image image;

        //    using (var ms = new MemoryStream(imageStream))
        //    {
        //        image = Image.FromStream(ms);
        //    }

        //    int sourceWidth = image.Width;
        //    int sourceHeight = image.Height;

        //    int sourceX = 0;
        //    int sourceY = 0;
        //    double destX = 0;
        //    double destY = 0;

        //    double nScale = 0;
        //    double nScaleW = 0;
        //    double nScaleH = 0;

        //    nScaleW = (width / (double)sourceWidth);
        //    nScaleH = (height / (double)sourceHeight);
        //    if (!needToFill)
        //    {
        //        nScale = Math.Min(nScaleH, nScaleW);
        //    }
        //    else
        //    {
        //        nScale = Math.Max(nScaleH, nScaleW);
        //        destY = (height - sourceHeight * nScale) / 2;
        //        destX = (width - sourceWidth * nScale) / 2;
        //    }

        //    if (nScale > 1)
        //        nScale = 1;

        //    int destWidth = (int)Math.Round(sourceWidth * nScale);
        //    int destHeight = (int)Math.Round(sourceHeight * nScale);

        //    Bitmap bmPhoto = null;
        //    try
        //    {
        //        bool sizesAvailable = true;

        //        if (destWidth < width)
        //        {
        //            destWidth = width;
        //            sizesAvailable = false;
        //        }

        //        if (destHeight < height)
        //        {
        //            destHeight = height;
        //            sizesAvailable = false;
        //        }

        //        if (sizesAvailable)
        //        {
        //            bmPhoto = new Bitmap(destWidth + (int)Math.Round(2 * destX), destHeight + (int)Math.Round(2 * destY));
        //        }
        //        else
        //        {
        //            bmPhoto = new Bitmap(destWidth, destHeight);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException(string.Format("destWidth:{0}, destX:{1}, destHeight:{2}, desxtY:{3}, Width:{4}, Height:{5}", destWidth, destX, destHeight, destY, width, height), ex);
        //    }
        //    using (Graphics grPhoto = Graphics.FromImage(bmPhoto))
        //    {
        //        grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //        grPhoto.CompositingQuality = CompositingQuality.HighQuality;
        //        grPhoto.SmoothingMode = SmoothingMode.HighQuality;

        //        Rectangle to = new Rectangle((int)Math.Round(destX), (int)Math.Round(destY), destWidth, destHeight);
        //        Rectangle from = new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);
        //        //Console.WriteLine("From: " + from.ToString());
        //        //Console.WriteLine("To: " + to.ToString());
        //        grPhoto.DrawImage(image, to, from, GraphicsUnit.Pixel);
        //    }

        //    using (var ms = new MemoryStream())
        //    {
        //        bmPhoto.Save(ms, image.RawFormat);
        //        return ms.ToArray();
        //    }
        //}

        public static string GetSqlWhereConditionInValues<T>(IEnumerable<T> inValues)
        {
            return string.Join(", ", inValues.Select(p => p.ToString()));
        }

        public static DeviceType GetDeviceTypeByChannel(string channelType)
        {
            switch (channelType)
            {
                case ChannelType.Ios:
                    return DeviceType.Ios;
                case ChannelType.Android:
                    return DeviceType.Android;
                default:
                    return DeviceType.None;
            }
        }

    }
}
