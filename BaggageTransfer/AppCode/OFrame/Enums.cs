namespace BaggageTransfer
{
    public enum Measure
    {
        Unit,
        Small,
        Medium,
        Large,
        Set,
        Piece,
        Meter,
        CM,
    }

    public enum PaymentStatus
    { 
        Paid,
        Returned,
        Cancelled,
    }

    public enum PaymentMode
    {
        Cash = 1,
        Card = 2,
        Cheque = 3,
        Online = 4,
    }

    public enum RequestType
    {
        Travel = 1,
        Baggage = 2
    }

    public enum PaymentFlow
    {
        Debit = 1,
        Credit = 2
    }

    public enum ApiResult
    {
        ValidationError = 0,
        Success = 1,
        Failure = 2,
        Error = 3
    }


    public enum DBStatus
    {
        Success,
        Conflict,
        Exist,
        DoesntExist,
        Error
    }

    public enum GroupType
    {
        VideoPlayList,
        AudioPlayList,
        LiteratureGroup,
        Links,
        GalleryGroup
    }

    public enum AdminListingType
    {
        Contents,
        Categories,
        Groups
    }

    public enum ReviewType
    {
        ContactUs,
        Video,
        Audio
    }

    public enum BlinkRate
    {
        None,
        Slow,
        Regular,
        Fast,
    }

    public enum NotificationType
    {
        Booking,
        Welcome, 
        Push,
    }

    public enum EventSchedule
    {
        UpComing,
        Past,
        All,
        Continuing,
    }

    public enum FieldWidth
    {
        xxsmall,
        xsmall,
        small,
        medium,
        large,
        largeXL,
        full,
    }

    public enum FileType
    {
        Image,
        Document,
        Audio,
        PDF,
        Custom,
        All
    }

    public enum UserType
    {
        SubAdmin,
        Admin,
        User
    }

    public enum Gender
    {
        Male,
        Female,
        Unspecified,
    }

    public enum HashServiceProvider : int
    {
        SHA1,
        SHA256,
        SHA384,
        SHA512,
        MD5,
    }

    public enum LogType
    {
        Error,
        Activity
    }

    public enum ManageMessageId
    {
        AddPhoneSuccess,
        ChangePasswordSuccess,
        SetTwoFactorSuccess,
        SetPasswordSuccess,
        RemoveLoginSuccess,
        RemovePhoneSuccess,
        Error
    }

    public enum MemoryCacheItemPriority
    {
        Default = 1,
        NotRemovable = 2,
    }

    public enum MessageColor
    {
        None,
        White,
        Black,
        Blue,
        Orange,
        Yellow,
        Red,
        Green,
    }

    public enum PageSetting
    {
        Add = 0,
        List = 1,
        Manage = 2,
    }

    public enum PerformanceMode
    {
        None = 0,
        ApplicationState = 1,
        Cache = 2,
        MemoryCache = 3,
        Session = 4,
        Redis = 5
    }

    public enum StatusMessageType
    {
        Info,
        Error,
        Success,
        Warning,
    }

    public enum SymCryptographyServiceProvider : int
    {
        Rijndael,
        RC2,
        DES,
        TripleDES,
    }

    public enum TipPosition
    {
        Left = 0,
        Right = 2,
    }
}
