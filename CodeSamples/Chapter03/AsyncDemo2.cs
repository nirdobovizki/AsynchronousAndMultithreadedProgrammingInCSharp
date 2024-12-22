using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter03
{

    public class AsyncDemo2
    {
        public async Task<int> GetBitmapWidth(string path)
        {
            using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var fileId = new byte[2];
                var read = await file.ReadAsync(fileId, 0, 2);
                if (read != 2 || fileId[0] != 'B' || fileId[1] != 'M')
                    throw new Exception("Not a BMP file");

                file.Seek(0x12, SeekOrigin.Begin);
                var widthBuffer = new byte[4];
                read = await file.ReadAsync(widthBuffer, 0, 4);
                if (read != 4) throw new Exception("Not a BMP file");
                return BitConverter.ToInt32(widthBuffer, 0);
            }
        }
    }
}
