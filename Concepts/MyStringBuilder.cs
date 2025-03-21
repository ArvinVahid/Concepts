public class StringBuilder
{
    private char[] _buffer;       // Internal buffer
    private int _position;        // Current position in buffer
    private int _capacity;        // Current capacity

    // Constructor with default capacity
    public StringBuilder()
    {
        _capacity = 16;  // Default initial capacity
        _buffer = new char[_capacity];
        _position = 0;
    }

    // Constructor with specified capacity
    public StringBuilder(int capacity)
    {
        _capacity = capacity;
        _buffer = new char[_capacity];
        _position = 0;
    }

    // Append a string
    public StringBuilder Append(string value)
    {
        if (string.IsNullOrEmpty(value))
            return this;

        // Ensure capacity
        EnsureCapacity(_position + value.Length);

        // Copy characters
        for (int i = 0; i < value.Length; i++)
        {
            _buffer[_position++] = value[i];
        }

        return this;
    }

    // Ensure buffer has enough capacity
    private void EnsureCapacity(int minCapacity)
    {
        if (minCapacity > _capacity)
        {
            int newCapacity = Math.Max(_capacity * 2, minCapacity);
            char[] newBuffer = new char[newCapacity];
            Array.Copy(_buffer, newBuffer, _position);
            _buffer = newBuffer;
            _capacity = newCapacity;
        }
    }
}