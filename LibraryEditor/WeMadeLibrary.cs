using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace LibraryEditor
{
    public class WeMadeLibrary
    {
        private const string WixExtention = ".Wix",
                             WilExtention = ".Wil";

        public WeMadeImage[] Images;

        private readonly string _fileName;

        private int[] _palette;
        private List<int> _indexList;
        private int _version;

        private BinaryReader _bReader;
        private FileStream _fStream;

        private bool _initialized;

        public WeMadeLibrary(string name)
        {
            _fileName = Path.ChangeExtension(name, null);
            Initialize();
        }

        public void Initialize()
        {
            _initialized = true;

            if (!File.Exists(_fileName + WixExtention))
                return;

            if (!File.Exists(_fileName + WilExtention))
                return;

            _fStream = new FileStream(_fileName + WilExtention, FileMode.Open, FileAccess.Read);
            _bReader = new BinaryReader(_fStream);
            LoadImageInfo();

            for (int i = 0; i < Images.Length; i++)
                CheckImage(i);
        }

        private void LoadImageInfo()
        {
            _fStream.Seek(48, SeekOrigin.Begin);

            _palette = new int[_bReader.ReadInt32()];
            _fStream.Seek(4, SeekOrigin.Current);
            _version = _bReader.ReadInt32();

            LoadIndexFile();

            Images = new WeMadeImage[_indexList.Count];

            _fStream.Seek(_version == 0 ? 0 : 4, SeekOrigin.Current);

            for (int i = 1; i < _palette.Length; i++)
                _palette[i] = _bReader.ReadInt32() + (255 << 24);
        }

        private void LoadIndexFile()
        {
            _indexList = new List<int>();
            FileStream stream = null;

            try
            {
                stream = new FileStream(_fileName + WixExtention, FileMode.Open, FileAccess.Read);

                stream.Seek(_version == 0 ? 48 : 52, SeekOrigin.Begin);


                using (BinaryReader reader = new BinaryReader(stream))
                {
                    stream = null;
                    while (reader.BaseStream.Position <= reader.BaseStream.Length - 4)
                        _indexList.Add(reader.ReadInt32());
                }
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }
        }

        private void CheckImage(int index)
        {
            if (!_initialized) Initialize();
            if (Images == null || index < 0 || index >= Images.Length) return;

            if (Images[index] == null)
            {
                _fStream.Position = _indexList[index];
                Images[index] = new WeMadeImage(_bReader);
            }

            if (Images[index].Image == null)
            {
                _fStream.Seek(_indexList[index] + (_version == 0 ? 8 : 12), SeekOrigin.Begin);
                Images[index].CreateTexture(_bReader, _palette);
            }

        }

        public void ToMLibrary()
        {
            string fileName = Path.ChangeExtension(_fileName, ".Lib");

            if (File.Exists(fileName))
                File.Delete(fileName);

            MLibrary library = new MLibrary(fileName) {Images = new List<MLibrary.MImage>(), IndexList = new List<int>(), Count = Images.Length};

            for (int i = 0; i < library.Count; i++)
                library.Images.Add(null);

            ParallelOptions options = new ParallelOptions {MaxDegreeOfParallelism = 8};
            Parallel.For(0, Images.Length, options, i =>
                {
                    WeMadeImage image = Images[i];
                    library.Images[i] = new MLibrary.MImage(image.Image) {X = image.X, Y = image.Y};
                });
            
            library.Save();
        }

        public class WeMadeImage
        {
            public readonly short Width, Height, X, Y;
            public Rectangle TrueSize;
            public Bitmap Image;
            public long CleanTime;

            public WeMadeImage(BinaryReader reader)
            {
                Width = reader.ReadInt16();
                Height = reader.ReadInt16();
                X = reader.ReadInt16();
                Y = reader.ReadInt16();
            }

            public unsafe void CreateTexture(BinaryReader reader, int[] palette)
            {
                if (Width == 0 || Height == 0) return;

                Image = new Bitmap(Width, Height);

                BitmapData data = Image.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);


                byte[] bytes = reader.ReadBytes(Width * Height);

                int index = 0;

                int* scan0 = (int*) data.Scan0;
                {
                    for (int y = Height - 1; y >= 0; y--)
                    {
                        for (int x = 0; x < Width; x++)
                        {
                            scan0[y*Width + x] = palette[bytes[index++]];
                        }
                    }
                }

                Image.UnlockBits(data);
            }
        }

    }

}