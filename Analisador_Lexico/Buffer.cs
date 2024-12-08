public class Buffer {
    private readonly string _source;     
    private readonly int _tambuffer;    
    private int _cIndex;                

    public char Current { get; private set; }  
    public int Linha { get; private set; } = 1; 
    public int Coluna { get; private set; } = 1; 

    public Buffer(string source, int tambuffer = 1024) {
        _source = source + '\0';      
        _tambuffer = tambuffer;       
        _cIndex = 0;                   
        Current = _source[_cIndex];    
    }

    public char Peek() {
        return _cIndex + 1 < _source.Length ? _source[_cIndex + 1] : '\0';
    }

    public void Advance() {
        if (Current == '\n') {
            Linha++;  
            Coluna = 1;
        } else {
            Coluna++; 
        }

        _cIndex++;  
        Current = _cIndex < _source.Length ? _source[_cIndex] : '\0'; 
    }
}
