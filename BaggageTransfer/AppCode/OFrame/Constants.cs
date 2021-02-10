using BaggageTransfer.SettingsHelpers;
using BaggageTransfer.Util;

namespace BaggageTransfer
{
    public static class Constants
    {
        public static readonly string ErrorMessage = Language("SomeErrorOccurredWhile" + " {0} {1} ");

        public static readonly string ColonNextLine = " : \n";

        public static readonly string Video = Language("Video");
        public static readonly string Audio = Language("Audio");
        public static readonly string Link = Language("Link");
        public static readonly string GalleryImage = Language("GalleryImage");
        public static readonly string Literature = Language("Literature");
        public static readonly string Group = Language("Group");
        public static readonly string UserReview = Language("Review");

        public static readonly string Adding = Language("Adding");
        public static readonly string Updating = Language("Updating");
        public static readonly string Deleting = Language("Deleting");


        public static readonly string ErrorAddingVideo = string.Format(ErrorMessage, Adding, Video);
        public static readonly string ErrorUpdatingVideo = string.Format(ErrorMessage, Updating, Video);
        public static readonly string ErrorDeletingVideo = string.Format(ErrorMessage, Deleting, Video);

        public static readonly string ErrorAddingAudio = string.Format(ErrorMessage, Adding, Audio);
        public static readonly string ErrorUpdatingAudio = string.Format(ErrorMessage, Updating, Audio);
        public static readonly string ErrorDeletingAudio = string.Format(ErrorMessage, Deleting, Audio);
         
        public static readonly string ErrorAddingLink = string.Format(ErrorMessage, Adding, Link);
        public static readonly string ErrorUpdatingLink = string.Format(ErrorMessage, Updating, Link);
        public static readonly string ErrorDeletingLink = string.Format(ErrorMessage, Deleting, Link);

        public static readonly string ErrorAddingGalleryImage = string.Format(ErrorMessage, Adding, GalleryImage);
        public static readonly string ErrorUpdatingGalleryImage = string.Format(ErrorMessage, Updating, GalleryImage);
        public static readonly string ErrorDeletingGalleryImage = string.Format(ErrorMessage, Deleting, GalleryImage);

        public static readonly string ErrorAddingLiterature = string.Format(ErrorMessage, Adding, Literature);
        public static readonly string ErrorUpdatingLiterature = string.Format(ErrorMessage, Updating, Literature);
        public static readonly string ErrorDeletingLiterature = string.Format(ErrorMessage, Deleting, Literature);

        public static readonly string ErrorAddingGroup = string.Format(ErrorMessage, Adding, Group);
        public static readonly string ErrorUpdatingGroup = string.Format(ErrorMessage, Updating, Group);
        public static readonly string ErrorDeletingGroup = string.Format(ErrorMessage, Deleting, Group);

        public static readonly string ErrorAddingUserReview = string.Format(ErrorMessage, Adding, UserReview);
        public static readonly string ErrorUpdatingUserReview = string.Format(ErrorMessage, Updating, UserReview);
        public static readonly string ErrorDeletingUserReview = string.Format(ErrorMessage, Deleting, UserReview);

        public static readonly string PlayList = Language("PlayList");
        public static readonly string Album = Language("Album");
        public static readonly string Library = Language("Library"); 
         

        public static string Language(string key) {
            return key.ToFriendlyCase();
        }
         
        public static class Keys
        {
            public const string AnonymousUserIDCookieKey = "_AnonymousUserID__";
            public const string AvatarPathPerformanceKey = "_AvatarPathPerformanceKey__";
            public const string CurrentCultureCookieKey = "_CurrentCulture__";
            public const string CurrentCultureDirectionCookieKey = "_CurrentCultureDirection__";
            public const string CurrentCultureSessionKey = "_CurrentCultureSessionKey__";
            public const string GridViewSortDirection = "_GridViewSortDirection__";
            public const string GridViewSortExpression = "_GridViewSortExpression__";
            public const string GuestEmailIDCookieKey = "_GuestEmailID__";
            public const string PrintSettingsKey = "_PrintSettings__";
        }

        public static class Messages
        {
            public const string ADD_SUCCESS_MESSAGE = "Item added successfully";
            public const string DELETE_SUCCESS_MESSAGE = "Item deleted successfully";
            public const string ITEM_ALREADY_PRESENT = "Item already present";
            public const string ITEM_NOT_EXISTS_MESSAGE = "Item does not exists";
            public const string RELATED_RECORD_EXISTS_MESSAGE = "Item cannot be deleted as it has related records";
            public const string SAVE_SUCCESS_MESSAGE = "Item saved successfully";
        }
    }
}
