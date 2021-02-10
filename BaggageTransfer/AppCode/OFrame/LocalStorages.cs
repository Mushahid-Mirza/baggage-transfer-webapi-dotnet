using BaggageTransfer.SettingsHelpers;

namespace BaggageTransfer
{
    public static class LocalStorages
    {
        public static string Storage
        {
            get
            {
                return LocalStoragesHelper.GetStoragePath("Storage");
            }

            set
            {
                LocalStoragesHelper.SetStoragePath("Storage", value);
            }
        }

        public static string Storage_Logs
        {
            get
            {
                return LocalStoragesHelper.GetStoragePath("Storage_Logs");
            }

            set
            {
                LocalStoragesHelper.SetStoragePath("Storage_Logs", value);
            }
        }

        public static string Storage_Temp
        {
            get
            {
                return LocalStoragesHelper.GetStoragePath("Storage_Temp");
            }

            set
            {
                LocalStoragesHelper.SetStoragePath("Storage_Temp", value);
            }
        }

        public static string Storage_Audio_Uploads
        {
            get
            {
                return LocalStoragesHelper.GetStoragePath("Storage_Audio_Uploads");
            }

            set
            {
                LocalStoragesHelper.SetStoragePath("Storage_Audio_Uploads", value);
            }
        }

        public static string Storage_Image_Uploads
        {
            get
            {
                return LocalStoragesHelper.GetStoragePath("Storage_Image_Uploads");
            }

            set
            {
                LocalStoragesHelper.SetStoragePath("Storage_Image_Uploads", value);
            }
        }

        public static string Storage_Literature_Uploads
        {
            get
            {
                return LocalStoragesHelper.GetStoragePath("Storage_Literature_Uploads");
            }

            set
            {
                LocalStoragesHelper.SetStoragePath("Storage_Literature_Uploads", value);
            }
        }
        public static string Storage_Uploads
        {
            get
            {
                return LocalStoragesHelper.GetStoragePath("Storage_Uploads");
            }

            set
            {
                LocalStoragesHelper.SetStoragePath("Storage_Uploads", value);
            }
        }
    }
}
