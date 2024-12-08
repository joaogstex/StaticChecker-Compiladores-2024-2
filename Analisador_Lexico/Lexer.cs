using System.Text;
using LexerApp.Models;

namespace Analisador_Lexico.Core;

public class Lexer {
    //private readonly InputReader _reader;
    private readonly Buffer _buffer;
    private readonly List<Token> _tokens = new();
    private readonly ErrorHandler _errorHandler;
    private readonly SymbolTable _symbolTable = new();

    public Lexer(string sourceCode) {
        //_reader = new InputReader(sourceCode);
        _buffer = new Buffer(sourceCode);
        _errorHandler = new ErrorHandler();
    }

    private void SkipWhitespace() {
    while (char.IsWhiteSpace(_buffer.Current)) {
        _buffer.Advance();
    }
}

    public List<Token> Analyze() {
        while (_buffer.Current != '\0') {
            SkipWhitespace();

            if (_buffer.Current == '/' && _buffer.Peek() == '/') {
            ProcessSingleLineComment();
            } 
            else if (_buffer.Current == '/' && _buffer.Peek() == '*') {
            ProcessMultiLineComment();
            } 
            else if (char.IsLetter(_buffer.Current)) {
                ProcessIdentifier();
            }
            else if (char.IsDigit(_buffer.Current)) {
                ProcessNumber();
            }
            else {
                ProcessSymbol();
            }
        }

        return _tokens;
    }

    public string GenerateLexicalReport(string sourceFileName) {
        var report = new StringBuilder();
        report.AppendLine("Código Identificador: EQ05");
        report.AppendLine("Nomes: João Gustavo da Silva Teixeira, Nicolas Raimundo Menezes de Araújo, Loren Vitória Cavalcante Santos, João Antônio Luz dos Santos");
        report.AppendLine("E-mails: joaogustavo.teixeira@ucsal.edu.br, nicolas.araujo@ucsal.edu.br, loren.santos@ucsal.edu.br, joaoantonio.santos@ucsal.edu.br");
        report.AppendLine("Telefones: +55 71 98798-7008, +55 71 99987-9517, +55 71 98514-7438, +55 71 99721-1113");
        report.AppendLine($"\nRELATÓRIO DA ANÁLISE LÉXICA. Texto fonte analisado: {sourceFileName}\n");
        report.AppendLine();

        foreach (var token in _tokens) {
            int symbolIndex = _symbolTable.GetIndex(token.Lexeme);
            report.AppendLine(
                $"Lexeme: {token.Lexeme}, Type: {token.Type}, Índice na tabela: {symbolIndex}, Linha: {token.Line}");
            report.AppendLine("---------------------------------------------------------------------------------");
        }

        return report.ToString();
    }

    // Adicionado parâmetro para mostrar o nome do arquivo no MeuTeste.TAB
    public string GenerateSymbolTableReport(string fileName) => _symbolTable.GenerateReport(fileName);

    private void ProcessSingleLineComment() {
    while (_buffer.Current != '\n' && _buffer.Current != '\0') {
        _buffer.Advance();
        }
    }

    private void ProcessMultiLineComment() {
    _buffer.Advance(); 
    _buffer.Advance(); 

    while (_buffer.Current != '\0') {
        if (_buffer.Current == '*' && _buffer.Peek() == '/') {
            _buffer.Advance(); 
            _buffer.Advance(); 
            break;
        }

        _buffer.Advance();
        }
    }
    
    private void ProcessIdentifier() {
        var startLine = _buffer.Linha;
        var startColumn = _buffer.Coluna;
        var lexeme = "";

        int maxLength = 30; // Limite máximo 
        int count = 0;

        while (char.IsLetterOrDigit(_buffer.Current)) {
            if (count < maxLength) {
            lexeme += _buffer.Current;
        }
            _buffer.Advance();
            count++;
        }

        if (count > maxLength) {
            Console.WriteLine($"Aviso: O identificador '{lexeme}' foi diminuído para {maxLength} caracteres.");
        }

        _tokens.Add(new Token("IDENTIFIER", lexeme, startLine, startColumn));
        _symbolTable.AddSymbol(lexeme, "IDENTIFIER", startLine);
    }

    private void ProcessNumber() {
        var startLine = _buffer.Linha;
        var startColumn = _buffer.Coluna;
        var lexeme = "";

        int maxLength = 30; // Mesma coisa
        int count = 0;

        while (char.IsDigit(_buffer.Current)) {
            if (count < maxLength) {
            lexeme += _buffer.Current;
        }
            _buffer.Advance();
            count++;
        }

        if (count > maxLength) {
            Console.WriteLine($"Aviso: O número '{lexeme}' foi diminuído para {maxLength} caracteres.");
        }

        _tokens.Add(new Token("NUMBER", lexeme, startLine, startColumn));
    }

    private void ProcessSymbol() {
        var startLine = _buffer.Linha;
        var startColumn = _buffer.Coluna;
        var lexeme = _buffer.Current.ToString();

        if ("{};,:=()".Contains(lexeme)) {
            _tokens.Add(new Token("SYMBOL", lexeme, startLine, startColumn));
        } else {
            _errorHandler.AddError(startLine, startColumn, $"Símbolo inesperado: {lexeme}");
        }

        _buffer.Advance();
    }

    public void PrintErrors() => _errorHandler.PrintErrors();
}
