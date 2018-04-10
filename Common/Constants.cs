namespace Common
{
    public class ExportTypeText
    {
        public const string Category = "category";
        public const string Product = "product";
    }

    public static class DropConstant
    {
        public const int ApiTokenValidDays = 30;
        //public const string ApiKeyValue = "T.E.A.M"; // taylan.erdi.aliko.mute
        //public const string JobApiKeyValue = "T.B.A.M"; // taylan.burak.aliko.mute
        //public static string ApiKeyHash = Helper.ApiKey.Instance.GetHashValue(ApiKeyValue);
        //public static string JobApiKeyHash = Helper.ApiKey.Instance.GetHashValue(JobApiKeyValue);
        public const string EncyrptingPassword = "T.E.A.M";
        public const string IosCertificatePath = "content/certificates/";
        public const int UntrackableQuantityValue = -1;
        public const decimal UntrackablePriceValue = -1;
        public const string NotificationOwner = "raqun";
    }

    public static class ErrorMessage
    {
        public const string IntegrationKeyError = "Application Integration key error.";
        public const string ApplicationExceptionMessage = "Uygulamada beklenmedik bir hata meydana geldi.\nLütfen daha sonra tekrar deneyiniz.";
        public const string RecordNotFound = "Listelenecek kayıt bulunamadı.";
        public const string LeaguesNotFoundWithRelatedCategory = "Bu kategoriye ait lig kaydı bulunamadı.";
        public const string ApiKeyNotFound = "Api key not found.";
        public const string JobApiKeyNotFound = "Job Api key not found.";
        public const string ChannelTypeNotFound = "Channel type key not found.";
        public const string ApiKeyIncorrect = "Given api key is incorrect.";
        public const string ChannelTypeIncorrect = "Given channel type is incorrect.";
        public const string UserNotFound = "Kullanıcı adı ya da sifre hatalı.";
        public const string UserEmailNotConfirmed = "Üyeliğiniz henüz aktiflestirilmemis. Lütfen kayıt olduğunuz mail adresinize gönderilen doğrulama maili ile üyeliğinizi aktiflestiriniz.";
        public const string UserNotActive = "Kullanıcı durumu aktif değil.";
        public const string UserEmailNotExists = "Mail adres alanı zounludur.";
        public const string PhoneNumberNotExists = "Telefon alanı zounludur.";
        public const string DeviceKeyNotExists = "DeviceKey alanı zounludur.";
        public const string EmailOrUserNameNotFound = "Girilen değer ile eslesen kullanıcı adı ya da email bulunamadı.";
        public const string RequestInvalid = "Invalid request.";
        public const string RequestNotFound = "Request body not found";
        public const string ClaimsNotFound = "İslemi gerçeklestirme yetkiniz bulunmamaktadır.";
        public const string AuthorNotFound = "Yazar bulunamadı ya da kullanıcının yazar rolü mevcut değil.";
        public const string SearchTypeNotFound = "Arama kriteri tipi bulunamadı.";
        public const string AuthorNotSaved = "Yazar kaydetme islemi basarısız oldu.";
        public const string CouponCannotBeDeleted = "Kupon silme islemi basarısız oldu.";
        public const string CouponStatusCannotBeChanged = "Kupon onay değisiklik islemi basarısız oldu.";
        public const string LeagueNotSaved = "Lig kaydetme islemi basarısız oldu.";
        public const string EventNotSaved = "Maç bilgileri kaydetme islemi basarısız oldu.";
        public const string EventNotUpdated = "Maç bilgileri güncelleme islemi basarısız oldu.";
        public const string OddsCannotDeleted = "Maça ait eski bahisleri güncelleme islemi basarısız oldu.";
        public const string OddsCannotCreated = "Maça ait yeni bahisleri kaydetme islemi basarısız oldu.";
        public const string EventExists = "Bültende bu kod ile tanımlı farklı bir maç bulunmaktadır.";
        public const string AuthorImageNotSaved = "Yazar resmi kaydetme islemi basarısız oldu.";
        public const string UserExists = "Kayıt olmak istenilen kullanıcı adı ya da email daha önce kullanılmıs.";
        public const string LeagueExists = "Tanımlamaya çalıstığınız lig {0} ({1}) ile çakısıyor. Spor kategori ve lig kodunu benzersiz giriniz.";
        public const string EventExistsWithRelatedLeague = "Silmeye çalıstığınız lig, bir karsılasma içerisinde tanımlı olduğundan islem basarısız oldu.";
        public const string EmailSendingFailure = "Email gönderimi basarısız oldu. Lütfen daha sonra tekrar deneyiniz.";
        public const string WrongVerificationLink = "Link geçerliliğini yitirmis.";
        public const string UserOrEmailNotFound = "Kullanıcı adı ya da email adresi bulunamadı.";
        public const string EventNotStarted = "Sonuç girmek için maç sonunu bekleyiniz.";
        public const string BetTypesNotFound = "Bahis tipi bulunamadı.";
        public const string AuthorListNotFound = "Yazar listesi bulunamadı.";
        public const string PredictionsNotSaved = "Tahmin kaydetme islemi basarısız oldu.";
        public const string PredictionsNotFound = "Maça ait tahmin bulunamadı.";
        public const string DuplicatedProduct = "Bu ürün daha önce kaydedilmis.";
        public const string CommentNotSaved = "Yorum kaydetme islemi basarısız oldu.";
        public const string CommentAndPredictionsNotSaved = "Tahmin ve  yorum kaydetme islemi basarısız oldu.";
        public const string OddsNotFound = "Bahis bulunamadı.";
        public const string ChannelTypeNotAppropriate = "Sadece mobil bir device key izni bulunmaktadır.";
        public const string NotAuthorized = "İslemi gerçeklestirme yetkiniz bulunmamaktadır.";
        public const string RecordNotSaved = "Veri kaydetme islemi basarısız oldu."; // generic not saved error message
        public const string RecordNotUpdated = "Veri güncelleme islemi basarısız oldu."; // generic not saved error message
        public const string WrongSecurityCode = "Güvenlik kodu hatalı."; // generic not saved error message
        public const string EventAdditionalInfoNotFound = "Maç limit, handikap bilgileri bulunamadı. Bu bilgilerin olması gerektiğini düsünyorsanız yöneticiniz ile görüsün.";
        public const string UserDeviceNotFound = "Kayıtlı mobil device bulunamadı, bildirim gönderilemedi.";
        public const string MobileUserCouponCannotBeDeleted = "Mobil kullanıcıların olusturduğu kuponları silme yetkiniz bulunmamaktadır.";
        public const string CouponCannotBeCreatedWithGivenCriteria = "Girilen kriterlere uygun bir kupon olusturulamadı.";
        public const string CouponCreationHasError = "Kupon olusturma islemi sırasında hata alındı.\nLütfen daha sonra tekrar deneyiniz.";
        public const string NotIntegratedFirm = "Takip etmek istediğiniz ürüne ait web sitesi henüz sistemimize entegre edilmemistir.";
        public const string UrlCannotBeParsed = "Takip etmek istediğiniz ürün ile ilgili beklenmedik bir sorun olustu.\nGirmis olduğunuz linkin geçerli bir ürüne ait olduğundan emin olunuz.";
        public const string CurrentPasswordWrong = "Mevcut sifreniz doğrulanamadı";
        public const string SessionKeyNotFound = "Session key not found!";
    }

    public static class NotificationMessage
    {
        public const string PriceIncreased = "Takip ettiğin ürünün fiyatı yükseldi.";
        public const string PriceDecreased = "Takip ettiğin ürünün fiyatı düstü.";
        public const string QuantityIncreased = "Takip ettiğin ürünün stok sayısı arttı.";
        public const string QuantityDecreased = "Takip ettiğin ürünün stok sayısı azaldı.";
        public const string DesiredPriceOccured = "Takip ettiğin ürün tam istediğin fiyat!";
        public const string DesiredQuantityOccured = "Takip ettiğin ürün tam istediğin stok sayısında!";
        public const string HasError = "Hatalı";
        public const string WaitingForSendingNotification = "Bildirim kuyruğuna eklendi";
        public const string NotificationSent = "Yeni"; //Gönderildi
        public const string NotificationRead = "Okundu";
        public const string UserInfoChanged = "Kullanıcı bilgilerin değisti.";
        public const string PasswordChanged = "Parolan değisti.";
    }

    public static class NotificationBody
    {
        public const string CheckOutProduct = "Güncel ürün fiyatını hemen öğren!";
        public const string UserInfoSuccessfullyUpdated = "Bilgilerin başarıyla güncellendi.";
    }

    public static class ApiResponseMessage
    {
        public const string IntegrationNotFound = "Integration not found";
        public const string ExportTypeNotFound = "Export type not found";
    }

    public static class HttpClientResponseMessage
    {
        public const string ContentNoFound = "Veri bulanamadi.";
        public const string ExportTypeNotFound = "Export type not found";
    }


    public static class BusinessResponseMessage
    {
        public const string BetProgramUpToDate = "Mevcut bülten daha önceden güncellenmis.";
        public const string WeeksNotFound = "Bülten hafta kodlari bulunamadi.";
        public const string EventsNotFound = "{0} hafta kodlu bülten maclari bulunamadi.";
        public const string EventsParseError = "{0} hafta kodlu bülten maclari parse hatasi.";
        public const string EventsSaveError = "{0} hafta kodlu bülten maclari kaydetme hatasi.";
        public const string BetProgramsNotFound = "Bülten bulunamadı.";
    }

    public static class DataAccessResponseMessage
    {
        public const string RecordNotSaved = "Kayit islemi basarisiz!";
    }

    public static class ContentTpye
    {
        public const string FormUrlencoded = "application/x-www-form-urlencoded";
    }

    public static class WebMethodTypeText
    {
        public const string Get = "Get";
        public const string Post = "Post";
        public const string Put = "Put";
    }

    public static class Mail
    {
        public const string VerificationSubject = "Hesap aktivasyon islemi";
        public const string ReminderSubject = "Kullanıcı parola resetleme isteği";
        public const string VerificationContent = "Hesabınızı aktiflestirmek için <a href=\"{0}\" taget=\"_blank\"> buraya </a> tıklayınız.<br/>";
        public const string ReminderContent = "Merhaba {0}, <br/>Parolanızı sıfırlamak için <a href=\"{1}\" taget=\"_blank\"> buraya </a> tıklayınız.<br/>";
        public const string Footer = "<br/>Raqun destek ekibi. <br/> <a href=\"http://raqun.co/\" taget=\"_blank\">www.raqun.co</a><br/>";
    }

    public static class ApplicationRole
    {
        public const string Owner = "Owner";
        public const string Admin = "Admin";
        public const string StandartUser = "StandartUser";
        public const string AdminOrStandartUser = "Admin,StandartUser";
        public const string None = "None";
    }

    public static class ApplicationUserClaimType
    {
        public const string Role = "role";
        public const string AccountType = "account";
        public const string AccountExpiresAt = "accExpires";
    }

    public static class ApplicationUserClaimValue
    {
        public const string PremiumAccount = "Premium";
        public const string StandartAccount = "Standart";
        public const string TrialAccount = "Trial";
    }

    public static class DefaultAuthenticationTypes
    {
        public const string ApplicationCookie = "ApplicationCookie";
        public const string ExternalCookie = "ExternalCookie";
    }

    public static class ApiRequest
    {
        public const string ApplicationCookie = "ApplicationCookie";
        public const string ExternalCookie = "ExternalCookie";
    }

    public static class ChannelType
    {
        public const string Ios = "0";
        public const string Android = "1";
        public const string WebApp = "2";
        public const string LandingPage = "3";
    }

    public static class DataGridTableNames
    {
        public const string BetProgramList = "Bülten Listesi";
        public const string EventList = "Maç Listesi";
        public const string MessageList = "Mesaj Listesi";
        public const string OddsList = "Bahis Listesi";
        public const string OddsTypeList = "Bahis Tipi Listesi";
    }

    public static class DataGridTableIds
    {
        public const string BetProgramList = "bet-program-list";
        public const string EventList = "event-list";
        public const string OddsList = "odds-list";
        public const string OddsTypeList = "odds-type-list";
    }

    public static class ControllerName
    {
        public const string BetProgram = "BetProgram";
        public const string Event = "Event";
        public const string Author = "Author";
        public const string Coupon = "Coupon";
        public const string Tip = "Tip";
        public const string Report = "Report";
        public const string Common = "Common";
    }

    public static class ActionName
    {
        public const string FillBetProgramList = "FillBetProgramList";
        public const string FillEventList = "FillEventList";
        public const string FillCurrentBetProgramEventList = "FillCurrentBetProgramEventList";
        public const string FillOddsList = "FillOddsList";
    }

    #region image paths

    public static class ImagePath
    {
        public const string Category = "content/media/category/";
        public const string User = "content/media/user/";
        public const string UserDefault = "content/media/user/avatar.png";
    }

    #endregion image path

    #region UserMessageTypes

    public static class UserMessageType
    {
        public const string None = "none";
        public const string ServerError = "server-error";
        public const string Error = "error";
        public const string Warning = "warning";
        public const string Success = "success";
        public const string Info = "info";
    }

    #endregion  UserMessageTypes

    #region api urls

    public static class ApiUrl
    {
        public const string Register = "Account/Register";
        public const string GetToken = "Token";
        public const string Login = "Account/Login";
        public const string Logout = "Account/Logout";
        public const string BetProgramUpdate = "BetProgram/Update";
        public const string BetProgramWeekCode = "BetProgram/WeekCode";
        public const string BetProgramList = "BetProgram/FillBetProgramList";
        public const string RequestBoxList = "Report/FillRequestBoxList";
        public const string ExceptionList = "Report/FillExceptionList";
        public const string UserList = "Report/FillUserList";
        public const string LogList = "Report/FillLogList";
        public const string AddLeague = "Common/League/Add";
        public const string EditLeague = "Common/League/Edit";
        public const string DeleteLeague = "Common/League/Delete/{0}";
        public const string LeagueDetail = "Common/LeagueDetail/{0}";
        public const string League = "Common/League/{0}";
        public const string BetProgramLeague = "Common/BetProgramLeague";
        public const string LeagueList = "Common/FillLeagueList";
        public const string Category = "Common/Category";
        public const string Interactions = "Common/Interactions";
        public const string BetType = "Common/BetType";
        public const string OddsType = "Common/OddsType/{0}";
        public const string Author = "Common/Author";
        public const string AuthorUser = "Common/AuthorUser";
        public const string ClearCache = "Common/ClearCache";
        public const string SendNotification = "Common/SendNotification";
        public const string EventList = "Event/FillEventList";
        public const string OddsTypeList = "Event/FillOddsTypeList";
        public const string AuthorList = "Author/FillAuthorList";
        public const string CouponDetail = "Coupon/{0}";
        public const string CouponList = "Coupon/FillCouponList";
        public const string DeleteCoupon = "Coupon/{0}/Delete";
        public const string GenerateCoupons = "Coupon/Generate";
        public const string SetCouponApprovalStatus = "Coupon/SetStatus";
        public const string AddAuthor = "Author/Add";
        public const string EditAuthor = "Author/{0}/Edit";
        public const string AuthorDetail = "Author/{0}";
        public const string CurrentUserPredictionList = "Tip/FillCurrentUserPredictionList";
        public const string PredictedEventList = "Tip/FillPredictedEventList";
        public const string CurrentUserCommentList = "Tip/FillCurrentUserCommentList";
        public const string CurrentUserEventCommentList = "Tip/FillCurrentUserEventCommentList";
        public const string SetPredictionResult = "Tip/SetPredictionResult";
        public const string DeletePrediction = "Tip/DeletePrediction";
        public const string DeleteComment = "Tip/DeleteComment";
        public const string UpdateComment = "Tip/UpdateComment";
        public const string NewCommentAndPredictions = "Tip/NewCommentAndPredictions";
        public const string NewOdds = "Tip/NewOdds";
        public const string NewComment = "Tip/NewComment";
        public const string OverrideOdds = "Tip/OverrideOdds";
        public const string EventAdditionalInfo = "Tip/EventAdditionalInfo";
        public const string EventDetails = "Event/Detail/{0}";
        public const string EventAuthorList = "Event/FillAuthorList";
        public const string AuthorTipDetails = "Event/{0}/Author/{1}/Tip";
        public const string AddEvent = "Event/Add";
        public const string EditEvent = "Event/{0}/Edit";
        public const string CurrentBetProgramEventList = "Tip/FillCurrentBetProgramEventList";
        public const string OddsList = "Tip/FillOddsList";
    }

    #endregion api urls

    #region Session

    public static class SessionVariables
    {
        public const string Breadcrumbs = "Breadcrumbs";
        public const string ApplcationUser = "ApplcationUser";
        public const string LeaguesDictionary = "LeaguesDictionary";
        public const string CaptchaCode = "CaptchaCode";
    }

    #endregion Session

    #region RequestType

    public static class RequestTypeText
    {
        public const string Complaint = "sikayet";
        public const string Suggession = "Öneri";
        public const string Wish = "İstek";
        public const string Other = "Diğer";
    }

    #endregion RequestType


    #region cookies

    public static class Cookies
    {
        public const string AccessToken = "AccessToken";
    }

    #endregion cookies

    #region cofig keys

    public static class ConfigKeys
    {
        public const string ApiUrl = "ApiUrl";
        public const string BetProgramReferer = "BetProgramReferer";
        public const string BetProgramUrl = "BetProgramUrl";
        public const string BetProgramUrlParams = "?type=6&sortValue=DATE&week={0}&day=-1&sort=-1&sortDir=1&groupId=-1&np=1&sport=1";
        public const string BetProgramWeekIdUrl = "BetProgramWeekIdUrl";
        public const string BetProgramWeekIdUrlParams = "?sport=1&type=6&sortValue=DATE&sortDir=-1&groupId=-1&np=0";
        public const string MailFrom = "MailFrom";
        public const string MailPass = "MailPass";
        public const string MailServer = "MailServer";
        public const string MailPort = "MailPort";
        public const string MailUseSsl = "MailUseSSL";
        public const string MailDisplayName = "MailDisplayName";
        public const string SendNotifications = "SendNotifications";
        public const string IosCerFile = "IosCerFile";
        public const string IosCerFilePwd = "IosCerFilePwd";
        public const string AndroidSenderId = "AndroidSenderId";
        public const string AndroidAuthToken = "AndroidAuthToken";
        public const string MaxCouponGeneratorPredictionLimit = "MaxCouponGeneratorPredictionLimit";
        public const string UseProxy = "UseProxy";
        public const string ProxyUrl = "ProxyUrl";
        public const string MaxBulkInsertCount = "MaxBulkInsertCount";
        public const string MaxProductRefreshCount = "MaxProductRefreshCount";
    }

    #endregion cofig keys

    #region request headers

    public static class RequestHeader
    {
        public const string Authorization = "Authorization";
        public const string ApiKey = "ApiKey";
        public const string JobApiKey = "JobApiKey";
        public const string ChannelType = "ChannelType";
        public const string SessionKey = "SessionKey";
    }

    #endregion request headers

    #region database Ids

    /// <summary>
    /// includes db related special keys or ids
    /// </summary>
    public static class DatabaseKey
    {
        public static class ApplicationRoleId
        {
            public const string Admin = "ede64fc4-7b30-45f7-b92d-e71f3d0027b6";
            public const string Owner = "911f5c44-c2d1-43aa-9247-ec71fbc17956";
        }

        public static class Setting
        {
            public const int NotifyOnPriceChanges = 1;

            public const int NotifyOnPriceDecreased = 2;

            public const int NotifyOnPriceIncreased = 3;

            public const int NotifyOnExactPrice = 4;

            public const int NotifyOnQuantityChanges = 5;

            public const int NotifyOnQuantityDecreased = 6;

            public const int NotifyOnQuantityIncreased = 7;

            public const int NotifyOnExactQuantity = 8;
        }

        /// <summary>
        /// job names in db
        /// </summary>
        public static class JobName
        {
            public const string ProductPropertyRefresher = "ProductPropertyRefresher";
        }

        /// <summary>
        /// Category ids in db
        /// </summary>
        public static class CategoryId
        {
            /// <summary>
            /// use this id for unknown categories
            /// </summary>
            public const int Diger = 7;

            public const int SanalPara = 4;

            public const int KadinOutlet = 128;
            public const int ErkekOutlet = 129;
            public const int CocukOutlet = 130;
            public const int BebekOutlet = 131;

            public const int YatakOdasi = 240;
            public const int Mutfak = 241;
            public const int Banyo = 242;
            public const int Kozmetik = 243;
            public const int HaliKilim = 244;
            public const int Perde = 245;
            public const int ElektrikliEvAletleri = 246;

            #region KadinAyakkabi

            public const int KadinAyakkabi = 8;

            public const int KadinAyakkabi_SporAyakkabi = 114;
            public const int KadinAyakkabi_Terlik = 115;
            public const int KadinAyakkabi_Casual = 116;
            public const int KadinAyakkabi_Sandalet = 117;
            public const int KadinAyakkabi_Babet = 118;
            public const int KadinAyakkabi_Bot = 119;
            public const int KadinAyakkabi_Topuklu = 120;
            public const int KadinAyakkabi_Espadril = 121;

            #endregion KadinAyakkabi

            #region ErkekAyakkabi

            public const int ErkekAyakkabi = 9;

            public const int ErkekAyakkabi_SporAyakkabi = 122;
            public const int ErkekAyakkabi_Terlik = 123;
            public const int ErkekAyakkabi_Casual = 124;
            public const int ErkekAyakkabi_Classic = 125;
            public const int ErkekAyakkabi_Loafer = 126;
            public const int ErkekAyakkabi_Bot = 127;

            #endregion ErkekAyakkabi

            #region  ErkekGiyim

            public const int ErkekGiyim = 10;

            public const int ErkekGiyim_CeketYelek = 11;
            public const int ErkekGiyim_SortCapri = 19;
            public const int ErkekGiyim_Gomlek = 20;
            public const int ErkekGiyim_HirkaKazak = 21;
            public const int ErkekGiyim_MontKaban = 23;
            public const int ErkekGiyim_Pantolon = 24;
            public const int ErkekGiyim_TshirtSweatshirt = 25;
            public const int ErkekGiyim_Jean = 26;
            public const int ErkekGiyim_TakimElbise = 27;
            public const int ErkekGiyim_IcGiyimPijama = 28;
            public const int ErkekGiyim_Mayo = 229;
            public const int ErkekGiyim_SporGiyim = 234;
            public const int ErkekGiyim_SporGiyim_Esofman = 247;


            #endregion  ErkekGiyim

            #region CocukGiyim

            public const int CocukGiyim = 12;

            public const int CocukGiyim_SortCapri = 49;
            public const int CocukGiyim_Gomlek = 50;
            public const int CocukGiyim_HırkaKazak = 51;
            public const int CocukGiyim_CeketYelek = 52;
            public const int CocukGiyim_MontKaban = 53;
            public const int CocukGiyim_Pantolon = 54;
            public const int CocukGiyim_TshirtSweatshirt = 55;
            public const int CocukGiyim_Jean = 56;
            public const int CocukGiyim_IcGiyimPijama = 58;
            public const int CocukGiyim_Etek = 59;
            public const int CocukGiyim_Atlet = 60;
            public const int CocukGiyim_Yagmurluk = 61;
            public const int CocukGiyim_BereSapka = 62;
            public const int CocukGiyim_SporGiyim = 235;
            public const int CocukGiyim_SporGiyim_Esofman = 248;

            #endregion CocukGiyim

            #region BebekGiyim

            public const int BebekGiyim = 13;
            // children
            public const int BebekGiyim_Gomlek = 63;
            public const int BebekGiyim_CeketYelek = 64;
            public const int BebekGiyim_Pantolon = 65;
            public const int BebekGiyim_TshirtSweatshirt = 66;
            public const int BebekGiyim_Jean = 67;
            public const int BebekGiyim_IcGiyimPijama = 68;
            public const int BebekGiyim_Atlet = 69;
            public const int BebekGiyim_BodyTulum = 70;
            public const int BebekGiyim_Yagmurluk = 71;

            #endregion BebekGiyim

            #region ErkekAksesuar

            public const int ErkekAksesuar = 14;
            //ErkekAksesuar children
            public const int ErkekAksesuar_Cuzdan = 72;
            public const int ErkekAksesuar_Corap = 73;
            public const int ErkekAksesuar_Bileklik = 74;
            public const int ErkekAksesuar_Saat = 75;
            public const int ErkekAksesuar_Kravat = 76;
            public const int ErkekAksesuar_Parfum = 77;
            public const int ErkekAksesuar_Canta = 78;
            public const int ErkekAksesuar_BereSapka = 79;
            public const int ErkekAksesuar_GunesGozluğu = 80;
            public const int ErkekAksesuar_AtkiEldivenSal = 81;
            public const int ErkekAksesuar_Kemer = 82;
            public const int ErkekAksesuar_PapyonKusak = 83;
            public const int ErkekAksesuar_SporAksesuar = 232;

            #endregion ErkekAksesuar

            #region KadinAksesuar

            public const int KadinAksesuar = 15;
            // children
            public const int KadinAksesuar_Cuzdan = 98;
            public const int KadinAksesuar_corap = 99;
            public const int KadinAksesuar_Bileklik = 100;
            public const int KadinAksesuar_Saat = 101;
            public const int KadinAksesuar_Parfum = 103;
            public const int KadinAksesuar_Canta = 104;
            public const int KadinAksesuar_BereSapka = 105;
            public const int KadinAksesuar_GunesGozlugu = 106;
            public const int KadinAksesuar_AtkiEldivenSal = 107;
            public const int KadinAksesuar_Kemer = 224;
            public const int KadinAksesuar_Kolye = 225;
            public const int KadinAksesuar_Kupe = 226;
            public const int KadinAksesuar_Yuzuk = 227;
            public const int KadinAksesuar_SporAksesuar = 233;

            #endregion KadinAksesuar

            #region KadinGiyim

            public const int KadinGiyim = 16;
            // children
            public const int KadinGiyim_SortCapri = 31;
            public const int KadinGiyim_Gomlek = 35;
            public const int KadinGiyim_HirkaKazak = 36;
            public const int KadinGiyim_CeketYelek = 37;
            public const int KadinGiyim_MontKaban = 38;
            public const int KadinGiyim_Pantolon = 39;
            public const int KadinGiyim_TshirtSweatshirt = 40;
            public const int KadinGiyim_Jean = 41;
            public const int KadinGiyim_Elbise = 42;
            public const int KadinGiyim_Bluz = 43;
            public const int KadinGiyim_Tunik = 44;
            public const int KadinGiyim_HamileGiyim = 45;
            public const int KadinGiyim_İcGiyimPijama = 46;
            public const int KadinGiyim_Etek = 47;
            public const int KadinGiyim_MayoBikini = 228;
            public const int KadinGiyim_SporGiyim = 236;
            public const int KadinGiyim_SporGiyim_Esofman = 249;

            #endregion KadinGiyim

            #region EvYasam

            public const int EvYasam = 17;
            //EvYasam children
            public const int EvYasam_Havlu = 110;

            #endregion EvYasam

            #region CocukAyakkabi

            public const int CocukAyakkabi = 18;
            // children
            public const int CocukAyakkabi_SporAyakkabi = 111;
            public const int CocukAyakkabi_Terlik = 112;
            public const int CocukAyakkabi_Bot = 113;

            #endregion CocukAyakkabi

            #region Hamile Bebek

            public const int Sut_Saklama_Gerecleri = 209;
            public const int Sut_Pompalari = 208;
            public const int Gogus_Pedleri = 207;
            public const int Gogus_Kremi = 206;
            public const int Gogus_Koruyuculari = 205;
            public const int Emzirme_urunleri = 204;
            public const int Emzirme_onlugu = 203;
            public const int Emzirme_Minderi = 202;
            public const int Emziren_Anne_İcecekleri = 201;
            public const int Organik_Bebek_Yiyecekleri = 200;
            public const int Keci_Sutu_Mamasi = 199;
            public const int Kavanoz_Mamalari = 198;
            public const int Kasik_Mamalari = 197;
            public const int Biberon_Mamalari = 196;
            public const int Beslenme_Gerecleri = 195;
            public const int Bebek_onlukleri = 194;
            public const int Bebek_Mamalari = 193;
            public const int Bebek_İcecekleri = 192;
            public const int Bebek_Emzikleri = 191;
            public const int Bebek_Biberonlari = 190;
            public const int Bebek_Beslenme_urunleri = 189;
            public const int Yurutec = 188;
            public const int Park_Yatak = 187;
            public const int Mama_Sandalyesi = 186;
            public const int Evde_Guvenlik_urunleri = 185;
            public const int Bebek_Telsizi = 184;
            public const int Bebek_Salincaklari = 183;
            public const int Bebek_Oto_Koltugu = 182;
            public const int Bebek_Kangurusu = 181;
            public const int Bebek_Arabasi = 180;
            public const int Baston_Puset = 179;
            public const int Araba_icin_Guvenlik_urunleri = 178;
            public const int Ana_Kucagi = 177;
            public const int Piller = 176;
            public const int Oyuncak_Bebekler = 175;
            public const int Bebek_Bisikletleri = 174;
            public const int Oyun_Halilari = 173;
            public const int Donence_Oyuncaklari = 172;
            public const int Bebek_Oyuncaklari = 171;
            public const int Bebek_Kitaplari = 170;
            public const int Bebek_Gunes_Gozlugu = 169;
            public const int Bebek_Deniz_Plaj_Oyuncaklari = 168;
            public const int Bebek_Bahce_Oyuncaklari = 167;
            public const int Akulu_Araba = 166;
            public const int Yenidogan_Bebek_Bezi = 165;
            public const int Mayo_Bebek_Bezi = 164;
            public const int Bebek_islak_Mendil = 163;
            public const int Bebek_Bezi_Atik_Sistemi = 162;
            public const int Bebek_Bezi = 161;
            public const int Bebek_Alt_Acma_Minderi = 160;
            public const int Hamile_Bakim_urunleri = 159;
            public const int Bebek_Tuvalet_Egitimi_urunleri = 158;
            public const int Bebek_sampuanlari = 157;
            public const int Bebek_Pisik_Kremleri = 156;
            public const int Bebek_Gunes_Kremi = 155;
            public const int Bebek_Deterjanlari = 154;
            public const int Bebek_cantalari = 153;
            public const int Bebek_Buhar_Makinesi = 152;
            public const int Bebek_Banyo_urunleri = 151;
            public const int Bebek_Bakim_urunleri = 150;
            public const int Anne_Bakim_urunleri = 149;
            public const int Bebek_Yataklari = 148;
            public const int Bebek_Yastiklari = 147;
            public const int Bebek_Uyku_Setleri = 146;
            public const int Bebek_Odasi_Tekstili = 145;
            public const int Bebek_Odasi_Mobilyasi = 144;
            public const int Bebek_Odasi_Aksesuarlari = 143;
            public const int Bebek_Nevresimleri = 142;
            public const int Bebek_Cibinlik = 141;
            public const int Bebek_Besikleri = 140;
            public const int Portatif_Besikler = 139;
            public const int Hamile_Giyim = 138;
            public const int Emzirme_Giyim = 137;
            public const int cocuk_cantasi = 136;
            public const int Bebek_coraplari = 134;
            public const int Bebek_Ayakkabilari = 133;
            public const int Anne_Bebek_Bakim_cantasi = 132;

            #endregion Hamile Bebek

            #region Oyun

            public const int Oyun = 210;

            public const int Oyun_Aksiyon = 212;
            public const int Oyun_Strateji = 213;
            public const int Oyun_Rpg = 214;
            public const int Oyun_Eglence = 215;
            public const int Oyun_Yaris = 216;
            public const int Oyun_Spor = 217;
            public const int Oyun_Simulasyon = 218;
            public const int Oyun_Multiplayer = 219;

            #endregion Oyun

            #region Yazilim

            public const int Yazilim = 211;

            public const int Yazilim_AnimasyonModelleme = 220;
            public const int Yazilim_TasarımIllustrasyon = 221;
            public const int Yazilim_VideoDuzenleme = 222;
            public const int Yazilim_Uygulama = 223;

            #endregion Yazilim

            public const int UnisexAyakkabi = 230;
            public const int UnisexAyakkabi_SporAyakkabi = 237;
            public const int UnisexGiyim = 238;
            public const int UnisexGiyim_SporGiyim = 239;
            public const int UnisexAksesuar = 231;
        }

        /// <summary>
        /// Brand ids in db
        /// </summary>
        public static class BrandId
        {
            /// <summary>
            /// use this id for unknown brands
            /// </summary>
            public const int Unknown = 7;
        }

    }

    #endregion database Ids
}