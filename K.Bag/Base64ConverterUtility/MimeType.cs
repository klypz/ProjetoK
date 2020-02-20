namespace K.Bag.Base64ConverterUtility
{
    internal class MimeType : IMimeType
    {
        internal readonly static IMimeType UNK = new MimeType("", "application/octet-stream", null);
        internal readonly static IMimeType AES = new MimeType("aes", "application/octet-stream", new byte?[] { 0x41, 0x45, 0x53 });
        internal readonly static IMimeType BMP = new MimeType("bmp", "image/gif", new byte?[] { 66, 77 });
        internal readonly static IMimeType BZ2 = new MimeType("bz2,tar,bz2,tbz2,tb2", "application/x-bzip2", new byte?[] { 0x42, 0x5A, 0x68 });
        internal readonly static IMimeType DLL_EXE = new MimeType("dll, exe", "application/octet-stream", new byte?[] { 0x4D, 0x5A });
        internal readonly static IMimeType DWG = new MimeType("dwg", "application/acad", new byte?[] { 0x41, 0x43, 0x31, 0x30 });
        internal readonly static IMimeType XLS = new MimeType("xls", "application/excel", new byte?[] { 0x09, 0x08, 0x10, 0x00, 0x00, 0x06, 0x05, 0x00 }, 512);
        internal readonly static IMimeType XLSX = new MimeType("xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", new byte?[] { 0x50, 0x4b, 0x03, 0x04 }, 0, new byte?[] { 0x77, 0x6f, 0x72, 0x6b, 0x62, 0x6f, 0x6f, 0x6b, 0x2e, 0x78, 0x6d, 0x6c });
        internal readonly static IMimeType DOCX = new MimeType("docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", new byte?[] { 0x50, 0x4b, 0x03, 0x04 }, 0, new byte?[] { 0x64, 0x6f, 0x63, 0x75, 0x6d, 0x65, 0x6e, 0x74, 0x2e, 0x78, 0x6d, 0x6c });
        internal readonly static IMimeType PPTX = new MimeType("pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", new byte?[] { 0x50, 0x4b, 0x03, 0x04 }, 0, new byte?[] { 0x70, 0x72, 0x65, 0x73, 0x65, 0x6e, 0x74, 0x61, 0x74, 0x69, 0x6f, 0x6e, 0x2e, 0x78, 0x6d, 0x6c });
        internal readonly static IMimeType FLV = new MimeType("flv", "application/unknown", new byte?[] { 0x46, 0x4C, 0x56, 0x01 });
        internal readonly static IMimeType GIF = new MimeType("gif", "image/gif", new byte?[] { 0x47, 0x49, 0x46, 0x38, null, 0x61 });
        internal readonly static IMimeType GZ_TGZ = new MimeType("gz, tgz", "application/x-gz", new byte?[] { 0x1F, 0x8B, 0x08 });
        internal readonly static IMimeType ICO = new MimeType("ico", "image/x-icon", new byte?[] { 0, 0, 1, 0 });
        internal readonly static IMimeType JPEG = new MimeType("jpg", "image/jpeg", new byte?[] { 0xFF, 0xD8, 0xFF });
        internal readonly static IMimeType LIB_COFF = new MimeType("lib", "application/octet-stream", new byte?[] { 0x21, 0x3C, 0x61, 0x72, 0x63, 0x68, 0x3E, 0x0A });
        internal readonly static IMimeType MIDI = new MimeType("midi,mid", "audio/midi", new byte?[] { 0x4D, 0x54, 0x68, 0x64 });
        internal readonly static IMimeType MSDOC = new MimeType("msdoc", "application/octet-stream", new byte?[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 });
        internal readonly static IMimeType ODS = new MimeType("ods", "application/vnd.oasis.opendocument.spreadsheet", null, 512);
        internal readonly static IMimeType ODT = new MimeType("odt", "application/vnd.oasis.opendocument.text", null, 512);
        internal readonly static IMimeType OGG = new MimeType("oga,ogg,ogv,ogx", "application/ogg", new byte?[] { 103, 103, 83, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0 });
        internal readonly static IMimeType PDF = new MimeType("pdf", "application/pdf", new byte?[] { 0x25, 0x50, 0x44, 0x46 });
        internal readonly static IMimeType PKR = new MimeType("pkr", "application/octet-stream", new byte?[] { 0x99, 0x01 });
        internal readonly static IMimeType PNG = new MimeType("png", "image/png", new byte?[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A });
        internal readonly static IMimeType PPT = new MimeType("ppt", "application/mspowerpoint", new byte?[] { 0xFD, 0xFF, 0xFF, 0xFF, null, 0x00, 0x00, 0x00 }, 512);
        internal readonly static IMimeType PSD = new MimeType("psd", "application/octet-stream", new byte?[] { 0x38, 0x42, 0x50, 0x53 });
        internal readonly static IMimeType PST = new MimeType("pst", "application/octet-stream", new byte?[] { 0x21, 0x42, 0x44, 0x4E });
        internal readonly static IMimeType RAR = new MimeType("rar", "application/x-compressed", new byte?[] { 0x52, 0x61, 0x72, 0x21 });
        internal readonly static IMimeType RTF = new MimeType("rtf", "application/rtf", new byte?[] { 0x7B, 0x5C, 0x72, 0x74, 0x66, 0x31 });
        internal readonly static IMimeType SKR = new MimeType("skr", "application/octet-stream", new byte?[] { 0x95, 0x00 });
        internal readonly static IMimeType SKR_2 = new MimeType("skr", "application/octet-stream", new byte?[] { 0x95, 0x01 });
        internal readonly static IMimeType TAR_ZH = new MimeType("tar.z", "application/x-tar", new byte?[] { 0x1F, 0xA0 });
        internal readonly static IMimeType TAR_ZV = new MimeType("tar.z", "application/x-tar", new byte?[] { 0x1F, 0x9D });
        internal readonly static IMimeType TXT = new MimeType("txt", "text/plain", null);
        internal readonly static IMimeType T_UTF16 = new MimeType("txt", "text/plain", new byte?[] { 0xFE, 0xFF });
        internal readonly static IMimeType T_UTF16_2 = new MimeType("txt", "text/plain", new byte?[] { 0xFF, 0xFE });
        internal readonly static IMimeType T_UTF32 = new MimeType("txt", "text/plain", new byte?[] { 0x00, 0x00, 0xFE, 0xFF });
        internal readonly static IMimeType T_UTF32_2 = new MimeType("txt", "text/plain", new byte?[] { 0xFF, 0xFE, 0x00, 0x00 });
        internal readonly static IMimeType T_UTF8 = new MimeType("txt", "text/plain", new byte?[] { 0xEF, 0xBB, 0xBF });
        internal readonly static IMimeType WAVE = new MimeType("wav", "audio/wav", new byte?[] { 0x52, 0x49, 0x46, 0x46, null, null, null, null, 0x57, 0x41, 0x56, 0x45, 0x66, 0x6D, 0x74, 0x20 });
        internal readonly static IMimeType DOC = new MimeType("doc", "application/msword", new byte?[] { 0xEC, 0xA5, 0xC1, 0x00 }, 512);
        internal readonly static IMimeType XLS2 = new MimeType("xls", "application/vnd.ms-excel", new byte?[] { 0x09, 0x08, 0x10, 0x00, 0x00, 0x06, 0x05, 0x00 }, 512);
        internal readonly static IMimeType PPT2 = new MimeType("ppt", "application/vnd.ms-powerpoint", new byte?[] { 0xFD, 0xFF, 0xFF, 0xFF, null, 0x00, 0x00, 0x00 }, 512);
        internal readonly static IMimeType PPT3 = new MimeType("ppt", "application/vnd.ms-powerpoint", new byte?[] { 0xD0, 0xCF, 0X11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 }, 0, new byte?[] { 0x50, 0x6F, 0x77, 0x65, 0x72, 0x50, 0x6F, 0x69, 0x6E, 0x74 });
        internal readonly static IMimeType XML = new MimeType("xml,xul", "text/xml", new byte?[] { 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x22, 0x31, 0x2E, 0x30, 0x22, 0x3F, 0x3E });
        internal readonly static IMimeType ZIP = new MimeType("zip", "application/x-compressed", new byte?[] { 0x50, 0x4B, 0x03, 0x04 });
        internal readonly static IMimeType COMP_7z = new MimeType("7z", "application/x-compressed", new byte?[] { 66, 77 });
        internal readonly static IMimeType COMP_7z_2 = new MimeType("7z", "application/x-compressed", new byte?[] { 0x37, 0x7A, 0xBC, 0xAF, 0x27, 0x1C });

        public string Extension { get; private set; }

        public string Mime { get; private set; }

        public byte?[] ByteHeader { get; private set; }

        public int Offset { get; private set; }
        public byte?[] OtherIdentifier { get; private set; }

        internal MimeType(string extension, string mime, byte?[] byteHeader, int offset = 0, byte?[] otherIdentifier = null)
        {
            Extension = extension;
            Mime = mime;
            ByteHeader = byteHeader;
            Offset = offset;
            OtherIdentifier = otherIdentifier;
        }
    }
}
