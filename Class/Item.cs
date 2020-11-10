using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Collections.Generic;
using IMAPI2.Interop;

namespace Data.MediaItem
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEINFO
    {
        public IntPtr hIcon;
        public IntPtr iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    }

    class Win32
    {
        public const uint SHGFI_ICON = 0x100;
        public const uint SHGFI_LARGEICON = 0x0;
        public const uint SHGFI_SMALLICON = 0x1;

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        [DllImport("user32.dll")]
        public static extern bool DestroyIcon(IntPtr handle);

        public const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;

        public const uint STGM_DELETEONRELEASE = 0x04000000;
        public const uint STGM_SHARE_DENY_WRITE = 0x00000020;
        public const uint STGM_SHARE_DENY_NONE = 0x00000040;
        public const uint STGM_READ = 0x00000000;

        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true, PreserveSig = false, EntryPoint = "SHCreateStreamOnFileW")]
        public static extern void SHCreateStreamOnFile(string fileName, uint mode, ref IStream stream);
    }

    interface IMediaItem
    {
        string Path { get; }

        Int64 ukuranDiDisc { get; }

        System.Drawing.Image FileIconImage { get; }

        bool tambahkanKeFileSystem(IFsiDirectoryItem rootItem);
    }

    class FileItem : IMediaItem
    {
        private const Int64 ukuranSektor = 2048;
        private Int64 panjangFile = 0;

        public FileItem(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File yang ditambahkan tidak ditemukan !!", path);
            }

            filePath = path;

            FileInfo fileInfo = new FileInfo(filePath);
            displayName = fileInfo.Name;
            panjangFile = fileInfo.Length;

            SHFILEINFO shinfo = new SHFILEINFO();
            IntPtr hImg = Win32.SHGetFileInfo(filePath, 0, ref shinfo,
            (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_SMALLICON);

            if (shinfo.hIcon != null)
            {
                System.Drawing.IconConverter imageConverter = new System.Drawing.IconConverter();
                System.Drawing.Icon icon = System.Drawing.Icon.FromHandle(shinfo.hIcon);
                try
                {
                    fileIconImage = (System.Drawing.Image)
                    imageConverter.ConvertTo(icon, typeof(System.Drawing.Image));
                }
                catch (NotSupportedException)
                {
                }
                Win32.DestroyIcon(shinfo.hIcon);
            }
        }

        public string Path
        {
            get
            {
                return filePath;
            }
        }
        private string filePath;

        public override string ToString()
        {
            return displayName;
        }
        private string displayName;

        public Int64 ukuranDiDisc
        {
            get
            {
                if (panjangFile > 0)
                {
                    return ((panjangFile / ukuranSektor) + 1) * ukuranSektor;
                }

                return 0;
            }
        }

        public System.Drawing.Image FileIconImage
        {
            get
            {
                return fileIconImage;
            }
        }
        private System.Drawing.Image fileIconImage = null;

        public bool tambahkanKeFileSystem(IFsiDirectoryItem rootItem)
        {
            IStream stream = null;

            try
            {
                Win32.SHCreateStreamOnFile(filePath, Win32.STGM_READ | Win32.STGM_SHARE_DENY_WRITE, ref stream);

                if (stream != null)
                {
                    rootItem.AddFile(displayName, stream);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Kesalahan menambahkan file...",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (stream != null)
                {
                    Marshal.FinalReleaseComObject(stream);
                }
            }
            return false;
        }
    }

    class DirectoryItem : IMediaItem
    {
        private List<IMediaItem> mediaItems = new List<IMediaItem>();

        public DirectoryItem(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new FileNotFoundException("File yang ditambahkan tidak ditemukan !!", directoryPath);
            }

            pathDirektori = directoryPath;
            FileInfo fileInfo = new FileInfo(pathDirektori);
            displayName = fileInfo.Name;

            string[] files = Directory.GetFiles(pathDirektori);
            foreach (string file in files)
            {
                mediaItems.Add(new FileItem(file));
            }

            string[] directories = Directory.GetDirectories(pathDirektori);
            foreach (string directory in directories)
            {
                mediaItems.Add(new DirectoryItem(directory));
            }

            SHFILEINFO shinfo = new SHFILEINFO();
            IntPtr hImg = Win32.SHGetFileInfo(pathDirektori, 0, ref shinfo,
            (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_SMALLICON);

            if (shinfo.hIcon != null)
            {
                System.Drawing.IconConverter imageConverter = new System.Drawing.IconConverter();
                System.Drawing.Icon icon = System.Drawing.Icon.FromHandle(shinfo.hIcon);
                try
                {
                    fileIconImage = (System.Drawing.Image)
                    imageConverter.ConvertTo(icon, typeof(System.Drawing.Image));
                }
                catch (NotSupportedException)
                {
                }
                Win32.DestroyIcon(shinfo.hIcon);
            }
        }

        public string Path
        {
            get
            {
                return pathDirektori;
            }
        }
        private string pathDirektori;

        public override string ToString()
        {
            return displayName;
        }
        private string displayName;

        public Int64 ukuranDiDisc
        {
            get
            {
                Int64 ukuranTotal = 0;
                foreach (IMediaItem mediaItem in mediaItems)
                {
                    ukuranTotal += mediaItem.ukuranDiDisc;
                }
                return ukuranTotal;
            }
        }

        public System.Drawing.Image FileIconImage
        {
            get
            {
                return fileIconImage;
            }
        }
        private System.Drawing.Image fileIconImage = null;

        public bool tambahkanKeFileSystem(IFsiDirectoryItem rootItem)
        {
            try
            {
                rootItem.AddTree(pathDirektori, true);
                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Kesalahan menambahkan folder...",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
