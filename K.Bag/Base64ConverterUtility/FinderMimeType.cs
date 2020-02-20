using System;
using System.Collections.Generic;
using System.Linq;

namespace K.Bag.Base64ConverterUtility
{
    internal static class FinderMimeType
    {
        private static readonly List<IMimeType> MIMES = new List<IMimeType>()
        {
            MimeType.AES,MimeType.BMP,MimeType.BZ2,MimeType.DLL_EXE,MimeType.DWG,MimeType.XLS,MimeType.XLSX,MimeType.DOCX,MimeType.PPTX,MimeType.FLV,MimeType.GIF,MimeType.GZ_TGZ,
            MimeType.ICO,MimeType.JPEG,MimeType.LIB_COFF,MimeType.MIDI,MimeType.MSDOC,MimeType.OGG,MimeType.PDF,MimeType.PKR,MimeType.PNG,
            MimeType.PPT,MimeType.PSD,MimeType.PST,MimeType.RAR,MimeType.RTF,MimeType.SKR,MimeType.SKR_2,MimeType.TAR_ZH,MimeType.TAR_ZV,MimeType.T_UTF16,
            MimeType.T_UTF16_2,MimeType.T_UTF32,MimeType.T_UTF32_2,MimeType.T_UTF8,MimeType.WAVE,MimeType.DOC,MimeType.XLS2,MimeType.PPT2,MimeType.PPT3,MimeType.XML,
            MimeType.ZIP,MimeType.COMP_7z,MimeType.COMP_7z_2

        };

        public static bool IsString(byte[] input)
        {
            return input.Count(f => f == 0x00) == 0;
        }

        public static IMimeType GetMimeType(byte[] input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (input.Length == 0)
                return MimeType.UNK;

            foreach (var item in MIMES)
            {
                if (IsMimeType(input, item))
                {
                    return item;
                }
            }
            return IsString(input) ? MimeType.TXT : MimeType.UNK;
        }

        public static bool IsMimeType(byte[] input, IMimeType mimeType)
        {
            var isMatch = FindMatch(input, mimeType.ByteHeader, mimeType.Offset);

            if (isMatch && mimeType.OtherIdentifier != null && mimeType.OtherIdentifier.Length > 0)
            {
                var matchingIndices = input.Select((b, i) => b == mimeType.OtherIdentifier[0] ? i : -1).Where(i => i != -1).ToList();
                isMatch = matchingIndices.Any(i => FindMatch(input, mimeType.OtherIdentifier, i));
            }

            return isMatch;
        }

        private static bool FindMatch(byte[] input, byte?[] searchArray, int offset = 0)
        {
            if (input.Count() < offset)
                return false;

            var matchingCount = 0;
            for (var i = 0; i < searchArray.Count(); i++)
            {
                var calculatedOffset = i + offset;

                if (searchArray[i] != null && searchArray[i] != input[calculatedOffset])
                {
                    matchingCount = 0;
                    break;
                }
                matchingCount++;
            }
            return matchingCount == searchArray.Count();
        }

    }
}
