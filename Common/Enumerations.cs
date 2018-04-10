namespace Common
{
    public enum AuthenticationMode
    {
        Network = 0,
        Application = 1,
        Both = 2,
        None = 3,
        BothSecure = 4
    }

    public enum DataExportType
    {
        FromPage,
        FromPopUp
    }

    public enum DataLoadType
    {
        AsPage,
        AsModalBox
    }
    public enum ColumnDataFormat
    {
        Default,
        Date,
        Money
    }

    public enum ColumnDataType
    {
        Text,
        LinkButton,
        ImageButton,
    }

    public enum DataSearchType
    {
        Text,
        Dropdown,
        DatePicker,
        DateRangePicker
    }

    public enum ExportType
    {
        Undefined = -1,
        Product = 0,
        Category = 1
    }

    public enum Status : byte
    {
        Active,
        Passive,
        Suspended,
        Deleted
    }

    public enum Condition
    {
        Ok,
        Injured, // sakat
        Missing, //cezali
        Resting // dinlendiriliyor
    }

    public enum CatalogVersion
    {
        Demo,
        Standart,
        Professional
    }

    public enum TemplateType
    {
        Default,
        Food,
        WhiteAppliances // beyaz esya
    }

    public enum Key
    {
        Tag,
        Discount,
        Image,
        Video
    }

    public enum ResponseCode
    {
        Fail = -1,
        Success = 0,
        Warning = 1,
        Info = 2,
        NoEffect = 3,
        DuplicateRecord = 4
    }

    public enum WebMethodType
    {
        Null,
        Get,
        Post,
        Put,
        Info,
        NoEffect
    }

    public enum ContentType
    {
        Null,
        FormUrlencoded
    }

    public enum BettingType
    {
        All,
        Player
    }

    public enum BetSiteId
    {
        Rivalo = 1,
        TempoBet
    }

    public enum PredictonStake : byte
    {
        Stake1 = 1,
        Stake2 = 2,
        Stake3 = 3,
        Stake4 = 4,
        Stake5 = 5,
        Stake6 = 6,
        Stake7 = 7,
        Stake8 = 8,
        Stake9 = 9,
        Stake10 = 10
    }

    public enum PredictionResult : byte
    {
        Pending = 0,
        Won = 1,
        Lost = 2,
        Canceled = 3
    }

    public enum AccountType
    {
        Trial,
        Standart,
        Premium
    }

    public enum TipType : byte
    {
        Comment = 0,
        Prediction = 1
    }

    public enum NotificationStatus : byte
    {
        Initial = 0,
        WaitingForSendingNotification = 1,
        NotificationSent = 2,
        NotificationRead = 3,
        HasError = 4
    }

    /// <summary>
    ///  dbo.UserSettings.Key 
    /// </summary>
    public enum UserSettingKey : byte
    {
        AuthorNotifications = 0
    }

    public enum SearchType
    {
        Authors = 1,
        Events = 2
    }

    public enum DeviceType : byte
    {
        Ios = 0,
        Android = 1,
        None = 2
    }

    public enum RequestType : byte
    {
        Complaint = 0,
        Suggession = 1,
        Wish = 2,
        Other = 3,
        None = 4
    }

    public enum AuthorOrderType
    {
        /// <summary>
        /// list authors order by won ratio
        /// </summary>
        WonRatio,
        /// <summary>
        /// list authors order by yield
        /// </summary>
        Yield,
        /// <summary>
        /// list authors order by prediction total
        /// </summary>
        PredictionTotal
    }

}