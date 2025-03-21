## Key Differences
1. Immutability :
   - String is immutable - operations create new strings
   - StringBuilder is mutable - operations modify the existing instance
2. Memory Usage :
   - String operations can create many temporary objects
   - StringBuilder reuses the same buffer, expanding it when needed
3. Performance :
   - For few concatenations, String is simpler and efficient
   - For many concatenations, StringBuilder is much more efficient
4. Thread Safety :
   - String is thread-safe due to immutability
   - StringBuilder is not thread-safe by default (StringBuffer in Java is the thread-safe equivalent)
