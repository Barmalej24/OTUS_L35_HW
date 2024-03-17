
namespace OTUS_L35_HW
{
    public class OtusDictionary
    {
        private (int key, string value)[] _array;
        private int _size = 32;

        public OtusDictionary() => _array = new (int key, string value)[_size];

        public string this[int i]
        {
            get => Get(i);
            set => Add(i, value);
        }

        public void Add(int key, string value)
        {
            if (value == null)
                return;

            if (_array[Hash(key)].value != null)
            {
                var newArray = Resize(2 * _size);
                foreach (var element in _array)
                {
                    if (element.value != null)
                    {
                        newArray[Hash(element.key)] = element;
                    }
                }
                _array = newArray;
            }
            else
            {
                _array[Hash(key)] = new (key, value);
            }
        }

        private (int key, string value)[] Resize(int size)
        {
            var newArray = new (int key, string value)[size];
            _size = size;
            return newArray;
        }

        public string Get(int key) => _array[Hash(key)].value;        

        private int Hash(int key) => (key.GetHashCode() & 0x7fffffff) % _size;
        
    }
}
