using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter03
{

    public class AsyncDemo1
    {
        public int GetBitmapWidth(string path)
        {
            using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var fileId = new byte[2];
                var read = file.Read(fileId, 0, 2);
                if (read != 2 || fileId[0] != 'B' || fileId[1] != 'M')
                    throw new Exception("Not a BMP file");

                file.Seek(18, SeekOrigin.Begin);
                var widthBuffer = new byte[4];
                read = file.Read(widthBuffer, 0, 4);
                if (read != 4) throw new Exception("Not a BMP file");
                return BitConverter.ToInt32(widthBuffer, 0);
            }
        }
    }
}
