
using System.Drawing;

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
            try
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Добавление пустого элемента запрещено");
                }

                if (_array[Hash(key)].value != null)
                {
                    IncreaseCapacity();
                    throw new Exception("Элемент занят");
                }
                
                _array[Hash(key)] = new(key, value);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Отловлено исключение {ex.Message}");
            }
        }

        private void IncreaseCapacity()
        {
            var newArray = new (int key, string value)[2 * _size];
            _size = 2 * _size;
            foreach (var element in _array)
            {
                if (element.value != null)
                {
                    newArray[Hash(element.key)] = element;
                }
            }
            _array = newArray;
        }

        public string Get(int key)
        {
            try
            {
                if (_array[Hash(key)].value == null)
                {
                    throw new ArgumentNullException("Не существующий элемент");
                }

                return _array[Hash(key)].value;
            }
            catch
            {
                throw;
            }

        }

        private int Hash(int key) => (key.GetHashCode() & 0x7fffffff) % _size;
        
    }
}
