using System.Collections.Generic;
using System.Text;
namespace Analisador_Lexico.Core;

public class SymbolTable {
    //private readonly Dictionary<string, string> _symbols = new();
    private readonly Dictionary<string, (string Type, HashSet<int> Lines)> _symbols = new();

    public void AddSymbol(string lexeme, string type, int line) {
        /* if (!_symbols.ContainsKey(lexeme)) {
            _symbols[lexeme] = type;
        }
        */
        if (_symbols.ContainsKey(lexeme)) {
            _symbols[lexeme].Lines.Add(line);
        } else {
            _symbols[lexeme] = (type, new HashSet<int> { line });
        }
    }

    public int GetIndex(string lexeme) {
        var keys = _symbols.Keys.ToList();
        return keys.IndexOf(lexeme) + 1; 
    }

    public string GenerateReport(string fileName) {
        var report = new StringBuilder();
        report.AppendLine("Código Identificador: EQ05");
        report.AppendLine("Nomes: João Gustavo da Silva Teixeira, Nicolas Raimundo Menezes de Araújo, Loren Vitória Cavalcante Santos, João Antônio Luz dos Santos");
        report.AppendLine("E-mails: joaogustavo.teixeira@ucsal.edu.br, nicolas.araujo@ucsal.edu.br, loren.santos@ucsal.edu.br, joaoantonio.santos@ucsal.edu.br");
        report.AppendLine("Telefones: +55 71 98798-7008, +55 71 99987-9517, +55 71 98514-7438, +55 71 99721-1113");
        report.AppendLine($"\nRELATÓRIO DA TABELA DE SÍMBOLOS. Texto fonte analisado: {fileName}\n");

        int entryIndex = 1;
        foreach (var entry in _symbols) {
        //report.AppendLine($"{entry.Key}, {entry.Value}");
        string lexeme = entry.Key;
        string tipoSimb = entry.Value.Type;
        string linhas = string.Join(", ", entry.Value.Lines);

        report.AppendLine($"Entrada: {entryIndex}, Codigo: 513, Lexeme: {lexeme},");
        report.AppendLine($"QtdCharAntesTrunc: {lexeme.Length}, QtdCharDepoisTrunc: {lexeme.Length},");
        report.AppendLine($"TipoSimb: {tipoSimb}, Linhas: {{{linhas}}}."); 
        report.AppendLine("---------------------------------------------------------------------------------");
        entryIndex++;
        }

        return report.ToString();
    }
}